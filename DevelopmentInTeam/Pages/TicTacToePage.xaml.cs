namespace DevelopmentInTeam.Pages;

public partial class TicTacToePage : ContentPage
{
	public TicTacToePage()
	{
		InitializeComponent();
	}
    public void spotPressed(Button spot)
    {
        spot.IsEnabled = false;

    }
    private void TopLeft_Clicked(object sender, EventArgs e)
    {
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

    private void NewGame_Clicked(object sender, EventArgs e)
    {
        spotPressed(NewGame);
    }
}