namespace DevelopmentInTeam.Pages;

/// <summary>
/// 
/// ALEKS' task
/// main page
/// do not touch unless messaged
/// 
/// </summary>
/// 


// TODO: Add buttons for navigating across pages
//
// pages needed: TicTacToePage, ConnectFourPage, 
// folders needed: Logic (with subfolder for every game: e.g. ConnectFourLogic)
//

public partial class MainPage : ContentPage
{
    // declaring fields and properties
    CarouselCover _carouselCover;
    public CarouselCover Carousel => _carouselCover;
    public MainPage()
    {
        InitializeComponent();
        _carouselCover = new CarouselCover();

        BindingContext = this;
    }


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
}