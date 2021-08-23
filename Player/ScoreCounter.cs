using Asteroids2D_GameLogic.Architecture.Objects;

namespace Asteroids2D_GameLogic.Player
{
    public class ScoreCounter
    {
        // Score
        private int points = 0;

        // Return number of points
        public int Count => points;

        // The method adds some value to the points
        public void Add(int value)
        {
            points += value;
        }

        public void Add(ObjectType type)
        {
            switch (type)
            {
                case ObjectType.Asteroid:
                    Add(150);
                    break;
                case ObjectType.SmallAsteroid:
                    Add(250);
                    break;
                case ObjectType.FlyingSaucer:
                    Add(600);
                    break;
                default:
                    break;
            }
        }

        // Constructors
        public ScoreCounter() { }
        public ScoreCounter(int startPoints)
        {
            points = startPoints;
        }
    }
}
