namespace DataAccess;

/// <summary>
/// Calculator class used in XUnit testing project
/// </summary>
public class Calculator
{
    public static double Add(double x, double y)
    {
        return x + y;
    }
    
    public static double Subtract(double x, double y)
    {
        return x - y;
    }  
    
    public static double Multiply(double x, double y)
    {
        return x * y;
    }  
    
    public static double Divide(double x, double y)
    {
        //Instead of returning double.PositiveInfinity
        if (y == 0)
            throw new DivideByZeroException();
        
        return x / y;
    }  
}