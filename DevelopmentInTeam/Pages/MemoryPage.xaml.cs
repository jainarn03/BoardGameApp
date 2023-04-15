namespace DevelopmentInTeam.Pages;

public partial class MemoryPage : ContentPage
{
	public MemoryPage()
	{
		InitializeComponent();
	}

    private async void OnNewGameClicked(object sender, EventArgs e)
    {
        // adds page to the navigation stack and removes the old one
        await Navigation.PushAsync(new MemoryPage());
        Navigation.RemovePage(this);
    }
}