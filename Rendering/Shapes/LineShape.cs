using SDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayur.Rendering.Shapes
{
    internal unsafe class LineShape : Shape
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }

        public LineShape(float x1, float y1, float x2, float y2, AyurColor color)
            : base(color)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        //Rendering LineShape
        public override unsafe void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);
            SDL3.SDL_RenderLine(renderer, X1, Y1, X2, Y2);
        }
    }
}
