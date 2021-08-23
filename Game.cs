using Asteroids2D_GameLogic.Architecture;
using Asteroids2D_GameLogic.Architecture.Components;
using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Mathematics;
using Asteroids2D_GameLogic.Player;
using System;
using System.Collections.Generic;

namespace Asteroids2D_GameLogic
{
    public class Game : Updatable
    {
        public readonly Core Core;

        public readonly Ship Ship;

        public readonly ScoreCounter Score = new ScoreCounter();

        // Border constants
        public readonly Vec2 borderSize = new Vec2(9f, 5f);
        public readonly float spawnIdent = 3f;

        internal List<BaseObject> Objects = new List<BaseObject>();
        internal List<Collider2D> Colliders = new List<Collider2D>();

        internal List<ObjectType> nextCreatedObjects = new List<ObjectType>();
        internal List<BaseObject> nextDestroyableObjects = new List<BaseObject>();

        // Actions
        public event Action<BaseObject> ObjectCreationNotify;
        public event Action GameIsOverNotify;

        private readonly EnemySpawner enemySpawner;

        public Game(Core Core) : base(Core)
        {
            this.Core = Core;

            ObjectFactory.ObjectCreationNotify += OnObjectCreate;

            enemySpawner = new EnemySpawner(Core);
            Ship = new Ship(new Vec2(), 0f, Core);
            Objects.Add(Ship);
            Colliders.Add(Ship.collider);
        }

        public void CreateObject(ObjectType type)
        {
            nextCreatedObjects.Add(type);
        }

        public void CreateObject(ObjectType type, int number)
        {
            for (int i = 0; i < number; i++)
            {
                nextCreatedObjects.Add(type);
            }
        }

        public void CreateObject(ObjectType type, Vec2 position)
        {
            nextCreatedObjects.Add(type);
        }

        private void DestroyObject(BaseObject destructible)
        {
            nextDestroyableObjects.Add(destructible);
            Score.Add(destructible.Type);
            destructible.DestroyNotify -= DestroyObject;
        }

        // On object create handler
        private void OnObjectCreate(BaseObject newObject)
        {
            Objects.Add(newObject);
            newObject.DestroyNotify += DestroyObject;
            Colliders.Add(newObject.collider);
            ObjectCreationNotify?.Invoke(newObject);
        }

        internal void GameOver()
        {
            GameIsOverNotify?.Invoke();
            Core.TimeWarp.Stop();
        }

        protected override void UpdateThis() { }
    }
}
