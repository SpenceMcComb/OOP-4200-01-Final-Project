using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public abstract class Player
    {
        //instance
        protected String name;
        protected Cards hand;
        
        //getters and setters
        protected abstract String GetName();

        protected abstract void SetName(String name);

        protected abstract Cards GetHand();

        protected abstract void Pickup(Card cardOnBoard);

        //attacking method
        protected abstract Card Attack(bool initialAttack);

        //defending method
        protected abstract Card Defend();

        //give card method
        protected abstract void Draw(Card card, int numberToDraw);
    }
}


