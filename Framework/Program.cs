using System;
using AyurCSharp;


class Program
{
    static void Main(string[] args)
    {
        Colors c = new Colors();
        Rect rect = new Rect(300, 300, 100, 100);
        Graphics.Window(1000, 800, "MyGraphics Test");

        Core.SetFps(60);

        while (!Graphics.ShouldCloseWindow())
        {
            Graphics.Begin(true);

            Graphics.BackgroundColor(c.Gray);
            Graphics.DrawRect(rect, c.Red);

            Graphics.End();
        }

        Graphics.Close();
      }
}

