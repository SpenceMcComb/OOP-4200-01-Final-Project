using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLib;
using MyCardBox;

namespace Final_Project_GUI
{
    public partial class frmBoard : Form
    {
        #region Fields and Properties

        // The default card size
        static private Size cardSize = new Size(90, 151);

        // The amount, in points, that CardBox controls are enlarged when hovered over. 
        private const int POP = 25;

        private CardBox dragCard;

        private Deck theTalon = new Deck();

        #endregion

        /// <summary>
        /// Constructor for the game board
        /// </summary>
        public frmBoard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event for the game board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBoard_Load(object sender, EventArgs e)
        {
            // Create a new, SHUFFLED talon and identify the trump suit

            //theTalon.Shuffle();
            Card trumpCard = theTalon.DrawCard();
            pbTalon.Image = trumpCard.GetCardImage();
            trumpCard.FaceUp = true;
            pbTrumpSuit.Image = trumpCard.GetCardImage();

            // Draw a hand of 7 cards - Player
            for (int i = 1; i <= 7; i++)
            {
                Card handCard = theTalon.DrawCard();
                handCard.FaceUp = true;
                CardBox aCardBox = new CardBox(handCard);

                // Wire the apporpriate event handlers for each cardbox
                aCardBox.MouseDown += CardBox_MouseDown;
                aCardBox.DragEnter += CardBox_DragEnter;
                aCardBox.DragDrop += CardBox_DragDrop;
                aCardBox.Click += CardBox_Click;

                // wire CardBox_MouseEnter for the "POP" visual effect
                aCardBox.MouseEnter += CardBox_MouseEnter;

                // wire CardBox_MouseLeave for the regular visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;

                pnlPlayerHand.Controls.Add(aCardBox);
                RealignCards(pnlPlayerHand);
            }

            // Draw a hand of 7 cards - AI
            for (int i = 1; i <= 7; i++)
            {
                Card handCard = theTalon.DrawCard();
                handCard.FaceUp = true; // Change this to false later
                CardBox aCardBox = new CardBox(handCard);
                pnlOpponentHand.Controls.Add(aCardBox);
                RealignCards(pnlOpponentHand);
            }
        }

        /// <summary>
        /// Deal a card or reset the deck on clicking the deck.
        /// </summary>
        private void pbTalon_Click(object sender, EventArgs e)
        {
            // If the deck is empty, do nothing
            if (pbTalon.Image != null)
            {
                // Draw a card from the talon
                Card card = theTalon.DrawCard();
                card.FaceUp = true; 

                // Create a new CardBox control based on the card drawn
                CardBox aCardBox = new CardBox(card);

                // Wire the event handlers for this CardBox
                //aCardBox.MouseDown += CardBox_MouseDown;
                aCardBox.DragEnter += CardBox_DragEnter;
                aCardBox.DragDrop += CardBox_DragDrop;
                aCardBox.Click += CardBox_Click;
                aCardBox.MouseEnter += CardBox_MouseEnter;
                aCardBox.MouseLeave += CardBox_MouseLeave;

                // Add the new control to the appropriate panel
                pnlPlayerHand.Controls.Add(aCardBox);

                // Realign the controls in the panel so they appear correctly.
                RealignCards(pnlPlayerHand);
            }
        }

        /// <summary>
        /// Make the mouse pointer a "move" pointer when a drag enters a Panel.
        /// </summary>
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            // Make the mouse pointer a "move" pointer
            e.Effect = DragDropEffects.Move;
        }


        /// <summary>
        /// Move a card/control when it is dropped from one Panel to another.
        /// </summary>
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            // If there is a CardBox to move
            if (dragCard != null)
            {
                // Determine which Panel is which
                Panel thisPanel = sender as Panel;
                Panel fromPanel = dragCard.Parent as Panel;

                // If neither panel is null (no conversion issue)
                if (thisPanel != null && fromPanel != null)
                {
                    // if the Panels are not the same (this would happen if a card is dragged from one spot in the Panel to another)
                    if (thisPanel != fromPanel)
                    {
                        // Remove the card from the Panel it started in
                        fromPanel.Controls.Remove(dragCard);

                        // Add the card to the Panel it was dropped in 
                        thisPanel.Controls.Add(dragCard);

                        // Realign cards in both Panels
                        RealignCards(thisPanel);
                        RealignCards(fromPanel);
                    }
                }
            }
        }

        #region CARD BOX EVENT HANDLERS

        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked and the card is in hand
            if (aCardBox != null)
            {
                if (aCardBox.Parent == pnlPlayerHand)
                {
                    // Enlarge the card for visual effect
                    aCardBox.Size = new Size(cardSize.Width + POP, cardSize.Height + POP);

                    // move the card to the top edge of the panel.
                    aCardBox.Top = 0;
                }
            }
        }


        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                if (aCardBox.Parent == pnlPlayerHand)
                {
                    // resize the card back to regular size
                    aCardBox.Size = cardSize;

                    // move the card down to accommodate for the smaller size.
                    aCardBox.Top = POP;
                }
            }
        }


        /// <summary>
        /// Initiate a card move on the start of a drag.
        /// </summary>
        void CardBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Set dragCard
            dragCard = sender as CardBox;

            // If the conversion worked
            if (dragCard != null)
            {
                // Set the data to be dragged and the allowed effect dragging will have.
                DoDragDrop(dragCard, DragDropEffects.Move);
            }
        }


        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlPlayerHand)
                {
                    // Remove the card from the home panel
                    pnlPlayerHand.Controls.Remove(aCardBox);

                    // Add the control to the play panel
                    pnlPlayArea.Controls.Add(aCardBox);
                }
            }

            // Realign the cards 
            RealignCards(pnlPlayerHand);
            RealignCards(pnlPlayArea);
        }


        /// <summary>
        /// When a drag is enters a card, enter the parent panel instead.
        /// </summary>
        void CardBox_DragEnter(object sender, DragEventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // Do the operation on the parent panel instead
                Panel_DragEnter(aCardBox.Parent, e);
            }
        }

        /// <summary>
        /// When a drag is dropped on a card, drop on the parent panel instead.
        /// </summary>
        void CardBox_DragDrop(object sender, DragEventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // Do the operation on the parent panel instead
                Panel_DragDrop(aCardBox.Parent, e);
            }
        }

        #endregion


        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * 25) / (myCount - 1);  // Minus the offset on both sides

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                    {
                        offset = cardWidth;
                    }

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = 25;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n"); // Debugging
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = 25;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            }
        }
    }
}
