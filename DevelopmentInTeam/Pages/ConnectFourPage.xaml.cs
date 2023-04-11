// ALEKS' PAGE
namespace DevelopmentInTeam.Pages;

public partial class ConnectFourPage : ContentPage
{
    // creating a 2D array for the board with 6 rows and 7 columns
    int[,] _gameBoard = new int[6, 7];

    public ConnectFourPage()
    {
        InitializeComponent();

        // ***** START OF GAME LOGIC HERE TEMPORARILY ***** will think about separation of concerns later.

        // starts Connect Four
        InitializeBoard(); // board initialized and all slots are empty
    }

    /// <summary>
    /// Initializes the board, iterating through each element of _gameBoard and setting its value to 0.
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
    /// Iterates through each element of the _gameBoard and counts the number of non-zero elements.
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
    /// Checks the board to see if there is currently a winner, called every time a move is made.
    /// checks row/column/diagonal winners, checks for a draw.
    /// </summary>
    /// <returns>0 if no player has won yet, 1 if Player 1 wins, 2 if Player 2 wins, 3 if draw</returns>
    public int CheckGameStatus() // IGNORE: maybe more appropriate name for future: CheckGameStatus? (implementing draw check, yet a draw is a win for both players...)
    {
        // checks for wins among the ROWS
        for (int row = 0; row < 6; row++)
        {
            // only necessary to iterate up to fourth column, slots for columns 5-7 will still be spanned (DO SAME FOR COLUMN CHECK)
            for (int col = 0; col < 4; col++) 
            {
                int slot = _gameBoard[row, col]; // sets the current slot
                
                // checks for four consecutive slots in a single row
                // checking the slots of same row but next 3 columns, if all four slots share the same value: returns the slot
                if (slot != 0 && slot == _gameBoard[row, col + 1] && slot == _gameBoard[row, col + 2] && slot == _gameBoard[row, col + 3])
                {
                    return slot; // returns slot value which corresponds to a win if 1/2 or just 0 if empty consecutive rows
                }
            }
        }

        // checks for wins among the COLUMNS
        for (int col = 0; col < 7; col++)
        {
            // iterates up to third row
            for (int row = 0; row < 3; row++) 
            {
                int slot = _gameBoard[row, col]; // sets the current slot

                // checks for four consective slots in a single column, incrementing the row and returning slot when four slots share the same value
                if (slot != 0 && slot == _gameBoard[row + 1, col] && slot == _gameBoard[row + 2, col] && slot == _gameBoard[row + 3, col]) 
                {
                    return slot; 
                }
            }
        }

        // checks for wins among the DIAGONALS

            // checking in direction going up-right
        // iterate up to third row (going upwards, the three rows above will be checked)
        for (int row = 0; row < 3; row++)
        {
            // iterates up to fourth column
            for (int col = 0; col < 4; col++)
            {
                int slot = _gameBoard[row, col]; // current slot

                // checks for four consecutive slots in diagonal, incrementing both row and column (going up and right)
                if (slot != 0 && slot == _gameBoard[row + 1, col + 1] && slot == _gameBoard[row + 2, col + 2] && slot == _gameBoard[row + 3, col + 3])
                {
                    return slot;
                }
            }
        }

            // checking in direction going down-right
        // iterating between rows 4-6 (going downwards, rows 3 and under are checked)
        for (int row = 3; row < 6; row++) 
        {
            for (int col = 0; col < 4; col++)
            {
                int slot = _gameBoard[row, col]; // current slot

                // checks for four consecutive slots in diagonal, decrementing row while incrementing column (going down and right)
                if (slot != 0 && slot == _gameBoard[row - 1, col + 1] && slot == _gameBoard[row - 2, col + 2] && slot == _gameBoard[row - 3, col + 3])
                {
                    return slot;
                }
            }
        }

        // checks if game is unfinished (for case of no winner up until now while empty slots remain)
        for (int col = 0; col < 7; col++)
        {
            if (_gameBoard[5, col] == 0) // if any empty slots exist on the top row
            {
                return 0; // game unfinished, still proceeding
            }
        }

        // draw, no empty slots and yet no winners found.
        return 3;
    }

    /// <summary>
    /// updates the board in the UI (every slot is a button in a 7x6 grid)
    /// finds the corresponding button by name for each slot and changes its color to represent the tiles of both players.
    /// </summary>
    public void UpdateUI()
    {
        // iterates through all the slots in the board
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                // sets a string to the button name corresponding to each slot
                string buttonName = "Slot" + (row + 1) + (col + 1);

                // uses the Element.FindByName(string) method to find the button name of the slot (needed in changing its background color property)
                // docu https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.element.findbyname?view=net-maui-7.0
                // discovered on https://stackoverflow.com/questions/74344580/get-the-name-of-a-element-net-maui-xamarin-forms
                var button = (Button)this.FindByName(buttonName);  

                // changes the slot's color with respect to the player
                if (_gameBoard[row, col] == 1)
                {
                    button.Background = Color.FromArgb("5440d4"); 
                }
                else if (_gameBoard[row, col] == 2)
                {
                    button.Background = Color.FromArgb("89CFF0");
                }
            }
        }
    }

    /// <summary>
    /// Displays alert if there is a winner/draw message to be made
    /// </summary>
    /// <param name="winner">taken from CheckWinner() method</param>
    public void HandleGameStatusUI(int winner)
    {
        if (winner == 0)
        {
            return;
        }
        else if (winner == 1)
        {
            DisplayAlert("Game over!", "Player 1 has won.", "OK");
            TerminateGame();
        }
        else if (winner == 2)
        {
            DisplayAlert("Game over!", "Player 2 has won.", "OK");
            TerminateGame();
        }

        else if (winner == 3)
        {
            DisplayAlert("Game over!", "Draw.", "OK");
            TerminateGame();
        }
    }
    
    // method for ending the game, stops input from the UI:
    // iterates through every button child element of the board's grid and disables each one
    public void TerminateGame()
    {
        foreach (Button button in ConnectFourBoard.Children)
        {
            button.IsEnabled = false;
        }
    }

/*    /// <summary>
    /// TEST (no longer used)
    /// method to see if makemove method works
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
    }*/

    /// <summary>
    /// TEST
    /// button for whatever purposes
    /// </summary>
    private void OnTestClicked(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Event handler region for the slot buttons clicked on the ConnectFourBoard grid.
    /// SlotXYClicked: X = row number from the bottom up, Y = column number from left to right.
    /// Parameter for MakeMove() method is the specific slot's column.
    /// UpdateUI() method displays the current board on the UI.
    /// CheckGameStatus() method checks the current board's game status,
    /// then it is passed as a parameter in HandleGameStatus() which will handle the display alerts and disabling the controls
    /// </summary>
    #region
    private void Slot11Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot12Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot13Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot14Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot15Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot16Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot17Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot21Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot22Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot23Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot24Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot25Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot26Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot27Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot31Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot32Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot33Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot34Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot35Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot36Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot37Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot41Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot42Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot43Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot44Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
    }

    private void Slot45Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot46Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot47Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot51Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot52Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot53Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot54Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot55Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot56Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot57Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot61Clicked(object sender, EventArgs e)
    {
        MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot62Clicked(object sender, EventArgs e)
    {
        MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot63Clicked(object sender, EventArgs e)
    {
        MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot64Clicked(object sender, EventArgs e)
    {
        MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot65Clicked(object sender, EventArgs e)
    {
        MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot66Clicked(object sender, EventArgs e)
    {
        MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }

    private void Slot67Clicked(object sender, EventArgs e)
    {
        MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(CheckGameStatus());
    }
    #endregion 

    /// <summary>
    /// reloads the ConnectFourPage by pushing new one to the stack then removing the old page
    /// </summary>
    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConnectFourPage());
        Navigation.RemovePage(this);
    }
}