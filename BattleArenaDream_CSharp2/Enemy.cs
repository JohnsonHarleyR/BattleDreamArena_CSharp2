using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArenaDream_CSharp2
{
    class Enemy
    {
        // variables
        private int hp = 10;  // the enemy starts with 10 hp, if it reaches 0 it dies

        public Enemy() { } // for good measure

        // methods

        // check if enemy is alive
        public bool IsAlive()
        {
            if (hp <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // getters and setters
        // using shortcut
        public int Hp
        {
            get { return hp; } // there's an example online where you can do it like this: 
                               // "public int MyVal { get; set { _myVal = value; myOtherVal++; } }"
                               // but when I tested it out, it wanted me to type out both
            set { if (value < 20) { hp = 0; } else { hp = value; } } // if hp is less than 0, set it to 0
        }

    }
}
