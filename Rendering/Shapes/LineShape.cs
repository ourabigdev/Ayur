using SDL;

namespace Ayur.Rendering.Shapes
{
    /// <summary>
    /// A line connecting two points.
    /// </summary>
    internal unsafe class LineShape : Shape
    {
        /// <summary>Start X position</summary>
        public float X1 { get; set; }
        /// <summary>Start Y position</summary>
        public float Y1 { get; set; }
        /// <summary>End X position</summary>
        public float X2 { get; set; }
        /// <summary>End Y position</summary>
        public float Y2 { get; set; }

        /// <summary>Create a line from point (x1,y1) to point (x2,y2)</summary>
        public LineShape(float x1, float y1, float x2, float y2, AyurColor color)
            : base(color)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>Render the line</summary>
        public override unsafe void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);
            SDL3.SDL_RenderLine(renderer, X1, Y1, X2, Y2);
        }
    }
}
