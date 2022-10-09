using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawMath
{
    public class FunctionP : Function
    {
        public Dictionary<double, double> Evaluate(float accuracy, double[] przedzial)
        {
            return GetFunctionPoints(GetInput(), accuracy, przedzial);
        }

        private double CalcY(string input, double x)
        {
            return Convert.ToDouble(new Expression("(" + input.Substring(input.IndexOf('=') + 1).Replace("|", string.Empty).Replace("x", "(" + Convert.ToString(x) + ")").Replace(",", ".") + ")*(-1)").calculate());
        }
        private double CalcYAbs(string input, double x)
        {
            return AbsoluteValue(Convert.ToDouble(new Expression("(" + input.Substring(input.IndexOf('=') + 1).Replace("|", string.Empty).Replace("x", "(" + Convert.ToString(x) + ")").Replace(",", ".") + ")*(-1)").calculate()));
        }
        private Dictionary<double, double> GetFunctionPoints(string input, float accuracy, double[] przedzial)
        {
            Dictionary<double, double> FunctionPoints = new Dictionary<double, double>();
            for (double i = przedzial[0] ; i <= przedzial[1]; i += accuracy)
            {
                if (input.Contains("|"))
                {
                    FunctionPoints.Add(Math.Round(i, 2), CalcYAbs(input, Math.Round(i, 2)) * -1);
                }
                else FunctionPoints.Add(Math.Round(i, 2), CalcY(input, Math.Round(i, 2)));
            }
            return FunctionPoints;
        }
        private double AbsoluteValue(double value)
        {
            if (value > 0)
            {
                return value;
            }
            return value * -1;
        }
    }
}
