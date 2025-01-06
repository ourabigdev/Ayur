using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AmlilCSharp
{
    public class Core
    {
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFps(int FPS);
    }
}
