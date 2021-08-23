using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Objects.Projectiles
{
    public class Bullet : BaseObject
    {
        private Vec2 rotationVector;
        public Bullet(Vec2 position, Vec2 moveTo, Core core)
            : base(
            type: ObjectType.Bullet,
            position: position,
            maxSpeed: 4,
            angle: 0,
            size: 0.01f,
            core: core
            )
        {
            rotationVector = moveTo;
        }

        protected override void OnColissionEnter(BaseObject collisions)
        {
            if (collisions.Type == ObjectType.SmallAsteroid || collisions.Type == ObjectType.FlyingSaucer
                        || collisions.Type == ObjectType.Asteroid)
            {
                if (collisions.Type == ObjectType.Asteroid)
                {
                    Instantiate(ObjectType.SmallAsteroid, transform.position);
                    Instantiate(ObjectType.SmallAsteroid, transform.position);
                }
                collisions.Destroy();
                Destroy();
            }
        }

        protected override void Update()
        {
            transform.Translate(rotationVector * maxSpeed);
        }
    }
}
