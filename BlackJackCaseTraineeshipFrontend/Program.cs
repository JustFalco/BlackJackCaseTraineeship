using BlackJackCaseTraineeship.Controllers;
using BlackJackCaseTraineeship.Utils;

namespace BlackJackCaseTraineeshipFrontend
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welkom bij BlackJack!");
			while (true)
			{
				switch (UserInput.QuestingChar("Nieuwe game: (y)es / (n)o"))
				{
					case 'y':
						new Game();
						break;
					case 'n':
						return;

				}
			}
			
		}
	}
}
