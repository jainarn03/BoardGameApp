// Arnav's Page
namespace DevelopmentInTeam.Pages;

public partial class CheckersPage : ContentPage
{
    int[,] _gameBoard;
    private int _redCount;
    private int _blackCount;
    private int _currentPlayer;

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
        _blackCount = 1;
        _currentPlayer = 1;

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
        int piece = _gameBoard[fromRow, fromCol];

        // Check if the move is valid
        if (!IsValidMove(piece, fromRow, fromCol, toRow, toCol))
        {
            return;
        }

        // Check if a piece was captured
        if (Math.Abs(fromRow - toRow) == 2)
        {
            int capturedRow = (fromRow + toRow) / 2;
            int capturedCol = (fromCol + toCol) / 2;
            int capturedPiece = _gameBoard[capturedRow, capturedCol];
            if (capturedPiece == 1 || capturedPiece == 3)
            {
                _redCount--;
            }
            else if (capturedPiece == 2 || capturedPiece == 4)
            {
                _blackCount--;
            }
            _gameBoard[capturedRow, capturedCol] = 0;
        }

        // Move the piece and update the board
        UpdateBoard(fromRow, fromCol, toRow, toCol);
        CheckResult();

        // Check if the piece should be promoted to a king
        if (_gameBoard[toRow, toCol] == 1 && toRow == 7)
        {
            _gameBoard[toRow, toCol] = 3; // Promote to red king
            Console.WriteLine("Red piece promoted to king!");
        }
        else if (_gameBoard[toRow, toCol] == 2 && toRow == 0)
        {
            _gameBoard[toRow, toCol] = 4; // Promote to black king
            Console.WriteLine("Black piece promoted to king!");
        }

        // Switch the turn to the other player
        _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
    }


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

    public void UpdateBoard(int oldRow, int oldCol, int newRow, int newCol)
    {
        // Check if the piece has captured an opponent's piece
        int capturedRow = (oldRow + newRow) / 2;
        int capturedCol = (oldCol + newCol) / 2;
        int capturedPiece = _gameBoard[capturedRow, capturedCol];
        if (capturedPiece != 0)
        {
            if (capturedPiece == 1 || capturedPiece == 3)
            {
                _redCount--;
            }
            else
            {
                _blackCount--;
            }
            _gameBoard[capturedRow, capturedCol] = 0;
        }

        // Move the piece to the new position
        _gameBoard[newRow, newCol] = _gameBoard[oldRow, oldCol];
        _gameBoard[oldRow, oldCol] = 0;

        // Check if the piece has reached the last row of the opponent's side or if it is a king in the last row
        if (_gameBoard[newRow, newCol] == 1 && (newRow == 7 || (newRow == 6 && _gameBoard[newRow, newCol] == 3)))
        {
            _gameBoard[newRow, newCol] = 3; // promote red piece to king
        }
        else if (_gameBoard[newRow, newCol] == 2 && (newRow == 0 || (newRow == 1 && _gameBoard[newRow, newCol] == 4)))
        {
            _gameBoard[newRow, newCol] = 4; // promote black piece to king
        }

        // Update current player
        _currentPlayer = (_currentPlayer == 1) ? 2 : 1;

        // Print the updated game board
        Console.WriteLine("Updated game board:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(_gameBoard[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private string CheckResult()
    {
        if (_redCount == 0)
        {
            Console.WriteLine("Black Wins!");
            return "Black Wins!";
        }
        else if (_blackCount == 0)
        {
            Console.WriteLine("Red Wins!");
            return "Red Wins!";
        }
        else if (_redCount == 1 && _blackCount == 1)
        {
            Console.WriteLine("Draw!");
            return "Draw!"; // Both have one piece left
        }
        else
        {
            return ""; // Game is still in progress
        }
    }

    #region Image Buttons
    //red peice image button event handler
    private void square_B8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 1;
    }
    private void square_D8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 3;
        
    }
    private void square_F8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 5;
    }
    private void square_H8_red(object sender, EventArgs e)
    {
        int row = 0; int col = 7;
    }
    private void square_A7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 0;
    }
    private void square_C7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 2;
    }
    private void square_E7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 4;
    }
    private void square_G7_red(object sender, EventArgs e)
    {
        int row = 1; int col = 6;
    }
    private void square_B6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 1;
    }
    private void square_D6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 3;
    }
    private void square_F6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 5;
    }
    private void square_H6_red(object sender, EventArgs e)
    {
        int row = 2; int col = 7;
    }
    private void square_A5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 0;
    }
    private void square_C5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 2;
    }
    private void square_E5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 4;
    }
    private void square_G5_red(object sender, EventArgs e)
    {
        int row = 3; int col = 6;
    }
    private void square_B4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 1;
    }
    private void square_D4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 3;
    }
    private void square_F4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 5;
    }
    private void square_H4_red(object sender, EventArgs e)
    {
        int row = 4; int col = 7;
    }
    private void square_A3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 0;
    }
    private void square_C3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 2;
    }
    private void square_E3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 4;
    }
    private void square_G3_red(object sender, EventArgs e)
    {
        int row = 5; int col = 6;
    }
    private void square_B2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 1;
    }
    private void square_D2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 3;
    }
    private void square_F2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 5;
    }
    private void square_H2_red(object sender, EventArgs e)
    {
        int row = 6; int col = 7;
    }
    private void square_A1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 0;
    }
    private void square_C1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 2;
    }
    private void square_E1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 4;
    }
    private void square_G1_red(object sender, EventArgs e)
    {
        int row = 7; int col = 6;
    }


    //black peice image button event handler
    private void square_B8_black(object sender, EventArgs e)
    {
    }
    private void square_D8_black(object sender, EventArgs e)
    {
    }
    private void square_F8_black(object sender, EventArgs e)
    {
    }
    private void square_H8_black(object sender, EventArgs e)
    {
    }
    private void square_A7_black(object sender, EventArgs e)
    {
    }
    private void square_C7_black(object sender, EventArgs e)
    {
    }
    private void square_E7_black(object sender, EventArgs e)
    {
    }
    private void square_G7_black(object sender, EventArgs e)
    {
    }
    private void square_B6_black(object sender, EventArgs e)
    {
    }
    private void square_D6_black(object sender, EventArgs e)
    {
    }
    private void square_F6_black(object sender, EventArgs e)
    {
    }
    private void square_H6_black(object sender, EventArgs e)
    {
    }
    private void square_A5_black(object sender, EventArgs e)
    {
    }
    private void square_C5_black(object sender, EventArgs e)
    {
    }
    private void square_E5_black(object sender, EventArgs e)
    {
    }
    private void square_G5_black(object sender, EventArgs e)
    {
    }
    private void square_B4_black(object sender, EventArgs e)
    {
    }
    private void square_D4_black(object sender, EventArgs e)
    {
    }
    private void square_F4_black(object sender, EventArgs e)
    {
    }
    private void square_H4_black(object sender, EventArgs e)
    {
    }
    private void square_A3_black(object sender, EventArgs e)
    {
    }
    private void square_C3_black(object sender, EventArgs e)
    {
    }
    private void square_E3_black(object sender, EventArgs e)
    {
    }
    private void square_G3_black(object sender, EventArgs e)
    {
    }
    private void square_B2_black(object sender, EventArgs e)
    {
    }
    private void square_D2_black(object sender, EventArgs e)
    {
    }
    private void square_F2_black(object sender, EventArgs e)
    {
    }
    private void square_H2_black(object sender, EventArgs e)
    {
    }
    private void square_A1_black(object sender, EventArgs e)
    {
    }
    private void square_C1_black(object sender, EventArgs e)
    {
    }
    private void square_E1_black(object sender, EventArgs e)
    {
    }
    private void square_G1_black(object sender, EventArgs e)
    {
    }


    //red King peice image button event handler
    private void square_B8_redking(object sender, EventArgs e)
    {
    }
    private void square_D8_redking(object sender, EventArgs e)
    {
    }
    private void square_F8_redking(object sender, EventArgs e)
    {
    }
    private void square_H8_redking(object sender, EventArgs e)
    {
    }
    private void square_A7_redking(object sender, EventArgs e)
    {
    }
    private void square_C7_redking(object sender, EventArgs e)
    {
    }
    private void square_E7_redking(object sender, EventArgs e)
    {
    }
    private void square_G7_redking(object sender, EventArgs e)
    {
    }
    private void square_B6_redking(object sender, EventArgs e)
    {
    }
    private void square_D6_redking(object sender, EventArgs e)
    {
    }
    private void square_F6_redking(object sender, EventArgs e)
    {
    }
    private void square_H6_redking(object sender, EventArgs e)
    {
    }
    private void square_A5_redking(object sender, EventArgs e)
    {
    }
    private void square_C5_redking(object sender, EventArgs e)
    {
    }
    private void square_E5_redking(object sender, EventArgs e)
    {
    }
    private void square_G5_redking(object sender, EventArgs e)
    {
    }
    private void square_B4_redking(object sender, EventArgs e)
    {
    }
    private void square_D4_redking(object sender, EventArgs e)
    {
    }
    private void square_F4_redking(object sender, EventArgs e)
    {
    }
    private void square_H4_redking(object sender, EventArgs e)
    {
    }
    private void square_A3_redking(object sender, EventArgs e)
    {
    }
    private void square_C3_redking(object sender, EventArgs e)
    {
    }
    private void square_E3_redking(object sender, EventArgs e)
    {
    }
    private void square_G3_redking(object sender, EventArgs e)
    {
    }
    private void square_B2_redking(object sender, EventArgs e)
    {
    }
    private void square_D2_redking(object sender, EventArgs e)
    {
    }
    private void square_F2_redking(object sender, EventArgs e)
    {
    }
    private void square_H2_redking(object sender, EventArgs e)
    {
    }
    private void square_A1_redking(object sender, EventArgs e)
    {
    }
    private void square_C1_redking(object sender, EventArgs e)
    {
    }
    private void square_E1_redking(object sender, EventArgs e)
    {
    }
    private void square_G1_redking(object sender, EventArgs e)
    {
    }



    //black King peice image button event handler
    private void square_B8_blackking(object sender, EventArgs e)
    {
    }
    private void square_D8_blackking(object sender, EventArgs e)
    {
    }
    private void square_F8_blackking(object sender, EventArgs e)
    {
    }
    private void square_H8_blackking(object sender, EventArgs e)
    {
    }
    private void square_A7_blackking(object sender, EventArgs e)
    {
    }
    private void square_C7_blackking(object sender, EventArgs e)
    {
    }
    private void square_E7_blackking(object sender, EventArgs e)
    {
    }
    private void square_G7_blackking(object sender, EventArgs e)
    {
    }
    private void square_B6_blackking(object sender, EventArgs e)
    {
    }
    private void square_D6_blackking(object sender, EventArgs e)
    {
    }
    private void square_F6_blackking(object sender, EventArgs e)
    {
    }
    private void square_H6_blackking(object sender, EventArgs e)
    {
    }
    private void square_A5_blackking(object sender, EventArgs e)
    {
    }
    private void square_C5_blackking(object sender, EventArgs e)
    {
    }
    private void square_E5_blackking(object sender, EventArgs e)
    {
    }
    private void square_G5_blackking(object sender, EventArgs e)
    {
    }
    private void square_B4_blackking(object sender, EventArgs e)
    {
    }
    private void square_D4_blackking(object sender, EventArgs e)
    {
    }
    private void square_F4_blackking(object sender, EventArgs e)
    {
    }
    private void square_H4_blackking(object sender, EventArgs e)
    {
    }
    private void square_A3_blackking(object sender, EventArgs e)
    {
    }
    private void square_C3_blackking(object sender, EventArgs e)
    {
    }
    private void square_E3_blackking(object sender, EventArgs e)
    {
    }
    private void square_G3_blackking(object sender, EventArgs e)
    {
    }
    private void square_B2_blackking(object sender, EventArgs e)
    {
    }
    private void square_D2_blackking(object sender, EventArgs e)
    {
    }
    private void square_F2_blackking(object sender, EventArgs e)
    {
    }
    private void square_H2_blackking(object sender, EventArgs e)
    {
    }
    private void square_A1_blackking(object sender, EventArgs e)
    {
    }
    private void square_C1_blackking(object sender, EventArgs e)
    {
    }
    private void square_E1_blackking(object sender, EventArgs e)
    {
    }
    private void square_G1_blackking(object sender, EventArgs e)
    {
    }


    // green dot image button event handler
    private void square_B8_greendot(object sender, EventArgs e)
    {
    }
    private void square_D8_greendot(object sender, EventArgs e)
    {
    }
    private void square_F8_greendot(object sender, EventArgs e)
    {
    }
    private void square_H8_greendot(object sender, EventArgs e)
    {
    }
    private void square_A7_greendot(object sender, EventArgs e)
    {
    }
    private void square_C7_greendot(object sender, EventArgs e)
    {
    }
    private void square_E7_greendot(object sender, EventArgs e)
    {
    }
    private void square_G7_greendot(object sender, EventArgs e)
    {
    }
    private void square_B6_greendot(object sender, EventArgs e)
    {
    }
    private void square_D6_greendot(object sender, EventArgs e)
    {
    }
    private void square_F6_greendot(object sender, EventArgs e)
    {
    }
    private void square_H6_greendot(object sender, EventArgs e)
    {
    }
    private void square_A5_greendot(object sender, EventArgs e)
    {
    }
    private void square_C5_greendot(object sender, EventArgs e)
    {
    }
    private void square_E5_greendot(object sender, EventArgs e)
    {
    }
    private void square_G5_greendot(object sender, EventArgs e)
    {
    }
    private void square_B4_greendot(object sender, EventArgs e)
    {
    }
    private void square_D4_greendot(object sender, EventArgs e)
    {
    }
    private void square_F4_greendot(object sender, EventArgs e)
    {
    }
    private void square_H4_greendot(object sender, EventArgs e)
    {
    }
    private void square_A3_greendot(object sender, EventArgs e)
    {
    }
    private void square_C3_greendot(object sender, EventArgs e)
    {
    }
    private void square_E3_greendot(object sender, EventArgs e)
    {
    }
    private void square_G3_greendot(object sender, EventArgs e)
    {
    }
    private void square_B2_greendot(object sender, EventArgs e)
    {
    }
    private void square_D2_greendot(object sender, EventArgs e)
    {
    }
    private void square_F2_greendot(object sender, EventArgs e)
    {
    }
    private void square_H2_greendot(object sender, EventArgs e)
    {
    }
    private void square_A1_greendot(object sender, EventArgs e)
    {
    }
    private void square_C1_greendot(object sender, EventArgs e)
    {
    }
    private void square_E1_greendot(object sender, EventArgs e)
    {
    }
    private void square_G1_greendot(object sender, EventArgs e)
    {
    }
    #endregion

}