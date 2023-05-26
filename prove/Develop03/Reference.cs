public class Reference
{
    private string _value; // Private attribute string used for storing reference value

    public string Value // Uses a getter to return _value
    {
        get { return _value; }
    }   
    public Reference(string reference)  //Constructor taking string params of reference
    {
        _value = reference; // Reference is assigned to the _value
    }
}