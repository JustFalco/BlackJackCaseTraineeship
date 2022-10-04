using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Models
{
	public class Player
	{
		private List<Card> cardsInHand;
		private string name;
		private int bet;
		private int totalBetAmound;

		public Player()
		{
			cardsInHand = new List<Card>();
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public List<Card> Cards { get { return cardsInHand; } }

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
				foreach (Card card in cardsInHand)
				{
					if(card.Value == 1)
					{
						hasAce = true;
					}
					amount += card.Value;
				}
				if (hasAce)
				{
					if((amount + 10) <= 21)
					{
						amount += 10;
					}
				}
				return amount;
			}
		}

		public int Bet
		{
			get
			{
				return bet;
			}
			set
			{
				bet = value;
			}
		}

		public override string? ToString()
		{
			string returnString = $"Speler {name} heeft: ";

			foreach(Card card in cardsInHand)
			{
				returnString = returnString + "\n" + card;
			}

			return returnString;
		}
	}
}
