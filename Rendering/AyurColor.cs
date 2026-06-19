using System.Runtime.InteropServices;

namespace Ayur.Rendering
{
    /// <summary>
    /// Represents an RGBA color: Red, Green, Blue, Alpha.
    /// Each channel: 0-255 (0 = min, 255 = max).
    /// Simple struct for easy color creation and manipulation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)] // Ensures C# memory layout matches SDL3
    public record struct AyurColor : IEquatable<AyurColor>
    {
        /// <summary>Red channel (0-255)</summary>
        public byte r;
        /// <summary>Green channel (0-255)</summary>
        public byte g;
        /// <summary>Blue channel (0-255)</summary>
        public byte b;
        /// <summary>Alpha/opacity channel (0=transparent, 255=opaque)</summary>
        public byte a;

        /// <summary>Create a color from RGBA values</summary>
        /// <param name="r">Red (0-255)</param>
        /// <param name="g">Green (0-255)</param>
        /// <param name="b">Blue (0-255)</param>
        /// <param name="a">Alpha (0-255, default 255=opaque)</param>
        public AyurColor(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        // Pre-defined common colors - add more as needed
        /// <summary>Black: RGB(0, 0, 0)</summary>
        public static readonly AyurColor Black = new(0, 0, 0);
        /// <summary>White: RGB(255, 255, 255)</summary>
        public static readonly AyurColor White = new(255, 255, 255);
        /// <summary>Red: RGB(255, 0, 0)</summary>
        public static readonly AyurColor Red = new(255, 0, 0);
        /// <summary>Green: RGB(0, 255, 0)</summary>
        public static readonly AyurColor Green = new(0, 255, 0);
        /// <summary>Blue: RGB(0, 0, 255)</summary>
        public static readonly AyurColor Blue = new(0, 0, 255);
        /// <summary>Yellow: RGB(255, 255, 0)</summary>
        public static readonly AyurColor Yellow = new(255, 255, 0);
        /// <summary>Cyan: RGB(0, 255, 255)</summary>
        public static readonly AyurColor Cyan = new(0, 255, 255);
        /// <summary>Magenta: RGB(255, 0, 255)</summary>
        public static readonly AyurColor Magenta = new(255, 0, 255);
        /// <summary>Gray: RGB(128, 128, 128)</summary>
        public static readonly AyurColor Gray = new(128, 128, 128);
    }
}
