using System;
using SDL;

namespace Ayur
{
    internal unsafe class Texture
    {
        //private
        private SDL_Texture* mTexture;
        private int mWidth;
        private int mHeight;

        //public
        public SDL_Window* gWindow;
        public SDL_Renderer* gRenderer;


        public Texture(SDL_Texture* mTexture, int mWidth, int mHeight)
        {
            this.mTexture = mTexture;
            this.mWidth = mWidth;
            this.mHeight = mHeight;
        }
        ~Texture()
        {
            destroy();
        }

        public bool loadFromFile(String path)
        {
            destroy();

            SDL_Surface* loadedSurface = SDL3_image.IMG_Load(path.ToString());
            if (loadedSurface == null)
            {
                Console.WriteLine($"Unable to load image {path.ToString()}! SDL_image error: {SDL3.SDL_GetError}\n");
            }
            else
            {
                if (mTexture = SDL3.SDL_CreateTextureFromSurface())
                {
                    Console.WriteLine($"Unable to load image {path.ToString()}! SDL_image error: {SDL3.SDL_GetError}\n");
                }
            }

        }


        public void destroy()
        {

        }
        
        public void render(float x, float y)
        {

        }

        public int getWidth()
        {

        }

        public int getHeight()
        {

        }

        public bool isLoaded()
        {

        }
    }
}
