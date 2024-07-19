namespace Deliverable2
{
	internal class Program
	{
		private static string Username = "";
		private static int score = 0;
		private static readonly Random random = new();
		private static readonly string[] losingInsults = [
			"", " Hm, roast {0} DOES sound nice.", " As if you could ever win...", " This is hardly a competition, is it?", 
			" I look forward to your humiliating defeat, {0}"
		];
		private static readonly string[] winningInsults = [
			"", " How can this be?", " BAH! Simple beginner's luck.", " Are you cheating?!", " A {0} couldn't POSSIBLY be able to see the future...",
			" That's not supposed to happen."
		];
		private static readonly string[] outcomes = [
			"You didn't guess correctly EVEN ONCE? {0}, you are TRULY PATHETIC. I almost feel bad for you.", 
			"I KNEW you could never hope to stand against me {0}!", "ONCE AGAIN, glorious victory is MINE!", 
			"That's HARDLY better than 50/50. {0} The Lucky, they should call you.", "How, {0}? HOW did you DO IT?", 
			"NO! I'M supposed to WIN! NOT YOU! HOW DARE YOU!"
		];

		static void Main(string[] args)
		{
			Console.WriteLine("Greetings, pathetic mortal. What is your name?");
			Username = Console.ReadLine()?.Trim() ?? "";
			Username = char.ToUpper(Username[0]) + Username[1..];
			Console.WriteLine($"Okay, {Username}. Will you take THE COIN FLIP CHALLENGE?");
			Console.WriteLine("[Y]es or [N]o?");
			Console.WriteLine();

			if (!GetYesNo())
			{
				Console.WriteLine($"HA! You shall be known as {Username} The Coward! But of course, mere flesh and bone could never win!");
				WaitForExit();
				return;
			}

			Console.WriteLine($"EXCELLENT! The defeat of {Username} will be a battle for the ages!");
			Console.WriteLine($"I will flip a coin FIVE TIMES, and you, {Username}, shall attempt to peer beyond the weave of fate and correctly guess WHICH SIDE the coin lands upon!");
			Console.WriteLine("Let us begin");
			Console.WriteLine();

			score = 0;

			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("HEADS OR TAILS?");
				bool headsUp = random.Next(2) is not 0;

				if (GetGuessedHeads() == headsUp)
				{
					score++;
					Console.WriteLine("You guessed correctly?" + Insult(winningInsults));
				}
				else
				{
					Console.WriteLine("WRONG!" + Insult(losingInsults));
				}
				Console.WriteLine();
			}

			Console.WriteLine($"You guessed {score} out of 5 correctly! {string.Format(outcomes[score], Username)}");
			WaitForExit();
		}

		static void WaitForExit()
		{
			Console.WriteLine();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		static string Insult(string[] insults)
			=> string.Format(insults[random.Next(insults.Length)], Username);

		static bool GetGuessedHeads()
		{
			while (true)
			{
				var line = Console.ReadLine()!.Trim();
				if (line.Equals("heads", StringComparison.OrdinalIgnoreCase))
					return true;
				if (line.Equals("tails", StringComparison.OrdinalIgnoreCase))
					return false;
			}
		}

		static bool GetYesNo()
		{
			while (true)
			{
				var key = Console.ReadKey();
				Console.Write("\b\\\b");
				switch (key.KeyChar)
				{
					case 'Y' or 'y':
						return true;
					case 'N' or 'n' or '\x1b':
						return false;
				}
			}
		}
	}
}
