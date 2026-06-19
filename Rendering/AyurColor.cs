using System.Runtime.InteropServices;

namespace Ayur.Rendering
{
    /// <summary>
    /// Represents an RGBA color (Red, Green, Blue, Alpha).
    /// Values range from 0-255 for each channel.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record struct AyurColor : IEquatable<AyurColor>
    {
        /// <summary>Red channel (0-255)</summary>
        public byte r;
        /// <summary>Green channel (0-255)</summary>
        public byte g;
        /// <summary>Blue channel (0-255)</summary>
        public byte b;
        /// <summary>Alpha/Opacity channel (0-255, 255 = opaque)</summary>
        public byte a;

        /// <summary>Create a color with RGBA values</summary>
        public AyurColor(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        // Pre-defined common colors
        /// <summary>Black (0, 0, 0)</summary>
        public static readonly AyurColor Black = new(0, 0, 0);
        /// <summary>White (255, 255, 255)</summary>
        public static readonly AyurColor White = new(255, 255, 255);
        /// <summary>Red (255, 0, 0)</summary>
        public static readonly AyurColor Red = new(255, 0, 0);
        /// <summary>Green (0, 255, 0)</summary>
        public static readonly AyurColor Green = new(0, 255, 0);
        /// <summary>Blue (0, 0, 255)</summary>
        public static readonly AyurColor Blue = new(0, 0, 255);
        /// <summary>Yellow (255, 255, 0)</summary>
        public static readonly AyurColor Yellow = new(255, 255, 0);
        /// <summary>Cyan (0, 255, 255)</summary>
        public static readonly AyurColor Cyan = new(0, 255, 255);
        /// <summary>Magenta (255, 0, 255)</summary>
        public static readonly AyurColor Magenta = new(255, 0, 255);
        /// <summary>Gray (128, 128, 128)</summary>
        public static readonly AyurColor Gray = new(128, 128, 128);
    }
}
