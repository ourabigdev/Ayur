using System.Drawing;
using System.Runtime.InteropServices;

namespace Ayur.Rendering
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct AyurColor : IEquatable<AyurColor>
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

        public static readonly AyurColor Black = new AyurColor(0, 0, 0);
        public static readonly AyurColor White = new AyurColor(255, 255, 255);
        public static readonly AyurColor Red = new AyurColor(255, 0, 0);
        public static readonly AyurColor Blue = new AyurColor(0, 0, 255);
        public static readonly AyurColor Green = new AyurColor(0, 255, 0);


        public static implicit operator AyurColor(Color c)=> new AyurColor(c.R, c.G, c.B, c.A);
        //MemoryMarshal 
    }
}
