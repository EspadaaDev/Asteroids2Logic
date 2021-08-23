using System.Collections.Generic;

namespace Asteroids2D_GameLogic.Commands
{
    public class DestroyObjects : Command
    {
        protected override bool Run()
        {
            foreach (var destroyable in Core.Game.nextDestroyableObjects)
            {
                Core.Game.Colliders.Remove(destroyable.collider);
                Core.Game.Objects.Remove(destroyable);
            }

            Core.Game.nextDestroyableObjects = new List<Architecture.Objects.BaseObject>();

            return true;
        }
    }
}
