using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    /// <summary>
    /// Card class that will be a specific card within a deck
    /// </summary>
    public class Card : ICloneable
    {
        // Returns a shallow copy of the object
        public object Clone()
        {
            return MemberwiseClone();
        }

        public readonly Suit suit;
        public readonly Rank rank;

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        private Card()
        {
        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}

