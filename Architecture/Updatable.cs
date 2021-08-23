using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture
{
    public abstract class Updatable
    {
        private Core Core;
        protected abstract void UpdateThis();
        public Updatable(Core core)
        {
            Core = core;
            Core.TimeWarp.AddTimeNotify += UpdateThis;
        }

        protected void UnsubscribeUpdate()
        {
            Core.TimeWarp.AddTimeNotify -= UpdateThis;
        }

        protected BaseObject Instantiate(ObjectType type)
        {
            return new ObjectFactory(Core).Create(type);
        }
        
        protected BaseObject Instantiate(ObjectType type, Vec2 position)
        {
            return new ObjectFactory(Core).Create(type, position);
        }
    }
}
