using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArenaDream_CSharp2
{
    // holds the player information
    class Player
    {
        private int stamina = 10; // starts at 10, it it reaches 0 the user dies
        private int panic = 10; // starts at 10, if it reaches 20 the user dies

        public Player() { } // for good measure

        // methods

        // check if the user is alive
        public bool IsAlive()
        {
            if (stamina > 0 && panic < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // getters and setters - using new shortcut
        public int Stamina
        {
            get { return stamina; }
            set { if (value < 0) { stamina = 0; } else { stamina = value; } } // if it's less than 0, set it to 0
                                                                              // otherwise leave it as it is
        }

        public int Panic
        {
            get { return panic; }
            set
            {
                // if (value > 20) { panic = 20; } else      // if it's greater than 20, set it to 20 - not necessary
                if (value < 0) { panic = 0; }          // or if it's less than 0, set it to 0
                else { panic = value; }
            }               // otherwise leave it as it is                                        
        }

    }
}
