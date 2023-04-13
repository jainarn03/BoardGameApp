
namespace DevelopmentInTeam.Pages;

public partial class WordlePage : ContentPage
{
    public WordlePage()
    {
        InitializeComponent();
    }

    private void NextLetter(Entry disableCurrent, Entry input)
    {
      
            disableCurrent.Unfocus();
            input.Focus();
            disableCurrent.IsEnabled = false;

        
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
    private void check(Entry CurrentEntry, Entry NextEntry)
    {
        if (!string.IsNullOrWhiteSpace(CurrentEntry.Text) && CurrentEntry.Text.All(char.IsLetter))
        {
            NextLetter(CurrentEntry, NextEntry);
        }
    }
    private void LetterEntry1(object sender, TextChangedEventArgs e)
    {
        
            OnTextChanged(sender, e);

            check(singleLetterEntry1, singleLetterEntry2);

        

    }
    private void LetterEntry2(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry2, singleLetterEntry3);   
    }
    private void LetterEntry3(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry3, singleLetterEntry4);
    }
    private void LetterEntry4(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry4, singleLetterEntry5);
    }
    private void LetterEntry5(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry5, singleLetterEntry6);
    }
    private void LetterEntry6(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry6, singleLetterEntry7);
    }
    private void LetterEntry7(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry7, singleLetterEntry8);
    }
    private void LetterEntry8(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry8, singleLetterEntry9);

    }
    private void LetterEntry9(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry9, singleLetterEntry10);

    }
    private void LetterEntry10(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry10, singleLetterEntry11);

    }
    private void LetterEntry11(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry11, singleLetterEntry12);

    }
    private void LetterEntry12(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry12, singleLetterEntry13);

    }
    private void LetterEntry13(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry13, singleLetterEntry14);

    }
    private void LetterEntry14(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry14, singleLetterEntry15);

    }
    private void LetterEntry15(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry15, singleLetterEntry16);

    }
    private void LetterEntry16(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry16, singleLetterEntry17);

    }
    private void LetterEntry17(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry17, singleLetterEntry18);

    }
    private void LetterEntry18(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry18, singleLetterEntry19);

    }
    private void LetterEntry19(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry19, singleLetterEntry20);

    }
    private void LetterEntry20(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry20, singleLetterEntry21);

    }
    private void LetterEntry21(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry21, singleLetterEntry22);

    }
    private void LetterEntry22(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry22, singleLetterEntry23);

    }
    private void LetterEntry23(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry23, singleLetterEntry24);

    }
    private void LetterEntry24(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry24, singleLetterEntry25);

    }
    private void LetterEntry25(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry25, singleLetterEntry26);

    }
    private void LetterEntry26(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry26, singleLetterEntry27);

    }
    private void LetterEntry27(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry27, singleLetterEntry28);

    }
    private void LetterEntry28(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry28, singleLetterEntry29);

    }
    private void LetterEntry29(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry29, singleLetterEntry30);

    }
    private void LetterEntry30(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry30, singleLetterEntry31);

    }
    private void LetterEntry31(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry31, singleLetterEntry32);

    }
    private void LetterEntry32(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry32, singleLetterEntry33);

    }
    private void LetterEntry33(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry33, singleLetterEntry34);

    }
    private void LetterEntry34(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry34, singleLetterEntry35);

    }
    private void LetterEntry35(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

        check(singleLetterEntry35, singleLetterEntry36);

    }
    private void LetterEntry36(object sender, TextChangedEventArgs e)
    {
        OnTextChanged(sender, e);

    }
    private async void Restartclick(object sender, EventArgs e)
        {
            // adds page to the navigation stack and removes the old one
            await Navigation.PushAsync(new WordlePage());
            Navigation.RemovePage(this);
        }
}
