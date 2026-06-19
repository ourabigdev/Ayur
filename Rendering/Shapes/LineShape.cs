using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// A line from point (X1, Y1) to point (X2, Y2).
    /// Simple and fast - delegates to SDL3's built-in line drawing.
    /// No complex line rendering algorithms - let SDL handle it.
    /// </summary>
    internal unsafe class LineShape : Shape
    {
        /// <summary>Starting point X</summary>
        public float X1 { get; set; }
        /// <summary>Starting point Y</summary>
        public float Y1 { get; set; }
        /// <summary>Ending point X</summary>
        public float X2 { get; set; }
        /// <summary>Ending point Y</summary>
        public float Y2 { get; set; }

        /// <summary>Create a line from (x1,y1) to (x2,y2)</summary>
        public LineShape(float x1, float y1, float x2, float y2, AyurColor color)
            : base(color)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>Draw the line</summary>
        public override void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);
            SDL3.SDL_RenderLine(renderer, X1, Y1, X2, Y2);
        }
    }
}
