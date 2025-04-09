using System.Text;
using SDL;

namespace Ayur
{
    internal unsafe class Window
    {
        private SDL_Window* window;
        public SDL_Renderer* renderer;


        public bool Init()
        {
            
            if (SDL3.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO) == false)
            {
                string error = SDL3.SDL_GetError();
                fixed (byte* fmt = Encoding.ASCII.GetBytes("SDL could not initialize: %s\0"))
                {
                    SDL3.SDL_LogError((int)SDL.SDL_LogCategory.SDL_LOG_CATEGORY_SYSTEM, fmt, __arglist(error));
                }

                return false;
            }
            return true;
        }

        public bool CreateWindowAndRender(string title, int width, int height, AyurColor renderDrawColor)
        {
            SDL_Window* localWindow;
            SDL_Renderer* localRenderer;
            fixed (byte* titlePtr = Encoding.ASCII.GetBytes(title + "\0"))
            {
                if (SDL3.SDL_CreateWindowAndRenderer(titlePtr, width, height, 0, &localWindow, &localRenderer) == false)
                {
                    string error = SDL3.SDL_GetError();
                    fixed (byte* fmt = Encoding.ASCII.GetBytes("SDL could not initialize: %s\0"))
                    {
                        SDL3.SDL_LogError((int)SDL.SDL_LogCategory.SDL_LOG_CATEGORY_SYSTEM, fmt, __arglist(error));
                    }
                    return false;
                }
            }
            this.window = localWindow;
            this.renderer = localRenderer;

            SDL3.SDL_SetRenderDrawColor(renderer, renderDrawColor.r, renderDrawColor.g, renderDrawColor.b, renderDrawColor.a);
            return true;
        }

        public bool PollEvent(out AyurEvent ayurEvent)
        {
            SDL.SDL_Event e;
            if(SDL3.SDL_PollEvent(&e))
            {
                if(e.Type == SDL_EventType.SDL_EVENT_QUIT)
                {
                    ayurEvent = new AyurEvent { Type = AyurEventType.Quit };
                    return true;
                }

                //will add more events later
                ayurEvent = new AyurEvent { Type = AyurEventType.None };
                return true;
            }
            ayurEvent = default;
            return false;
        }

        public void Clear()
        {
            SDL3.SDL_RenderClear(renderer);
        }

        public void Present()
        {
            SDL3.SDL_RenderPresent(renderer);
        }

        public void Destroy()
        {
            SDL3.SDL_DestroyRenderer(renderer);
            SDL3.SDL_DestroyWindow(window);
        }

        public void Quit()
        {
            SDL3.SDL_Quit();
        }
    }
}
