using BlackJackCaseTraineeship.Utils;
using BlackJackCaseTraineeship.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Controllers
{
	public class Game
	{
		GameController controller;

		public Game(GameController controller)
		{
			this.controller = controller;

			Menus.MainMenu();
			int amoundOfPlayers = UserInput.QuestionInt("Met hoeveel spelers wilt u spelen");
			controller.addPlayers(amoundOfPlayers);
			controller.PlaceBets();
			controller.DealRound();
			Console.Clear();
			controller.PrintHands();
			Console.ReadLine();
			controller.DealRound();
			Console.Clear();
			controller.PrintHands();
		}


	}
}
