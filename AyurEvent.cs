using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayur
{
    public enum AyurEventType { 
        None,
        Quit,
    }

    public struct AyurEvent
    {
        public AyurEventType Type;
    }
}
