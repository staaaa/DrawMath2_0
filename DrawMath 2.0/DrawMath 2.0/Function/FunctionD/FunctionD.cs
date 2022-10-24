using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawMath
{
    public class FunctionD
    {
        //input
        public string input;
        public double[] przedzial;
        public double[] przedzialMonoEkst;
        public double punktGranica;
        public double dokladnosc;
        public double punktPochodna;

        //obliczane potem
        public double Oy;
        public int monot;
        public int monotWPrzedziale;
        public List<double> miejscaZerowe;
        public double granicaWPunkcie;
        public List<double> graniceNaKoncach;
        public Ekstrema ekst;
        public List<double> dziedzinaFunkcji;
        public string pochodna;
        //public Dictionary<double, double> asymptoty;
        public FunctionD(string input, double[] przedzial, double[] przedzialMonoEkst, double punktGranica, double dokladnosc, double punktPochodna)
        {
            this.input = input;
            this.przedzial = przedzial;
            this.przedzialMonoEkst = przedzialMonoEkst;
            this.punktGranica = punktGranica;
            this.dokladnosc = dokladnosc;
            this.punktPochodna = punktPochodna;

            miejscaZerowe = new List<double>();
            graniceNaKoncach = new List<double>();
            dziedzinaFunkcji = new List<double>();

            Oy = checkOy(input);
            monot = checkMonot(input);
            monotWPrzedziale = checkMonot(input);
            granicaWPunkcie = countExpression(input, punktGranica);
            graniceNaKoncach.Add(countExpression(input, przedzial[0]));
            graniceNaKoncach.Add(countExpression(input, przedzial[1]));
            ekst = new Ekstrema(input, przedzialMonoEkst[0], przedzialMonoEkst[1]);
            dziedzinaFunkcji = CountDziedzinaFunkcji(input, przedzial);
            pochodna = countPochodna(input);
        }
    
        public int checkMonot(string input)
        {
            List<int> test1 = new List<int>();
            int monot=0;
            double min = countExpression(input, -10.1);

                for (double i = -10; i <= 10; i = i + 0.1)
                {
                    double test = countExpression(input, Math.Round(i, 2));
                    if (min < test)
                    {
                        //ROSNIE
                        min = test;
                        monot = 0;
                        test1.Add(monot);
                    }
                    else if (min > test)
                    {
                        //MALEJE
                        min = test;
                        monot = 1;
                        test1.Add(monot);
                    }
                    else if (min == test)
                    {
                        //STALA
                        min = test;
                        monot = 2;
                        test1.Add(monot);
                    }
                }
                if (test1.Distinct().Skip(1).Any())
                {
                    //STACHU?? NIEMONOTONICZNE TO
                    return 3;
                }
            

            return monot;
        }
        

        public double checkOy(string input)
        {
            int x = 0;
            return countExpression(input, x);
        }

        public async Task countMiejscaZerowe(double[] przedzial, double lastX)
        {
            await Task.Run(() =>
            {
                for (var i = przedzial[0]; i < przedzial[1]; i++)
                {
                    double X = Convert.ToDouble(new Expression("solve(" + input + ",x," + lastX + "," + przedzial[1] + ")").calculate());
                    if (!double.IsNaN(X))
                    {

                        if (!miejscaZerowe.Contains(Math.Round(X,2)))
                        {
                            miejscaZerowe.Add(Math.Round(X, 2));
                        }
                    }
                    
                }
            });          
        }

        public string countPochodna(string input)
        {
            Expression e = new Expression("der("+input+", x,"+punktPochodna+")");
            return e.calculate().ToString();
        }
        //dzielenie przez zero - pierwiastek
        public List<double> CountDziedzinaFunkcji(string input, double[] przedzial)
        {
            List<double> rzeczyWyrzuconeZDziedziny = new List<double>();
            for (double i = przedzial[0]; i < przedzial[1]; i += 0.1)
            {
                double test = 0;
                test = countExpression(input, Math.Round(i, 2));
                if (double.IsNaN(test))
                {
                    rzeczyWyrzuconeZDziedziny.Add(Math.Round(i, 2));
                }
            }
            return rzeczyWyrzuconeZDziedziny;
        }

        public double countExpression(string input, double x)
        {
            return Convert.ToDouble(new Expression("(" + input.Substring(input.IndexOf('=') + 1).Replace("|", string.Empty).Replace("x", "(" + Convert.ToString(x) + ")").Replace(",", ".") + ")").calculate());
        }
    }

}