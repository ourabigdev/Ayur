namespace Ayur.Core
{
    /// <summary>Types of events that can be triggered</summary>
    public enum AyurEventType
    {
        /// <summary>No event</summary>
        None,
        /// <summary>Window close/quit requested</summary>
        Quit,
    }

    /// <summary>Represents an event in the engine</summary>
    public struct AyurEvent
    {
        /// <summary>Type of this event</summary>
        public AyurEventType Type;
    }
}
