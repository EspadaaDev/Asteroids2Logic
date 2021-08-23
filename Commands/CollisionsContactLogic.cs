using Asteroids2D_GameLogic.Architecture.Objects;

namespace Asteroids2D_GameLogic.Commands
{
    public class CollisionsContactLogic
    {
        public void CheckContact(BaseObject item, Core Core)
        {
            // Bullet
            if (item.Type == ObjectType.Bullet)
            {
                var contactColliders = item.collider.GetContacts(Core.Game.Colliders);
                foreach (var colider in contactColliders)
                {
                    if (colider.baseObject.Type == ObjectType.SmallAsteroid || colider.baseObject.Type == ObjectType.FlyingSaucer
                        || colider.baseObject.Type == ObjectType.Asteroid)
                    {
                        Core.Game.Score.Add(colider.baseObject.Type);
                        if (colider.baseObject.Type == ObjectType.Asteroid)
                        {
                            Core.Game.CreateObject(ObjectType.SmallAsteroid, 2);
                        }
                        item.Destroy();
                        colider.baseObject.Destroy();
                    }
                }
            }

            // Laser Ray
            if (item.Type == ObjectType.LaserRay)
            {
                var contactColliders = item.collider.GetContacts(Core.Game.Colliders);
                foreach (var colider in contactColliders)
                {
                    if (colider.baseObject.Type != ObjectType.Ship && colider.baseObject.Type != ObjectType.Bullet)
                    {
                        Core.Game.Score.Add(colider.baseObject.Type);
                        colider.baseObject.Destroy();
                    }
                }
            }

            // Ship
            if (item.Type == ObjectType.Ship)
            {
                var contactColliders = item.collider.GetContacts(Core.Game.Colliders);
                foreach (var colider in contactColliders)
                {
                    if (colider.baseObject.Type != ObjectType.Bullet && colider.baseObject.Type != ObjectType.LaserRay)
                    {
                        Core.Game.GameOver();
                    }
                }
            }
        }
    }
}
