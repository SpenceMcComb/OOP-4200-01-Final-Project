using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

/**
 * Program.cs - A testing class for the Ch11CardLib library
 * 
 * Author: Spence McComb - 100426427
 * Since: 2020/02/07
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tutorial 1-6 testing
            Deck deck1 = new Deck();
            Deck deck2 = (Deck)deck1.Clone();
            Console.WriteLine("The first card in the original deck is: {0}", deck1.GetCard(0));
            Console.WriteLine("The first card in the cloned deck is: {0}", deck2.GetCard(0));
            deck1.Shuffle();
            Console.WriteLine("The original deck has been shuffled.");
            Console.WriteLine("The first card in the original deck is: {0}", deck1.GetCard(0));
            Console.WriteLine("The first card in the cloned deck is: {0}", deck2.GetCard(0));

            // Tutorial 7 testing
            Deck deck3 = new Deck();
            try
            {
                Card myCard = deck3.GetCard(60);
            }
            catch (CardOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.DeckContents[0]);
            }
            Console.ReadKey();
        }
    }
}
