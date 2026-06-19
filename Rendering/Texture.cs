using SDL;

namespace Ayur.Rendering
{
    /// <summary>
    /// Represents a loaded image/texture that can be drawn on screen.
    /// Handles loading images (PNG, JPG, BMP, etc.) and rendering them.
    /// Simple and straightforward - no scaling/rotation complexity.
    /// </summary>
    internal unsafe class Texture
    {
        private SDL_Texture* texturePtr;  // SDL3 texture handle
        private int width;                // Width in pixels
        private int height;               // Height in pixels
        private SDL_Renderer* renderer;   // Renderer for drawing

        /// <summary>Cleanup texture when object is destroyed</summary>
        ~Texture()
        {
            Destroy();
        }

        /// <summary>
        /// Load an image file and create a texture from it.
        /// </summary>
        /// <param name="path">Path to image file (relative or absolute)</param>
        /// <param name="rendererPtr">SDL3 renderer for creating texture</param>
        /// <param name="windowPtr">SDL3 window (stored but not used for basic rendering)</param>
        /// <returns>True if successfully loaded, false otherwise</returns>
        public bool LoadFromFile(string path, SDL_Renderer* rendererPtr, SDL_Window* windowPtr)
        {
            // Clear any existing texture
            Destroy();
            renderer = rendererPtr;

            // Load image into memory
            SDL_Surface* surface = SDL3_image.IMG_Load(path);
            if (surface == null)
            {
                Console.WriteLine($"Error: Failed to load image: {path}");
                return false;
            }

            // Convert surface to texture for GPU rendering
            texturePtr = SDL3.SDL_CreateTextureFromSurface(renderer, surface);
            if (texturePtr == null)
            {
                Console.WriteLine($"Error: Failed to create texture from {path}");
                SDL3.SDL_DestroySurface(surface);
                return false;
            }

            // Store dimensions
            width = surface->w;
            height = surface->h;

            // Free the surface (no longer needed after texture creation)
            SDL3.SDL_DestroySurface(surface);

            return true;
        }

        /// <summary>Draw texture at specified position (original size)</summary>
        public void Render(float x, float y)
        {
            SDL_FRect rect = new()
            {
                x = x,
                y = y,
                w = width,
                h = height,
            };

            SDL3.SDL_RenderTexture(renderer, texturePtr, null, &rect);
        }

        /// <summary>Draw texture at position with custom width/height</summary>
        public void Render(float x, float y, float w, float h)
        {
            SDL_FRect rect = new()
            {
                x = x,
                y = y,
                w = w,
                h = h,
            };

            SDL3.SDL_RenderTexture(renderer, texturePtr, null, &rect);
        }

        /// <summary>Get texture width in pixels</summary>
        public int GetWidth() => width;

        /// <summary>Get texture height in pixels</summary>
        public int GetHeight() => height;

        /// <summary>Check if texture is loaded and ready to render</summary>
        public bool IsLoaded() => texturePtr != null;

        /// <summary>Free texture memory</summary>
        public void Destroy()
        {
            if (texturePtr != null)
            {
                SDL3.SDL_DestroyTexture(texturePtr);
                texturePtr = null;
            }
            width = 0;
            height = 0;
        }
    }
}
