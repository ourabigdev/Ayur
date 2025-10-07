using System.Runtime.InteropServices;

namespace Ayur.Rendering
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AyurColor
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public AyurColor(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}
