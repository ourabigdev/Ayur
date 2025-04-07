using SDL3;

namespace Ayur
{
    internal class Window
    {
        public nint window;
        public nint renderer;

        public bool Init()
        {
            if (SDL.Init(SDL.InitFlags.Video) != false)
            {
                SDL.LogError(SDL.LogCategory.System, $"SDL could not initialize: {SDL.GetError()}");
                return false;
            }
            return true;
        }

        public bool CreateWindowAndRender(string title, int width, int height, AyurColor renderDrawColor)
        {
            if (SDL.CreateWindowAndRenderer(title, width, height, 0, out window, out renderer) != false)
            {
                SDL.LogError(SDL.LogCategory.Application, $"Error creating window and renderer: {SDL.GetError()}");
                return false;
            }
            SDL.SetRenderDrawColor(renderer, renderDrawColor.r, renderDrawColor.g, renderDrawColor.b, renderDrawColor.a);
            return true;
        }

        public bool PollEvent(out SDL.Event e)
        {
            return SDL.PollEvent(out e) != false;
        }

        public void Clear()
        {
            SDL.RenderClear(renderer);
        }

        public void Present()
        {
            SDL.RenderPresent(renderer);
        }

        public void Destroy()
        {
            SDL.DestroyRenderer(renderer);
            SDL.DestroyWindow(window);
        }

        public void Quit()
        {
            SDL.Quit();
        }
    }
}
