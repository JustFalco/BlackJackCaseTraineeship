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
		}

		public void InitializeGame(int amoundOfPlayers, int amoundOfDecks)
		{
			//TODO InitializeGame Function
			//initialize all players
			this.playersInGame = initializePlayers(amoundOfPlayers);
			//set player names
			//initialize dealer
			dealer = new Dealer();

			//Set amound of decks
			this.cardsInGame = initializeCardDecks(amoundOfDecks);
		}


		//TODO refactor naar één initialize functie
		private List<Player> initializePlayers(int amoundOfPlayers)
		{
			List<Player> playerList = new List<Player>();

			for (int i = 0; i < amoundOfPlayers; i++)
			{
				playerList.Add(new Player());
			}

			return playerList;
		}

		private List<CardDeck> initializeCardDecks(int amoundOfCardDecks)
		{
			List<CardDeck> cards = new List<CardDeck>();

			for (int i = 0; i < amoundOfCardDecks; i++)
			{
				cards.Add(new CardDeck());
			}

			return cards;
		}

		private List<T> initializeList<T>(int amoundOfListItems)
		{
			List<T> itemList = new List<T>();

			for (int i = 0; i < amoundOfListItems; i++)
			{
				T obj = new T();
				itemList.Add(obj);
			}

			return itemList;
		}

	}
}
