using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public abstract class Player
    {
        //instance
        protected abstract String name;
        protected abstract Cards hand;
        
        //getters and setters
        protected abstract String GetName();

        protected abstract void SetName(String name);

        protected abstract Cards GetHand();

        protected abstract void SetHand(Cards hand);

        //attacking method
        protected abstract Card Attack(bool initialAttack);

        //defending method
        protected abstract Card Defend();

        //give card method
        protected abstract void GiveCard(Card card);
    }
}


