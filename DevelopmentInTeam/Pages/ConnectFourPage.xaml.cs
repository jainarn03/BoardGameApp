namespace DevelopmentInTeam.Pages;

public partial class ConnectFourPage : ContentPage
{
	public ConnectFourPage()
	{
		InitializeComponent();
	}

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