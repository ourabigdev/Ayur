using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// A rectangle: can be filled solid or just outlined.
    /// Simple shape - no rotation or complex transformations.
    /// </summary>
    internal unsafe class RectangleShape : Shape
    {
        /// <summary>Left edge X position</summary>
        public float X { get; set; }
        /// <summary>Top edge Y position</summary>
        public float Y { get; set; }
        /// <summary>Width in pixels</summary>
        public float Width { get; set; }
        /// <summary>Height in pixels</summary>
        public float Height { get; set; }
        /// <summary>True = filled, False = outlined only</summary>
        public bool Filled { get; set; }

        /// <summary>Create a rectangle</summary>
        public RectangleShape(float x, float y, float width, float height, AyurColor color, bool filled = true)
            : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Filled = filled;
        }

        /// <summary>Draw the rectangle</summary>
        public override void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);

            SDL_FRect rect = new()
            {
                x = X,
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
