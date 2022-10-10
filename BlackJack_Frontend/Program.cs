using BlackJack_BackEnd_Controllers;
using BlackJackCaseTraineeship.Utils;

namespace BlackJack_FrontEnd;

class Frontend
{
	private static string _uid;
	private static UserController _userController;
	private static GameController _gameController;

	static void Main(string[] args)
	{
		initializeControllers(new UserController(), new GameController());
		//Player logs on to the website
		Console.WriteLine("Welkom bij BlackJack!");
		string email = UserInput.QuestionString("Email");

		_uid = _userController.getUserUid(email);
		 
		//Player plays new game

	}

	static void initializeControllers(UserController userController, GameController gameController)
	{
		_userController = userController;
		_gameController = gameController;
	}
}