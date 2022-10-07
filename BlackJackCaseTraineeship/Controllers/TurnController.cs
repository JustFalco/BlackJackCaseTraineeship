using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;
using static BlackJackCaseTraineeship.Utils.TurnTypes;

namespace BlackJackCaseTraineeship.Controllers
{
	public class TurnController
	{
		//Variables
		private List<Player> playersInRound;
		private Dealer dealer;

		public List<Player> PlayersInRound
		{
			get
			{
				if (playersInRound == null)
				{
					playersInRound = new List<Player>();
				}
				return playersInRound;
			}
			set
			{
				playersInRound = value;
			}
		}

		private CardDeck cardsInGame;

		//Constructor
		public TurnController(List<Player> playersInRound, CardDeck cardsInGame)
		{
			PlayersInRound = playersInRound;
			this.cardsInGame = cardsInGame;
			dealer = new Dealer();
		}

		//Methods
		public void Turn()
		{
			dealer = new Dealer();
			foreach (TurnTypes turnTypes in Enum.GetValues(typeof(TurnTypes)))
			{
				NextTurn(turnTypes);
			}
			
		}

		public void NextTurn(TurnTypes turnTypes)
		{
			switch (turnTypes)
			{
				case DEALALLTURN:
					DealToAll();
					DealToAll();
					CheckForBlackJack();
					PrintHands();
					break;
				case PLAYERTURN:
					foreach (Player player in PlayersInRound)
					{
						PlayerTurn(player);
					}
					break;
				case DEALERTURN:
					DealerTurn();
					break;
				case FINALTURNS:
					FinalTurn();
					break;
			}
		}

		private void DealToAll()
		{
			//All players including the dealer get a card
			foreach (Player player in playersInRound)
			{
				GameController.DealPlayer(player, cardsInGame);
			}

			GameController.DealDealer(dealer, cardsInGame);
		}

		
		private void PlayerTurn(Player player)
		{
			bool isPlayersTurn = true;
			if (player.IsBusted || !isPlayersTurn)
			{
				return;
			}
			//player can choose to hit, stay, double, split
			while (isPlayersTurn)
			{
				Console.Clear();
				PrintHands();
				foreach (Hand hand in player.Hands)
				{
					switch (UserInput.QuestingChar($"{player.Name}: (h)it / (s)tay / (d)ouble / s(p)lit"))
					{
						case 'h':
							hand.AddCartToHand(cardsInGame.GetFirstActiveCardOnDeck());
							if (hand.TotalCardAmount > 21)
							{
								//TODO bust hand instead of player
								Console.Clear();
								Console.WriteLine($"{player.Name} busted!");
								Console.WriteLine(player + "\n");
								player.BustPlayer();
								return;
							}
							break;
						case 's':
							isPlayersTurn = false;
							return;
						case 'd':
							//TODO new bet bovenop de huidige met als max de huidige bet
							if (hand.CardsInHand.Count == 2 && hand.LeastTotalAmount <= 11)
							{
								hand.AddCartToHand(cardsInGame.GetFirstActiveCardOnDeck());
								//TODO set bet on hand
								player.Bet = player.Bet * 2;
								return;
							}
							Console.WriteLine("Cannot double down");
							break;
						case 'p':
							//TODO split hand
							if (player.PlayerCanSplit(hand))
							{

							}

							Console.WriteLine("Cannot split");
							throw new NotImplementedException();
							break;
					}
				}
			}
		}

		private void DealerTurn()
		{
			if (dealer.IsBusted)
			{
				return;
			}
			//Dealer has to pick a card if total is below 17
			while (dealer.Hands.First().TotalCardAmount < 17)
			{
				GameController.DealDealer(dealer, cardsInGame);
			}

			if (dealer.Hands.First().TotalCardAmount > 21)
			{
				dealer.BustPlayer();
				Console.WriteLine("Dealer Busted!");
			}

			foreach (Card card in dealer.Hands.First().CardsInHand)
			{
				card.IsHidden = false;
			}
		}

		private void FinalTurn()
		{
			Console.Clear();
			
			//Players that are not busted get their share of points, then all states get reset
			foreach (Player player in playersInRound)
			{
				player.DealScore(dealer);
			}

			PrintHands();

			foreach (Player player in playersInRound)
			{
				Console.WriteLine($"{player.Name} heeft {player.TotalMoneyWon} gewonnen!");
			}
		}

		private void PrintHands()
		{
			foreach (Player player in playersInRound)
			{
				Console.WriteLine(player);
			}
			Console.WriteLine(dealer);
		}

		private void CheckForBlackJack()
		{
			foreach (Player player in playersInRound)
			{
				foreach (Hand hand in player.Hands)
				{
					if (hand.TotalCardAmount == 21)
					{
						Console.WriteLine($"{player.Name} has BlackJack!");
						player.BlackJack();
					}
				}
				
			}
		}
	}
}
