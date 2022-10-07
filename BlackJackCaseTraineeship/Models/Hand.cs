using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Models
{
	public class Hand
	{
		private List<Card> cardsInHand;

		public List<Card> CardsInHand
		{
			get
			{
				if (cardsInHand == null)
				{
					cardsInHand = new List<Card>();
				}
				return cardsInHand; 

			}
			set
			{
				cardsInHand = value;
			}
		}

		public void AddCartToHand(Card card)
		{
			if (cardsInHand == null)
			{
				cardsInHand = new List<Card>();
			}
			cardsInHand.Add(card);
		}

		public void ClearHand()
		{
			cardsInHand.Clear();
		}

		public int LeastTotalAmount
		{
			get
			{
				//TODO testen met 2 aces
				//TODO make method
				int amount = 0;
				bool hasAce = false;

				foreach (Card card in cardsInHand)
				{
					if (card.Value == 1)
					{
						hasAce = true;
					}
					amount += card.Value;
				}



				//Ace on dealer is always 11
				if (this.GetType() == typeof(Dealer))
				{
					if (hasAce)
					{
						amount += 10;
					}
				}


				return amount;
			}
		}

		public int TotalCardAmount
		{
			get
			{
				int amount = 0;
				bool hasAce = false;
				foreach (Card card in cardsInHand)
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
