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
            Graphics.Begin(true);

            Graphics.BackgroundColor(255, 255, 255, 255);

            Graphics.End();
        }

        Graphics.Close();
      }
}

