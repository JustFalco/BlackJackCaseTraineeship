namespace BlackJackCaseTraineeship.Models
{
	public class Dealer
	{
		private List<Hand> hands;
		private bool busted;

		public Dealer()
		{
			hands = new List<Hand>();
		}

		public List<Hand> Hands { get { return hands; } }

		public bool IsBusted
		{
			get
			{
				return busted;
			}
			set
			{
				busted = value;
			}
		}

		public void BustPlayer()
		{
			busted = true;
		}

		public void ClearHands()
		{
			hands.Clear();
		}

		public override string? ToString()
		{
			string returnString = "";
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

			return returnString;
		}
	}
}
