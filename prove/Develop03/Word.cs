public class Word
{   
    // Define private fields to store text of words and hidden status 
    private string _text;
    private bool _hidden;

    // Defines two properties that povide read only access to the _text and _hidden fields 
    
    public string Text
    {
        get { return _text; }
    }
    // The properties don't have a setter, so their values can only be set internally within the class
    public bool Hidden
    {
        get { return _hidden; }
    }

    // initializes the _text field with the value of the text parameter & sets the _hidden field to false
    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // method to change the hidden status of the word
    public void Hide()
    {
        _hidden = true;
    }

    // method to change the hidden status of the word
    public void Reveal()
    {
        _hidden = false;
    }
}