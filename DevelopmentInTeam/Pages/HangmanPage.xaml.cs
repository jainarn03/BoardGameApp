namespace DevelopmentInTeam.Pages;

public partial class HangmanPage : ContentPage
{
	public HangmanPage()
	{
		InitializeComponent();
	}
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        // Check if the entered text contains non-letter characters
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            foreach (char c in e.NewTextValue)
            {
                if (!char.IsLetter(c))
                {
                    // Revert back to the old text value if it contains non-letter characters
                    ((Entry)sender).Text = e.OldTextValue;

                    // Set focus back to the entry that contains the non-letter character
                    ((Entry)sender).Focus();

                    break;
                }
            }
        }
    }

    private async void OnRestartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HangmanPage());
        Navigation.RemovePage(this);
    }

    private void Slot0(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);
    }

    private void Slot1(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);
    }
    private void Slot2(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
    private void Slot3(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
    private void Slot4(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
    private void Slot5(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);


    }
    private void Slot6(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
    private void Slot7(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
}