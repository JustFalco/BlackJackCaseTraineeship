using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Models
{
	public class Dealer : Player
	{
		public override string? ToString()
		{
			if(this.Cards.Count == 0)
			{
				return $"Dealer has no cards!";
			}
			else if (this.Cards.Count == 1)
			{
				return $"Dealer has {this.Cards.First()}";
			}
			else if (this.Cards.Count > 1)
			{
				return $"Dealer has {this.Cards.First()} and secret cards";
			}
			else
			{
				return "Unknown";
			}
		}
	}
}
