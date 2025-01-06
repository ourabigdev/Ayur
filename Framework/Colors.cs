using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlilCSharp
{
    public class Colors 
    {
        public AyurColor Black { get; } = new AyurColor(0, 0, 0);
        public AyurColor White { get; } = new AyurColor(255, 255, 255);
        public AyurColor Gray { get; } = new AyurColor(130, 130, 130);
        public AyurColor Red { get; } = new AyurColor(255, 0, 0);
        public AyurColor Green { get; } = new AyurColor(0, 255, 0);
        public AyurColor Blue { get; } = new AyurColor(0, 0, 255);
        public AyurColor Yellow { get; } = new AyurColor(255, 255, 0);
    }
}
