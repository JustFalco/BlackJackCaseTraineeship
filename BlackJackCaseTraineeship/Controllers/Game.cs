using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;
using BlackJackCaseTraineeship.Views;

namespace BlackJackCaseTraineeship.Controllers
{
	public class Game
	{
		GameController gameController;
		TurnController turnController;
		List<Player> playersInGame;
		List<CardDeck> cardsInGame;
		bool IsGameActive = true;

		public Game(GameController gameController, TurnController turnController)
		{
			this.turnController = turnController;
			this.gameController = gameController;
		}

		public void InitializeGame()
		{
			//initialize all players
			//initialize dealer
			//Set amound of decks
		}

	}
}
