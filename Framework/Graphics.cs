using System;
using System.Runtime.InteropServices;


namespace AyurCSharp
{
    public class Graphics
    {
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Window(int x, int y, string title);

        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ShouldCloseWindow();

        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Close();

        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Begin(bool Showfps);

        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void End();

        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundColor(AyurColor c);
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadSprite(string path);
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawRect(Rect rectangle, AyurColor color);
    }
}
