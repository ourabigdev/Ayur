using Ayur.Rendering;
using System.Diagnostics;

namespace Ayur.Core
{
    /// <summary>
    /// Manages the game loop and window lifecycle.
    /// This is the minimal game loop: input -> update -> render -> frame limit.
    /// Everything is straightforward - no unnecessary complexity.
    /// </summary>
    internal class GameRunner
    {
        private readonly Game game;
        private readonly Window window;
        private bool running = true;

        // Fixed frame rate: 60 FPS (16.67ms per frame)
        private const int TargetFPS = 60;
        private const int FrameTimeMs = 1000 / TargetFPS;

        public GameRunner(Game game)
        {
            this.game = game;
            this.window = new Window();
        }

        /// <summary>Initialize window and prepare game to run</summary>
        public bool Init(string title, int width, int height, AyurColor backgroundColor)
        {
            if (!window.Init())
                return false;

            if (!window.CreateWindowAndRender(title, width, height, backgroundColor))
                return false;

            // Give game access to window for rendering
            game.Window = window;
            return true;
        }

        /// <summary>
        /// Start the main game loop.
        /// Runs until user closes window or game requests quit.
        /// </summary>
        public void Run()
        {
            // Load resources once
            game.Load();

            var stopwatch = new Stopwatch();
            AyurEvent e;

            while (running)
            {
                stopwatch.Restart();

                // 1. POLL EVENTS - Handle quit and input
                while (window.PollEvent(out e))
                {
                    if (e.Type == AyurEventType.Quit)
                        running = false;
                }

                // 2. UPDATE - Update game logic
                float dt = FrameTimeMs / 1000f; // Convert ms to seconds
                game.Update(dt);

                // 3. RENDER - Draw everything
                window.Clear();
                game.Render();
                window.Present();

                // 4. FRAME LIMITING - Lock to 60 FPS
                long elapsed = stopwatch.ElapsedMilliseconds;
                if (elapsed < FrameTimeMs)
                    Thread.Sleep((int)(FrameTimeMs - elapsed));
            }

            // Cleanup
            window.Destroy();
            window.Quit();
        }
    }
}
