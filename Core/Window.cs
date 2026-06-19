using System.Text;
using Ayur.Rendering;
using SDL;

namespace Ayur.Core
{
    /// <summary>
    /// Internal window management using SDL3.
    /// Handles window creation, rendering, and event polling.
    /// This class is kept simple: only essential SDL3 operations.
    /// </summary>
    internal unsafe class Window
    {
        /// <summary>SDL3 window pointer</summary>
        public SDL_Window* window;
        /// <summary>SDL3 renderer pointer</summary>
        public SDL_Renderer* renderer;
        /// <summary>Background color of the window</summary>
        public AyurColor BackgroundColor { get; set; }

        /// <summary>Initialize SDL3 for video rendering</summary>
        public bool Init()
        {
            if (!SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO))
            {
                Console.WriteLine("Error: SDL could not initialize");
                return false;
            }
            return true;
        }

        /// <summary>Create window and renderer for drawing</summary>
        public bool CreateWindowAndRender(string title, int width, int height, AyurColor backgroundColor)
        {
            BackgroundColor = backgroundColor;

            SDL_Window* tempWindow;
            SDL_Renderer* tempRenderer;

            // Convert title to null-terminated C string for SDL3
            fixed (byte* titlePtr = Encoding.ASCII.GetBytes(title + "\0"))
            {
                if (!SDL3.SDL_CreateWindowAndRenderer(titlePtr, width, height, 0, &tempWindow, &tempRenderer))
                {
                    Console.WriteLine("Error: Failed to create window and renderer");
                    return false;
                }
            }

            window = tempWindow;
            renderer = tempRenderer;

            // Set initial background color
            SDL3.SDL_SetRenderDrawColor(renderer, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a);
            return true;
        }

        /// <summary>Poll for events (quit, etc.)</summary>
        public bool PollEvent(out AyurEvent ayurEvent)
        {
            SDL_Event e;
            if (SDL3.SDL_PollEvent(&e))
            {
                // Check if user requested window close
                if (e.Type == SDL_EventType.SDL_EVENT_QUIT)
                {
                    ayurEvent = new AyurEvent { Type = AyurEventType.Quit };
                    return true;
                }

                // No recognized event
                ayurEvent = new AyurEvent { Type = AyurEventType.None };
                return true;
            }

            ayurEvent = default;
            return false;
        }

        /// <summary>Clear screen with background color</summary>
        public void Clear()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, BackgroundColor.r, BackgroundColor.g, BackgroundColor.b, BackgroundColor.a);
            SDL3.SDL_RenderClear(renderer);
        }

        /// <summary>Display rendered frame on screen</summary>
        public void Present()
        {
            SDL3.SDL_RenderPresent(renderer);
        }

        /// <summary>Cleanup renderer and window resources</summary>
        public void Destroy()
        {
            if (renderer != null)
                SDL3.SDL_DestroyRenderer(renderer);
            if (window != null)
                SDL3.SDL_DestroyWindow(window);
        }

        /// <summary>Shutdown SDL3 library</summary>
        public void Quit()
        {
            SDL3.SDL_Quit();
        }
    }
}
