using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCaseTraineeship.Utils
{
	public static class UserInput
	{
		public static string QuestionString(string question)
		{
			Console.WriteLine($"{question}?");
			string? answer = null;
			while (answer == null)
			{
				answer = Console.ReadLine();
			};
			return answer;
		}

		public static int QuestionInt(string question)
		{
			int? answer = null;
			while (answer == null)
			{
				var str = QuestionString(question);
				if (int.TryParse(str, out int a))
				{
					answer = a;
				}
			}
			return answer.Value;
		}

		public static char QuestingChar(string question)
		{
			char? answer = null;
			while (answer == null)
			{
				var str = QuestionString(question);
				if (char.TryParse(str, out char a))
				{
					answer = a;
				}
			}
			return answer.Value;
		}
	}
}
