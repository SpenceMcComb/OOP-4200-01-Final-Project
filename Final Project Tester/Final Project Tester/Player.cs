using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public abstract class Player
    {
        //instance
        private String name = "";
        private Cards hand = new Cards();


        //class 
        public const String DEFAULT_NAME = "Bruce Wayne";
        public const Cards DEFAULT_HAND = null;

        //default constructor
        public Player()
        {
            setName(DEFAULT_NAME);
            setHand(DEFAULT_HAND);
        }

        //getters and setters
        protected String getName()
        {
            return name;
        }

        protected void setName(String name)
        {
            this.name = name;
        }

        protected Cards getHand()
        {
            return hand;
        }

        protected void setHand(Cards hand)
        {
            this.hand = hand;
        }

        //attacking method
        protected abstract Card Attack(bool initialAttack);

        //defending method
        protected abstract Card Defend();
    }
}


