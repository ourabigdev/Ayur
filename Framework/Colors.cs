using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyurCSharp
{
    public class Colors 
    {
        public static readonly AyurColor Black  = new AyurColor(0, 0, 0);
        public static readonly AyurColor White  = new AyurColor(255, 255, 255);
        public static readonly AyurColor Gray  = new AyurColor(130, 130, 130);
        public static readonly AyurColor Red  = new AyurColor(255, 0, 0);
        public static readonly AyurColor Green  = new AyurColor(0, 255, 0);
        public static readonly AyurColor Blue  = new AyurColor(0, 0, 255);
        public static readonly AyurColor Yellow  = new AyurColor(255, 255, 0);
    }
}
