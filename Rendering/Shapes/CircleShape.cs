using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// A circle shape. Rendered as a filled circle.
    /// </summary>
    internal unsafe class CircleShape : Shape
    {
        /// <summary>Center X position</summary>
        public float X { get; set; }
        /// <summary>Center Y position</summary>
        public float Y { get; set; }
        /// <summary>Radius in pixels</summary>
        public float Radius { get; set; }

        /// <summary>Create a circle</summary>
        public CircleShape(float x, float y, float radius, AyurColor color)
            : base(color)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        /// <summary>Render the circle</summary>
        public override unsafe void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);

            // Draw filled circle using midpoint circle algorithm
            float r = Radius;
            for (float w = -r; w < r; w++)
            {
                for (float h = -r; h < r; h++)
                {
                    if (w * w + h * h <= r * r)
                    {
                        SDL3.SDL_RenderPoint(renderer, X + w, Y + h);
                    }
                }
            }
        }
    }
}
