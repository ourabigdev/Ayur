using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AyurCSharp
{
    public class Core
    {
        [DllImport("Ayur", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Window(string title, int w, int h);
    }
}
