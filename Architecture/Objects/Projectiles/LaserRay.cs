using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Objects.Projectiles
{
    public class LaserRay : BaseObject
    {
        public LaserRay(Vec2 position, Vec2 moveTo, Core core)
            : base(
            type: ObjectType.LaserRay,
            position: position,
            maxSpeed: 4,
            angle: 0,
            size: 0.04f,
            core: core
            )
        {
            transform.rotation = moveTo;
        }

        protected override void OnColissionEnter(BaseObject collisions)
        {
            if (collisions.Type == ObjectType.Asteroid ||
                collisions.Type == ObjectType.FlyingSaucer ||
                collisions.Type == ObjectType.SmallAsteroid)
            {
                collisions.Destroy();
            }
        }

        protected override void Update()
        {
            transform.Translate(transform.up * maxSpeed);
        }
    }
}
