using Asteroids2D_GameLogic.Architecture;

namespace Asteroids2D_GameLogic
{
    public class Core
    {
        public readonly Game Game;

        public readonly Turns Turns;

        public readonly TimeWarp TimeWarp;

        public readonly InputManager InputManager;

        public readonly GameInfo GameInfo;

        internal readonly ObjectFactory Factory;


        public Core()
        {            
            Turns = new Turns();
            TimeWarp = new TimeWarp(this);
            Game = new Game(this);
            Factory = new ObjectFactory(this);
            InputManager = new InputManager(Game);

            GameInfo = new GameInfo(this);
        }

    }
}
