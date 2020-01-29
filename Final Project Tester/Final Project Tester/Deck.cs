using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public class Deck
    {
        private Card[] theDeck;

        // Constructor
        public Deck()
        {
            theDeck = new Card[36];
            int cardIterator = 0;

            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 0; rankVal < 14; rankVal++)
                {
                    theDeck[cardIterator] = new Card(suitVal, rankVal);
                    cardIterator++;
                }
            }
        }
    }
}
