using Asteroids2D_GameLogic.Architecture;
using Asteroids2D_GameLogic.Architecture.Objects;

namespace Asteroids2D_GameLogic
{
    internal class EnemySpawner : Updatable
    {
        // Default time to create enemies
        private readonly float timeToCreateAsteroid = 3;
        private readonly float timeToCreateSmallAsteroid = 2;
        private readonly float timeToCreateFlyingSaucer = 9;

        // Timers
        private float asteroidCreationTimer = 0;
        private float smallAsteroidCreationTimer = 0;
        private float flyingSaucerCreationTimer = 0;

        // Constructor
        public EnemySpawner(Core core) : base(core) { }

        // Updatable overriding update method
        protected override void UpdateThis()
        {
            TimeFlow(TimeWarp.deltaTime);
        }

        // River time
        private void TimeFlow(float ms)
        {
            asteroidCreationTimer += ms;
            smallAsteroidCreationTimer += ms;
            flyingSaucerCreationTimer += ms;

            CreationLogic();
        }

        // Logi to create objects
        private void CreationLogic()
        {
            // Asteroid
            if (asteroidCreationTimer > timeToCreateAsteroid)
            {
                Instantiate(ObjectType.Asteroid);
                asteroidCreationTimer = 0;
            }

            // Small asteroid
            if (smallAsteroidCreationTimer > timeToCreateSmallAsteroid)
            {
                Instantiate(ObjectType.SmallAsteroid);
                smallAsteroidCreationTimer = 0;
            }

            // Flying Saucer
            if (flyingSaucerCreationTimer > timeToCreateFlyingSaucer)
            {
                Instantiate(ObjectType.FlyingSaucer);
                flyingSaucerCreationTimer = 0;
            }
        }
    }
}
