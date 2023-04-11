namespace DevelopmentInTeam.Pages;

public partial class ConnectFourPage : ContentPage
{
	public ConnectFourPage()
	{
		InitializeComponent();

            // START OF GAME LOGIC HERE TEMPORARILY, will think about separation of concerns later.

        // creating a 2D array for the board with 6 rows and 7 columns
        int[,] gameBoard = new int[6, 7];

        // initializing the board, iterating through each element of gameBoard and setting its value to 0
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                gameBoard[i, j] = 0;
            }
        }




    }

    /// <summary>
    /// reloads the ConnectFourPage by pushing new one to the stack then removing the old page
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConnectFourPage());
        Navigation.RemovePage(this);
    }

    /// <summary>
    /// test button for seeing properties of the slots may be changed
    /// </summary>
    private void OnTestClicked(object sender, EventArgs e)
    {
        Slot11.Background = Color.FromArgb("89CFF0");
        Slot12.Background = Color.FromArgb("5440d4");
        Slot21.Background = Color.FromArgb("89CFF0");
        Slot22.Background = Color.FromArgb("5440d4");
        Slot31.Background = Color.FromArgb("89CFF0");
        Slot32.Background = Color.FromArgb("5440d4");
        Slot41.Background = Color.FromArgb("89CFF0");
        Slot42.Background = Color.FromArgb("5440d4");

    }

    #region
    private void Slot11Clicked(object sender, EventArgs e)
    {

    }

    private void Slot12Clicked(object sender, EventArgs e)
    {

    }

    private void Slot13Clicked(object sender, EventArgs e)
    {

    }

    private void Slot14Clicked(object sender, EventArgs e)
    {

    }

    private void Slot15Clicked(object sender, EventArgs e)
    {

    }

    private void Slot16Clicked(object sender, EventArgs e)
    {

    }

    private void Slot17Clicked(object sender, EventArgs e)
    {

    }

    private void Slot21Clicked(object sender, EventArgs e)
    {

    }

    private void Slot22Clicked(object sender, EventArgs e)
    {

    }

    private void Slot23Clicked(object sender, EventArgs e)
    {

    }

    private void Slot24Clicked(object sender, EventArgs e)
    {

    }

    private void Slot25Clicked(object sender, EventArgs e)
    {

    }

    private void Slot26Clicked(object sender, EventArgs e)
    {

    }

    private void Slot27Clicked(object sender, EventArgs e)
    {

    }

    private void Slot31Clicked(object sender, EventArgs e)
    {

    }

    private void Slot32Clicked(object sender, EventArgs e)
    {

    }

    private void Slot33Clicked(object sender, EventArgs e)
    {

    }

    private void Slot34Clicked(object sender, EventArgs e)
    {

    }

    private void Slot35Clicked(object sender, EventArgs e)
    {

    }

    private void Slot36Clicked(object sender, EventArgs e)
    {

    }

    private void Slot37Clicked(object sender, EventArgs e)
    {

    }

    private void Slot41Clicked(object sender, EventArgs e)
    {

    }

    private void Slot42Clicked(object sender, EventArgs e)
    {

    }

    private void Slot43Clicked(object sender, EventArgs e)
    {

    }

    private void Slot44Clicked(object sender, EventArgs e)
    {

    }

    private void Slot45Clicked(object sender, EventArgs e)
    {

    }

    private void Slot46Clicked(object sender, EventArgs e)
    {

    }

    private void Slot47Clicked(object sender, EventArgs e)
    {

    }

    private void Slot51Clicked(object sender, EventArgs e)
    {

    }

    private void Slot52Clicked(object sender, EventArgs e)
    {

    }

    private void Slot53Clicked(object sender, EventArgs e)
    {

    }

    private void Slot54Clicked(object sender, EventArgs e)
    {

    }

    private void Slot55Clicked(object sender, EventArgs e)
    {

    }

    private void Slot56Clicked(object sender, EventArgs e)
    {

    }

    private void Slot57Clicked(object sender, EventArgs e)
    {

    }

    private void Slot61Clicked(object sender, EventArgs e)
    {

    }

    private void Slot62Clicked(object sender, EventArgs e)
    {

    }

    private void Slot63Clicked(object sender, EventArgs e)
    {

    }

    private void Slot64Clicked(object sender, EventArgs e)
    {

    }

    private void Slot65Clicked(object sender, EventArgs e)
    {

    }

    private void Slot66Clicked(object sender, EventArgs e)
    {

    }

    private void Slot67Clicked(object sender, EventArgs e)
    {

    }
    #endregion Slots Clicked Event Handler

}