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
    public void winCheck()
    //This starts the win condition for X
    {   //This if statement checks for top line completion of X
        if (topLeftImage.Source != null && topMiddleImage.Source != null && topRightImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && topMiddleImage.Source is FileImageSource topMiddleSource && topRightImage.Source is FileImageSource topRightSource)
            {
                if (topLeftSource.File == "purple_x.svg" && topMiddleSource.File == "purple_x.svg" && topRightSource.File == "purple_x.svg")
                {
                    xWinner.IsVisible = true;
                    topLeft.IsEnabled = false;
                    topRight.IsEnabled = false;
                    topMiddle.IsEnabled = false;
                    middleLeft.IsEnabled = false;
                    middleRight.IsEnabled = false;
                    middMiddle.IsEnabled = false;
                    bottomLeft.IsEnabled = false;
                    bottomMiddle.IsEnabled = false;
                    bottomRight.IsEnabled = false;
                    xTurn.IsVisible = false;
                    oTurn.IsVisible = false;
                }
            }

        }
    }
        private void TopLeft_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), topLeftImage);
        spotPressed(topLeft);
        winCheck();
    }

    private void TopMiddle_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), topMiddleImage);
        spotPressed(topMiddle);
        winCheck();

    }

    private void TopRight_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), topRightImage);
        winCheck();
        spotPressed(topRight);
    }

    private void MiddleLeft_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), middleLeftImage);
        spotPressed(middleLeft);
    }

    private void MiddMiddle_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), middMiddleImage);
        spotPressed(middMiddle);
    }

    private void MiddleRight_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), middleRightImage); 
        spotPressed(middleRight);
    }

    private void BottomLeft_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomLeftImage);  
        spotPressed(bottomLeft);
    }

    private void BottomMiddle_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomMiddleImage);
        spotPressed(bottomMiddle);
    }

    private void BottomRight_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomRightImage);
        spotPressed(bottomRight);
    }

 
}