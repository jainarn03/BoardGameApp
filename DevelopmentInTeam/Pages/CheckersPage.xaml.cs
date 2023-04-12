// Arnav's Page
namespace DevelopmentInTeam.Pages;

public partial class CheckersPage : ContentPage
{
    int[,] _gameBoard = new int[8, 8]; 
	public CheckersPage()
	{
		InitializeComponent();
	}

    private void newGameClicked(object sender, EventArgs e)
    {

    }

    private async void mainMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    public void InitializeBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                _gameBoard[row, col] = 0;
            }
        }
    }

    #region Image Buttons

    // red peices image buttons
    private void square_B8(object sender, EventArgs e)
    {
    }
    private void square_D8(object sender, EventArgs e)
    {

    }
    private void square_F8(object sender, EventArgs e)
    {

    }
    private void square_H8(object sender, EventArgs e)
    {

    }
    private void square_A7(object sender, EventArgs e)
    {

    }
    private void square_C7(object sender, EventArgs e)
    {

    }
    private void square_E7(object sender, EventArgs e)
    {

    }
    private void square_G7(object sender, EventArgs e)
    {

    }
    private void square_B6(object sender, EventArgs e)
    {

    }
    private void square_D6(object sender, EventArgs e)
    {

    }
    private void square_F6(object sender, EventArgs e)
    {

    }
    private void square_H6(object sender, EventArgs e)
    {

    }

    //black peices image buttons
    private void square_A3(object sender, EventArgs e)
    {

    }
    private void square_C3(object sender, EventArgs e)
    {

    }
    private void square_E3(object sender, EventArgs e)
    {

    }
    private void square_G3(object sender, EventArgs e)
    {

    }
    private void square_B2(object sender, EventArgs e)
    {

    }
    private void square_D2(object sender, EventArgs e)
    {

    }
    private void square_F2(object sender, EventArgs e)
    {

    }
    private void square_H2(object sender, EventArgs e)
    {

    }
    private void square_A1(object sender, EventArgs e)
    {

    }
    private void square_C1(object sender, EventArgs e)
    {

    }
    private void square_E1(object sender, EventArgs e)
    {

    }
    private void square_G1(object sender, EventArgs e)
    {

    }

    //non image buttons
    private void square_A5(object sender, EventArgs e)
    {

    }
    private void square_C5(object sender, EventArgs e)
    {

    }
    private void square_E5(object sender, EventArgs e)
    {

    }
    private void square_G5(object sender, EventArgs e)
    {

    }
    private void square_B4(object sender, EventArgs e)
    {

    }
    private void square_D4(object sender, EventArgs e)
    {

    }
    private void square_F4(object sender, EventArgs e)
    {

    }
    private void square_H4(object sender, EventArgs e)
    {

    }
    #endregion

}