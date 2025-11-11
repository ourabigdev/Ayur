using SDL;

namespace Ayur.Rendering.Shapes
{
    internal unsafe class CircleShape : Shape
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }

        public CircleShape(float x, float y, float radius, AyurColor color)
            : base(color)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
        //Render circle shape
        public override unsafe void Render(SDL_Renderer* renderer)
        {
            SDL3.SDL_SetRenderDrawColor(renderer, Color.r, Color.g, Color.b, Color.a);

            //loop to calculate the shape to draw using render point
            for(float w = -Radius; w < Radius; w++)
            {
                for(float h = -Radius; h < Radius; h++)
                {
                    if(w*w + h*h <= Radius * Radius)
                    {
                        SDL3.SDL_RenderPoint(renderer, X+w, Y+h);
                    }
                }
            }
        }
    }
}
