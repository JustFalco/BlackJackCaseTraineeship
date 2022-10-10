using BlackJack_BackEnd_Models;
using Utils;

namespace BlackJack_BackEnd_Controllers;

public class GameController
{
	public Game NewGame(Player player)
	{
		if (player == null)
		{
			throw new ArgumentNullException("player", "Player cannot be null");
		}

		Game newGame = new Game
		{
			Dealer = new Dealer(),
			Player = player,
			Cards = new CardDeck()
		};

		return newGame;
	}

	public Game PlayerPlayTurn(Decision decision, Game game)
	{
		throw new NotImplementedException();
	}
}