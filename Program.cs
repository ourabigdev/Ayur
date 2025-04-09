using Ayur;

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

        var texture = Texture.LoadTextureFromImage("Res/logo.png", window.renderer);
        if(texture == null)
        {
            Console.WriteLine("Failed to load texture");
            window.Destroy();
            window.Quit();
            return;
        }

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

            texture.Render(window.renderer, 100, 100, 200, 200);

            window.Present();
        }

        window.Destroy();
        window.Quit();
    }
}
