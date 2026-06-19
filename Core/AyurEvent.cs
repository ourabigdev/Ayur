namespace Ayur.Core
{
    /// <summary>
    /// Event types the framework recognizes.
    /// Minimal set - only essential events.
    /// </summary>
    public enum AyurEventType
    {
        /// <summary>No event</summary>
        None,
        /// <summary>User requested window close</summary>
        Quit,
    }

    /// <summary>
    /// Represents a single event.
    /// Simple struct - no unnecessary complexity.
    /// </summary>
    public struct AyurEvent
    {
        /// <summary>What type of event is this?</summary>
        public AyurEventType Type;
    }
}
