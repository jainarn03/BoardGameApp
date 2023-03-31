namespace DevelopmentInTeam;

public partial class MainPage : ContentPage
{
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
        "tictactoe_art.png"
        };
    }
}

