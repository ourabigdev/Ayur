using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// Base class for all drawable shapes.
    /// Every shape must be able to render itself.
    /// Simple abstraction - no complex features.
    /// </summary>
    internal unsafe abstract class Shape
    {
        /// <summary>Color to draw this shape with</summary>
        public AyurColor Color { get; set; }

        /// <summary>Initialize shape with a color</summary>
        protected Shape(AyurColor color)
        {
            Color = color;
        }

        /// <summary>Draw this shape to the screen</summary>
        public abstract void Render(SDL_Renderer* renderer);
    }
}
