using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>Base class for all drawable shapes</summary>
    internal unsafe abstract class Shape
    {
        /// <summary>Color of the shape</summary>
        public AyurColor Color { get; set; }

        /// <summary>Initialize shape with a color</summary>
        protected Shape(AyurColor color)
        {
            Color = color;
        }

        /// <summary>Render this shape to the screen</summary>
        public abstract void Render(SDL_Renderer* renderer);
    }
}
