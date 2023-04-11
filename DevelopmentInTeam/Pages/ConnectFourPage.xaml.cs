namespace DevelopmentInTeam.Pages;

public partial class ConnectFourPage : ContentPage
{
    // creating a 2D array for the board with 6 rows and 7 columns
    int[,] _gameBoard = new int[6, 7];

    public ConnectFourPage()
    {
        InitializeComponent();

        // ***** START OF GAME LOGIC HERE TEMPORARILY ***** will think about separation of concerns later.

        InitializeBoard(); // board initialized and all slots are empty

        MakeMove(2);
        MakeMove(2);
        MakeMove(2);
    }

    /// <summary>
    /// Initializes the board, iterating through each element of gameBoard and setting its value to 0.
    /// </summary>
    public void InitializeBoard()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                _gameBoard[row, col] = 0;
            }
        }
    }

    /// <summary>
    /// Used to determine which player's turn it is to move.
    /// Iterates through each element of the gameBoard and counts the number of non-zero elements.
    /// If the number is even (remainder of 0) then it is Player 1's turn to move,
    /// if the number is odd (remainder not 0) then it is Player 2's turn to move.
    /// </summary>
    /// <returns>true if Player 1's turn, false if Player 2's turn</returns>
    public bool IsPlayer1Turn()
    {
        int count = 0;
        
        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row < 6; row++)
            {
                if (_gameBoard[row, col] != 0)
                {
                    count++;
                }
            }
        }
        return count % 2 == 0;
    }

    /// <summary>
    /// Main method for making a move and updating the board if valid move was made.
    /// Takes whichever column was selected, checks if it is full or not, finds lowest empty slot, then
    /// updates the board with the new slot claimed by the player with the current turn.
    /// </summary>
    /// <param name="col">selected column</param>
    /// <returns>bool indicating if the move was successful or not</returns>
    public bool MakeMove(int col)
    {
        // checking if the selected column is full
        if (_gameBoard[5, col] != 0)
        {
            return false;
        }

        // applying gravity: finding the lowest empty slot
        // searching the rows from the bottom up, will stop once a row for the selected column is empty.
        int row = 0;
        while (_gameBoard[row, col] != 0) 
        {
            row++;
        }

        // when valid slot is found:
        int slotClaimed = IsPlayer1Turn() ? 1 : 2; // sets the value of the slot to the player with the current turn
        _gameBoard[row, col] = slotClaimed; // updates the board with the new slot claimed

        return true; // returns true as move has succeeded
    }

    /// <summary>
    /// test method to see if makemove method works
    /// </summary>
    /// <returns>number of slots claimed</returns>
    public int SlotsClaimed()
    {
        int count = 0;
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (_gameBoard[row, col] != 0)
                    count++;
            }
        }

        return count;
    }

    /// <summary>
    /// test button for whatever purposes
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

       DisplayAlert(SlotsClaimed().ToString(), "s", "ok");
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
    #endregion Slots Clicked Event Handlers

    /// <summary>
    /// reloads the ConnectFourPage by pushing new one to the stack then removing the old page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConnectFourPage());
        Navigation.RemovePage(this);
    }
}