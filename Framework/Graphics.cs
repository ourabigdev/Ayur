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
        public static extern SpriteAnimation CreateSpriteAnimation(
            IntPtr atlas,
            int framePerSecond,
            Rectangle[] rectangles,
            int legth
        );
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeSpriteAnimation(ref SpriteAnimation animation);
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawAnimation(
            SpriteAnimation animation,
            Rectangle dest,
            Vector2 origin,
            float rotation,
            AyurColor tint
        );
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadSprite(string path);
    }

    public struct Vector2
    {
        public float x;
        public float y;
    }

}
