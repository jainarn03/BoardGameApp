// ALEKS' PAGE
using DevelopmentInTeam.Logic;

namespace DevelopmentInTeam.Pages;

public partial class ConnectFourPage : ContentPage
{
    // declaring field for ConnectFourGame class and its corresponding property
    ConnectFourGame _connectFourGame;
    public ConnectFourGame ConnectFourGame => _connectFourGame;

    public ConnectFourPage()
    {
        InitializeComponent();

        // creating new instance of ConnectFourGame class
        _connectFourGame = new ConnectFourGame();
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
                if (ConnectFourGame.GameBoard[row, col] == 1) 
                {
                    button.Background = Color.FromArgb("ce3b28"); // dark color
                }
                else if (ConnectFourGame.GameBoard[row, col] == 2)
                {
                    button.Background = Color.FromArgb("2B5FC7"); // light color
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
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot12Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot13Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot14Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot15Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot16Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot17Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot21Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot22Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot23Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot24Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot25Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot26Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot27Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot31Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot32Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot33Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot34Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot35Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot36Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot37Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot41Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot42Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot43Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot44Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot45Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot46Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot47Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot51Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot52Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot53Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot54Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot55Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot56Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot57Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot61Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(0);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot62Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(1);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot63Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(2);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot64Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(3);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot65Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(4);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot66Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(5);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }

    private void Slot67Clicked(object sender, EventArgs e)
    {
        ConnectFourGame.MakeMove(6);
        UpdateUI();
        HandleGameStatusUI(ConnectFourGame.CheckGameStatus());
    }
    #endregion 

    /// <summary>
    /// Restarts the game when start new game button is clicked, 
    /// by re-enabling the board buttons, resetting the slot colors to empty, and creating a new game instance
    /// </summary>
    private void OnNewGameClicked(object sender, EventArgs e)
    {
        // iterate through all the buttons of the board grid
        foreach (Button button in ConnectFourBoard.Children)
        {
            button.IsEnabled = true; // re-enables them
            button.Background = Color.FromArgb("Edf0f9"); // changes back to empty slot color
        }

        _connectFourGame = new ConnectFourGame(); // resets old game object by assigning its field to new instance 

    }
}