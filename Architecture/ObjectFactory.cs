using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Architecture.Objects.Enemies;
using Asteroids2D_GameLogic.Architecture.Objects.Projectiles;
using Asteroids2D_GameLogic.Mathematics;
using System;

namespace Asteroids2D_GameLogic.Architecture
{
    internal class ObjectFactory
    {
        static public Action<BaseObject> ObjectCreationNotify;

        private Core Core;

        private SpawnMath spawnMath;

        public ObjectFactory(Core core)
        {
            Core = core;
            spawnMath = new SpawnMath(Core.Game.borderSize, Core.Game.spawnIdent);
        }

        public BaseObject Create(ObjectType type)
        {
            BaseObject temp = null;
            switch (type)
            {
                case ObjectType.Asteroid:
                    temp = new Asteroid(spawnMath.GetRandomSpawnPosition(), spawnMath.GetRandomPointToTranslate(), Core);
                    break;

                case ObjectType.SmallAsteroid:
                    temp = new SmallAsteroid(spawnMath.GetRandomSpawnPosition(), spawnMath.GetRandomPointToTranslate(), Core);
                    break;

                case ObjectType.FlyingSaucer:
                    temp = new FlyingSaucer(spawnMath.GetRandomSpawnPosition(), Core.Game.Ship, Core);
                    break;

                case ObjectType.Bullet:
                    temp = new Bullet(Core.Game.Ship.transform.position, Core.Game.Ship.transform.up.normalize, Core);
                    break;

                case ObjectType.LaserRay:
                    temp = new LaserRay(Core.Game.Ship.transform.position, Core.Game.Ship.transform.up.normalize, Core);
                    break;
            }
            if (temp != null)
            {
                ObjectCreationNotify?.Invoke(temp);
                return temp;
            }

            return null;
        }
        
        public BaseObject Create(ObjectType type, Vec2 position)
        {
            BaseObject temp = null;
            switch (type)
            {
                case ObjectType.Ship:
                    temp = new Ship(position, 0, Core);
                    return temp;

                case ObjectType.Asteroid:
                    temp = new Asteroid(position, spawnMath.GetRandomPointToTranslate(), Core);
                    break;

                case ObjectType.SmallAsteroid:
                    temp = new SmallAsteroid(position, spawnMath.GetRandomPointToTranslate(), Core);
                    break;

                case ObjectType.FlyingSaucer:
                    temp = new FlyingSaucer(position, Core.Game.Ship, Core);
                    break;

                case ObjectType.Bullet:
                    temp = new Bullet(position, Core.Game.Ship.transform.up.normalize, Core);
                    break;

                case ObjectType.LaserRay:
                    temp = new LaserRay(position, Core.Game.Ship.transform.up.normalize, Core);
                    break;
            }
            if (temp != null)
            {
                ObjectCreationNotify?.Invoke(temp);
                return temp;
            }

            return null;
        }
    }
}
