using System;
using org.mariuszgromada.math.mxparser;

public class Ekstrema
{
    public string input;
    public double start;
    public double end;
    public double max;
    public double min;

    public Ekstrema(string input, double start, double end)
    {
        this.input = input;
        this.start = start;
        this.end = end;

        max = countMax(this.input, this.start, this.end);
        min = countMin(this.input, this.start, this.end);

    }
    private double countMax(string input, double start, double end)
    {
        double max = countExpression(input, start);
        for(double i = start; i < end; i+=0.1)
        {
            if(countExpression(input, i) > max){
                max = countExpression(input, i);
            }
        }
        return max;
    }
    private double countMin(string input, double start, double end)
    {
        double min = countExpression(input, start);
        for(double i = start; i < end; i+=0.1)
        {
            if(countExpression(input, i) < min){
                min = countExpression(input, i);
            }
        }
        return min;
    }
    private double countExpression(string input, double x)
    {
        return Convert.ToDouble(new Expression("(" + input.Substring(input.IndexOf('=') + 1).Replace("|", string.Empty).Replace("x", "(" + Convert.ToString(x) + ")").Replace(",", ".") + ")").calculate());
    }
}
