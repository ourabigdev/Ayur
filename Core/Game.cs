namespace Ayur.Core
{
    /// <summary>
    /// Base class for all Ayur games.
    /// Override Load(), Update(), and Render() to create your game.
    /// Keep it simple - this is the contract between framework and user code.
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        /// Called once at game startup.
        /// Load resources here: textures, shapes, initial values.
        /// </summary>
        public virtual void Load() { }

        /// <summary>
        /// Called every frame (~60 times per second).
        /// Update game logic here: move objects, check collisions, etc.
        /// </summary>
        /// <param name="dt">Delta time since last frame (in seconds)</param>
        public virtual void Update(float dt) { }

        /// <summary>
        /// Called every frame after Update().
        /// Render graphics here: draw shapes, textures, etc.
        /// </summary>
        public virtual void Render() { }

        /// <summary>Internal: Window reference managed by GameRunner</summary>
        internal Window Window { get; set; }
    }
}
