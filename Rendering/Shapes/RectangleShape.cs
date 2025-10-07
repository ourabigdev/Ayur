using SDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayur.Rendering.Shapes
{
    internal unsafe class RectangleShape : Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Filled { get; set; }

        public RectangleShape(float x, float y, float width, float height, AyurColor color,bool filled = true) 
            : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Filled = filled;
        }
        //Rendering RectangleShape
        public override unsafe void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);

            SDL_FRect rect = new SDL_FRect
            {
                x= X,
                y = Y,
                w = Width,
                h = Height,
            };

            if (Filled)
                SDL3.SDL_RenderFillRect(renderer, &rect);
            else
                SDL3.SDL_RenderRect(renderer, &rect);
        }
    }
}
