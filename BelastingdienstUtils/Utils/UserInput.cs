namespace BlackJackCaseTraineeship.Utils
{
	public static class UserInput
	{
		public static string QuestionString(string question)
		{
			return QuestionString(question, false);
		}

		public static string QuestionString(string question, bool clearScreenBeforePrinting)
		{
			if (clearScreenBeforePrinting)
			{
				Console.Clear();
			}
			
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
			return QuestionInt(question, int.MinValue, int.MaxValue);
		}

		public static int QuestionInt(string question, int min, int max)
		{
			int? answer = null;
			while (answer == null || answer < min || answer > max)
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
