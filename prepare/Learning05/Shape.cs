using System.Security.Cryptography.X509Certificates;
public abstract class Shape
{
    private string __color;
    public Shape(){}
    public Shape(string color){
        SetColor(color);
    }
    public string GetColor()
    {
        return __color;
    }
    public void SetColor(string color)
    {
        __color = color;
    }
    public abstract double GetArea();
    
}