using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

namespace Example
{
    /// <summary>
    /// Example game demonstrating Ayur framework features.
    /// Shows how to load resources, update logic, and render graphics.
    /// </summary>
    public unsafe class MyGame : Game
    {
        // These fields are initialized in Load(), marked with ? to indicate they may be null until then
        private RectangleShape? rect1;
        private RectangleShape? rect2;
        private LineShape? line;
        private CircleShape? circle;
        private Texture? logo;

        /// <summary>Load resources here (called once at startup)</summary>
        public override void Load()
        {
            // Create rectangles - filled and outlined
            rect1 = new RectangleShape(50, 50, 200, 100, AyurColor.White, filled: true);
            rect2 = new RectangleShape(450, 50, 200, 100, AyurColor.Red, filled: false);

            // Create line
            line = new LineShape(450, 450, 500, 300, AyurColor.Blue);

            // Create circle
            circle = new CircleShape(700, 300, 50, AyurColor.Green);

            // Load and initialize texture
            logo = new Texture();
            logo.LoadFromFile("Res/logo.png", Window!.renderer, Window.window);
        }

        /// <summary>Update game logic here (called every frame)</summary>
        public override void Update(float dt)
        {
            // Add your game logic here
            // Example: move objects, check input, update physics, etc.
        }

        /// <summary>Draw everything here (called every frame)</summary>
        public override void Render()
        {
            // Render all shapes and textures
            // Use the null-forgiving operator (!) since we know Load() was called first
            rect1?.Render(Window!.renderer);
            rect2?.Render(Window.renderer);
            line?.Render(Window.renderer);
            circle?.Render(Window.renderer);
            logo?.Render(100, 100);
        }
    }
}
