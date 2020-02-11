using System;

namespace Final_Project_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck theDeck = new Deck();
            Card[] theCards = new Card[36];

            // Loop through the deck
            for (int i = 0; i < 36; i++)
            {
                // Draw the cards and display them to the user
                theCards[i] = theDeck.GetCard(i);
                Console.WriteLine(theCards[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
