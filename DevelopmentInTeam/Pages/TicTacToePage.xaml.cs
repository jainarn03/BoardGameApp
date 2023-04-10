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
    //Onces button is clicked, page reloads
    private async void NewGame_Clicked(object sender, EventArgs e)
    {
        // adds page to the navigation stack and removes the old one
        await Navigation.PushAsync(new TicTacToePage());
        Navigation.RemovePage(this);

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
        //This if statement checks for middle row completion of X
        if (middleLeftImage.Source != null && middMiddleImage.Source != null && middleRightImage.Source != null)
        {
            if (middleLeftImage.Source is FileImageSource middleLeftSource && middMiddleImage.Source is FileImageSource middMiddleSource && middleRightImage.Source is FileImageSource middleRightSource)
            {
                if (middleLeftSource.File == "purple_x.svg" && middMiddleSource.File == "purple_x.svg" && middleRightSource.File == "purple_x.svg")
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
        // This if statement checks for bottom row completion of X
        if (bottomLeftImage.Source != null && bottomMiddleImage.Source != null && bottomRightImage.Source != null)
        {
            if (bottomLeftImage.Source is FileImageSource bottomLeftSource && bottomMiddleImage.Source is FileImageSource bottomMiddleSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (bottomLeftSource.File == "purple_x.svg" && bottomMiddleSource.File == "purple_x.svg" && bottomRightSource.File == "purple_x.svg")
                {
                    xWinner.IsEnabled = true;
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
        // This if statement checks for left column completion of X
        if (topLeftImage.Source != null && middleLeftImage.Source != null && bottomLeftImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && middleLeftImage.Source is FileImageSource middleLeftSource && bottomLeftImage.Source is FileImageSource bottomLeftSource)
            {
                if (topLeftSource.File == "purple_x.svg" && middleLeftSource.File == "purple_x.svg" && bottomLeftSource.File == "purple_x.svg")
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

        // This if statement checks for middle column completion of X
        if (topMiddleImage.Source != null && middMiddleImage.Source != null && bottomMiddleImage.Source != null)
        {
            //This if statement checks the image that is in each cell for win conditions
            if (topMiddleImage.Source is FileImageSource topMiddleSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomMiddleImage.Source is FileImageSource bottomMiddleSource)
            {

                if (topMiddleSource.File == "purple_x.svg" && middMiddleSource.File == "purple_x.svg" && bottomMiddleSource.File == "purple_x.svg")
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

        // This if statement checks for right column completion of X
        if (topRightImage.Source != null && middleRightImage.Source != null && bottomRightImage.Source != null)
        {
            if (topRightImage.Source is FileImageSource topRightSource && middleRightImage.Source is FileImageSource middleRightSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (topRightSource.File == "purple_x.svg" && middleRightSource.File == "purple_x.svg" && bottomRightSource.File == "purple_x.svg")
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
        //This if statement checks for diagonal completion of X from top-left to bottom-right
        if (topLeftImage.Source != null && middMiddleImage.Source != null && bottomRightImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (topLeftSource.File == "purple_x.svg" && middMiddleSource.File == "purple_x.svg" && bottomRightSource.File == "purple_x.svg")
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

        //This if statement checks for diagonal completion of X from top-right to bottom-left
        if (topRightImage.Source != null && middMiddleImage.Source != null && bottomLeftImage.Source != null)
        {
            if (topRightImage.Source is FileImageSource topRightSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomLeftImage.Source is FileImageSource bottomLeftSource)
            {
                if (topRightSource.File == "purple_x.svg" && middMiddleSource.File == "purple_x.svg" && bottomLeftSource.File == "purple_x.svg")
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
        //This starts the win condition for O
        //This if statement checks for top row completion of O
        if (topLeftImage.Source != null && topMiddleImage.Source != null && topRightImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && topMiddleImage.Source is FileImageSource topMiddleSource && topRightImage.Source is FileImageSource topRightSource)
            {
                if (topLeftSource.File == "blue_circle.svg" && topMiddleSource.File == "blue_circle.svg" && topRightSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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
        //This if statement checks for middle row completion of O
        if (middleLeftImage.Source != null && middMiddleImage.Source != null && middleRightImage.Source != null)
        {
            if (middleLeftImage.Source is FileImageSource middleLeftSource && middMiddleImage.Source is FileImageSource middMiddleSource && middleRightImage.Source is FileImageSource middleRightSource)
            {
                if (middleLeftSource.File == "blue_circle.svg" && middMiddleSource.File == "blue_circle.svg" && middleRightSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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
        // This if statement checks for bottom row completion of O
        if (bottomLeftImage.Source != null && bottomMiddleImage.Source != null && bottomRightImage.Source != null)
        {
            if (bottomLeftImage.Source is FileImageSource bottomLeftSource && bottomMiddleImage.Source is FileImageSource bottomMiddleSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (bottomLeftSource.File == "blue_circle.svg" && bottomMiddleSource.File == "blue_circle.svg" && bottomRightSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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
        // This if statement checks for left column completion of O
        if (topLeftImage.Source != null && middleLeftImage.Source != null && bottomLeftImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && middleLeftImage.Source is FileImageSource middleLeftSource && bottomLeftImage.Source is FileImageSource bottomLeftSource)
            {
                if (topLeftSource.File == "blue_circle.svg" && middleLeftSource.File == "blue_circle.svg" && bottomLeftSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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

        // This if statement checks for middle column completion of O
        if (topMiddleImage.Source != null && middMiddleImage.Source != null && bottomMiddleImage.Source != null)
        {
            if (topMiddleImage.Source is FileImageSource topMiddleSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomMiddleImage.Source is FileImageSource bottomMiddleSource)
            {
                if (topMiddleSource.File == "blue_circle.svg" && middMiddleSource.File == "blue_circle.svg" && bottomMiddleSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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

        // This if statement checks for right column completion of O
        if (topRightImage.Source != null && middleRightImage.Source != null && bottomRightImage.Source != null)
        {
            if (topRightImage.Source is FileImageSource topRightSource && middleRightImage.Source is FileImageSource middleRightSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (topRightSource.File == "blue_circle.svg" && middleRightSource.File == "blue_circle.svg" && bottomRightSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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
        //This if statement checks for diagonal completion of O from top-left to bottom-right
        if (topLeftImage.Source != null && middMiddleImage.Source != null && bottomRightImage.Source != null)
        {
            if (topLeftImage.Source is FileImageSource topLeftSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomRightImage.Source is FileImageSource bottomRightSource)
            {
                if (topLeftSource.File == "blue_circle.svg" && middMiddleSource.File == "blue_circle.svg" && bottomRightSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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

        //This if statement checks for diagonal completion of O from top-right to bottom-left
        if (topRightImage.Source != null && middMiddleImage.Source != null && bottomLeftImage.Source != null)
        {
            if (topRightImage.Source is FileImageSource topRightSource && middMiddleImage.Source is FileImageSource middMiddleSource && bottomLeftImage.Source is FileImageSource bottomLeftSource)
            {
                if (topRightSource.File == "blue_circle.svg" && middMiddleSource.File == "blue_circle.svg" && bottomLeftSource.File == "blue_circle.svg")
                {
                    oWinner.IsVisible = true;
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
        if (topLeftImage.Source != null && topMiddleImage.Source != null && topRightImage.Source != null && middleLeftImage.Source != null && middMiddleImage.Source != null && middleRightImage.Source != null && bottomLeftImage.Source != null && bottomMiddleImage.Source != null && bottomRightImage.Source != null)
            if (xWinner.IsEnabled == false && oWinner.IsEnabled == false)
            {
                NoWinner.IsVisible = true;
                xTurn.IsVisible = false;
                oTurn.IsVisible = false;
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
        winCheck();

    }

    private void MiddMiddle_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), middMiddleImage);
        spotPressed(middMiddle);
        winCheck();

    }

    private void MiddleRight_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), middleRightImage); 
        spotPressed(middleRight);
        winCheck();

    }

    private void BottomLeft_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomLeftImage);  
        spotPressed(bottomLeft);
        winCheck();

    }

    private void BottomMiddle_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomMiddleImage);
        spotPressed(bottomMiddle);
        winCheck();

    }

    private void BottomRight_Clicked(object sender, EventArgs e)
    {
        imageApp(turn(), bottomRightImage);
        spotPressed(bottomRight);
        winCheck();

    }


}