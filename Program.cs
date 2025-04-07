using Ayur;
using SDL3;

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
        SDL.Event e;

        while (loop)
        {
            while (window.PollEvent(out e))
            {
                if (e.Type == (uint)SDL.EventType.Quit)
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
