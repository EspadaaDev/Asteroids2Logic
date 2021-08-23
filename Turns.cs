namespace Asteroids2D_GameLogic
{
    public class Turns
	{
		public int CurrentTurn { get; private set; }

		internal void NextTurn()
		{
			CurrentTurn++;
		}
	}
}
