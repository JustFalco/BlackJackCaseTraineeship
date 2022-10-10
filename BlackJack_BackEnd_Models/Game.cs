namespace BlackJack_BackEnd_Models;

public class Game
{
	private Dealer dealer;
	private Player player;
	private CardDeck cards;

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
}