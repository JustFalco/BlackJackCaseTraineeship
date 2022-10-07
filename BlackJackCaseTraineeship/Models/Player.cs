namespace BlackJackCaseTraineeship.Models
{
	public class Player : Dealer
	{
		
		private string name;
		private double bet;
		private double totalMoneyWon;
		private bool playerHasBlackJack;

		public Player()
		{
			
		}

		public bool PlayerCanSplit(Hand hand)
		{
			if (hand.CardsInHand.Count == 2)
			{
				return hand.CardsInHand.First().Value == hand.CardsInHand.Last().Value;
			}

			return false;
		}

		public string Name
		{
			get { return name; } 
			set { name = value; }
		}

		public double Bet
		{
			get { return bet; }
			set { bet = value; }
		}

		public double TotalMoneyWon
		{
			get { return totalMoneyWon; }
		}

		public void DealScore(Dealer dealer)
		{
			foreach (Hand hand in this.Hands)
			{
				if (this.IsBusted)
				{
					this.totalMoneyWon = 0;
				}
				else if (dealer.IsBusted)
				{
					this.totalMoneyWon = this.bet * 2;
				}
				else if (hand.TotalCardAmount > dealer.Hands.First().TotalCardAmount)
				{
					this.totalMoneyWon = this.bet * 2;
				}
			}
			
		}

		public void BlackJack()
		{
			playerHasBlackJack = true;
			totalMoneyWon = bet + (bet * 1.5);
			BustPlayer();
		}

		//TODO OOP
		public override string? ToString()
		{
			string returnString = "";
			if (this.GetType() == typeof(Dealer))
			{
				if (this.Hands.First().CardsInHand.Count == 0)
				{
					returnString = "Dealer has no cards!";
				}
				else
				{
					returnString = $"Dealer has \n";
					foreach (Card card in this.Hands.First().CardsInHand)
					{
						returnString = returnString + card.ToString() + "\n";
					}
					returnString = returnString + $"Totaal: {(IsBusted ? "busted" : this.Hands.First().TotalCardAmount)}\n";
				}
			}
			else
			{
				returnString = $"Speler {name} heeft: \n";

				foreach (Hand hand in Hands)
				{
					returnString = returnString + "Hand: \n";
					foreach (Card card in hand.CardsInHand)
					{
						returnString = returnString + card + "\n";
					}
					returnString = returnString + $"Totaal: {(IsBusted ? "busted" : hand.TotalCardAmount)}\n";
				}
				
			}

			

			return returnString;
		}
	}
}
