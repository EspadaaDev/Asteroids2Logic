namespace Asteroids2D_GameLogic.Mathematics
{
    public class SpawnMath
    {
        // Lower border of objects spawn
        private Vec2 minSpawnBorderSize;
        // Upper border of objects spawn
        private Vec2 maxSpawnBorderSize;

        // Constructor
        public SpawnMath(Vec2 spawnBorderSize, float spawnIdent)
        {
            if (spawnIdent < 0)
            {
                spawnIdent *= -1;
            }

            this.minSpawnBorderSize = spawnBorderSize;
            maxSpawnBorderSize = new Vec2(spawnBorderSize.x + spawnIdent, spawnBorderSize.y + spawnIdent);
        }

        // Return random position for spawn object within the given framework
        public Vec2 GetRandomSpawnPosition()
        {
            // Quarter selection
            switch (RandomExt.Next(0, 4))
            {
                case 0:
                    return new Vec2(RandomExt.NextFloat(-maxSpawnBorderSize.x, maxSpawnBorderSize.x)
                , RandomExt.NextFloat(minSpawnBorderSize.y, maxSpawnBorderSize.y));
                case 1:
                    return new Vec2(RandomExt.NextFloat(-maxSpawnBorderSize.x, maxSpawnBorderSize.x)
                , RandomExt.NextFloat(-maxSpawnBorderSize.y, -minSpawnBorderSize.y));
                case 2:
                    return new Vec2(RandomExt.NextFloat(-maxSpawnBorderSize.x, -minSpawnBorderSize.x)
                , RandomExt.NextFloat(-maxSpawnBorderSize.y, maxSpawnBorderSize.y));
                case 3:
                    return new Vec2(RandomExt.NextFloat(minSpawnBorderSize.x, maxSpawnBorderSize.x)
                , RandomExt.NextFloat(-maxSpawnBorderSize.y, maxSpawnBorderSize.y));
            }

            return new Vec2();
        }

        public Vec2 GetRandomPointToTranslate()
        {
            Vec2 vectorToTarget = new Vec2(
                RandomExt.NextFloat(-minSpawnBorderSize.x, minSpawnBorderSize.x),
                RandomExt.NextFloat(-minSpawnBorderSize.y, minSpawnBorderSize.y));
            return vectorToTarget;
        }
    }
}
