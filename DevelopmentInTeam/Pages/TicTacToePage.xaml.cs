namespace DevelopmentInTeam.Pages;

public partial class TicTacToePage : ContentPage
{
    int playerTurn = 0;

    public TicTacToePage()
	{
		InitializeComponent();
	}
    public void spotPressed(Button spot)
    {
        spot.IsEnabled = false;

    }
    public String turn()
    {
        //Determines players turn using even and odd counter, also displays whos turn it is
        playerTurn++;
        String imageturn;
        if (playerTurn % 2 == 0)
        {
            imageturn = "purple_x.svg";

            oTurn.IsVisible = true;
            xTurn.IsVisible = false;
        }
        else
        {
            imageturn = "blue_circle.svg";
            xTurn.IsVisible = true;
            oTurn.IsVisible = false;
        }
        return imageturn;
    }
    //This method makes either an X or an O appear depending on the turn
    public void imageApp(string imageturn, Image image)
    {
        image.IsVisible = true;
        image.Source = ImageSource.FromFile(imageturn);
    }
    //Onces button is clicked, app restarts
    private void NewGame_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }

        private void TopLeft_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), topLeftImage);
        spotPressed(topLeft);
    }

    private void TopMiddle_Clicked(object sender, EventArgs e)
    {
        spotPressed(topMiddle);
    }

    private void TopRight_Clicked(object sender, EventArgs e)
    {
        spotPressed(topRight);
    }

    private void MiddleLeft_Clicked(object sender, EventArgs e)
    {
        spotPressed(middleLeft);
    }

    private void MiddMiddle_Clicked(object sender, EventArgs e)
    {
        spotPressed(middMiddle);
    }

    private void MiddleRight_Clicked(object sender, EventArgs e)
    {
        spotPressed(middleRight);
    }

    private void BottomLeft_Clicked(object sender, EventArgs e)
    {
        spotPressed(bottomLeft);
    }

    private void BottomMiddle_Clicked(object sender, EventArgs e)
    {
        spotPressed(bottomMiddle);
    }

    private void BottomRight_Clicked(object sender, EventArgs e)
    {
        spotPressed(bottomRight);
    }

 
}