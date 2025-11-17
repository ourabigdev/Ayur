namespace Ayur.Core
{
    public abstract class Game
    {
        public virtual void Load() { }
        public virtual void Update(float dt) { }
        public virtual void Render() { }

        internal Window Window { get; set; }
    }
}
