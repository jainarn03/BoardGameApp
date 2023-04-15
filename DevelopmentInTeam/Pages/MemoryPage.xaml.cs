// ALEKS' PAGE
using DevelopmentInTeam.Logic;

namespace DevelopmentInTeam.Pages;

public partial class MemoryPage : ContentPage
{
    // declaring field for MemoryGame class and its corresponding property
    MemoryGame _memoryGame;

    public MemoryGame MemoryGame => _memoryGame;

	public MemoryPage()
	{
		InitializeComponent();

        // creating new instance of MemoryGame class
        _memoryGame = new MemoryGame();
	}

    /// <summary>
    /// 1-12 Card clicked EventHandlers region
    /// </summary>
    #region
    private void Card11Clicked(object sender, EventArgs e)
    {

    }
    private void Card12Clicked(object sender, EventArgs e)
    {

    }

    private void Card13Clicked(object sender, EventArgs e)
    {

    }

    private void Card21Clicked(object sender, EventArgs e)
    {

    }
    private void Card22Clicked(object sender, EventArgs e)
    {

    }

    private void Card23Clicked(object sender, EventArgs e)
    {

    }

    private void Card31Clicked(object sender, EventArgs e)
    {

    }
    private void Card32Clicked(object sender, EventArgs e)
    {

    }

    private void Card33Clicked(object sender, EventArgs e)
    {

    }

    private void Card41Clicked(object sender, EventArgs e)
    {

    }
    private void Card42Clicked(object sender, EventArgs e)
    {

    }

    private void Card43Clicked(object sender, EventArgs e)
    {

    }

    #endregion

    /// <summary>
    ///  new game clicked eventhandler reloads the page
    /// </summary>
    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        // adds page to the navigation stack and removes the old one
        await Navigation.PushAsync(new MemoryPage());
        Navigation.RemovePage(this);
    }

}