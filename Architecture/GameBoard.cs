using Asteroids2D_GameLogic.Mathematics;

namespace Asteroids2D_GameLogic.Architecture
{
    public class GameBoard
    {
        private Vec2 _size = new Vec2(9f, 5f);
        public Vec2 Size => _size;

        public GameBoard(Vec2 size)
        {
            _size = size;
        }

        public GameBoard() { }
    }
}
