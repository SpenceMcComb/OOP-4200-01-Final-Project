using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Deck.cs - A class defining the Deck object and it's associated methods.
 * Implements the ICloneable interface.
 * Author: Spence McComb - 100426427
 * Since: 2020/02/07
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardLib
{
    public class Deck : ICloneable
    {
        public event EventHandler LastCardDrawn;

        // Produces a deep copy of a Deck object.
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        // Create a new Cards object
        private Cards cards = new Cards();

        // Default constructor for a Deck object
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Rank)rankVal, (Suit)suitVal));
                }
            }
        }

        // Parameterized constructor for a Deck object
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        // Non-default constructor. Allows aces to be set to high
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        // Non-default constructor. Allows a trump suit to be used
        public Deck(bool useTrumps, Suit trumpSuit) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trumpSuit;
        }

        // Non-default constructor. Allows aces to be set high and a trump suit to be used
        public Deck(bool isAceHigh, bool useTrumps, Suit trumpSuit) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trumpSuit;
        }

        // Accessor for a Card in the Deck
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                // Trigger an event if LastCardDrawn is written and the last card is drawn
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }     
            else
                throw new CardOutOfRangeException(cards.Clone() as Cards);
        }

        // Method for randomizing the order of cards in the Deck object
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();

            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }

                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
    }
}