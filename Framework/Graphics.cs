using System;
using System.Runtime.InteropServices;

namespace AmlilCSharp
{
    public class Graphics
    {
        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Window(int x, int y, string title);

        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ShouldCloseWindow();

        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Close();

        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Begin(bool Showfps);

        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void End();

        [DllImport("Amlil", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BackgroundColor(int r, int g, int b, int a);


        
    }
}
