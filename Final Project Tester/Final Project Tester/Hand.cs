﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Project_Tester
{
    class Hand : ICloneable
    {
        //instance attributes
        Cards hand = new Cards();
        //private bool isHandEmpty = false;
        private int cardCount = 0;
        
        //default constructor
        public Hand()
        {

        }

        //parameterized constructor
        private Hand(Cards newHand)
        {
            hand = newHand;
        }

        //clone method
        //returns a clone of playerhand
        public object Clone()
        {
            Hand newHand = new Hand(hand.Clone() as Cards);
            return newHand;
        }

        //addcardtohand method, add a card to the players hand
        public void AddCard(Card card)
        {
            hand.Add(card);
            cardCount = hand.Count();
        }

        //will add cards to players hand
        public void AddCards(Cards cards)
        {


            for (int i = 0; i < cards.Count(); i++)
            {
                hand.Add(cards[i]);
            }

            cardCount = hand.Count();
        }


        //removecardfromhand method, will remove a card from the players hand
        public void RemoveCard(Card card)
        {
            hand.Remove(card);
            cardCount = hand.Count();
        }

        //gets hand count
        public int length()
        {
            return hand.Count();
        }

        //choosecardfromhand method, will select a specific card from the hand then remove from list
        public Card ChooseCard(int cardNumber)
        {
            Card card;
            card = hand.GetCard(cardNumber, hand);
            hand.Remove(card);
            return card;
        }

        //choose specific card from hand
        public Card ChooseCard(Card card)
        {
            return card;
        }

        //get card based on int number
        public Card GetCard(int cardNumber)
        {
            if (cardNumber >= 0 && cardNumber <= 51)
                return hand[cardNumber];
            else
                throw(new System.ArgumentOutOfRangeException("cardNumber", cardNumber, "The deck is between 0 and 51 cards long, how do you screw this up?."));
        }
    }
}
