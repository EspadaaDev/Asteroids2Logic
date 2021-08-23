namespace Asteroids2D_GameLogic.Commands
{
    public class NextTurn : Command
	{		
		protected override bool Run()
		{
			// Time dependent methods

			new CreateObjects().Execute(Core);
			new DestroyObjects().Execute(Core);
			new RemoveObjectsAbroad().Execute(Core);

			Core.Turns.NextTurn();
			return true;
		}
	}
}
