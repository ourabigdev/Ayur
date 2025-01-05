using System;
using AmlilCSharp;


class Program
{
    static void Main(string[] args)
    {
        Graphics.Window(1000, 800, "MyGraphics Test");

        Core.SetFps(60);


        while (!Graphics.ShouldCloseWindow())
        {
            Graphics.Begin();

            Graphics.Clear(1, 1, 1, 1);

            Graphics.DrawCustomRectangle(500, 400, 100, 100);

            Graphics.DrawFps(30, 30);

            Graphics.End();
        }

        Graphics.Close();
      }
}

