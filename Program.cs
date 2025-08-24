using Ayur;
using Ayur.Window;
using Ayur.Texture;

internal static class Program
{
    [STAThread]
    private unsafe static void Main()
    {
        var window = new Window();
        if (!window.Init())
        {
            return;
        }

        if (!window.CreateWindowAndRender("hello", 800, 600, new AyurColor(100, 149, 237)))
        {
            return;
        }

        
        

        var image = new Texture();

        image.loadFromFile("Res/logo.png", window.renderer, window.window);


        

        var loop = true;
        AyurEvent e;

        while (loop)
        {
            while (window.PollEvent(out e))
            {
                if (e.Type == AyurEventType.Quit)
                {
                    loop = false;
                }
            }

            window.Clear();

            image.render(100, 100);

            window.Present(16);
        }

        image.destroy();
        window.Destroy();
        window.Quit();
    }
}
