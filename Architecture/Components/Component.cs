using Asteroids2D_GameLogic.Architecture.Objects;

namespace Asteroids2D_GameLogic.Architecture.Components
{
    internal class Component
    {
        public readonly BaseObject baseObject;

        public Component(BaseObject parent)
        {
            baseObject = parent;
        }
    }
}
