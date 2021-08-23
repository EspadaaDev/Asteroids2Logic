using Asteroids2D_GameLogic.Architecture.Objects;
using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic
{
    public class InputManager
    {
        private Ship ship;

        public void AxisInput(float x, float y)
        {
            ship.Move(new Vec2(x, y));
        }
        public void MakeBulletShot()
        {
            ship.MakeBulletShot();
        }
        public void MakeLaserShot()
        {
            ship.MakeLaserShot();
        }

        public InputManager(Game Game)
        {
            ship = Game.Ship;
        }
    }
}
