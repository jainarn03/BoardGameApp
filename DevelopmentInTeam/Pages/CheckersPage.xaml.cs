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

    #region Image Buttons
    //red peice image button event handler
    private void square_B8_red(object sender, EventArgs e)
    {
        _gameBoard[0, 1] = 1;
    }
    private void square_D8_red(object sender, EventArgs e)
    {
    }
    private void square_F8_red(object sender, EventArgs e)
    {
    }
    private void square_H8_red(object sender, EventArgs e)
    {
    }
    private void square_A7_red(object sender, EventArgs e)
    {
    }
    private void square_C7_red(object sender, EventArgs e)
    {
    }
    private void square_E7_red(object sender, EventArgs e)
    {
    }
    private void square_G7_red(object sender, EventArgs e)
    {
    }
    private void square_B6_red(object sender, EventArgs e)
    {
    }
    private void square_D6_red(object sender, EventArgs e)
    {
    }
    private void square_F6_red(object sender, EventArgs e)
    {
    }
    private void square_H6_red(object sender, EventArgs e)
    {
    }
    private void square_A5_red(object sender, EventArgs e)
    {
    }
    private void square_C5_red(object sender, EventArgs e)
    {
    }
    private void square_E5_red(object sender, EventArgs e)
    {
    }
    private void square_G5_red(object sender, EventArgs e)
    {
    }
    private void square_B4_red(object sender, EventArgs e)
    {
    }
    private void square_D4_red(object sender, EventArgs e)
    {
    }
    private void square_F4_red(object sender, EventArgs e)
    {
    }
    private void square_H4_red(object sender, EventArgs e)
    {
    }
    private void square_A3_red(object sender, EventArgs e)
    {
    }
    private void square_C3_red(object sender, EventArgs e)
    {
    }
    private void square_E3_red(object sender, EventArgs e)
    {
    }
    private void square_G3_red(object sender, EventArgs e)
    {
    }
    private void square_B2_red(object sender, EventArgs e)
    {
    }
    private void square_D2_red(object sender, EventArgs e)
    {
    }
    private void square_F2_red(object sender, EventArgs e)
    {
    }
    private void square_H2_red(object sender, EventArgs e)
    {
    }
    private void square_A1_red(object sender, EventArgs e)
    {
    }
    private void square_C1_red(object sender, EventArgs e)
    {
    }
    private void square_E1_red(object sender, EventArgs e)
    {
    }
    private void square_G1_red(object sender, EventArgs e)
    {
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