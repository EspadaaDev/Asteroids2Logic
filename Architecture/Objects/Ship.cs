using Asteroids2D_GameLogic.Architecture.Weapons;
using Asteroids2D_GameLogic.Mathematics;
using System;

namespace Asteroids2D_GameLogic.Architecture.Objects
{
    public class Ship : BaseObject
    {
        private float speedForce = 4.0f;
        private float maxAngularVelocity = 5.0f;
        private float angularAcceleration = 0.7f;

        internal readonly LaserGun LaserGun;
        internal readonly MachineGun MachineGun;

        public readonly Core Core;

        public Ship(Vec2 position, float direction, Core core)
            : base(position: position,
                   maxSpeed: 2f,
                   angle: direction,
                   size: 0.22f,
                   type: ObjectType.Ship,
                   core: core
                   )
        {
            LaserGun = new LaserGun();
            MachineGun = new MachineGun();
            Core = core;
        }

        public void Move(Vec2 input)
        {
            if (input.y > 0)
            {
                if (rigidbody.velocity.magnitude < maxSpeed)
                {
                    rigidbody.AddForce(transform.up * speedForce);
                }
            }

            if (input.x > 0)
            {
                if (rigidbody.angularVelocity < maxAngularVelocity)
                {
                    rigidbody.AddAngularForce(angularAcceleration);
                }
            }

            if (input.x < 0)
            {
                if (rigidbody.angularVelocity > -maxAngularVelocity)
                {
                    rigidbody.AddAngularForce(-angularAcceleration);
                }
            }
        }

        public void MakeBulletShot()
        {
            if (MachineGun.Shot())
            {
                Core.Game.CreateObject(ObjectType.Bullet, 1);
            }
        }
        
        public void MakeLaserShot()
        {
            if (LaserGun.Shot())
            {
                Core.Game.CreateObject(ObjectType.LaserRay, 1);
            }
        }

        protected override void OnColissionEnter(BaseObject collisions)
        {
            if (collisions.Type == ObjectType.Asteroid ||
                collisions.Type == ObjectType.FlyingSaucer ||
                collisions.Type == ObjectType.SmallAsteroid)
            {
                Core.Game.GameOver();
            }
        }
        protected override void Update()
        {
            BorderTeleport();
            LaserGun.TimeFlow(TimeWarp.deltaTime);
        }

        private void BorderTeleport()
        {
            if (Math.Abs(x) > Core.Game.borderSize.x ||
                Math.Abs(y) > Core.Game.borderSize.y)
            {
                transform.position *= -1f;
            }
        }
    }
}
