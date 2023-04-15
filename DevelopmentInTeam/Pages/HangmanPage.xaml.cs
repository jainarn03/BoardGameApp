namespace DevelopmentInTeam.Pages;

public partial class HangmanPage : ContentPage
{
    public HangmanPage()
    {
        InitializeComponent();
    }
    int imagechange = 0;

    private void LetterOnlyCheck(object sender, TextChangedEventArgs e)
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
    private void NextLetter(Entry CurrentEntry, Entry NextEntry)
    {
        NextEntry.IsEnabled = true;
        NextEntry.Focus();
        CurrentEntry.IsEnabled = false;
    }

    private async void OnRestartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HangmanPage());
        Navigation.RemovePage(this);
    }

    private void EnterGuess(object sender, EventArgs e)

    {
        string prompt = "findings";
        if (!string.IsNullOrEmpty(UserInput.Text))
        {
            string entry = UserInput.Text.ToLower(); // get the text from the UserInput entry box

            if (!string.IsNullOrEmpty(entry) && prompt.Contains(entry.ToLower()))
            {
                for (int i = 0; i < prompt.Length; i++)
                {
                    if (prompt[i] == entry[0])
                    {
                        string SlotName = "Slot" + i.ToString();
                        Entry slot = (Entry)FindByName(SlotName);
                        slot.Text = entry;
                    }
                    else
                    {

                        switch (imagechange)
                        {
                            case 0:
                                HangmanImage.Source = "hangmanhead.svg";
                                imagechange++;
                                break;
                            case 1:
                                HangmanImage.Source = "hangmanbody.svg";
                                imagechange++;
                                break;
                            case 2:
                                HangmanImage.Source = "hangmanleg.svg";
                                imagechange++;
                                break;
                            case 3:
                                HangmanImage.Source = "hangmanarm.svg";
                                imagechange++;
                                break;
                            case 4:
                                HangmanImage.Source = "hangmanarm2.svg";
                                imagechange++;
                                break;
                            case 5:
                                HangmanImage.Source = "hangmanfull.svg";
                                imagechange++;
                                break;

                        }
                    }
                }





            }

        }
    }
}