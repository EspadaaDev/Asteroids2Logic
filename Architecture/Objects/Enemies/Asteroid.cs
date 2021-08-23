using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Objects.Enemies
{
    public class Asteroid : BaseObject
    {
        public Asteroid(Vec2 position, Vec2 moveTo, Core core)
            : base(
            type: ObjectType.Asteroid,
            position: position,
            maxSpeed: 1,
            angle: 0,
            size: 0.44f,
            core: core
            )
        {
            transform.rotation = (moveTo - position).normalize;
        }

        protected override void Update()
        {
            transform.Translate(transform.up * maxSpeed);
        }
    }
}
