using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public class Card
    {
        public readonly Suit mySuit;
        public readonly Rank myRank;

        // Default constructor
        Card()
        {
            
        }

        // Parameterized constructor
        Card(Suit newSuit, Rank newRank)
        {
            mySuit = newSuit;
            myRank = newRank;
        }

        public override string ToString()
        {
            return "The " + myRank + " of " + mySuit + "s.";
        }


    }
}
