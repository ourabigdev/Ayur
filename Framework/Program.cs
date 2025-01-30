using System;
using AyurCSharp;


class Program
{
    static void Main(string[] args)
    {
        Rect rect = new Rect(300, 300, 100, 100);
        Graphics.Window(1000, 800, "MyGraphics Test");

        Core.SetFps(60);

        while (!Graphics.ShouldCloseWindow())
        {
            Graphics.Begin(true);

            Graphics.BackgroundColor(Colors.Gray);

            Graphics.DrawRect(rect, Colors.Black);

            Graphics.End();
        }

        Graphics.Close();
      }
}

