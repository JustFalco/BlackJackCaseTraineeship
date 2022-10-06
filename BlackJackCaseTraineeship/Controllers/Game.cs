using BlackJackCaseTraineeship.Models;
using BlackJackCaseTraineeship.Utils;
using BlackJackCaseTraineeship.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Controllers
{
	public class Game
	{
		GameController controller;
		bool IsGameActive = true;

		public Game(GameController controller)
		{
			this.controller = controller;

			Menus.MainMenu();
			int amoundOfPlayers = UserInput.QuestionInt("Met hoeveel spelers wilt u spelen");
			controller.addPlayers(amoundOfPlayers);
			controller.PlaceBets();
			while (IsGameActive)
			{
				controller.DealRound();
				Console.Clear();
				controller.PrintHands();
				Console.ReadLine();
				controller.DealRound();
				Console.Clear();
				controller.PrintHands();

				controller.CheckForPlayerWinAfterDealingCards();

				Console.ReadLine();


				foreach (Player currentPlayer in controller.playersInRound)
				{
					bool stay = false;

					if (currentPlayer.IsBusted)
					{
						continue;
					}

					while (!stay)
					{

						switch (UserInput.QuestingChar($"{currentPlayer.Name} maak uw keuze: (h)it / (s)tay"))
						{
							case 'h':
								Console.Clear();
								Console.WriteLine("Hit");
								controller.DealPlayer(currentPlayer);
								controller.PrintHands();
								if (currentPlayer.TotalCardAmount > 21)
								{
									Console.WriteLine($"{currentPlayer.Name} busted!");
									controller.BustPlayerFromRound(currentPlayer);
									stay = true;
									continue;
								}
								break;
							case 's':
								Console.WriteLine("Stay");
								stay = true;
								break;
						}
					}


				}


				controller.DealerCardCheck();
				controller.CheckScores();
				Console.Clear();
				controller.PrintHands();
				controller.PrintScores();

				switch (UserInput.QuestingChar("Nog een ronde: (y)es / (n)o"))
				{
					case 'y':
						controller.ClearHands();
						controller.index = 0;
						break;
					case 'n':
						IsGameActive = false;
						Console.WriteLine("Bedankt voor het spelen!");
						return;
				}
			}
			
			
		}


	}
}
