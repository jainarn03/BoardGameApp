// ALEKS' PAGE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentInTeam.Logic
{
    /// <summary>
    /// Class containing all the game logic for connect four.
    /// Contains methods for initializing board, checking turns, making moves and checking wins/draws.
    /// </summary>
    public class ConnectFourGame
    {
        // declaring game board field
        private int[,] _gameBoard;

        public int[,] GameBoard // getter/setter for game board field
        {
            get => _gameBoard;
            set => _gameBoard = value;
        }

        /// <summary>
        /// class constructor, creating a 2D array for the board with 6 rows and 7 columns
        /// includes InitializeBoard() method as it is impossible to create a valid ConnectFourGame object without it
        /// </summary>
        public ConnectFourGame()
        {
            GameBoard = new int[6, 7]; // 2D array, 6 rows by 7 columns
            InitializeBoard(); // method starts the game, therefore included in constructor.
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

        /*/// <summary>
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

    }
}
