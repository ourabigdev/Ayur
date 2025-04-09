using System;
using SDL;
using StbImageSharp;

namespace Ayur
{
    internal unsafe class Texture
    {
        public SDL_Texture* AyurTexture { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Texture(SDL_Texture* texture, int width, int height)
        {
            AyurTexture = texture;
            Width = width;
            Height = height;
        }

        public static Texture LoadTextureFromImage(string path, SDL_Renderer* renderer)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Image file not found: {path}");
                return null;
            }

            using var stream = File.OpenRead(path);
            var image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

            if (image == null || image.Data == null || image.Width == 0 || image.Height == 0)
            {
                Console.WriteLine("Error loading image. Check the image format or path.");
                return null;
            }

            int pitch = image.Width * 4;

            fixed (byte* pixelPtr = image.Data)
            {
                SDL_Surface* surface = SDL3.SDL_CreateSurfaceFrom(
                    image.Width,
                    image.Height,
                    SDL_PixelFormat.SDL_PIXELFORMAT_RGBA8888,
                    (nint)pixelPtr,
                    pitch
                );

                if (surface == null)
                {
                    Console.WriteLine($"Failed to create surface: {SDL3.SDL_GetError()}");
                    return null;
                }

                if (renderer == null)
                {
                    Console.WriteLine("Renderer is invalid.");
                    SDL3.SDL_DestroySurface(surface);
                    return null;
                }

                SDL_Texture* texture = SDL3.SDL_CreateTextureFromSurface(renderer, surface);
                SDL3.SDL_DestroySurface(surface);
                if (texture == null)
                {
                    Console.WriteLine($"Failed to create texture: {SDL3.SDL_GetError()}");
                    return null;
                }

                return new Texture(texture, image.Width, image.Height);
            }
        }

        public void Render(SDL_Renderer* renderer, int x, int y, int width,int height)
        {
            SDL_FRect dstRect = new SDL_FRect
            {
                x = x,
                y = y,
                w = width,
                h = height
            };
            SDL3.SDL_SetTextureBlendMode(AyurTexture, SDL_BlendMode.SDL_BLENDMODE_BLEND);

            SDL3.SDL_RenderTexture(renderer, AyurTexture, null, &dstRect);
        }

        public void Destroy()
        {
            if (AyurTexture != null)
            {
                SDL3.SDL_DestroyTexture(AyurTexture);
                AyurTexture = null;
            }
        }
    }
}
