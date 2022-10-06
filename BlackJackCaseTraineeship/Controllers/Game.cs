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
		private Dealer dealer;
		List<CardDeck> cardsInGame;
		bool IsGameActive = true;

		public Game()
		{
			this.turnController = new TurnController();
			this.gameController = new GameController();

			int amoundOfPlayers = UserInput.QuestionInt("Aantal spelers");
			int amoundOfDecks = UserInput.QuestionInt("Aantal speeldecks");

			InitializeGame(amoundOfPlayers, amoundOfDecks);

			while (IsGameActive)
			{
				//play turn
			}
		}
		 
		public void InitializeGame(int amoundOfPlayers, int amoundOfDecks)
		{
			//TODO InitializeGame Function
			//initialize all players
			this.playersInGame = initializeList(playersInGame, amoundOfPlayers);
			
			//set player data
			setPlayerData();

			//initialize dealer
			dealer = new Dealer();

			//Set amound of decks
			this.cardsInGame = initializeList(cardsInGame, amoundOfDecks);
		}

		private List<T> initializeList<T>(List<T> itemList ,int amoundOfListItems) where T : new()
		{
			for (int i = 0; i < amoundOfListItems; i++)
			{
				itemList.Add(new T());
			}

			return itemList;
		}

		private void setPlayerData()
		{
			int playerIndex = 1;
			foreach (Player player in playersInGame)
			{
				player.Name = UserInput.QuestionString($"Naam speler {playerIndex}");
				player.Bet = UserInput.QuestionInt($"Hoeveel legt {player.Name} in");
				playerIndex++;
			}
		}

	}
}
