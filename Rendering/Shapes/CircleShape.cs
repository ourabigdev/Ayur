using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// A filled circle centered at (X, Y) with given radius.
    /// Simple rendering: checks each pixel if it's inside the circle.
    /// No anti-aliasing or advanced features - keeps it lightweight.
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

        /// <summary>Draw the filled circle</summary>
        public override void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);

            // Use midpoint circle algorithm:
            // For each point (w, h) from center, check if distance <= radius
            // If yes, it's part of the circle - draw it
            float r = Radius;
            for (float w = -r; w < r; w++)
            {
                for (float h = -r; h < r; h++)
                {
                    // Distance formula: sqrt(w² + h²)
                    // Optimization: compare squared distances (avoid sqrt)
                    if (w * w + h * h <= r * r)
                    {
                        SDL3.SDL_RenderPoint(renderer, X + w, Y + h);
                    }
                }
            }
        }
    }
}
