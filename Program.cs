using Ayur;

internal static class Program
{
    [STAThread]
    private static void Main()
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
            window.Present();
        }

        window.Destroy();
        window.Quit();
    }
}
