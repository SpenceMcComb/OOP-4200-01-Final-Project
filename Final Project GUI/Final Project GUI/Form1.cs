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

namespace Final_Project_GUI
{
    public partial class frmBoard : Form
    {
        #region Fields and Properties

        // The default card size
        static private Size cardSize = new Size(115, 176);

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
            // Create a new, shuffled talon and identify the trump suit
            Deck theTalon = new Deck();
            theTalon.Shuffle();
            Card trumpCard = theTalon.GetCard(0);
            pbTalon.Image = trumpCard.GetCardImage();
            trumpCard.FaceUp = true;
            pbTrumpSuit.Image = trumpCard.GetCardImage();

            // Draw a hand of 7 cards
            for (int i = 1; i <= 7; i++)
            {
                Card handCard = theTalon.GetCard(0);
                handCard.FaceUp = true;
                PictureBox aPictureBox = new PictureBox();
                aPictureBox.Image = handCard.GetCardImage();
                aPictureBox.Width = 115;
                aPictureBox.Height = 176;
                aPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pnlPlayerHand.Controls.Add(aPictureBox);
                RealignCards(pnlPlayerHand);
            } 
        }

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
                panelHand.Controls[myCount - 1].Top = 0;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n"); // Debugging
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = 0;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }
            }
        }
    }
}
