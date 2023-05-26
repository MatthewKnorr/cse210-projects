public class Word // Provide read only access
{
    private string _text; // Private _text field to store text of words
    private bool _hidden; // Private _hidden field to store hidden status 
    public string Text
    {
        get { return _text; }
    }
    // The properties don't have a setter, so their values can only be set internally within the class
    public bool Hidden
    {
        get { return _hidden; }
    }

    public Word(string text)
    {
        _text = text;
        _hidden = false; 
    }

    public void Hide() // method to change the hidden status of the word
    {
        _hidden = true;
    }

    public void Reveal() // method to change the hidden status of the word
    {
        _hidden = false;
    }
}