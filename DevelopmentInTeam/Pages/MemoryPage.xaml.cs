// ALEKS' PAGE
using DevelopmentInTeam.Logic;

namespace DevelopmentInTeam.Pages;

public partial class MemoryPage : ContentPage
{
    // declaring field for MemoryGame object and its corresponding property
    MemoryGame _memoryGame;
    public MemoryGame MemoryGame => _memoryGame;

	public MemoryPage()
	{
		InitializeComponent();

        // creating new instance of MemoryGame class
        _memoryGame = new MemoryGame();
	}

    /// <summary>
    /// method for updating the UI by iterating through each card in the deck and updating the corresponding imagebutton
    /// based on whether it is matched/flipped, defaults to the face-down card image if neither. Also handles the game completion,
    /// if game is complete then displayalerts a win message and terminates the game (disbales imagebuttons)
    /// </summary>
    public void UpdateUI()
    {
        int cardCounter = 0; // counter which will be used for tracking the # of current element in the Cards deck

        foreach (Card card in _memoryGame.Cards)
        {
            cardCounter++; // increments counter by 1 so that it will span cards 1-12
            string imageButtonName = "Card" + cardCounter; // concatenates the # of current element in the Cards deck to the string
            var imageButton = (ImageButton)this.FindByName(imageButtonName); // assigns variable to the ImageButton control with the corresponding name

            if (card.IsMatched || card == _memoryGame.FlippedCard) // if the card is matched or flipped
            {
                imageButton.Source = card.ImageFileName; // sets image source to the cards imagefilename string
            }
            else 
            {
                imageButton.Source = "card_back.png"; // sets the image source to the face-down card image
            }
        }

        // if game is complete, deck is disabled.
        if (_memoryGame.GameOver)
        {
            DisplayAlert("Game over!", "Game has been completed, you won.", "OK");
            TerminateGame(); // disables the imagebuttons
        }
    }

    /// <summary>
    /// method for terminating game by iterating through the Deck grid and disabling all the imagebuttons.
    /// </summary>
    public void TerminateGame()
    {
        foreach (ImageButton imageButton in MemoryDeck.Children)
        {
            imageButton.IsEnabled = false;
        }
    }

    /// <summary>
    /// Clicked EventHandlers region for all 1-12 cards in the deck
    /// </summary>
    #region
    private void Card1Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[0]);
        UpdateUI();
    }
    private void Card2Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[1]);
        UpdateUI();
    }

    private void Card3Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[2]);
        UpdateUI();
    }

    private void Card4Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[3]);
        UpdateUI();
    }
    private void Card5Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[4]);
        UpdateUI();
    }

    private void Card6Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[5]);
        UpdateUI();
    }

    private void Card7Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[6]);
        UpdateUI();
    }
    private void Card8Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[7]);
        UpdateUI();
    }

    private void Card9Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[8]);
        UpdateUI();
    }

    private void Card10Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[9]);
        UpdateUI();
    }
    private void Card11Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[10]);
        UpdateUI();
    }

    private void Card12Clicked(object sender, EventArgs e)
    {
        _memoryGame.FlipCard(_memoryGame.Cards[11]);
        UpdateUI();
    }

    #endregion

    /// <summary>
    /// Restarts the game when start new game button is clicked, 
    /// by re-enabling the deck's imagebuttons, creating a new game instance and updating the UI
    /// </summary>
    private void OnNewGameClicked(object sender, EventArgs e)
    {
        // iterates each imagebutton (card) of the deck grid
        foreach (ImageButton imageButton in MemoryDeck.Children)
        {
            imageButton.IsEnabled = true; // re-enables them
        }

        _memoryGame = new MemoryGame(); // resets old game object by assigning its field to new instance 
        UpdateUI();
    }
}