using System.Runtime.InteropServices;
using System.Text;
using Ayur.Rendering;
using SDL;

namespace Ayur.Core
{
    /// <summary>
    /// Internal window management class using SDL3.
    /// Handles window creation, rendering, and event polling.
    /// </summary>
    internal unsafe class Window
    {
        // SDL3 window and renderer pointers
        public SDL_Window* window;
        public SDL_Renderer* renderer;
        
        /// <summary>Background color of the window</summary>
        public AyurColor BackgroundColor { get; set; }

        /// <summary>Initialize SDL3</summary>
        public bool Init()
        {
            if (SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO) == false)
            {
                Console.WriteLine("SDL could not initialize");
                return false;
            }
            return true;
        }

        /// <summary>Create window and renderer</summary>
        public bool CreateWindowAndRender(string title, int width, int height, AyurColor backgroundColor)
        {
            BackgroundColor = backgroundColor;
            
            SDL_Window* tempWindow;
            SDL_Renderer* tempRenderer;

            fixed (byte* titlePtr = Encoding.ASCII.GetBytes(title + "\0"))
            {
                if (!SDL3.SDL_CreateWindowAndRenderer(titlePtr, width, height, 0, &tempWindow, &tempRenderer))
                {
                    Console.WriteLine("Failed to create window and renderer");
                    return false;
                }
            }

            window = tempWindow;
            renderer = tempRenderer;

            // Set initial draw color
            SDL3.SDL_SetRenderDrawColor(renderer, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a);
            return true;
        }

        /// <summary>Poll and process SDL events</summary>
        public bool PollEvent(out AyurEvent ayurEvent)
        {
            SDL_Event e;
            if (SDL3.SDL_PollEvent(&e))
            {
                if (e.Type == SDL_EventType.SDL_EVENT_QUIT)
                {
                    ayurEvent = new AyurEvent { Type = AyurEventType.Quit };
                    return true;
                }
                
                ayurEvent = new AyurEvent { Type = AyurEventType.None };
                return true;
            }
            
            ayurEvent = default;
            return false;
        }

        /// <summary>Clear the screen with background color</summary>
        public void Clear()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, BackgroundColor.r, BackgroundColor.g, BackgroundColor.b, BackgroundColor.a);
            SDL3.SDL_RenderClear(renderer);
        }

        /// <summary>Present the rendered frame</summary>
        public void Present()
        {
            SDL3.SDL_RenderPresent(renderer);
        }

        /// <summary>Cleanup window and renderer</summary>
        public void Destroy()
        {
            SDL3.SDL_DestroyRenderer(renderer);
            SDL3.SDL_DestroyWindow(window);
        }

        /// <summary>Shutdown SDL3</summary>
        public void Quit()
        {
            SDL3.SDL_Quit();
        }
    }
}
