using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AyurCSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpriteAnimation
    {
        public IntPtr atlas;
        public int framePerSecond;
        public IntPtr rectangles;
        public int rectanglesLength;
    }
}
