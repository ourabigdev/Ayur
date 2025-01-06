using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlilCSharp
{
    public class Colors 
    {
        public AmlilColor Red()
        {
            return new AmlilColor(255, 0, 0);
        }
        public AmlilColor Green()
        {
            return new AmlilColor(0, 255, 0);
        }
        public AmlilColor Blue()
        {
            return new AmlilColor(0, 0, 255);
        }
        public AmlilColor Black()
        {
            return new AmlilColor(0, 0, 0);
        }
        public AmlilColor White()
        {
            return new AmlilColor(255, 255, 255);
        }
        
    }
}
