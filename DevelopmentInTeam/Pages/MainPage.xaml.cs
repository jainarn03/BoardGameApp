using DevelopmentInTeam.Logic;

namespace DevelopmentInTeam.Pages;

/// <summary>
/// 
/// ALEKS' task
/// main page
/// 
/// </summary>

public partial class MainPage : ContentPage
{
    // declaring fields and properties
    CarouselCover _carouselCover;
    public CarouselCover Carousel => _carouselCover;
    public MainPage()
    {
        InitializeComponent();

        _carouselCover = new CarouselCover(); // creating new Carousel

        BindingContext = this;
    }

    /// <summary>
    /// page navigation methods
    /// </summary>
    public async void GoToCheckersPage()
    {
        await Navigation.PushAsync(new CheckersPage());
    }

    public async void GoToConnectFourPage()
    {
        await Navigation.PushAsync(new ConnectFourPage());
    }

    public async void GoToTicTacToePage()
    {
        await Navigation.PushAsync(new TicTacToePage());
    }

    public async void GoToMemoryPage()
    {
        await Navigation.PushAsync(new MemoryPage());
    }

    public async void GoToWordlePage()
    {
        await Navigation.PushAsync(new WordlePage());
    }

    public async void GoToHangmanPage()
    {
        await Navigation.PushAsync(new HangmanPage());
    }

    /// <summary>
    /// Clicked event handler that takes ImageButton's source URL and navigates to the corresponding game page
    /// </summary>
    private void OnImageClicked(object sender, EventArgs e)
    {
        ImageButton clickedImageButton = (ImageButton)sender; // casts sender object to ImageButton
        string imageUrl = clickedImageButton.Source.ToString(); //gets url of clicked ImageButton

        // switch statement to compare imageUrl and navigate to corresponding page
        //      note: imageUrl string starts with File: 
        switch (imageUrl)
        {
            case "File: checkers_art.png":
                GoToCheckersPage();
                break;

            case "File: connectfour_art.png":
                GoToConnectFourPage();
                break;
                
            case "File: tictactoe_art.png":
                GoToTicTacToePage();
                break;

            case "File: memory_art.png":
                GoToMemoryPage();
                break;

            case "File: wordle_art.png":
                GoToWordlePage();
                break;

            case "File: hangman_art.png":
                GoToHangmanPage();
                break;
        }
    }
}