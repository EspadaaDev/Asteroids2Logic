using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Mathematics;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GameLogicUnitTests")]
namespace Asteroids2D_GameLogic.Architecture.Components
{
    internal class Transform : Component
    {
        public float x
        {
            get { return position.x; }
            set { position.x = value; }
        }
        public float y
        {
            get { return position.y; }
            set { position.y = value; }
        }

        public Vec2 position;
        public float angle { get; set; } = 0;

        public Vec2 rotation
        {
            set
            {
                var temp = (float)(Math.Acos((Vec2.up.x * value.x + Vec2.up.y * value.y) /
                    (Math.Sqrt(Vec2.up.x * Vec2.up.x + Vec2.up.y * Vec2.up.y) * 
                    Math.Sqrt(value.x * value.x + value.y * value.y))) * 180d / Math.PI);
                if (value.x > 0)
                {
                    angle = -temp;
                }
                else
                {
                    angle = temp;
                }
            }
            get
            {
                float x1 = (float)Math.Cos((angle + 90f) * Math.PI / 180);
                float y1 = (float)Math.Sin((angle + 90f) * Math.PI / 180);

                return new Vec2(x1, y1);
            }
        }

        public Vec2 up
        {
            get
            {
                return rotation;
            }
        }

        public Vec2 down
        {
            get
            {
                return -rotation;
            }
        }

        public Transform(float x, float y, float angle, BaseObject parent) : base(parent)
        {
            position = new Vec2(x, y);
            this.angle = angle;
            MaxMinAngleCheck();
        }

        public float MoveRotation(float value)
        {
            angle += value;
            MaxMinAngleCheck();
            return angle;
        }

        public float SetAngle(float angle)
        {
            this.angle = angle;
            MaxMinAngleCheck();
            return this.angle;
        }

        public void Translate(Vec2 offset)
        {
            offset /= 25f;

            x += offset.x;
            y += offset.y;
        }

        public void SetPosition(Vec2 position)
        {
            x = position.x;
            y = position.y;
        }

        private void MaxMinAngleCheck()
        {
            while (angle > 360f)
            {
                angle -= 360f;
            }
            while (angle < 0)
            {
                angle += 360f;
            }
        }
    }
}
