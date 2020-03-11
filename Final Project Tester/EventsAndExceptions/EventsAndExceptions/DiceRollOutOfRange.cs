/*  DiceRollOutOfRange.cs - Defines the DiceRollOutOfRange Class, which is derived from Exception
 * 
 *  Author:     Thom MacDonald
 *  Author:     Spence McComb - 100426427
 *  Since:      2020/03/05
 *  
 */

using System;

namespace EventsAndExceptions
{
    class DiceRollOutOfRange: Exception
    {
        // DiceRoll Property (get only)
        private readonly Dice myDiceRoll;
        public Dice DiceRoll
        {
            get { return myDiceRoll; }
        }
        
        // Ctor(Dice)
        public DiceRollOutOfRange(Dice dice)
        {
            // Set the Dice field
            myDiceRoll = dice;
        }

        // Ctor(Dice, Message)
        public DiceRollOutOfRange(Dice dice, string message) : base(message)
        {
            // Set the Dice field
            myDiceRoll = dice;
        }

    }
}
