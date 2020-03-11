/*  Dice.cs - Defines the Dice Class, which raises events
 * 
 *  Author:     Thom MacDonald
 *  Author:     Spence McComb - 100426427
 *  Since:      2020/03/05
 *  
 */

using System;

namespace EventsAndExceptions
{

    /// <summary>
    /// Delegate to define the signature the event handler must conform to.
    /// </summary>
    public delegate void SnakeEyesHandler();
    
    /// <summary>
    /// Dice - represents two cubic die.
    /// </summary>
    public class Dice
    {
        // Initialize a shared random number generator
        private static Random myRandom = new Random();

        // Events
        public event SnakeEyesHandler RolledSnakeEyes;
        public event EventHandler<DiceRollEventArgs> RolledSeven;
        public event EventHandler<DiceRollEventArgs> RolledTwelve;

        // Properties
        private int myDieOne;
        public int DieOne { get { return myDieOne; } }
        
        private int myDieTwo;
        public int DieTwo { get { return myDieTwo; } }

        public int Value { get { return myDieOne + myDieTwo; } }

        // Roll Method
        public void Roll()
        {
            // define MIN and MAX die values
            const int MIN = 1;
            const int MAX = 6;

            // Set each die to a random value in range
            myDieOne = myRandom.Next(MIN, MAX + 1);
            myDieTwo = myRandom.Next(MIN, MAX + 1);

            // Validate roll value:
            if (Value < (MIN * 2) || Value > (MAX * 2))
            {
                //throw new DiceRollOutOfRange(this as Dice); // or (this.MemberwiseClone() as Dice)
                throw new DiceRollOutOfRange(this as Dice, "Whoa!");
            }

            // Raise any events:
            // If the applicaton has an event hanlder defined for orlling a 2, and the roll is 2
            if (RolledSnakeEyes != null && Value == 2)
            {
                RolledSnakeEyes(); // call the event handler defined for rolling a 2
            }
            else if (RolledSeven != null && Value == 7)
            {
                RolledSeven(this, new DiceRollEventArgs(RollSlangNames.Natural));
            }
            else if (RolledTwelve != null && Value == 12)
            {
                RolledTwelve(this, new DiceRollEventArgs(RollSlangNames.Boxcars));
            }
        }

        // Ctor
        public Dice()
        {
           Roll(); // Roll to establish initial values.
        }
    }
}
