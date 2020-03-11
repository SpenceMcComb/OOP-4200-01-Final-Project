using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

/**
 * The class containing the game's attributes and rules.
 * 
 * Author: Spence McComb - 100426427
 * Since: 2020/03/05
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardClient
{
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;

        public Game()
        {
            currentCard = 0;
            playDeck = new Deck(true);
            playDeck.LastCardDrawn += Reshuffle;
            playDeck.Shuffle();
            discardedCards = new Cards();
        }

        /// <summary>
        /// Puts the discarded cards back into the deck and reshuffles it
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void Reshuffle(object source, EventArgs args)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }

        /// <summary>
        /// Creates the players for the game: between 2 and 7, inclusive
        /// </summary>
        /// <param name="newPlayers"></param>
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
            {
                throw new ArgumentException("A maximum of 7 players may play this game.");
            }

            if (newPlayers.Length < 2)
            {
                throw new ArgumentException("A minimum of 2 players may play this game.");
            }

            players = newPlayers;
        }

        /// <summary>
        /// Deals each player their hand
        /// </summary>
        private void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }

        public int PlayGame()
        {
            // Only if the players exist
            if (players == null)
                return -1;

            // Deal initial hands
            DealHands();

            // Initialize the game variables, including a card on the table
            bool gameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);

            // Main loop
            do
            {
                // Loop through players in each game round
                for (currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
                {
                    // Write out the current player, hand, and card on table
                    Console.WriteLine("{0}'s turn.", players[currentPlayer].Name);
                    Console.WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine("Card in play: {0}", playCard);

                    
                    bool inputOkay = false;
                    do
                    {
                        Console.WriteLine("Press T to take card in play or D to draw.");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "t")
                        {
                            // The input is good
                            inputOkay = true;

                            // Add the card to the hand
                            players[currentPlayer].PlayHand.Add(playCard);
                            Console.WriteLine("Drawn: {0}", playCard);

                            // Remove from discarded cards if possible (reshuffled means it's gone)
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }
                        }
                        if (input.ToLower() == "d")
                        {
                            inputOkay = true;

                            // Add a new card from deck to player's hand if it's available
                            Card newCard;
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);

                                // Check if the card is in the discard pile
                                cardIsAvailable = !discardedCards.Contains(newCard);

                                if (cardIsAvailable)
                                {
                                    // Loop through all hands to see if the newCard is already in one
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvailable);

                            // Add the card to the player's hand
                            players[currentPlayer].PlayHand.Add(newCard);
                            Console.WriteLine("Drawn: {0}", newCard);
                            inputOkay = true;
                        }
                    } while (!inputOkay);

                    // Display new hand with cards numbered
                    Console.WriteLine("New hand:");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, players[currentPlayer].PlayHand[i]);
                    }

                    // Prompt player for a card to discard
                    inputOkay = false;
                    int choice = -1;
                    do
                    {
                        Console.WriteLine("Choose a card to discard:");
                        string input = Console.ReadLine();
                        try
                        {
                            // Attempt to convert input to a valid card number
                            choice = Convert.ToInt32(input);
                            if (choice > 0 && choice <= 8)
                            {
                                inputOkay = true;
                            }
                        }
                        catch
                        {
                            // Ignore failed conversions, continue prompting
                        }
                    } while (!inputOkay);

                    // Place reference to removed card in playCard, then remove from hand, add to discard
                    Console.WriteLine("Discarding: {0}\n", playCard);
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                    discardedCards.Add(playCard);

                    // Check to see if player has won the game and exit the loop if so
                    gameWon = players[currentPlayer].HasWon();
                    if (gameWon)
                        break;
                }
            } while (!gameWon);

            // End the game, noting the winning player
            return currentPlayer;
        }
    }
}
