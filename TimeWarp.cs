using Asteroids2D_GameLogic.Commands;
using System;

namespace Asteroids2D_GameLogic
{
    public class TimeWarp
    {
        public readonly Core Core;
        public static float deltaTime { get; private set; }
        public static float time { get; private set; } 
        public bool IsStopped { get; private set; }

        public event Action AddTimeNotify;        

        public TimeWarp(Core core)
        {
            deltaTime = 0;
            time = 0;

            Core = core;
            IsStopped = false;
        }

        public void Stop()
        {
            IsStopped = true;
        }

        public void Start()
        {
            IsStopped = false;
        }

        public void AddTime(float ms)
        {
            if (IsStopped) return;

            time += ms;
            deltaTime = ms;
            AddTimeNotify?.Invoke();

            new NextTurn().Execute(Core);
        }
    }
}
