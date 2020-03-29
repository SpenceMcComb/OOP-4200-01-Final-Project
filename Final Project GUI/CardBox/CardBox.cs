using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLib;

/**
 * CardBox.cs - The CardBox Class
 * 
 * @author Thom MacDonald
 * @version 1.0
 * @since 2014-02-22
 */

namespace CardBox
{
    /// <summary>
    /// A control to use in a WFA that displays a playing card
    /// </summary>
    public partial class CardBox: UserControl
    {

        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }
            get { return myCard; }
        }

        public Suit Suit
        {
            set
            {
                Card.Suit = value;
                UpdateCardImage();
            }
            get { return Card.Suit; }
        }

        public Rank Rank
        {
            set
            {
                Card.Rank = value;
                UpdateCardImage();
            }
            get { return Card.Rank; }
        }

        public bool FaceUp
        {
            set
            {
                // If the value is different than the current property
                if (myCard.FaceUp != value)
                {
                    // Change the property and update it
                    myCard.FaceUp = value;
                    UpdateCardImage();

                    // There is an event handler for CardFlipped in the client's program
                    if (CardFlipped != null)
                    {
                        CardFlipped(this, new EventArgs()); // Call it
                    }
                }
            }
            get { return Card.FaceUp; }
        }

        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                if (myOrientation != value)
                {
                    // Change the orientation
                    myOrientation = value;
                    this.Size = new Size(Size.Height, Size.Width); // Swap the height and width
                    // Update card image
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        /// <summary>
        /// Changes the orientation of the card
        /// </summary>
        private void UpdateCardImage()
        {
            // Set the image using the underlying card
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {
                // Rotate the image
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        /// <summary>
        /// Constructor (Default): Constructs the control with a new card, oriented vertically
        /// </summary>
        public CardBox()
        {
            InitializeComponent(); // required method for Designer support
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="card"></param>
        /// <param name="orientation"></param>
        public CardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;
            myCard = card;
        }

        /// <summary>
        /// Overrides System.Object.ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return myCard.ToString();
        }


        /*
         * Events and handlers
         */

        // Load event          
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        // An event the client program can handle when the card flips
        public event EventHandler CardFlipped; // No new - not hiding in base class

        // Delegate for when the user clicks the control
        new public event EventHandler Click;


        // Click event for picture box
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null) // Application has set a click event handler for our delegate
            {
                Click(this, e); // Call it
            }

        }
    }
}
