using SDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayur.Rendering.Shapes
{
    //initial Shape Class
    internal unsafe abstract class Shape
    {
        public AyurColor Color { get; set; }

        protected Shape(AyurColor color)
        {
            Color = color;
        }

        public abstract void Render(SDL_Renderer* renderer);
    }
}
