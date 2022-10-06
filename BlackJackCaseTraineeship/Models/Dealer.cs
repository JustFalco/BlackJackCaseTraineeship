using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Models
{
	public class Dealer : Player
	{

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
				if (hasAce)
				{
					amount += 10;
				}
				return amount;
			}
		}

		public override string? ToString()
		{
			if(this.Cards.Count == 0)
			{
				return $"Dealer has no cards!";
			}
			else
			{
				string returnString = $"Dealer has \n";
				foreach(Card card in this.Cards)
				{
					returnString = returnString + card.ToString() + "\n";
				}
				return returnString;
			}
			
		}
	}
}
