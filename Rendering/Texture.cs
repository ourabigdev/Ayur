using SDL;

namespace Ayur.Rendering
{
    /// <summary>
    /// Represents an image/texture that can be drawn on screen.
    /// </summary>
    internal unsafe class Texture
    {
        private SDL_Texture* mTexture;
        private int mWidth;
        private int mHeight;
        private SDL_Renderer* gRenderer;

        ~Texture()
        {
            Destroy();
        }

        /// <summary>
        /// Load a texture from an image file.
        /// </summary>
        /// <param name="path">Path to the image file (PNG, JPG, etc.)</param>
        /// <param name="renderer">SDL renderer</param>
        /// <param name="window">SDL window</param>
        public bool LoadFromFile(string path, SDL_Renderer* renderer, SDL_Window* window)
        {
            Destroy();
            gRenderer = renderer;

            // Load image surface
            SDL_Surface* surface = SDL3_image.IMG_Load(path);
            if (surface == null)
            {
                Console.WriteLine($"Failed to load image: {path}");
                return false;
            }

            // Create texture from surface
            mTexture = SDL3.SDL_CreateTextureFromSurface(renderer, surface);
            if (mTexture == null)
            {
                Console.WriteLine($"Failed to create texture from {path}");
                SDL3.SDL_DestroySurface(surface);
                return false;
            }

            mWidth = surface->w;
            mHeight = surface->h;
            SDL3.SDL_DestroySurface(surface);

            return true;
        }

        /// <summary>Render the texture at the specified position</summary>
        public void Render(float x, float y)
        {
            SDL_FRect rect = new()
            {
                x = x,
                y = y,
                w = mWidth,
                h = mHeight,
            };

            SDL3.SDL_RenderTexture(gRenderer, mTexture, null, &rect);
        }

        /// <summary>Render the texture at position with custom width/height</summary>
        public void Render(float x, float y, float width, float height)
        {
            SDL_FRect rect = new()
            {
                x = x,
                y = y,
                w = width,
                h = height,
            };

            SDL3.SDL_RenderTexture(gRenderer, mTexture, null, &rect);
        }

        /// <summary>Get texture width in pixels</summary>
        public int GetWidth() => mWidth;

        /// <summary>Get texture height in pixels</summary>
        public int GetHeight低() => mHeight;

        /// <summary>Check if texture is loaded</summary>
        public bool IsLoaded() => mTexture != null;

        /// <summary>Destroy and free the texture</summary>
        public void Destroy()
        {
            if (mTexture != null)
            {
                SDL3.SDL_DestroyTexture(mTexture);
                mTexture = null;
            }
            mWidth = 0;
            mHeight = 0;
        }
    }
}
