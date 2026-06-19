using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

namespace Example
{
    /// <summary>
    /// Example game demonstrating Ayur framework features.
    /// </summary>
    public unsafe class MyGame : Game
    {
        private RectangleShape rect1, rect2;
        private LineShape line;
        private CircleShape circle;
        private Texture logo;

        /// <summary>Load resources here (called once at startup)</summary>
        public override void Load()
        {
            // Create rectangles
            rect1 = new RectangleShape(50, 50, 200, 100, AyurColor.White, filled: true);
            rect2 = new RectangleShape(450, 50, 200, 100, AyurColor.Red, filled: false);

            // Create line
            line = new LineShape(450, 450, 500, 300, AyurColor.Blue);

            // Create circle
            circle = new CircleShape(700, 300, 50, AyurColor.Green);

            // Load image
            logo = new Texture();
            logo.LoadFromFile("Res/logo.png", Window.renderer, Window.window);
        }

        /// <summary>Update game logic here (called every frame)</summary>
        public override void Update(float dt)
        {
            // Add game logic here
        }

        /// <summary>Draw everything here (called every frame)</summary>
        public override void Render()
        {
            rect1.Render(Window.renderer);
            rect2.Render(Window.renderer);
            line.Render(Window.renderer);
            circle.Render(Window.renderer);
            logo.Render(100, 100);
        }
    }
}
