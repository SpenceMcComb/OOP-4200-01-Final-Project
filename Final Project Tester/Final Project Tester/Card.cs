using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    /// <summary>
    /// Card class that will be a specific card within a deck
    /// </summary>
    public class Card
    {
        // Readonly properties for the card
        public readonly Suit mySuit;
        public readonly Rank myRank;

        // Default constructor
        private Card()
        {
            
        }

        // Parameterized constructor that will take the suit and which rank the new card is
        public Card(Suit newSuit, Rank newRank)
        {
            mySuit = newSuit;
            myRank = newRank;
        }

        /// <summary>
        /// Converts the cards values into a readable string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return "The " + myRank + " of " + mySuit + "s.";
        }


    }
}
