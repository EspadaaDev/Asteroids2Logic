namespace Asteroids2D_GameLogic.Architecture.Weapons
{
    public class MachineGun : Weapon
    {
        private float reloadTimer = 0;

        public override bool Shot()
        {
            if (reloadTimer <= 0)
            {
                return true;
            }
            return false;
        }
        private void Reload(float value)
        {
            if (reloadTimer > 0)
            {
                reloadTimer -= value;
            }
        }
        public override void TimeFlow(float value)
        {
            Reload(value);
        }
    }
}
