using SDL;

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
