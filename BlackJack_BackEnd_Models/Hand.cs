namespace BlackJack_BackEnd_Models;

public class Hand
{
	private List<Card> cardsInHand;
	private bool isBustedHand;

	public Hand()
	{
		cardsInHand = new List<Card>();
	}

	public bool IsBustedHand
	{
		get
		{
			return isBustedHand;
		}
		set
		{
			isBustedHand = value;
		}
	}

	public void BustHand()
	{
		isBustedHand = true;
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

	public int HighestTotalAmound
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
			
			if (hasAce)
			{
				amount += 10;
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

			
			if (hasAce)
			{
				if ((amount + 10) <= 21)
				{
					amount += 10;
				}
			}
			

			return amount;
		}
	}

	public List<Card> CardsInHand
	{
		get
		{
			return cardsInHand;
		}
	}

	public void Add(Card card)
	{
		cardsInHand.Add(card);
	}

	public bool CanSplit()
	{
		return cardsInHand.Count == 2 && cardsInHand.First().Value == cardsInHand.Last().Value;
	}

	public bool CanDouble()
	{
		return this.CardsInHand.Count == 2 && this.TotalCardAmount <= 11;
	}

	public bool HasBlackJack()
	{
		return this.TotalCardAmount == 21;
	}

	public override string ToString()
	{
		string returnString = "\tHand has\n";

		foreach (Card card in cardsInHand)
		{
			returnString = returnString + "\t\t" + card + "\n";
		}

		return returnString;
	}
}