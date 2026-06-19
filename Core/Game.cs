namespace Ayur.Core
{
    /// <summary>
    /// Base class for creating games with Ayur.
    /// Override Load(), Update(), and Render() to implement your game logic.
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        /// Called once when the game starts.
        /// Use this to load resources and initialize game state.
        /// </summary>
        public virtual void Load() { }

        /// <summary>
        /// Called every frame with delta time.
        /// Use this for game logic and updating entity positions.
        /// </summary>
        /// <param name="dt">Delta time in seconds</param>
        public virtual void Update(float dt) { }

        /// <summary>
        /// Called every frame to render graphics.
        /// Use draw functions from Ayur to render your game.
        /// </summary>
        public virtual void Render() { }

        /// <summary>Internal reference to the window (managed by GameRunner)</summary>
        internal Window Window { get; set; }
    }
}
