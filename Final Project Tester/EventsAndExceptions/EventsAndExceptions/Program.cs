/*  Program.cs - Defines the Program class for the Events and Custom Exceptions video exercise.
 * 
 *  Author:     Thom MacDonald
 *  Author:     Spence McComb
 *  Since:      2020/03/05
 *  See:        https://www.youtube.com/
 *  See:        Watson, K., Hammer, J. V., Reid, J. D., Skinner, M., Kemper, D., & Nagel, C. (2012). 
 *              Chapter 13: Additional OOP Techniques. In Beginning Visual C# 2012 Programming. (pp. 213-238). 
 *              John Wiley & Sons.
 */

using System;

using System.Timers;  // for Timer class, ElapsedEventHandler delegate

namespace EventsAndExceptions
{
 

    class Program
    {
        static void Main(string[] args)
        {
            try
            {              
                Console.WriteLine("\n   Events and Custom Exceptions in C#\n\t    {0}", DateTime.Now.ToLongDateString());
                Console.WriteLine("=========================================\n");

                // Part 1: Handling Events
                //HandlingEvents();


                // Part 2: Defining Events
                // Instantiate a new Dice object
                Dice myDice = new Dice();

                // Event wiring goes here:
                //myDice.RolledSnakeEyes += myDice_SnakeEyes;
                myDice.RolledSnakeEyes += delegate () { Console.Write("!!SNAKE EYES!! "); }; // anonymous method


                // Part 3: Multipurpose event handlers
                // Write one handler to RolledSeven and RolledTwelve events
                myDice.RolledSeven += myDice_SpecialRoll;
                myDice.RolledTwelve += myDice_SpecialRoll;

                // Roll the dice 99 times:
                RollDice(myDice, 99);
            }


            // Part 4: Custom Exceptions
            
            catch (DiceRollOutOfRange diceEx)
            {
                Console.WriteLine("{0} ({1}/{2})", diceEx.Message, diceEx.DiceRoll.DieOne, diceEx.DiceRoll.DieTwo);
            }
            catch (Exception ex) // catch a base Exception
            {
                // Display basic information about the exception
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // End the program:
                Console.WriteLine("\n\n========================================="); 
                Console.WriteLine("Press any key to end...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Demonstrates wiring an event. Also an example of the Timer class
        /// </summary>
        static void HandlingEvents()
        {
            // Create a new Timer with a 1 second interval.
            Timer theTimer = new Timer(1000.00);

            // Wire our event handler to the Timer's Elapsed Event
            theTimer.Elapsed += new ElapsedEventHandler(theTimer_Elapsed);

            // Start the Timer.
            theTimer.Start();

            // Suspend this thread for ROUGHLY 3 seconds.
            System.Threading.Thread.Sleep(3010);

            // Stop the Timer.
            theTimer.Stop();
        }

        /// <summary>
        /// theTimer_Elapsed - Our event handler for when the timer interval has elapsed.
        /// </summary>
        /// <param name="source">object that raised the event.</param>
        /// <param name="e">additional event information.</param>
        static void theTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            // Display some info about the event
            Console.WriteLine("{0} elapsed at {1}", source.ToString(), e.SignalTime);
        }


        /// <summary>
        /// RollDice() - Rolls the dice a set number of times and displays the resulting values.
        /// </summary>
        /// <param name="theDice">the dice object to roll</param>
        /// <param name="rollLimit">the number of times to roll the dice</param>
        static void RollDice(Dice theDice, int rollLimit)
        {
            // Tell the user how many times we will roll the dice
            Console.WriteLine("Rolling the dice {0} times: \n", rollLimit);

            // For each roll up to the roll limit
            for (int roll = 1; roll <= rollLimit; roll++)
            {
                // Display the roll number
                Console.Write("Roll {0}: ", roll.ToString().PadRight(3));

                // Roll the dice
                theDice.Roll();
        
                // Display the dice value
                Console.WriteLine(theDice.Value);

                // If the roll number is a multiple of 15
                if (roll % 15 == 0)
                {
                    // Pause the console
                    Console.WriteLine("\nPress any key to continue...\n");
                    Console.ReadKey();           
                }
            }
        }

        /// <summary>
        /// SnakeEyes Event Handler - Writes a special message when a pair of '1' are rolled.
        /// </summary>
        static void myDice_SnakeEyes()
        {
            // Write the special message to the console
            Console.Write("**SNAKE EYES!** ");
        }

        /// <summary>
        /// A Multipurpose Event Handler.
        /// </summary>
        /// <param name="source">the object that raised the event</param>
        /// <param name="e">extra information about the event</param>
        static void myDice_SpecialRoll(object source, DiceRollEventArgs e)
        {
            Console.Write("{0} ({1}/{2}): ", e.Message, (source as Dice).DieOne, (source as Dice).DieTwo);
        }

    }
}
