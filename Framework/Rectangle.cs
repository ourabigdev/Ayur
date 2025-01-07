using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AyurCSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        int posX;
        int posY;
        int height;
        int width;

        public Rect(int posX, int posY, int height, int width)
        {
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;
        }

    }
}
