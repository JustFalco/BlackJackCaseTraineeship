using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;


namespace BlackJackCaseTraineeship.Controllers
{
	public class Game
	{
		TurnController turnController;
		List<Player> playersInGame;
		CardDeck cardsInGame;
		bool IsGameActive = true;

		public Game()
		{
			playersInGame = new List<Player>();

			int amoundOfPlayers = UserInput.QuestionInt("Aantal spelers (max 5)", 1, 5);
			int amoundOfDecks = UserInput.QuestionInt("Aantal speeldecks (max 6)", 1, 6);

			InitializeGame(amoundOfPlayers, amoundOfDecks);

			this.turnController = new TurnController(playersInGame, cardsInGame);

			while (IsGameActive)
			{
				Console.Clear();

				//set player data
				setPlayerData();
				
				//play turn
				GameController.ClearHands(playersInGame);
				turnController.Turn();
				IsGameActive = newRound();
			}
		}
		 
		public void InitializeGame(int amoundOfPlayers, int amoundOfDecks)
		{
			//initialize all players
			this.playersInGame = initializeList(playersInGame, amoundOfPlayers);

			//Set amound of decks
			this.cardsInGame = listToCardDeck(amoundOfDecks);
		}

		private List<T> initializeList<T>(List<T> itemList ,int amoundOfListItems) where T : new()
		{
			for (int i = 0; i < amoundOfListItems; i++)
			{
				itemList.Add(new T());
			}

			return itemList;
		}

		private CardDeck listToCardDeck(int amoundOfDecks)
		{
			List<CardDeck> templist = new List<CardDeck>();
			templist = initializeList(templist, amoundOfDecks);
			CardDeck finalCardDeck = new CardDeck().StackAllCardDecks(templist);
			return finalCardDeck;
		}

		private void setPlayerData()
		{
			int playerIndex = 1;
			foreach (Player player in playersInGame)
			{
				if (string.IsNullOrEmpty(player.Name))
				{
					player.Name = UserInput.QuestionString($"Naam speler {playerIndex}", true);
				}
				
				player.Bet = UserInput.QuestionInt($"Hoeveel legt {player.Name} in");
				playerIndex++;
			}
		}

		private bool newRound()
		{
			while (true)
			{
				switch (UserInput.QuestingChar("Nog een ronde: (y)es / (n)o"))
				{
					case 'y':
						return true;
					case 'n':
						return false;
				}
			}
		}

		
	}
}
