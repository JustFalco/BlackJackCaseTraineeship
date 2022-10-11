using System.Net.Http.Headers;
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
			Cards = new CardDeck(),
			IsActiveGame = true
		};

		return newGame;
	}

	public TurnTypes? NextTurn(Game game)
	{
		if (game == null)
		{
			throw new ArgumentNullException(nameof(game), "One or more objects in game are null");
		}
		// || game.Player == null || game.Cards == null || game.Dealer == null
		if (game.Player.Hands.Count == 1 && game.Player.Hands.First().CardsInHand.Count == 0 && !game.Player.IsBusted)
		{
			return TurnTypes.DEALALLTURN;
		}
		if (!game.Player.IsBusted && !game.Dealer.IsBusted)
		{
			return TurnTypes.PLAYERTURN;
		}
		if (game.Player.IsBusted && !game.Dealer.IsBusted)
		{
			return TurnTypes.DEALERTURN;
		}
		if (game.Dealer.IsBusted || game.Dealer.GetScore >= 17)
		{
			return TurnTypes.FINALTURNS;
		}
		
		return null;
		
	}

	public Game DealAllTurn(Game game, UserController userController)
	{
		userController.PlayerDrawHand(game);
		userController.DealerDrawHand(game);
		return game;
	}

	public Game DealerPlayTurn(Game game)
	{
		while (!game.Dealer.Hand.IsBustedHand)
		{
			game.Dealer.Hit(game.Dealer.Hand, game.Cards.GetFirstActiveCardOnDeck());
		}
		game.Dealer.RevealAllCards();
		return game;
	}

	//TODO give player instead of game
	public Game PlayerPlayTurn(Decision decision, Game game, UserController userController)
	{
		userController.PlayTurn(decision, game);
		return game;
	}

	public string CheckWinner(Game game, UserController userController)
	{
		string winnerString = "Speler heeft met:\n";
		int count = 1;
		foreach (Hand hand in game.Player.Hands)
		{
			if (userController.CheckIfPlayerHandWonFromDealerHand(hand, game.Dealer))
			{
				winnerString = winnerString + $"\thand {count} gewonnen van dealer\n";
			}
			else
			{
				winnerString = winnerString + $"\thand {count} verloren van dealer\n";
			}

			count++;
		}

		return winnerString;
	}
}