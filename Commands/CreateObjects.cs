using Asteroids2D_GameLogic.Architecture;
using Asteroids2D_GameLogic.Architecture.Objects;
using System.Collections.Generic;

namespace Asteroids2D_GameLogic.Commands
{
    public class CreateObjects : Command
    {
        protected override bool Run()
        {
            foreach (var item in Core.Game.nextCreatedObjects)
            {
                new ObjectFactory(Core).Create(item);
            }

            Core.Game.nextCreatedObjects = new List<ObjectType>();

            return true;
        }
    }
}
