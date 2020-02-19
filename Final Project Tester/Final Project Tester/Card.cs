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

        /// <summary>
        /// Returns a shallow copy of the object given
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        // Read only enumerator fields
        public readonly Suit suit;
        public readonly Rank rank;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="newSuit">Suit of the card being passed to the method</param>
        /// <param name="newRank">Rank of the card being passed to the method</param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        private Card()
        {

        }

        /// <summary>
        /// Returns a human readable string of the card
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        /// <summary>
        /// Overriding the less than operator
        /// </summary>
        /// <param name="left">The left card operand</param>
        /// <param name="right">The right card operand</param>
        /// <returns>bool</returns>
        public static bool operator <(Card left, Card right)
        {
            return (left.rank < right.rank);
        }

        /// <summary>
        /// Overriding the less than or equal to operator
        /// </summary>
        /// <param name="left">The left card operand</param>
        /// <param name="right">The right card operand</param>
        /// <returns>bool</returns>
        public static bool operator <=(Card left, Card right)
        {
            return (left < right || left.rank == right.rank);
        }

        /// <summary>
        /// Overriding the greater than operator
        /// </summary>
        /// <param name="left">The left card operand</param>
        /// <param name="right">The right card operand</param>
        /// <returns>bool</returns>
        public static bool operator >(Card left, Card right)
        {
            return !(left <= right);
        }

        /// <summary>
        /// Overriding the greater than than or equal to operator
        /// </summary>
        /// <param name="left">The left card operand</param>
        /// <param name="right">The right card operand</param>
        /// <returns>bool</returns>
        public static bool operator >=(Card left, Card right)
        {
            return !(left < right);
        }
    }
}

