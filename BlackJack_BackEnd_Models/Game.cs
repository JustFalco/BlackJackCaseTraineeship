namespace BlackJack_BackEnd_Models;

public class Game
{
	private Dealer dealer;
	private Player player;
	private CardDeck cards;
	private bool isActiveGame;

	public Dealer Dealer
	{
		get
		{
			return dealer;
		}
		set
		{
			dealer = value;
		}
	}

	public Player Player
	{
		get
		{
			return player;
		}
		set
		{
			player = value;
		}
	}

	public CardDeck Cards
	{
		get
		{
			return cards;
		}
		set
		{
			cards = value;
		}
	}

	public bool IsActiveGame
	{
		get
		{
			return isActiveGame;
		}
		set
		{
			isActiveGame = value;
		}
	}

	public override string ToString()
	{
		string returnString = player + "\n" + dealer;
		return returnString;
	}
}