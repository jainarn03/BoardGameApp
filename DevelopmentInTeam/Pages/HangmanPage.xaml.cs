namespace DevelopmentInTeam.Pages;

public partial class HangmanPage : ContentPage
{

    List<string> userEntries = new List<string>();

    int imagechange = 0;
    private List<string> eightLetterWords;

    // Declare a field to store the selected random word
    private string randomWord;
    public HangmanPage()
    {
        InitializeComponent();
        eightLetterWords = new List<string>
            {

"accuracy",

            };

        // Select a random word from the list and store it in a field
        Random rand = new Random();
        randomWord = eightLetterWords[rand.Next(0, eightLetterWords.Count)];
    }


    private async void OnMainMenuClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // navigation stack recursion here (pushes to mainpage instead of pop) code changed by aleks 
    }
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
 

    private async void OnRestartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HangmanPage());
        Navigation.RemovePage(this);
    }

    private void EnterGuess(object sender, EventArgs e)
    {

        string prompt = randomWord;
        if (!string.IsNullOrEmpty(UserInput.Text))
        {
            string entry = UserInput.Text.ToLower(); // get the text from the UserInput entry box




            if (prompt.Contains(entry.ToLower()))
            {
                for (int i = 0; i < prompt.Length; i++)
                {
                    if (prompt[i] == entry[0])
                    {
                        string SlotName = "Slot" + i.ToString();
                        Entry slot = (Entry)FindByName(SlotName);
                        slot.Text = entry.ToUpper();

                    }
                }

            }

            else
            {
                String Originaltext = Used.Text;

                if (!userEntries.Contains(entry))
                {
                    userEntries.Add(entry);
                    Used.Text = Originaltext + " " + entry.ToUpper();




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
                            DisplayAlert("You Lost", "Sorry, the correct word was " + randomWord, "OK");
                            UserInput.IsEnabled = false;
                            break;

                    }
                }

            }

        }

        string combinedWord = Slot0.Text + Slot1.Text + Slot2.Text + Slot3.Text + Slot4.Text + Slot5.Text + Slot6.Text + Slot7.Text;
        if (combinedWord == randomWord.ToUpper())
        {
            DisplayAlert("Congratulations", "You Won", "OK");

        }





    }

}

