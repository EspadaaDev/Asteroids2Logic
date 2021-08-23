namespace Asteroids2D_GameLogic.Architecture.Weapons
{
    public class LaserGun : Weapon
    {
        public readonly int MaximumShots = 3;
        public int NumOfShots { get; private set; } = 0;
        public float ShotReloadTimer { get; private set; } = 0;
        public float ReloadTimeOfOneShot { get; private set; } = 3.0f;


        // Shot
        public override bool Shot()
        {
            if (NumOfShots > 0f)
            {
                NumOfShots -= 1;
                return true;
            }
            return false;
        }

        // Add shots 
        private void AddShotTimer(float value)
        {
            if (NumOfShots < MaximumShots) {
                ShotReloadTimer += value;
            }
            else
            {
                ShotReloadTimer = 0;
            }

            if (ShotReloadTimer > ReloadTimeOfOneShot)
            {
                NumOfShots += 1;
                ShotReloadTimer = 0;
            }
        }

        public override void TimeFlow(float value)
        {
            AddShotTimer(value);
        }
    }
}
