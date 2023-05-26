public class Reference
{
    // Class has a private attribute _value of type string used for storing reference value.
    private string _value;

    //  It uses a getter method to return the _value when accessed.
    public string Value
    {
        // Uses a getter to return _value
        get { return _value; }
    }   
    // A constructor Refr() taking parems of string reference
    public Reference(string reference)
    {
        // Value of reference is assigned to the _value
        _value = reference;
    }
}