using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Objects.Enemies
{
    public class SmallAsteroid : BaseObject
    {
        private Vec2 targetPoint;
        public SmallAsteroid(Vec2 position, Vec2 moveTo, Core core)
            : base(
            type: ObjectType.SmallAsteroid,
            position: position,
            maxSpeed: 1,
            angle: 0,
            size: 0.23f,
            core: core
            )
        {
            targetPoint = (moveTo - position).normalize;
        }

        protected override void Update()
        {
            transform.Translate(targetPoint * maxSpeed);
        }
    }
}
