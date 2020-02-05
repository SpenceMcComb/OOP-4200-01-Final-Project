using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ch10CardLib;

namespace Ch10FiveCardClient
{
    class Program
    {
        static void Main(string[] args)
        {  
            // The maximum number of cards that can drawn
            const int NUMBER_OF_CARDS = 50;

            // Create the deck
            Deck theDeck = new Deck();

            // Create an array to hold the cards
            Card[] theCards = new Card[NUMBER_OF_CARDS];

            // Create a hand array
            Card[] aHand = new Card[5];

            // Shuffle the deck
            theDeck.Shuffle();

            // Loop through the bulk of the deck
            for (int i = 0; i < NUMBER_OF_CARDS; i++)
            {
                // Draw the cards and display them to the user
                theCards[i] = theDeck.GetCard(i);
                Console.WriteLine(theCards[i].ToString());

                // Every 5 cards
                if ((i+1)%5 == 0)
                {
                    // Determine if a flush has occurred
                    if (theCards[i].suit == theCards[i-4].suit &&
                        theCards[i].suit == theCards[i-3].suit &&
                        theCards[i].suit == theCards[i-2].suit &&
                        theCards[i].suit == theCards[i-1].suit)
                    {
                        // Tell the user they have drawn a flush
                        Console.WriteLine("A flush!");

                        // End the loop
                        i = NUMBER_OF_CARDS;
                    }
                    // Add spacing
                    Console.WriteLine();              
                }
            }

            // End the program after a keypress
            Console.Write("Press any key to end the program...");
            Console.ReadKey();
        }
    }
}
