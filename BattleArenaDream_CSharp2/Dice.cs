using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArenaDream_CSharp2
{
    class Dice// roll the dice to play the game
    {
        // variables
        // "readonly indicates that an instance member doesn't modify the state of the structure."
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
        private readonly Random random = new Random();
        private int diceRoll; // should be rolled before referenced

        public Dice()  // for good measure
        {
            diceRoll = 0;
        } 

        // roll the dice
        public void RollDice()
        {
            diceRoll = random.Next(1, 7);
            //diceRoll = 5;
        }

        // getters and setters
        // TODO See if there's a way to generate getts and setters like in Eclipse
        //public int DiceRoll { get; set; } // there's a shortcut for C# - this is the shortest one
        // (the above didn't work correctly for some reason - the internet lied or I didn't do it right)
        public int GetDiceRoll() // using the recommended syntax
        {
            return diceRoll;
        }

        public void SetDiceRoll(int diceRoll)
        {
            this.diceRoll = diceRoll;
        }

    }
}
