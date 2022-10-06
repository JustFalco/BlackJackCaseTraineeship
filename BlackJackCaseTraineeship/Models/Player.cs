namespace BlackJackCaseTraineeship.Models
{
	public class Player : Dealer
	{
		
		private string name;
		private double bet;
		private double totalBetAmound;


		public Player()
		{
			
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

		public double TotalBetAmound
		{
			get { return totalBetAmound; }
			set { totalBetAmound = value; }
		}

		public override string? ToString()
		{
			//TODO kan ingekort worden
			if (this.GetType() == typeof(Dealer))
			{
				if (this.Cards.Count == 0)
				{
					return $"Dealer has no cards!";
				}
				else
				{
					string returnString = $"Dealer has \n";
					foreach (Card card in this.Cards)
					{
						returnString = returnString + card.ToString() + "\n";
					}
					return returnString;
				}
			}
			else
			{
				string returnString = $"Speler {name} heeft: \n";

				foreach (Card card in Cards)
				{
					returnString = returnString + card + "\n";
				}

				return returnString;
			}
		}
	}
}
