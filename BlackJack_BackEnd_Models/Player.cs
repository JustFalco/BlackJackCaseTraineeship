using Utils;

namespace BlackJack_BackEnd_Models;

public class Player : PersonInGame
{
	internal List<Hand> hands = new List<Hand>() { new Hand() };
	public string Email { get; set; }

	public override void Hit(Hand hand, Card card)
	{
		if (!hand.IsBustedHand && hand.LeastTotalAmount < 21)
		{
			hand.Add(card);
		}
		else
		{
			Bust();
			hand.BustHand();
		}

		if (hand.LeastTotalAmount > 21)
		{
			Bust();
			hand.BustHand();
		}
	}

	public override void Stand()
	{
		Bust();
	}

	public void Double(Hand hand, Card card)
	{
		if (hand.CanDouble())
		{
			hand.Add(card);
			Bust();
			hand.BustHand();
		}
	}

	public void Split(Hand hand, CardDeck cardDeck)
	{
		if (hand.CanSplit())
		{
			Hand newHand = new Hand();
			newHand.Add(hand.CardsInHand.Last());
			hand.CardsInHand.RemoveAt(1);

			newHand.Add(cardDeck.GetFirstActiveCardOnDeck());
			hand.Add(cardDeck.GetFirstActiveCardOnDeck());

			this.Hands.Add(newHand);
		}
	}

	public List<Hand> Hands
	{
		get
		{
			return this.hands;
		}
	}

	public Decision? MakeDecision(char input)
	{
		Decision? decision = null;

		switch (input)
		{
			case 'h':
				decision = Decision.HIT;
				break;
			case 's':
				decision = Decision.STAND;
				break;
			case 'd':
				decision = Decision.DOUBLE;
				break;
			case 'p':
				decision = Decision.SPLIT;
				break;
			default:
				decision = null;
				break;

		}

		return decision;
	}

	public override string ToString()
	{
		string returnString = $"Player {Email} has\n";
		foreach (Hand hand in hands)
		{
			returnString = returnString + hand;
		}
		return returnString;
	}

}