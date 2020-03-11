using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

/**
 * The class containing the different attributes and methods
 * for a player of a card game.
 * 
 * Author: Spence McComb - 100426427
 * Since: 2020/03/05
 * See: Beginning Visual C#® 2012 Programming
 */

namespace CardClient
{
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }

        // Default constructor
        private Player()
        {

        }

        // Parameterized constructor: assigns a name and new hand
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }

        /// <summary>
        /// Determines if a player wins the game via a flush
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].suit == match;
            }
            return won;
        }
    }
}
