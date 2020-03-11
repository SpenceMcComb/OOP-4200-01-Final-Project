/*  DiceRollEventArgs.cs - Defines the DiceRollEventArgs Class, which is derived from EventArgs
 * 
 *  Author:     Thom MacDonald
 *  Author:     Spence McComb - 100426427
 *  Since:      2020/03/05
 *  
 */

using System;

namespace EventsAndExceptions
{

    public class DiceRollEventArgs : EventArgs
    {
        // Properties
        private string myMessage;
        public string Message { get { return myMessage; } }

        // Ctor(String)
        public DiceRollEventArgs(string message = "No message sent")
        {
            myMessage = message;
        }

        // Ctor(RollNames)
        public DiceRollEventArgs(RollSlangNames name)
        {
            myMessage = name.ToString();
        }
    }
}
