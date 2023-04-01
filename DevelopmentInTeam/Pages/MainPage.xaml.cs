namespace DevelopmentInTeam.Pages;

/// <summary>
/// 
/// ALEKS' task
/// main page
/// do not touch unless messaged
/// 
/// </summary>


// TERM PROJECT TODO: 
//
// pages needed: ???
// folders needed: Logic (with subfolder for every game: e.g. ConnectFourLogic)
// 
//

// MAIN PAGE TODO:
// add title contents
// add side bar contents
//

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
    /// contents of the carousel view
    /// </summary>
    public class CarouselCover
    {
        /// <summary>
        /// specified image URLs in string array assigned to ImageURLs property
        /// </summary>
        public IEnumerable<string> ImageURLs { get; } = new List<string>
        {
        "checkers_art.png",
        "connectfour_art.png",
        "tictactoe_art.png",
        };

        
    }
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

    /// <summary>
    /// page navigation event handler for when ImageButton is clicked
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
        }
    }

}