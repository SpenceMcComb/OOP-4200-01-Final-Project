using System;

namespace Final_Project_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck theDeck = new Deck();

            // Loop through the deck
            for (int i = 0; i < 36; i++)
            {
                // Draw the cards and display them to the user
                Console.WriteLine(theDeck.GetCard(i).ToString());
            }

            // Testing comparison operators
            Console.WriteLine("\n=================================================================\nTesting Comparison Operators with Ace of Spades and Six of Spades\n=================================================================\n");

            if (theDeck.GetCard(0) < theDeck.GetCard(8))
            {
                Console.WriteLine("{0} is less than {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }
            else
            {
                Console.WriteLine("{0} is NOT less than {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }

            if (theDeck.GetCard(0) <= theDeck.GetCard(8))
            {
                Console.WriteLine("{0} is less than or equal to {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }
            else
            {
                Console.WriteLine("{0} is NOT less than or equal to {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }

            if (theDeck.GetCard(0) > theDeck.GetCard(8))
            {
                Console.WriteLine("{0} is greater than {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }
            else
            {
                Console.WriteLine("{0} is NOT greater than {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }

            if (theDeck.GetCard(0) >= theDeck.GetCard(8))
            {
                Console.WriteLine("{0} is greater than or equal to {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }
            else
            {
                Console.WriteLine("{0} is NOT greater than or equal to {1}", theDeck.GetCard(0), theDeck.GetCard(8));
            }

            Console.ReadKey();
        }
    }
}
