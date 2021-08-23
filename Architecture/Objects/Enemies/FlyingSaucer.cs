using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Objects.Enemies
{
    public class FlyingSaucer : BaseObject
    {
        private BaseObject ship;
        public FlyingSaucer(Vec2 position, BaseObject ship, Core core)
            : base(
            type: ObjectType.FlyingSaucer,
            position: position,
            maxSpeed: 1,
            angle: 0,
            size: 0.36f,
            core: core
            )
        {
            this.ship = ship;
        }

        protected override void Update()
        {
            transform.Translate((ship.transform.position - transform.position).normalize * maxSpeed);
        }
    }
}
