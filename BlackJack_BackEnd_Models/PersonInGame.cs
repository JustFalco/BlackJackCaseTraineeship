using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_BackEnd_Models
{
	public abstract class PersonInGame
	{
		
		private bool isBusted;
		private int score;

		public int GetScore
		{
			get
			{
				return score;
			}
			set
			{
				score = value;
			}
		}

		public bool IsBusted
		{
			get
			{
				return isBusted;
			}
			set
			{
				isBusted = value;
			}
		}

		public void GrabHand()
		{

		}

		public abstract void Hit(Hand hand, Card card);

		public abstract void Stand();

		public void Bust()
		{
			isBusted = true;
		}

		public void DrawCard(Hand hand, CardDeck cards, bool IsVisibleCard)
		{
			Card card = cards.GetFirstActiveCardOnDeck();
			card.IsHidden = !IsVisibleCard;
			hand.Add(card);
		}
	}
}
