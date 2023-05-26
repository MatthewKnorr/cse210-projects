using System;

// Contains the logic for tracking singles words Hidden status and altaring its value
class Word
{
    // Defines properties Text and Hidden with specific modifers to access get/set behavior
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    // The constructor Word(str txt) is called when a new instance of the Word class is created.
    public Word(string text)
    {
        // Takes the parameter text and assigns its value to the Text property of the Word object
        Text = text;
        // It also sets the initial value of the Hidden property to false, indicating that the word is not hidden.
        Hidden = false;
    }
    // method sets the Hidden property of the Word object to true, indicating that the word should be hidden   
    public void Hide()
    {
        Hidden = true;
    }

    // Method sets the Hidden property of the Word object to false, indicating that the word should be revealed
    public void Reveal()
    {
        Hidden = false;
    }
}