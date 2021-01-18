using System;

namespace BattleArenaDream_CSharp2
{
	class Program
	{

		// I re-typed most of the code that is the same as in the Java program, only a few things were 
		// copy and paste like comments and a couple arrays. I did this for the sake of memorization
		static void Main(string[] args)
		{
			// notes for reference
			// Console.Read();
			// Console.WriteLine($"My age is {myAge}. Your age is {yourAge}.");
			// \r means a carriage return - moves cursor to the very far left

			// variables
			Random random = new Random();
			string[] diceFronts = new string[]
			{// To get the circles lined perfectly, they would be too large.
				" _________ \n"				// This is good for now. (Java didn't want to accept an overline char.)
			  + "|         |\n"
			  + "|         |\n"
			  + "|    O    |\n"
			  + "|         |\n"
			  + "|_________|",
			  			" _________ \n"
					  + "|         |\n"
					  + "| O       |\n"
					  + "|         |\n"
					  + "|       O |\n"
					  + "|_________|",
								" _________ \n"
							  + "|         |\n"
							  + "| O       |\n"
							  + "|    O    |\n"
							  + "|       O |\n"
							  + "|_________|",
							  			" _________ \n"
									  + "|         |\n"
									  + "| O     O |\n"
									  + "|         |\n"
									  + "| O     O |\n"
									  + "|_________|",
									  			" _________ \n"
											  + "|         |\n"
											  + "| O     O |\n"
											  + "|    O    |\n"
											  + "| O     O |\n"
											  + "|_________|",
											  			" _________ \n"
													  + "|         |\n"
													  + "| O     O |\n"
													  + "| O     O |\n"
													  + "| O     O |\n"
													  + "|_________|",};
			string[] endings = new string[]
			{"...Will this ever end?", "Is fighting your purpose in life?",
				"An existential crisis sets in as you wonder why this won't end.",
				"Why does he bring you back to die again?\nYou're getting too deep so you shake yourself out of it.",
				"If this is a dream, it's more like a nightmare.", "Does he expect you to do this all on your own?",
				"If he has so much power, why are you the one fighting?",
				"You ask, \"Hey, could I get some help?\" The grim reaper shakes his head.",
				"How many enemies must you defeat? How many lives must you live?",
				"You wonder if you'll get a prize at some point.",
				"You tell him that you're more of a philosopher than a fighter, but the grim reaper shrugs.",
				"\"What happens if I refuse to kill more?\", you ask."
				+ "\n\"You die,\" he replies. \"Oh...\" You let out a sigh."};

			// Intro title
			Console.WriteLine(" __       ___ ___       ___          __   ___           \r\n" +
					"|__)  /\\   |   |  |    |__      /\\  |__) |__  |\\ |  /\\  \r\n" +
					"|__) /~~\\  |   |  |___ |___    /~~\\ |  \\ |___ | \\| /~~\\ \n");
			Console.WriteLine("You open your eyes to see a sword in one hand and a shield in the other. You hear cheering.");
			Console.WriteLine("How strange, you look around to see you are standing in an arena with no crowd.");
			Console.WriteLine("\nIs this real life or a dream?");

			Console.WriteLine("Test");

			// The dream runs an infinite loop so the user must close the app in order to exit.
			while (true)
			{

				// start a new round

				// set the variables
				int turns = 10;
				Player player = new Player(); // the user's stats
				Enemy enemy = new Enemy(); // the current enemy
				Dice dice = new Dice(); // dice to roll
				string death = "\nYou have been killed!"; // this is the default unless panic increases to 20

				// this loop will go as long as user has not died and they are not out of turns
				while (player.IsAlive() == true)
				{
					ShowStats(player, enemy, turns); // show the stats

					// see if enemy has been defeated, replace it with a new one if it's dead
					// putting it here so that the player can see the enemy HP go to 0
					if (!enemy.IsAlive())
					{
						Console.WriteLine("\nThe enemy falls to its death!\nA gate rumbles opens to reveal another menacing goblin." +
							"\n...How many must you kill before this ends?");
						enemy = new Enemy();
					}

					// put a pause so the player can read what's happening
					if (turns == 10)
					{
						// only show this on first turn
						Console.WriteLine("\nAn angry goblin in armor stands before you.\n(Hit enter to roll for an attack.)");
					}
					else
					{
						Console.WriteLine($"\nYou have {turns} turns left.\n(Hit enter to roll for an attack.)");
					}
					Console.ReadLine(); // this is like printLine in Java

					// roll the dice
					dice.RollDice();
					// display results
					//Console.WriteLine(dice.getDiceRoll()); // test
					Console.WriteLine($"{diceFronts[dice.GetDiceRoll() - 1]}\n");

					// check outcome
					GetOutcome(player, enemy, dice);

					// subtract from turns
					turns--;

					// check if they ran out of turns, if so set the panic to 20
					if (turns <= 0 && player.Stamina != 0)
					{
						player.Panic = 20;
						Console.WriteLine("\nThis has gone on too long! Your panic increases to 20!");
						death = "\nYou die of a heart attack! Where's the doctor?";
					}


				}
				// show player stats
				ShowStats(player, enemy, turns);

				// once the user has died, tell the player they have died and to start everything over
				Console.WriteLine(death); // tells them the cause of death
				Console.WriteLine("Suddenly, the grim reaper appears to bring you back to life.");
				Console.WriteLine($"\n{ endings[random.Next(0, endings.Length - 1)]}");

				Console.WriteLine("\n(Hit enter to continue.)");
				Console.ReadLine();

				Console.WriteLine("You must fight!");

			}

		}

		// Methods for the game

		// Show player's stats
		public static void ShowStats(Player player, Enemy enemy, int turns)
		{
			if (turns == 10) // only on first turn
			{
				Console.WriteLine("\n*Your Stats*");
			}
			else
			{
				Console.WriteLine("\n*New Stats*");
			}
			Console.WriteLine($"Stamina: {player.Stamina}"); // new trick in C# but not Java - try to remember this
			Console.WriteLine($"Panic Level: {player.Panic}");
			Console.WriteLine($"Enemy HP: {enemy.Hp}");
		}

		// Get the outcome of a dice roll
		public static void GetOutcome(Player player, Enemy enemy, Dice dice)
		{
			// determine the outcome by what the player rolled
			int diceRoll = dice.GetDiceRoll();

			switch (diceRoll)
			{
				case 1:
					Console.WriteLine("The enemy smirks as he taunts you. He seeks to intimidate."
							+ "\nIt works. Your panic increases by 2.");
					player.Panic += 2;
					break;
				case 2:
					Console.WriteLine("The enemy attacks! You dodge, but he strikes anyway!\nYour stamina " +
							"decreases by 1.");
					player.Stamina -= 1;
					break;
				case 3:
					Console.WriteLine("The enemy strikes, but you block the attack!\nNothing else happens.");
					break;
				case 4:
					Console.WriteLine("You let out a beastly growl. The enemy backs away!\nYour stamina increases by 1.");
					player.Stamina += 1;
					break;
				case 5:
					Console.WriteLine("You swing your sword. The enemy dodges, but you strike anyway!" +
							"\nYour panic reduces by 1. The enemy loses 3 hit points.");
					player.Panic -= 1;
					enemy.Hp -= 3;
					break;
				case 6:
					Console.WriteLine("*THWACK* You swing fast to strike a critical blow with your sword!" +
							"\nYour panic reduces by 3. Your stamina increases by 2. The enemy loses 5 hit points.");
					player.Panic -= 3;
					player.Stamina += 2;
					enemy.Hp -= 5;
					break;
				default:
					Console.WriteLine("ERROR - not a number 1 through 6");
					break;
			}
		}
	}
}
