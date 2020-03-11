/*  RollSlangNames.cs - Defines the RollSlangNames enumeration
 * 
 *  Author:     Thom MacDonald
 *  Author:     Your Name
 *  Since:       Feb 2016 <update>
 *  
 */

using System;

namespace EventsAndExceptions
{
    /// <summary>
    /// Slang terms for the results of various dice rolls
    /// </summary>
    public enum RollSlangNames
    {
        SnakeEyes,  // Pair of 1s
        AceDeuce,   // 1 and 2
        EasyFour,   // 1 and 3
        HardFour,   // Pair of 2s
        FeverFive,  // Any 5
        EasySix,    // 1 and 5 or 2 and 4
        HardSix,    // Pair of 3s
        Natural,    // Any 7
        EasyEight,  // Any 8 except a pair of 4s
        HardEight,  // Pair of 4s
        Nina,       // Any 9
        EasyTen,    // Any 10 except a pair of 5s
        HardTen,    // Pair of 5s
        YoLeven,    // Any 11
        Boxcars     // Pair of 6s
    }


}
