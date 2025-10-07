using Ayur.Core;
using SDL;
using System;

namespace Ayur.Rendering
{
    internal unsafe class Texture
    {
        //private
        private SDL_Texture* mTexture;
        private int mWidth;
        private int mHeight;
        private SDL_Window* gWindow;
        private SDL_Renderer* gRenderer;


        /*public Texture(SDL_Texture* mTexture, int mWidth, int mHeight)
        {
            this.mTexture = mTexture;
            this.mWidth = mWidth;
            this.mHeight = mHeight;
        }*/
        ~Texture()
        {
            destroy();
        }

        public bool loadFromFile(string path, SDL_Renderer* renderer, SDL_Window* window)
        {
            destroy();
            gRenderer = renderer;
            gWindow = window;

            SDL_Surface* loadedSurface = SDL3_image.IMG_Load(path.ToString());
            if (loadedSurface == null)
            {
                Console.WriteLine($"Unable to load image {path.ToString()}! SDL_image error: {SDL3.SDL_GetError()}\n");
            }
            else
            {
                mTexture = SDL3.SDL_CreateTextureFromSurface(gRenderer, loadedSurface);
                if (mTexture == null)
                {
                    Console.WriteLine($"\"Unable to create texture from loaded pixels! SDL error: {SDL3.SDL_GetError()}\n");
                }
                else
                {
                    mWidth = loadedSurface->w;
                    mHeight = loadedSurface->h;
                }
                SDL3.SDL_DestroySurface(loadedSurface);
            }

            return mTexture != null;

        }


        public void destroy()
        {
            SDL3.SDL_DestroyTexture(mTexture);
            mTexture = null;
            mWidth = 0;
            mHeight = 0;
        }
        
        public void render(float x, float y)
        {
            
            SDL_FRect dstRect = new SDL_FRect{
                x = x, 
                y = y,
                w =  mWidth,
                h =  mHeight,
            };

            SDL3.SDL_RenderTexture(gRenderer, mTexture, null, &dstRect);
        }

        public int getWidth()
        {
            return mWidth;
        }

        public int getHeight()
        {
            return mHeight;
        }

        public bool isLoaded()
        {
            return mTexture != null;
        }
    }
}
