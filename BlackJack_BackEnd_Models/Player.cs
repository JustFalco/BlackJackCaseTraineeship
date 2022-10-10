using Utils;

namespace BlackJack_BackEnd_Models;

public class Player : PersonInGame
{
	internal List<Hand> hands = new List<Hand>() { new Hand() };
	public string Email { get; set; }

	public override void Hit(Hand hand, Card card)
	{
		if (!IsBusted && hand.LeastTotalAmount < 21)
		{
			hand.Add(card);
		}
		else
		{
			Bust();
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

	public void Double()
	{

	}

	public void Split()
	{

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
			case 'b':
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