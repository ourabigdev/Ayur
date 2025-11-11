namespace Ayur.Core
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
