using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

namespace Example
{
    public  unsafe class MyGame : Game
    {
        private RectangleShape rect1, rect2;
        private LineShape line;
        private CircleShape circle;
        private Texture logo;

        public override void Load()
        {
            rect1 = new RectangleShape(50, 50, 200, 100, AyurColor.White, filled: true);
            rect2 = new RectangleShape(450, 50, 200, 100, AyurColor.Red, filled: false);
            line = new LineShape(450, 450, 500, 300, AyurColor.Blue);
            circle = new CircleShape(700, 300, 50, AyurColor.Green);

            logo = new Texture();
            logo.loadFromFile("Res/logo.png", Window.renderer, Window.window);
        }

        public override void Update(float dt)
        {
            
        }

        public override void Render()
        {
            rect1.Render(Window.renderer);
            rect2.Render(Window.renderer);
            line.Render(Window.renderer);
            circle.Render(Window.renderer);
            logo.render(100, 100);
        }
    }
}
