namespace DevelopmentInTeam.Pages;

public partial class CheckersPage : ContentPage
{
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
}