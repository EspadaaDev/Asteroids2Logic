using System;

namespace Asteroids2D_GameLogic.Mathematics
{
    internal class RandomExt
    {
        private static Random rnd = new Random();
        public static float NextFloat(float min, float max)
        {
            float integer = rnd.Next((int)min, (int)max);
            double fraction = rnd.NextDouble();

            if (fraction < min - (int)min)
            {
                fraction = min - (int)min;
            }
            if (fraction > max - (int)max)
            {
                fraction = max - (int)max;
            }

            return integer + (float)fraction;
        }

        public static int Next(int min, int max)
        {
            return rnd.Next(min, max);
        }

    }
}
