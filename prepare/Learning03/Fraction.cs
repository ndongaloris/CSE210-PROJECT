public class Fraction{
    private int _top;
    private int _bottom;
    public void fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public void fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public  void fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    public void GetTop()
    {
        Console.WriteLine(_top);
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public void GetBottom()
    {
        Console.WriteLine(_bottom);
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    public void GetFractionString()
    {
        Console.WriteLine($"{_top}/{_bottom}");
    }
    public double GetDecimalValue()
    {
       return (double)_top/(double)_bottom;
    }
}