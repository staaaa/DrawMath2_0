using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;

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

        //obliczane potem
        public double Oy;
        public int monot;
        public int monotWPrzedziale;
        public List<double> miejscaZerowe;
        public double granicaWPunkcie;
        public List<double> graniceNaKoncach;
        public Ekstrema ekst;
        public List<double> dziedzinaFunkcji;
        //public Dictionary<double, double> asymptoty;
        public FunctionD(string input, double[] przedzial, double[] przedzialMonoEkst, double punktGranica, double dokladnosc)
        {
            this.input = input;
            this.przedzial = przedzial;
            this.przedzialMonoEkst = przedzialMonoEkst;
            this.punktGranica = punktGranica;
            this.dokladnosc = dokladnosc;

            miejscaZerowe = new List<double>();
            countMiejscaZerowe(input, przedzial);

            graniceNaKoncach = new List<double>();
            dziedzinaFunkcji = new List<double>();

            Oy = checkOy(input);
            monot = checkMonotonicznosc(input, przedzial);
            monotWPrzedziale = checkMonotonicznosc(input, przedzialMonoEkst);
            granicaWPunkcie = countExpression(input, punktGranica);
            graniceNaKoncach.Add(countExpression(input, przedzial[0]));
            graniceNaKoncach.Add(countExpression(input, przedzial[1]));
            ekst = new Ekstrema(input, przedzialMonoEkst[0], przedzialMonoEkst[1]);
            dziedzinaFunkcji = CountDziedzinaFunkcji(input, przedzial);
        }

        public int checkMonotonicznosc(string input, double[] przedzial)
        {
            int monot = 0;
            for (double i = przedzial[0]; i < przedzial[1]; i += 0.1)
            {
                //ROSNĄCA
                if (countExpression(input, i) < countExpression(input, i + 0.1))
                {
                    monot = 1;
                }
            }
            for (double i = przedzial[0]; i < przedzial[1]; i += 0.1)
            {
                //STAŁA
                if (countExpression(input, i) == countExpression(input, i + 0.1))
                {
                    monot = 2;
                }
            }
            for (double i = przedzial[0]; i < przedzial[1]; i += 0.1)
            {
                //MALEJACA
                if (countExpression(input, i) > countExpression(input, i + 0.1))
                {
                    double x = 0;
                    x = countExpression(input, i);
                    monot = 3;
                }
            }
            for (double i = przedzial[0]; i < przedzial[1]; i += 0.1)
            {
                //MALEJACA
                if (countExpression(input, i) > countExpression(input, i + 0.1) || countExpression(input, i) < countExpression(input, i + 0.1))
                {
                    monot = 0;
                }
            }
            return monot;
        }

        public double checkOy(string input)
        {
            int x = 0;
            return countExpression(input, x);
        }

        public void countMiejscaZerowe(string input, double[] przedzial)
        {
            for(double i = przedzial[0]; i < przedzial[1]; i+= 0.01)
            {
                double X = Convert.ToDouble(new Expression("solve(" + input + ",x," + i + "," + przedzial[1] + ")").calculate());
                if (!double.IsNaN(X))
                {
                    miejscaZerowe.Add(X);
                }
            }   
        }

        public Dictionary<double, double> countAsymptoty(string input)
        {
            throw new NotImplementedException();
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