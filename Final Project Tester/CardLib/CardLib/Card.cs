using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Card.cs - A class defining the Card object. Implements 
 * the ICloneable interface.
 *
 * Author: Spence McComb - 100426427
 * Since: 2020/02/14
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardLib
{
    public class Card : ICloneable
    {
        // Flag for trump usage. If true, trumps are valued higher than other suits
        public static bool useTrumps = false;

        // Set the default trump suit if useTrumps is true
        public static Suit trump = Suit.Club;

        // Indicates whether aces are considered high value or low
        public static bool isAceHigh = true;

        // Returns a shallow copy of the object
        public object Clone()
        {
            return MemberwiseClone();
        }

        /*
         * OPERATOR OVERLOADS
         */

        // Equality operator
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit && card1.rank == card2.rank);
        }

        // Inequality operator
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        // Another equality check
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        // Used for comparing cards
        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        // Determines if a card is superior than another
        public static bool operator >(Card card1, Card card2)
        {
            // The end result to return
            bool theResult;

            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace) // Card 1 may be greater
                    {
                        if (card2.rank == Rank.Ace) // They are both aces
                        {
                            theResult = false;
                        }
                        else
                        {
                            theResult = true;
                        }
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace) // Card 2 will be greater
                        {
                            theResult = false;
                        }
                        else // Neither are aces
                        {
                            // Compare the ranks other than ace
                            theResult = (card1.rank > card2.rank);
                        }
                    }
                }
                else // Aces low
                {
                    // Compare the cards normally
                    theResult = (card1.rank > card2.rank);
                }
            }
            else // Suits are not equal
            {
                // Card 2 is a trump card
                if (useTrumps && (card2.suit == Card.trump))
                {
                    theResult = false;
                }
                else // Any other situation
                {
                    theResult = true;
                }
            }

            return theResult;
        }

        // Determines if a card is inferior to another
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        // Determines if a card is equivalent or of greater value than another
        public static bool operator >=(Card card1, Card card2)
        {
            bool theResult;

            if (card1.suit == card2.suit) // Trump need not be considered
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace) // The highest possible card of the same suit
                    {
                        theResult = true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                        {
                            theResult = false;
                        }
                        else // The ranking can be determined by card rank alone
                        {
                            theResult = (card1.rank >= card2.rank);
                        }

                    }
                }
                else // No need to consider aces high or trump suit
                {
                    theResult = (card1.rank >= card2.rank);
                }
            }
            else // Different suits
            {
                if (useTrumps && (card2.suit == Card.trump)) // Only the second card is trump, it wins
                {
                    theResult = false;
                }
                else
                {
                    theResult = true;
                }
            }

            return theResult;
        }

        // Determines if a card is equivalent or of lesser value than another
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
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
