﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Tester
{
    class Talon : ICloneable
    {
        Cards theTalon = new Cards();
        private int riverCardsRemaning = 0;


        //default constructor
        public Talon()
        {

        }

        //parameriterized constructor sets new talon
        private Talon(Cards newDeck)
        {
            theTalon = newDeck;
        }


        //addcardtoriver method, will add a card to talon
        public void AddCard(Card card)
        {
            theTalon.Add(card);
            riverCardsRemaning = theTalon.Count();
        }

        //removecardfromriver method, will remove a card from the talon
        public void RemoveCard(Card card)
        {
            theTalon.Remove(card);
            riverCardsRemaning = theTalon.Count();
        }

        //shows the length of the talon
        public int length()
        {
            return theTalon.Count();
        }

        //get card based on int number
        public Card GetCard(int cardNumber)
        {
            if (cardNumber >= 0 && cardNumber <= 51)
                return theTalon[cardNumber];
            else
                throw (new System.ArgumentOutOfRangeException("cardNumber", cardNumber, "The deck is between 0 and 51 cards long, how do you screw this up?."));
        }

        //clones the talon cards
        public object Clone()
        {
            Talon newTalon = new Talon(theTalon.Clone() as Cards);
            return newTalon;
        }

        //clears the talon
        public void Clear()
        {
            theTalon.Clear();
        }
    }
}
