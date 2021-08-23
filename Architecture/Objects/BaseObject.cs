using Asteroids2D_GameLogic.Architecture.Components;
using Asteroids2D_GameLogic.Mathematics;
using System;

namespace Asteroids2D_GameLogic.Architecture.Objects
{
    public abstract class BaseObject : Updatable
    {

        public readonly ObjectType Type;

        public Action<BaseObject> DestroyNotify;

        // Transform links
        public float x => transform.x;
        public float y => transform.y;
        public float angleOfRotation => transform.angle;
        public float Size => collider.Size;

        protected readonly float maxSpeed;

        private Core core;

        // Components
        internal Transform transform { get; private set; }
        internal Collider2D collider { get; private set; }
        internal Rigidbody2D rigidbody { get; private set; }

        // Constructor
        public BaseObject(ObjectType type, Vec2 position, float maxSpeed, float angle, float size, Core core)
            : base (core)
        {
            transform = new Transform(position.x, position.y, angle, this);
            collider = new Collider2D(size, this);
            rigidbody = new Rigidbody2D(this);
            Type = type;
            this.core = core;
            this.maxSpeed = maxSpeed;
        }

        internal ObjectType Destroy()
        {
            DestroyNotify?.Invoke(this);
            UnsubscribeUpdate();
            return Type;
        }      

        protected override sealed void UpdateThis()
        {
            rigidbody.Update();
            Update();
            CheckCollisions();            
        }

        protected virtual void Update() {}
        protected virtual void OnColissionEnter(BaseObject collisions) { }

        private void CheckCollisions()
        {
            var contactColliders = collider.GetContacts(core.Game.Colliders);
            foreach (var colider in contactColliders)
            {
                OnColissionEnter(colider.baseObject);
            }
        }
    }
}
