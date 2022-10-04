using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Controllers
{
	public class GameController
	{
		List<Player> players = new List<Player>();
		Dealer dealer = new Dealer();
		public CardDeck cardDeck = new CardDeck();
		int index = 0;

		public GameController()
		{

		}

		public void DealRound()
		{
			foreach(Player player in players)
			{
				player.AddCard(cardDeck.getCard(index));
				index++;
			}

			dealer.AddCard(cardDeck.getCard(index));
			index++;
		}

		public void PlaceBets()
		{
			foreach(Player player in players)
			{
				player.Bet = UserInput.QuestionInt($"Hoeveel wilt {player.Name} inleggen");
			}
		}

		public void addPlayers(int amountOfPlayers)
		{	
			for(int i = 0; i < amountOfPlayers; i++)
			{
				Player player = new Player();
				player.Name = UserInput.QuestionString($"Naam speler {i + 1}");
				players.Add(player);
			}
		}

		public void PrintHands()
		{
			foreach(Player player in players)
			{
				Console.WriteLine(player);
			}
			Console.WriteLine(dealer);
		}

	}
}
