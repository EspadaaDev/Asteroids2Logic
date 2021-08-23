using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture.Components
{
    internal class Rigidbody2D : Component
    {

        public float mass { get; set; } = 1.0f;
        public Vec2 velocity { get; set; }
        public float angularVelocity { get; set; } = 0;
        public float angularDrag { get; set; } = 0.05f;
        public float Drag { get; set; } = 0.01f;
        public float rotation { get; set; } = 0;


        public Transform transform;

        public Rigidbody2D(BaseObject parent) : base(parent)
        {
            transform = parent.transform;
        }

        public void AddForce(Vec2 force)
        {
            velocity += force / 10000f;
        }

        public void AddAngularForce(float value)
        {
            angularVelocity += value / 15f;
        }

        public void AddForceAtPosition(float force, Vec2 position)
        {
            velocity += (position - transform.position).normalize * force;
        }

        public void Update()
        {
            ApplyDrag();
            ApplyVelocity();
        }

        private void ApplyVelocity()
        {
            // velocity
            transform.position += velocity;
            // angularVelocity
            transform.angle += angularVelocity;
        }

        private void ApplyDrag()
        {
            // Drag
            if (Drag > 1)
            {
                velocity /= Drag;
            }
            else if (Drag > 0)
            {
                velocity *= 1f - Drag;
            }

            // Angular Drag
            if (angularDrag > 1)
            {
                angularVelocity /= angularDrag;
            }
            else if (angularDrag > 0)
            {
                angularVelocity *= 1f - angularDrag;
            }
        }
    }
}
