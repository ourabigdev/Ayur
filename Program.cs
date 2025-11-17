using Ayur.Rendering;
using Ayur.Rendering.Shapes;
using Ayur.Core;
using System.Drawing;

namespace Example;
internal static class Program
{
    [STAThread]
    private unsafe static void Main()
    {
        var game = new MyGame();
        var runner = new GameRunner(game);

        if(!runner.Init("My Ayur Game", 800, 600, AyurColor.Black))
            return;
        runner.Run();
    }
}
