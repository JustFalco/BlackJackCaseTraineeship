namespace BlackJackCaseTraineeship.Models
{
	public class Dealer
	{
		private List<Card> cardsInHand;
		private bool busted;

		public Dealer()
		{
			cardsInHand = new List<Card>();
		}

		public List<Card> Cards { get { return cardsInHand; } }

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

		public void AddCard(Card card)
		{
			cardsInHand.Add(card);
		}

		public void ClearHand()
		{
			cardsInHand.Clear();
		}

		public int TotalCardAmount
		{
			get
			{
				int amount = 0;
				bool hasAce = false;
				foreach (Card card in Cards)
				{
					if (card.Value == 1)
					{
						hasAce = true;
					}
					amount += card.Value;
				}

				if (this.GetType() == typeof(Dealer))
				{
					if (hasAce)
					{
						amount += 10;
					}
				}
				else
				{
					if (hasAce)
					{
						if ((amount + 10) <= 21)
						{
							amount += 10;
						}
					}
				}
				
				return amount;
			}
		}
	}
}
