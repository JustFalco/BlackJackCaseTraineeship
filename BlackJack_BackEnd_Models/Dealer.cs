namespace BlackJack_BackEnd_Models;

public class Dealer : PersonInGame
{
	private Hand hand;

	public Dealer()
	{
		hand = new Hand();
	}

	public Hand Hand
	{
		get
		{
			return hand;
		}
		set
		{
			hand = value;
		}
	}

	public override string ToString()
	{
		string returnString = $"Dealer has\n";
		returnString = returnString + hand;
		return returnString;
	}

	public override void Hit(Hand hand, Card card)
	{
		if (!IsBusted && hand.HighestTotalAmound < 17)
		{
			hand.Add(card);
		}
		else
		{
			Bust();
		}

		if (hand.HighestTotalAmound > 21)
		{
			Bust();
		}
	}
	
	public override void Stand()
	{
		Bust();
	}

	public void RevealAllCards()
	{
		foreach (Card card in Hand.CardsInHand)
		{
			card.IsHidden = false;
		}
	}
}