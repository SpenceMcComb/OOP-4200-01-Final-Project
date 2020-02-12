using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Tester
{
    public abstract class Player
    {
        //instance
        private String name = "";
        private PlayerHand hand = new playerHand();

        private bool Attacking = false;
        private bool Defending = false;


        //class 
        public const String DEFAULT_NAME = "Bruce Wayne";
        public const PlayerHand DEFAULT_HAND = null;

        //public const bool DEFAULT_ATTACK = false;
        //public const bool DEFAULT_DEFEND = false;


        //default constructor
        public Player()
        {
            setName(DEFAULT_NAME);
            setHand(DEFAULT_HAND);
            //setIsAttacking(DEFAULT_ATTACK);
            //setIsDefending(DEFAULT_DEFEND);
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

        protected PlayerHand getHand()
        {
            return hand;
        }

        protected void setHand(PlayerHand hand)
        {
            this.hand = hand;
        }
    }
}


