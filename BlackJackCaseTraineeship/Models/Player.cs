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
		private double bet;
		private int totalBetAmound;
		private bool busted;

		public Player()
		{
			cardsInHand = new List<Card>();
		}

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

		public double Bet
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
			string returnString = $"Speler {name} heeft: \n";

			foreach(Card card in cardsInHand)
			{
				returnString = returnString + card + "\n";
			}

			return returnString;
		}
	}
}
