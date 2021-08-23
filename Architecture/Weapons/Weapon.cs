namespace Asteroids2D_GameLogic.Architecture.Weapons
{
    public abstract class Weapon
    {
        public abstract bool Shot();
        public abstract void TimeFlow(float value);
    }
}
