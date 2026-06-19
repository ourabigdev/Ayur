using Ayur.Rendering;
using System.Diagnostics;

namespace Ayur.Core
{
    /// <summary>
    /// Manages the main game loop and window lifecycle.
    /// This class is internal and handles the relationship between your Game and the Window.
    /// </summary>
    internal class GameRunner
    {
        private readonly Game game;
        private readonly Window window;
        private bool running = true;
        
        // Target frame rate (60 FPS)
        private const int TargetFPS = 60;
        private const int FrameTimeMs = 1000 / TargetFPS;

        public GameRunner(Game game)
        {
            this.game = game;
            this.window = new Window();
        }

        /// <summary>
        /// Initialize the game window and prepare for running.
        /// </summary>
        public bool Init(string title, int width, int height, AyurColor backgroundColor)
        {
            if (!window.Init())
                return false;
            if (!window.CreateWindowAndRender(title, width, height, backgroundColor))
                return false;

            // Give game reference to window
            game.Window = window;
            return true;
        }

        /// <summary>
        /// Start the main game loop.
        /// </summary>
        public void Run()
        {
            // Load game resources
            game.Load();

            var stopwatch = new Stopwatch();
            AyurEvent e;

            while (running)
            {
                stopwatch.Restart();

                // Poll and handle events
                while (window.PollEvent(out e))
                {
                    if (e.Type == AyurEventType.Quit)
                        running = false;
                }

                // Update game logic
                float dt = FrameTimeMs / 1000f;
                game.Update(dt);

                // Render
                window.Clear();
                game.Render();
                window.Present();

                // Frame rate limiting (lock to 60 FPS)
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
