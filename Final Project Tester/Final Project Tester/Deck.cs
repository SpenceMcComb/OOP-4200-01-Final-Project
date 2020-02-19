using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public class Deck
    {
        // Declarations of the appropriate constants for a game of Durak
        const int NUMBER_OF_SUITS = 4;
        const int NUMBER_OF_RANKS = 9;
        const int CARDS_IN_DECK = 36;

        // Collection of cards to be used in the creation of a Deck       
        private Card[] cards;
        
        /// <summary>
        /// Default constructor for a Deck
        /// </summary>
        public Deck()
        {
            cards = new Card[CARDS_IN_DECK];
            for (int suitVal = 0; suitVal < NUMBER_OF_SUITS; suitVal++)
            {
                for (int rankVal = 0; rankVal < NUMBER_OF_RANKS; rankVal++)
                {
                    cards[suitVal * NUMBER_OF_RANKS + rankVal] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }  
        }

        /// <summary>
        /// Parameterized constructor for a SHUFFLED Deck
        /// </summary>
        /// <param name="isShuffled"></param>
        public Deck(bool isShuffled) : this()
        {
            if (isShuffled)
            {
                Shuffle();
            }
            
        }

        /// <summary>
        /// Returns the Xth card from a Deck
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum < CARDS_IN_DECK)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                "Value must be between 0 and " + CARDS_IN_DECK + "."));
        }

        /// <summary>
        /// Shuffles the Deck
        /// </summary>
        public void Shuffle()
        {
            Card[] newDeck = new Card[CARDS_IN_DECK];
            bool[] assigned = new bool[CARDS_IN_DECK];
            Random sourceGen = new Random();

            for (int i = 0; i < CARDS_IN_DECK; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    destCard = sourceGen.Next(CARDS_IN_DECK);
                    if (assigned[destCard] == false)
                        foundCard = true;
                }

                assigned[destCard] = true;
                newDeck[destCard] = cards[i];
            }
            newDeck.CopyTo(cards, 0);
        }
    }
}
