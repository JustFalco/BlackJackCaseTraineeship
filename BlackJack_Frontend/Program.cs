using BlackJack_BackEnd_Controllers;
using BlackJack_BackEnd_Models;
using BlackJackCaseTraineeship.Utils;
using Utils;

namespace BlackJack_FrontEnd;

class Frontend
{
	private static Player player;
	private static UserController _userController;
	private static GameController _gameController;
	private static Game game;
	static void Main(string[] args)
	{
		initializeControllers(new UserController(), new GameController());
		//Player logs on to the website
		Console.WriteLine("Welkom bij BlackJack!");
		string email = UserInput.QuestionString("Email");

		player = _userController.GetPlayer(email);
		 
		//Player plays new game
		game = _gameController.NewGame(player);

		while (game.IsActiveGame)
		{
			switch (_gameController.NextTurn(game))
			{
				case null:
					throw new ArgumentNullException("game", "Could not pick a turn to return");
				case TurnTypes.DEALALLTURN:
					_gameController.DealAllTurn(game, _userController);
					break;
				case TurnTypes.PLAYERTURN:
					PlayerTurnScreen(game);
					break;
				case TurnTypes.DEALERTURN:
					DealerTurnScreen(game);
					break;
				case TurnTypes.FINALTURNS:
					
					FinalScoreScreen(game);
					game.IsActiveGame = false;
					Thread.Sleep(2000);
					return;
			}
		}
	}

	public static void ShowHandsScreen()
	{
		Console.Clear();
		Console.WriteLine(game);
	}

	public static void PlayerTurnScreen(Game game)
	{
		Console.Clear();
		Console.WriteLine($"{game.Player.Email} turn");
		ShowHandsScreen();
		Decision? decision = null;

		while (decision == null)
		{
			decision = game.Player.MakeDecision(UserInput.QuestingChar($"{player.Email}: (h)it / (s)tay / (d)ouble / s(p)lit"));
		}

		Decision finalDecision = (Decision)decision;
		_gameController.PlayerPlayTurn(finalDecision, game, _userController);
	}

	public static void DealerTurnScreen(Game game)
	{
		Console.Clear();
		Console.WriteLine("Dealer turn");
		_gameController.DealerPlayTurn(game);
	}

	public static void FinalScoreScreen(Game game)
	{
		Console.Clear();
		ShowHandsScreen();
		Console.WriteLine(_gameController.CheckWinner(game, _userController));
	}

	static void initializeControllers(UserController userController, GameController gameController)
	{
		_userController = userController;
		_gameController = gameController;
	}
}