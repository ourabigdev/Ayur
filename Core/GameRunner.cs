using Ayur.Rendering;
using System.Diagnostics;

namespace Ayur.Core
{
    internal class GameRunner
    {
        private readonly Game game;
        private readonly Window window;
        private bool running = true;

        public GameRunner(Game game)
        {
            this.game = game;
            this.window = new Window();
        }

        public bool Init(string title, int width, int height, AyurColor bg)
        {
            if(!window.Init()) return false;
            if (!window.CreateWindowAndRender(title, width, height, bg)) return false;

            game.Window = window;
            return true;
        }

        public void Run()
        {
            game.Load();

            var stopwatch = new Stopwatch();
            AyurEvent e;

            while (running)
            {
                stopwatch.Restart();
                while (window.PollEvent(out e))
                {
                    if(e.Type == AyurEventType.Quit)
                    {
                        running = false;
                    }
                }

                float dt = 1f / 60f;

                window.Clear();
                game.Render();
                window.Present(16);


                //frame limiter
                long elapsed = stopwatch.ElapsedMilliseconds;
                if (elapsed < 16) Thread.Sleep((int)(16 - elapsed));
            }

            window.Destroy();
            window.Quit();
        }
    }
}
