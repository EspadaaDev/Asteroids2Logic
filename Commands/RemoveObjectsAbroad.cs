using System;

namespace Asteroids2D_GameLogic.Commands
{
    public class RemoveObjectsAbroad : Command
    {
        protected override bool Run()
        {
            foreach (var item in Core.Game.Objects)
            {
                if (Math.Abs(item.transform.position.x) > Core.Game.borderSize.x + Core.Game.spawnIdent ||
                    Math.Abs(item.transform.position.y) > Core.Game.borderSize.y + Core.Game.spawnIdent)
                {
                    item.Destroy();
                }
            }

            return true;
        }
    }
}
