using System;
public class Fraction
{   
    // The class should have two attributes for the top and bottom numbers.
    // Make sure the attributes are private.
    private int _top;
    private int _bottom;
    
    // Constructor that has no parameters that initializes the number to 1/1.
    public Fraction(){
        _top = 1;
        _bottom = 1;
    }
    
    // Constructor that has one parameter the top and that initializes the denominator to 1.example is wholeNumber/1 or 5/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    
    // Constructor that has two parameters, one for the top and one for the bottom.
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString(){
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue(){
        return (double)_top / (double)_bottom;
    }

}