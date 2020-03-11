using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * An example program for the CardLib and the Game and Player classes
 * 
 * Author: Spence McComb - 100426427
 * Since: 2020/03/05
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display introduction
            Console.WriteLine("KarliCards: a new and exciting card game.");
            Console.WriteLine("To win, you must have 7 cards of the same suit in your hand.");
            Console.WriteLine();

            // Prompt for number of players
            bool inputOkay = false;
            int numberOfPlayers = -1;
            do
            {
                Console.WriteLine("How many players (2-7)?");
                string input = Console.ReadLine();
                try
                {
                    // Attempt to convert input into a valid number of players
                    numberOfPlayers = Convert.ToInt32(input);
                    if (numberOfPlayers >= 2 && numberOfPlayers <= 7)
                    {
                        inputOkay = true;
                    }
                }
                catch
                {
                    // Ignore failed conversions, just continue prompting
                }
            } while (inputOkay == false);

            // Initialize player array
            Player[] players = new Player[numberOfPlayers];
            
            // Get player names
            for (int p = 0; p < players.Length; p++)
            {                
                Console.WriteLine("Player {0}, enter your name:", p + 1);
                string playerName = Console.ReadLine();

                // Create a new player object for the player array
                players[p] = new Player(playerName);
            }

            // Start the game
            Game newGame = new Game();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();

            // Display winning player
            Console.WriteLine("{0} has won the game!", players[whoWon].Name);
            Console.ReadKey();
        }
    }
}
