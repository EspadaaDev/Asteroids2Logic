namespace Asteroids2D_GameLogic
{
    public class GameInfo
    {
        private readonly Core core;
        public int Score => core.Game.Score.Count;

        // Ship
        public float ShipVelocity => core.Game.Ship.rigidbody.velocity.magnitude;
        public float ShipAngularVelocity => core.Game.Ship.rigidbody.angularVelocity;
        public float ShipLocationX => core.Game.Ship.x;
        public float ShipLocationY => core.Game.Ship.y;
        public float ShipAngleOfRotation => core.Game.Ship.angleOfRotation;

        // LaserGun
        public int MaxLaserShots => core.Game.Ship.LaserGun.MaximumShots; 
        public float NumOfLasershots => core.Game.Ship.LaserGun.NumOfShots;
        public float LaserShotReloadTimer => core.Game.Ship.LaserGun.ShotReloadTimer;
        public float ReloadTimeOfOneLaserShot => core.Game.Ship.LaserGun.ReloadTimeOfOneShot;

        public GameInfo(Core Core)
        {
            core = Core;
        }
    }
}
