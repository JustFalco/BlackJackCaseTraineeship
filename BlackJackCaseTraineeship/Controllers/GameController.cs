using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;

namespace BlackJackCaseTraineeship.Controllers
{
	public class GameController
	{
		List<Player> playersInGame = new List<Player>();
		public List<Player> playersInRound = new List<Player>();
		Dealer dealer = new Dealer();
		public CardDeck cardDeck = new CardDeck();
		public int index { get; set; } = 0;
		int roundCount = 0;

		public GameController()
		{

		}

		public void DealRound()
		{
			roundCount++;
			foreach (Player player in playersInRound)
			{
				DealPlayer(player);
			}

			DealDealer(this.dealer);
		}

		public void DealPlayer(Player player)
		{
			player.AddCard(cardDeck.getCard(index));
			index++;
		}

		public void DealDealer(Dealer dealer)
		{
			Card dealerCard = cardDeck.getCard(index);
			if (roundCount == 2)
			{
				dealerCard.IsHidden = true;
			}
			dealer.AddCard(dealerCard);
			index++;
		}

		public void PlaceBets()
		{
			foreach (Player player in playersInGame)
			{
				player.Bet = UserInput.QuestionInt($"Hoeveel wilt {player.Name} inleggen");
			}
		}

		public void addPlayers(int amountOfPlayers)
		{
			for (int i = 0; i < amountOfPlayers; i++)
			{
				Player player = new Player();
				player.Name = UserInput.QuestionString($"Naam speler {i + 1}");
				playersInGame.Add(player);
			}
			AddPlayersToRound();
		}

		public void AddPlayersToRound()
		{
			foreach (Player player in playersInGame)
			{
				playersInRound.Add(player);
			}
		}

		public void BustPlayerFromRound(Player player)
		{
			player.IsBusted = true;
		}

		public void PrintHands()
		{
			foreach (Player player in playersInRound)
			{
				Console.WriteLine(player);
			}
			Console.WriteLine(dealer);
		}

		public void PrintScores()
		{
			foreach (Player player in playersInRound)
			{
				Console.WriteLine($"{player.Name} heeft {player.Bet}");
			}
		}

		public void CheckForPlayerWinAfterDealingCards()
		{
			foreach (Player p in playersInRound)
			{
				if (p.TotalCardAmount == 21)
				{
					Console.WriteLine($"{p.Name} heeft blackjack!");
					p.Bet += p.Bet * 1.5;
					BustPlayerFromRound(p);
				}
			}
		}

		public void DealerCardCheck()
		{
			while (dealer.TotalCardAmount < 17)
			{
				DealDealer(dealer);
			}

			if (dealer.TotalCardAmount > 21)
			{
				dealer.IsBusted = true;
				Console.WriteLine("Dealer Busted!");
			}

			foreach (Card card in dealer.Cards)
			{
				card.IsHidden = false;
			}
		}

		public void CheckScores()
		{
			foreach (Player player in playersInRound)
			{
				if (!player.IsBusted && !dealer.IsBusted)
				{
					if (player.TotalCardAmount > dealer.TotalCardAmount)
					{
						player.Bet = player.Bet * 2;
					}
				}
				else if (!player.IsBusted && dealer.IsBusted)
				{
					player.Bet = player.Bet * 2;
				}
			}
		}

		public void ClearHands()
		{
			dealer.ClearHand();
			foreach (Player player in playersInRound)
			{
				player.IsBusted = false;
				player.ClearHand();
			}
		}

	}
}
