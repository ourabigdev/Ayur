using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlilCSharp
{
    public class Colors 
    {
        public AmlilColor Black { get; } = new AmlilColor(0, 0, 0);
        public AmlilColor White { get; } = new AmlilColor(255, 255, 255);
        public AmlilColor Gray { get; } = new AmlilColor(130, 130, 130);
        public AmlilColor Red { get; } = new AmlilColor(255, 0, 0);
        public AmlilColor Green { get; } = new AmlilColor(0, 255, 0);
        public AmlilColor Blue { get; } = new AmlilColor(0, 0, 255);
        public AmlilColor Yellow { get; } = new AmlilColor(255, 255, 0);
    }
}
