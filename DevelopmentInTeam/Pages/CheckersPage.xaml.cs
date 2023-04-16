// Arnav's Page
namespace DevelopmentInTeam.Pages;

public partial class CheckersPage : ContentPage
{
    int[,] _gameBoard;
    private int _redCount;
    private int _blackCount;
    private int _currentPlayer;
    private int _selectedRow;
    private int _selectedCol;

    public CheckersPage()
    {
        _gameBoard = new int[8, 8] {
            { 0, 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 2, 0, 2, 0, 2, 0, 2, 0 },
            { 0, 2, 0, 2, 0, 2, 0, 2 },
            { 2, 0, 2, 0, 2, 0, 2, 0 }
        };

        // Initialize piece counts and current player
        _redCount = 12;
        _blackCount = 12;
        _currentPlayer = 1;
        _selectedCol = -1;
        _selectedRow = -1;
        InitializeComponent();
    }

    private async void newGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CheckersPage()); 
        Navigation.RemovePage(this); // navigation stack recursion here (pushes new page but doesn't pop old one) code changed by aleks 
    }

    private async void mainMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // navigation stack recursion here (pushes to mainpage instead of pop) code changed by aleks 
    }

    public void InitializeBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if ((row + col) % 2 == 0 && row < 3)
                {
                    _gameBoard[row, col] = 2; // black piece
                }
                else if ((row + col) % 2 == 0 && row > 4)
                {
                    _gameBoard[row, col] = 1; // red piece
                }
                else //empty square
                {
                    _gameBoard[row, col] = 0;
                }

                // Initialize red king pieces
                if (_gameBoard[row, col] == 1 && row == 0)
                {
                    _gameBoard[row, col] = 3;
                }

                // Initialize black king pieces
                if (_gameBoard[row, col] == 2 && row == 7)
                {
                    _gameBoard[row, col] = 4;
                }
            }
        }
    }

    public void MovePiece(int fromRow, int fromCol, int toRow, int toCol)
    {
        int piece = _gameBoard[fromRow, fromCol]; // Get the piece to be moved from its original position

        // Check if the move is valid
        if (!IsValidMove(piece, fromRow, fromCol, toRow, toCol))
        {
            return; // If the move is not valid, exit the method
        }

        // Check if a piece was captured
        if (Math.Abs(fromRow - toRow) == 2) // If the move was a jump (i.e., a capture), calculate the captured piece's position
        {
            int capturedRow = (fromRow + toRow) / 2;
            int capturedCol = (fromCol + toCol) / 2;
            int capturedPiece = _gameBoard[capturedRow, capturedCol]; // Get the piece being captured

            if (capturedPiece == 1 || capturedPiece == 3) // If the captured piece was red, decrement the red count
            {
                _redCount--;
            }
            else if (capturedPiece == 2 || capturedPiece == 4) // If the captured piece was black, decrement the black count
            {
                _blackCount--;
            }
            _gameBoard[capturedRow, capturedCol] = 0; // Set the captured piece's position to 0 to signify that it is no longer on the board
        }

        // Move the piece and update the board
        _gameBoard[toRow, toCol] = piece; // Set the piece's new position on the board
        _gameBoard[fromRow, fromCol] = 0; // Set the piece's old position to 0 to signify that it is no longer there
        CheckResult(); // Check if the move resulted in a win or a tie

        // Check if the piece should be promoted to a king
        if (_gameBoard[toRow, toCol] == 1 && toRow == 7) // If the piece is red and has reached the opposite end of the board, promote it to a red king
        {
            _gameBoard[toRow, toCol] = 3;
            Console.WriteLine("Red piece promoted to king!");
        }
        else if (_gameBoard[toRow, toCol] == 2 && toRow == 0) // If the piece is black and has reached the opposite end of the board, promote it to a black king
        {
            _gameBoard[toRow, toCol] = 4;
            Console.WriteLine("Black piece promoted to king!");
        }

        _currentPlayer = (_currentPlayer == 1) ? 2 : 1; // Switch the turn to the other player
    }


    // This method checks if a move is valid by verifying if the target cell is empty,
    // if the piece is moving diagonally, if it's jumping over another piece, if it's jumping over
    // an opponent piece, if the piece is a king, and if it's moving in the correct direction.
    // It takes as input the piece to be moved, the starting row and column, and the ending row and column.
    // It returns a boolean value indicating whether the move is valid or not.
    private bool IsValidMove(int piece, int fromRow, int fromCol, int toRow, int toCol)
    {
        // Check if the target cell is empty
        if (_gameBoard[toRow, toCol] != 0)
        {
            Console.WriteLine("Target cell is not empty. Invalid move.");
            return false;
        }
        // Check if the piece is moving diagonally
        if (Math.Abs(fromRow - toRow) != 1 || Math.Abs(fromCol - toCol) != 1)
        {
            // Check if the piece is jumping over another piece
            if (Math.Abs(fromRow - toRow) != 2 || Math.Abs(fromCol - toCol) != 2)
            {
                Console.WriteLine("Invalid move. The piece can only move diagonally or jump over another piece.");
                return false;
            }

            // Check if the piece is jumping over an opponent piece
            int capturedRow = (fromRow + toRow) / 2;
            int capturedCol = (fromCol + toCol) / 2;
            int capturedPiece = _gameBoard[capturedRow, capturedCol];
            if (piece == 1 && (capturedPiece == 2 || capturedPiece == 4))
            {
                Console.WriteLine("Valid move. The piece can jump over an opponent piece.");
                return true;
            }
            else if (piece == 2 && (capturedPiece == 1 || capturedPiece == 3))
            {
                Console.WriteLine("Valid move. The piece can jump over an opponent piece.");
                return true;
            }
            else if (piece == 3 || piece == 4)
            {
                Console.WriteLine("Valid move. The king can jump over any piece.");
                return true;
            }
            Console.WriteLine("Invalid move. The piece can only jump over an opponent piece.");
            return false;
        }

        // Check if the piece is a king
        bool isKing = (piece == 3 || piece == 4);

        // Check if the piece is moving in the correct direction
        if (!isKing)
        {
            if (piece == 1)
            {
                if (toRow < fromRow)
                {
                    Console.WriteLine("Invalid move. The piece can only move forwards.");
                    return false;
                }
            }
            else if (piece == 2)
            {
                if (toRow > fromRow)
                {
                    Console.WriteLine("Invalid move. The piece can only move backwards.");
                    return false;
                }
            }
        }

        Console.WriteLine("Valid move.");
        return true;
    }

    //chceks the status of the game
        private string CheckResult()
    {
        if (_redCount == 0)
        {
            Console.WriteLine("Black Wins!");
            PlayerTurnIcon.Source = "black_king.png";
            PlayerToMove.Text = "Black Wins!";
            DisplayAlert("Game over!", "Black Won!", "OK");
            StopGame();
            return "Black Wins!";
        }
        else if (_blackCount == 0)
        {
            Console.WriteLine("Red Wins!");
            PlayerTurnIcon.Source = "red_king.png";
            PlayerToMove.Text = "Red Wins!";
            DisplayAlert("Game over!", "Red Won!", "OK");
            StopGame();
            return "Red Wins!";
        }
        else if (_redCount == 1 && _blackCount == 1)
        {
            Console.WriteLine("Draw!");
            DisplayAlert("Game over!", "Draw!", "OK");
            StopGame();
            PlayerTurnIcon.Source = null;
            PlayerToMove.Text = "Draw!";
            return "Draw!"; // Both have one piece left
        }
        else
        {
            return ""; // Game is still in progress
        }
    }

    // This method updates the game board UI
    private void UpdateUI()
    {
        // Update whose turn it is
        UpdatePlayerTurn();

        // Array of desired coordinates
        int[][] desiredSquares = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0, 5 }, new int[] { 0, 7 }, new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 1, 6 }, new int[] { 2, 1 }, new int[] { 2, 3 }, new int[] { 2, 5 }, new int[] { 2, 7 }, new int[] { 3, 0 }, new int[] { 3, 2 }, new int[] { 3, 4 }, new int[] { 3, 6 }, new int[] { 4, 1 }, new int[] { 4, 3 }, new int[] { 4, 5 }, new int[] { 4, 7 }, new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5, 6 }, new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 }, new int[] { 7, 0 }, new int[] { 7, 2 }, new int[] { 7, 4 }, new int[] { 7, 6 } };

        // Update the game board UI for the desired squares
        foreach (int[] square in desiredSquares)
        {
            // Get the row and column of the current square
            int row = square[0];
            int col = square[1];

            // Get the names of the red and black buttons for the current square
            string redButtonName = "red" + (row) + (col);
            string blackButtonName = "black" + (row) + (col);

            // Find the red and black buttons for the current square
            var redbutton = (ImageButton)this.FindByName(redButtonName);
            var blackbutton = (ImageButton)this.FindByName(blackButtonName);

            // If either button is null, skip this square
            if (redbutton == null || blackbutton == null)
            {
                continue;
            }

            // Update the visibility and source of the red and black buttons for the current square
            if (_gameBoard[row, col] == 0)
            {
                // Empty square
                redbutton.IsVisible = false;
                blackbutton.IsVisible = false;
            }
            else if (_gameBoard[row, col] == 1)
            {
                // Red checker
                redbutton.IsVisible = true;
                redbutton.Source = "red_c.png";
            }
            else if (_gameBoard[row, col] == 2)
            {
                // Black checker
                blackbutton.IsVisible = true;
                blackbutton.Source = "black_c.png";
            }
            else if (_gameBoard[row, col] == 3)
            {
                // Red king
                redbutton.IsVisible = true;
                redbutton.Source = "red_king.png";
            }
            else if (_gameBoard[row, col] == 4)
            {
                // Black king
                blackbutton.IsVisible = true;
                blackbutton.Source = "black_king.png";

            }
        }
    }

    //this function updates players turn on the UI by switching between red and black based on the field variable "_currentPlayerTurn"
    public void UpdatePlayerTurn()
    {
        if(_currentPlayer == 1)
        {
            PlayerTurnIcon.Source = "red_c.png";
            PlayerToMove.Text = "Red To Move";
        }
        else if(_currentPlayer == 2)
        {
            PlayerTurnIcon.Source = "black_c.png";
            PlayerToMove.Text = "Black To Move";
        }
    }

    // this function iterated through every button and turns it invisible
    //same foreach as the updateUI function
    public void StopGame()
    {
        int[][] desiredSquares = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0, 5 }, new int[] { 0, 7 }, new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 1, 6 }, new int[] { 2, 1 }, new int[] { 2, 3 }, new int[] { 2, 5 }, new int[] { 2, 7 }, new int[] { 3, 0 }, new int[] { 3, 2 }, new int[] { 3, 4 }, new int[] { 3, 6 }, new int[] { 4, 1 }, new int[] { 4, 3 }, new int[] { 4, 5 }, new int[] { 4, 7 }, new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5, 6 }, new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 }, new int[] { 7, 0 }, new int[] { 7, 2 }, new int[] { 7, 4 }, new int[] { 7, 6 } };

        // Update the game board UI for the desired squares
        foreach (int[] square in desiredSquares)
        {
            int row = square[0];
            int col = square[1];
            string redButtonName = "red" + (row) + (col);
            string blackButtonName = "black" + (row) + (col);

            var redbutton = (ImageButton)this.FindByName(redButtonName);
            var blackbutton = (ImageButton)this.FindByName(blackButtonName);

                redbutton.IsVisible = false;
                blackbutton.IsVisible = false;
        }
    }

    //this function is called by every image button and if a piece is clciked then it saves its coordinates and enables an overlay of greendots that are invisble
    //on the second click the greenbutton is clicked and it saves that coordinates as the destination corodinates and passes all that to make move which makes the move
    private void buttonClicked(int row, int col, int click)
    {
        if ((click == 1) && (_currentPlayer == 1))
        {
            _selectedRow= row;
            _selectedCol= col;
            B8_greendot.IsVisible = true;
            D8_greendot.IsVisible = true;
            F8_greendot.IsVisible = true;
            H8_greendot.IsVisible = true;
            A7_greendot.IsVisible = true;
            C7_greendot.IsVisible = true;
            E7_greendot.IsVisible = true;
            G7_greendot.IsVisible = true;
            B6_greendot.IsVisible = true;
            D6_greendot.IsVisible = true;
            F6_greendot.IsVisible = true;
            H6_greendot.IsVisible = true;
            A5_greendot.IsVisible = true;
            C5_greendot.IsVisible = true;
            E5_greendot.IsVisible = true;
            G5_greendot.IsVisible = true;
            B4_greendot.IsVisible = true;
            D4_greendot.IsVisible = true;
            F4_greendot.IsVisible = true;
            H4_greendot.IsVisible = true;
            A3_greendot.IsVisible = true;
            C3_greendot.IsVisible = true;
            E3_greendot.IsVisible = true;
            G3_greendot.IsVisible = true;
            B2_greendot.IsVisible = true;
            D2_greendot.IsVisible = true;
            F2_greendot.IsVisible = true;
            H2_greendot.IsVisible = true;
            A1_greendot.IsVisible = true;
            C1_greendot.IsVisible = true;
            E1_greendot.IsVisible = true;
            G1_greendot.IsVisible = true;
        }
        else if ((click == 2) && (_currentPlayer == 2))
        {
            _selectedRow = row;
            _selectedCol = col;
            B8_greendot.IsVisible = true;
            D8_greendot.IsVisible = true;
            F8_greendot.IsVisible = true;
            H8_greendot.IsVisible = true;
            A7_greendot.IsVisible = true;
            C7_greendot.IsVisible = true;
            E7_greendot.IsVisible = true;
            G7_greendot.IsVisible = true;
            B6_greendot.IsVisible = true;
            D6_greendot.IsVisible = true;
            F6_greendot.IsVisible = true;
            H6_greendot.IsVisible = true;
            A5_greendot.IsVisible = true;
            C5_greendot.IsVisible = true;
            E5_greendot.IsVisible = true;
            G5_greendot.IsVisible = true;
            B4_greendot.IsVisible = true;
            D4_greendot.IsVisible = true;
            F4_greendot.IsVisible = true;
            H4_greendot.IsVisible = true;
            A3_greendot.IsVisible = true;
            C3_greendot.IsVisible = true;
            E3_greendot.IsVisible = true;
            G3_greendot.IsVisible = true;
            B2_greendot.IsVisible = true;
            D2_greendot.IsVisible = true;
            F2_greendot.IsVisible = true;
            H2_greendot.IsVisible = true;
            A1_greendot.IsVisible = true;
            C1_greendot.IsVisible = true;
            E1_greendot.IsVisible = true;
            G1_greendot.IsVisible = true;
        }
        else if (click == 3)
        {
            MovePiece(_selectedRow, _selectedCol, row, col);
            B8_greendot.IsVisible = false;
            D8_greendot.IsVisible = false;
            F8_greendot.IsVisible = false;
            H8_greendot.IsVisible = false;
            A7_greendot.IsVisible = false;
            C7_greendot.IsVisible = false;
            E7_greendot.IsVisible = false;
            G7_greendot.IsVisible = false;
            B6_greendot.IsVisible = false;
            D6_greendot.IsVisible = false;
            F6_greendot.IsVisible = false;
            H6_greendot.IsVisible = false;
            A5_greendot.IsVisible = false;
            C5_greendot.IsVisible = false;
            E5_greendot.IsVisible = false;
            G5_greendot.IsVisible = false;
            B4_greendot.IsVisible = false;
            D4_greendot.IsVisible = false;
            F4_greendot.IsVisible = false;
            H4_greendot.IsVisible = false;
            A3_greendot.IsVisible = false;
            C3_greendot.IsVisible = false;
            E3_greendot.IsVisible = false;
            G3_greendot.IsVisible = false;
            B2_greendot.IsVisible = false;
            D2_greendot.IsVisible = false;
            F2_greendot.IsVisible = false;
            H2_greendot.IsVisible = false;
            A1_greendot.IsVisible = false;
            C1_greendot.IsVisible = false;
            E1_greendot.IsVisible = false;
            G1_greendot.IsVisible = false;
        }
        else
        {
            return;
        }
    }

    #region Image Buttons
    //red peice image button event handler
    private void square_B8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 1;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_D8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 3;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_F8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 5;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_H8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 7;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_A7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 0;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_C7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 2;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_E7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 4;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_G7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 6;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_B6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 1;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_D6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 3;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_F6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 5;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_H6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 7;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_A5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 0;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_C5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 2;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_E5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 4;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_G5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 6;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_B4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 1;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_D4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 3;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_F4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 5;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_H4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 7;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_A3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 0;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_C3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 2;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_E3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 4;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_G3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 6;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_B2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 1;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_D2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 3;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_F2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 5;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_H2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 7;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_A1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 0;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_C1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 2;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_E1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 4;
        buttonClicked(row, col, 1);
        UpdateUI();
    }
    private void square_G1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 6;
        buttonClicked(row, col, 1);
        UpdateUI();
    }


    //black peice image button event handler
    private void square_B8_black(object sender, EventArgs e)
    {
        int row = 0; int col = 1;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_D8_black(object sender, EventArgs e)
    {
        int row = 0; int col = 3;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_F8_black(object sender, EventArgs e)
    {
        int row = 0; int col = 5;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_H8_black(object sender, EventArgs e)
    {
        int row = 0; int col = 7;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_A7_black(object sender, EventArgs e)
    {
        int row = 1; int col = 0;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_C7_black(object sender, EventArgs e)
    {
        int row = 1; int col = 2;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_E7_black(object sender, EventArgs e)
    {
        int row = 1; int col = 4;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_G7_black(object sender, EventArgs e)
    {
        int row = 1; int col = 6;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_B6_black(object sender, EventArgs e)
    {
        int row = 2; int col = 1;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_D6_black(object sender, EventArgs e)
    {
        int row = 2; int col = 3;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_F6_black(object sender, EventArgs e)
    {
        int row = 2; int col = 5;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_H6_black(object sender, EventArgs e)
    {
        int row = 2; int col = 7;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_A5_black(object sender, EventArgs e)
    {
        int row = 3; int col = 0;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_C5_black(object sender, EventArgs e)
    {
        int row = 3; int col = 2;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_E5_black(object sender, EventArgs e)
    {
        int row = 3; int col = 4;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_G5_black(object sender, EventArgs e)
    {
        int row = 3; int col = 6;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_B4_black(object sender, EventArgs e)
    {
        int row = 4; int col = 1;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_D4_black(object sender, EventArgs e)
    {
        int row = 4; int col = 3;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_F4_black(object sender, EventArgs e)
    {
        int row = 4; int col = 5;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_H4_black(object sender, EventArgs e)
    {
        int row = 4; int col = 7;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_A3_black(object sender, EventArgs e)
    {
        int row = 5; int col = 0;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_C3_black(object sender, EventArgs e)
    {
        int row = 5; int col = 2;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_E3_black(object sender, EventArgs e)
    {
        int row = 5; int col = 4;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_G3_black(object sender, EventArgs e)
    {
        int row = 5; int col = 6;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_B2_black(object sender, EventArgs e)
    {
        int row = 6; int col = 1;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_D2_black(object sender, EventArgs e)
    {
        int row = 6; int col = 3;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_F2_black(object sender, EventArgs e)
    {
        int row = 6; int col = 5;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_H2_black(object sender, EventArgs e)
    {
        int row = 6; int col = 7;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_A1_black(object sender, EventArgs e)
    {
        int row = 7; int col = 0;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_C1_black(object sender, EventArgs e)
    {
        int row = 7; int col = 2;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_E1_black(object sender, EventArgs e)
    {
        int row = 7; int col = 4;
        buttonClicked(row, col, 2);
        UpdateUI();
    }
    private void square_G1_black(object sender, EventArgs e)
    {
        int row = 7; int col = 6;
        buttonClicked(row, col, 2);
        UpdateUI();
    }

    //greendot image buttons
    private void square_B8_greendot(object sender, EventArgs e)
    {
        int row = 0; int col = 1;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_D8_greendot(object sender, EventArgs e)
    {
        int row = 0; int col = 3;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_F8_greendot(object sender, EventArgs e)
    {
        int row = 0; int col = 5;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_H8_greendot(object sender, EventArgs e)
    {
        int row = 0; int col = 7;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_A7_greendot(object sender, EventArgs e)
    {
        int row = 1; int col = 0;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_C7_greendot(object sender, EventArgs e)
    {
        int row = 1; int col = 2;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_E7_greendot(object sender, EventArgs e)
    {
        int row = 1; int col = 4;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_G7_greendot(object sender, EventArgs e)
    {
        int row = 1; int col = 6;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_B6_greendot(object sender, EventArgs e)
    {
        int row = 2; int col = 1;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_D6_greendot(object sender, EventArgs e)
    {
        int row = 2; int col = 3;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_F6_greendot(object sender, EventArgs e)
    {
        int row = 2; int col = 5;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_H6_greendot(object sender, EventArgs e)
    {
        int row = 2; int col = 7;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_A5_greendot(object sender, EventArgs e)
    {
        int row = 3; int col = 0;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_C5_greendot(object sender, EventArgs e)
    {
        int row = 3; int col = 2;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_E5_greendot(object sender, EventArgs e)
    {
        int row = 3; int col = 4;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_G5_greendot(object sender, EventArgs e)
    {
        int row = 3; int col = 6;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_B4_greendot(object sender, EventArgs e)
    {
        int row = 4; int col = 1;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_D4_greendot(object sender, EventArgs e)
    {
        int row = 4; int col = 3;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_F4_greendot(object sender, EventArgs e)
    {
        int row = 4; int col = 5;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_H4_greendot(object sender, EventArgs e)
    {
        int row = 4; int col = 7;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_A3_greendot(object sender, EventArgs e)
    {
        int row = 5; int col = 0;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_C3_greendot(object sender, EventArgs e)
    {
        int row = 5; int col = 2;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_E3_greendot(object sender, EventArgs e)
    {
        int row = 5; int col = 4;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_G3_greendot(object sender, EventArgs e)
    {
        int row = 5; int col = 6;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_B2_greendot(object sender, EventArgs e)
    {
        int row = 6; int col = 1;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_D2_greendot(object sender, EventArgs e)
    {
        int row = 6; int col = 3;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_F2_greendot(object sender, EventArgs e)
    {
        int row = 6; int col = 5;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_H2_greendot(object sender, EventArgs e)
    {
        int row = 6; int col = 7;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_A1_greendot(object sender, EventArgs e)
    {
        int row = 7; int col = 0;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_C1_greendot(object sender, EventArgs e)
    {
        int row = 7; int col = 2;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_E1_greendot(object sender, EventArgs e)
    {
        int row = 7; int col = 4;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    private void square_G1_greendot(object sender, EventArgs e)
    {
        int row = 7; int col = 6;
        buttonClicked(row, col, 3);
        UpdateUI();
    }
    #endregion

}