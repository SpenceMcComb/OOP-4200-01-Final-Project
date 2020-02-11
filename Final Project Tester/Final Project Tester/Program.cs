using System;

namespace Final_Project_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck theDeck = new Deck();
            Card[] theCards = new Card[36];

            theDeck.ToString();

            Console.ReadKey();
        }
    }
}
