using System;
using AmlilCSharp;


class Program
{
    static void Main(string[] args)
    {
        Colors c = new Colors();
        Graphics.Window(1000, 800, "MyGraphics Test");

        Core.SetFps(60);

        while (!Graphics.ShouldCloseWindow())
        {
            Graphics.Begin(true);

            Graphics.BackgroundColor(c.Gray);

            Graphics.End();
        }

        Graphics.Close();
      }
}

