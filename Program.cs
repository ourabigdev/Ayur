using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

namespace Example;

/// <summary>Entry point for the Ayur framework</summary>
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var game = new MyGame();
        var runner = new GameRunner(game);

        // Initialize with window title, width, height, and background color
        if (!runner.Init("My Ayur Game", 800, 600, AyurColor.Black))
            return;

        // Start the game loop
        runner.Run();
    }
}
