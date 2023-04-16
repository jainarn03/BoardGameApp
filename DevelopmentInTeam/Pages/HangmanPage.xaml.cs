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
"activity",
"appendix",
"athletic",
"bacteria",
"boundary",
"building",
"calendar",
"casualty",
"category",
"ceremony",
"chemical",
"civilian",
"clinical",
"colonial",
"complain",
"compound",
"concrete",
"constant",
"contract",
"convince",
"coverage",
"creation",
"criminal",
"detailed",
"dialogue",
"directly",
"disabled",
"disorder",
"distinct",
"doctrine",
"dominate",
"dramatic",
"duration",
"educated",
"efficacy",
"election",
"eligible",
"emphasis",
"endeavor",
"envelope",
"estimate",
"eventual",
"exchange",
"exercise",
"extended",
"facility",
"featured",
"frequent",
"function",
"generate",
"genomics",
"goodwill",
"graduate",
"graphics",
"grateful",
"handling",
"heritage",
"historic",
"homepage",
"hospital",
"identity",
"imperial",
"included",
"industry",
"informed",
"initiate",
"integral",
"interior",
"intimate",
"judgment",
"junction",
"keyboard",
"language",
"learning",
"lifetime",
"likewise",
"location",
"magazine",
"maintain",
"majority",
"marriage",
"material",
"maximize",
"measured",
"medicine",
"memorial",
"merchant",
"military",
"minister",
"mobility",
"moderate",
"movement",
"national",
"negative",
"nineteen",
"observer",
"offshore",
"operator",
"optimism",
"ordinary",
"original",
"overcome",
"overseas",
"painting",
"patience",
"periodic",
"personal",
"pipeline",
"platform",
"positive",
"powerful",
"precious",
"presence",
"preserve",
"pressure",
"producer",
"progress",
"property",
"protocol",
"provided",
"province",
"quantity",
"rational",
"received",
"recovery",
"register",
"relation",
"reliable",
"religion",
"renowned",
"reporter",
"research",
"resource",
"response",
"revision",
"sampling",
"schedule",
"security",
"sentence",
"sequence",
"shipping",
"software",
"solution",
"somewhat",
"speaking",
"specific",
"standing",
"struggle",
"suburban",
"suitable",
"superior",
"surprise",
"sweeping",
"symbolic",
"tactical",
"tangible",
"terminal",
"thinking",
"thousand",
"tracking",
"treasury",
"triangle",
"ultimate",
"unlawful",
"valuable",
"vertical",
"volatile",
            };

        // Select a random word from the list and store it in a field
        Random rand = new Random();
        randomWord = eightLetterWords[rand.Next(0, eightLetterWords.Count)];
    }


    private async void OnMainMenuClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);

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

