using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Views
{
	public static class Menus
	{
		public static void MainMenu()
		{
			Console.WriteLine("Welkom bij BlackJack!");
		}

		public static void HitStay(string name)
		{
			Console.WriteLine($"{name} maak uw keuze: (h)it / (s)tay");
			
		}
	}
}
