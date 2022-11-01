using DrawMath;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawMath_2._0
{
    public partial class Form1 : Form
    {
        FunctionP f1 = new FunctionP();
        Pen Function = new Pen(Color.Red, 3);
        Pen Asymptota = new Pen(Color.DarkBlue, 2);
        Pen blackThick = new Pen(Color.Black, 2);
        Pen blackThin = new Pen(Color.Black, 1);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        ColorDialog XY = new ColorDialog();
        ColorDialog F = new ColorDialog();
        ColorDialog T = new ColorDialog();
        public Form1()
        {
            InitializeComponent();
            BoxDokladnosc.SelectedItem = "Mała dokładność";
        }

        private async void btnDraw_Click(object sender, EventArgs e)
        {
            double[] przedzial = { -10, 10 };
            double[] przedzialMonot;
            double punktGranica;
            double dokladnosc = 0;
            Bitmap bmp = new Bitmap(fBox.Width, fBox.Height);
            Graphics grap = Graphics.FromImage(bmp);
            PointF point1 = new PointF();
            PointF point2 = new PointF();
            Dictionary<double, double> Points = new Dictionary<double, double>();
            PointF point11 = new PointF();
            PointF point22 = new PointF();
            double j = przedzial[0];
            double k = 10;

            await CheckTextbox();
            punktGranica = setPunktGranica(txtBoxGranica.Text);
            przedzialMonot = new double[] { double.Parse(txtBoxMonot1.Text), double.Parse(txtBoxMonot2.Text) };
            showMessage();
            label6.Text = convertString(txtBoxInput.Text);
            f1.SetInput(label6.Text);

            //setup
            FunctionD fDane = new FunctionD(label6.Text, przedzial, przedzialMonot, punktGranica, dokladnosc, Convert.ToDouble(txtBoxPochodna.Text));
            grap.FillRectangle(whiteBrush, new Rectangle(0, 0, 506, 506));
            await DrawPoints(j, k, grap);

            if (BoxDokladnosc.SelectedIndex == 0)
            {
                Points = f1.Evaluate(1f, przedzial);
                dokladnosc = 1f;
            }
            else if (BoxDokladnosc.SelectedIndex == 1)
            {
                Points = f1.Evaluate(0.1f, przedzial);
                dokladnosc = 0.1f;
            }
            else
            {
                Points = f1.Evaluate(0.01f, przedzial);
                dokladnosc = 0.01f;
            }

            point11.X = 250;
            point11.Y = 0;
            point22.X = 250;
            point22.Y = 500;
            grap.DrawLine(blackThick, point11, point22);
            point11.X = 0;
            point11.Y = 250;
            point22.X = 500;
            point22.Y = 250;
            grap.DrawLine(blackThick, point11, point22);

            var trygFunc = checkTrygFunc();
            await drawFunction(Points, point1, point2, trygFunc, grap, fDane);
            //DANE O FUNKCJI
            double dokladnoscPrzeciecia = Convert.ToDouble(fDane.Oy.ToString());
            txtOy.Text = Math.Round(dokladnoscPrzeciecia, 5).ToString();
            checkSwitchMonot(fDane);
            await fDane.countMiejscaZerowe(przedzial, przedzial[0]);
            txtZerowe.Text = "";
            foreach (double x in fDane.miejscaZerowe)
            {
                txtZerowe.Text += x.ToString() + "; ";
            }
            txtGranicaPunkt.Text = Math.Round(fDane.granicaWPunkcie, 4).ToString();
            string txtGraniceNaKoncach = "";
            foreach (double x in fDane.graniceNaKoncach)
            {
                txtGraniceNaKoncach += Math.Round(x, 2).ToString() + "; ";
            }
            txtGraniceKoniec.Text = txtGraniceNaKoncach;
            txtEkstrema.Text = "Max: " + fDane.ekst.max + ", Min: " + fDane.ekst.min;
            if (fDane.dziedzinaFunkcji.Count() == 0)
            {
                txtDziedzina.Text = @"Wszystkie
liczby rzeczywiste";
            }
            else
            {
                string allX = "";
                foreach (double x in fDane.dziedzinaFunkcji)
                {
                    allX += x.ToString() + ", ";
                }
                txtDziedzina.Text = @"Rzeczywiste 
z wyłączeniem 
{ " + allX + " }";
            }
            txtPochodna.Text = Math.Round(Convert.ToDouble(fDane.pochodna), 4).ToString();
            MessageBox.Show("WYKRES NARYSOWANY!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fBox.Image = bmp;
            label6.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Pliki graficzne (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fBox.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            if (F.ShowDialog() == DialogResult.OK)
            {
                btnF.BackColor = F.Color;
                Function = new Pen(F.Color, 3);
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            if (T.ShowDialog() == DialogResult.OK)
            {
                btnT.BackColor = T.Color;
                whiteBrush = new SolidBrush(T.Color);
            }
        }

        private void txtBoxInput_TextChanged(object sender, EventArgs e)
        {
            List<char> operators = new List<char>() { '+', '-', '/', '*', '=', ' ', '|', };
            if (txtBoxInput.Text.Contains("^") && operators.Contains(txtBoxInput.Text[txtBoxInput.Text.Length - 1]))
            {
                txtBoxInput.Text = FormatPower(txtBoxInput.Text);
                txtBoxInput.SelectionStart = txtBoxInput.Text.Length;
                txtBoxInput.SelectionLength = 0;
            }
            if (txtBoxInput.Text.Contains("sqrt") && operators.Contains(txtBoxInput.Text[txtBoxInput.Text.Length - 1]))
            {
                txtBoxInput.Text = FormatSqareRoot(txtBoxInput.Text);
                txtBoxInput.SelectionStart = txtBoxInput.Text.Length;
                txtBoxInput.SelectionLength = 0;
            }
        }

        private string convertString(string input)
        {
            var newInput = input;
            newInput = newInput.Replace("⁰", "^0").Replace("¹", "^1").Replace("²", "^2").Replace("³", "^3").Replace("⁴", "^4").Replace("⁵", "^5").Replace("⁶", "^6").Replace("³", "^7").Replace("³", "^8").Replace("⁹", "^9");
            int i = 1;
            if (newInput.Contains("√"))
            {
                while (true)
                {
                    if (newInput[newInput.IndexOf("√") + i] != ' ')
                    {
                        i++;
                    }
                    else break;
                }
                newInput = newInput.Insert(newInput.IndexOf("√") + i, ")").Replace("√", "sqrt(");
            }

            return newInput;
        }
        static string FormatPower(string sentence)
        {
            string pattern = @"(ctg|tg|cos|sin|\)|\||x|\d)+(\^(\d+))";

            MatchCollection matches = Regex.Matches(sentence, pattern);

            foreach (Match match in matches)
            {
                // string.groups pobiera kolekcję grup dopasowane przez wyrażenie regularne - regex ktory jest wyzej.
                // grupa 2 = np. ^2
                string numberWithPower = match.Groups[2].Value;
                //grupa 3 analogicznie do przypadku wyżej = np. 2
                string number = match.Groups[3].Value;

                string formattedNumber = NumberToSuperscriptPower(number);

                sentence = sentence.Replace(numberWithPower, formattedNumber);
            }
            return sentence;
        }
        static string NumberToSuperscriptPower(string number)
        {
            char[] powers = { '⁰', '¹', '²', '³', '⁴', '⁵', '⁶', '⁷', '⁸', '⁹' };

            StringBuilder output = new StringBuilder();

            foreach (char num in number)
            {
                int index = (int)num - 48;
                output.Append(powers[index]);
            }

            return output.ToString();
        }
        static string FormatSqareRoot(string sentence)
        {
            Console.WriteLine(sentence);
            string pattern = @"sqrt(\((\d+|x)\))";
            MatchCollection matches = Regex.Matches(sentence, pattern);

            foreach (Match match in matches)
            {
                string numberWithSquareRoot = match.Groups[0].Value;
                string number = match.Groups[2].Value;

                sentence = sentence.Replace(numberWithSquareRoot, "√" + number);
            }
            return sentence;
        }

        private void txtMonotPrzedzial_Click(object sender, EventArgs e)
        {

        }

        private void txtEkstrema_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async Task CheckTextbox()
        {
            if (txtBoxMonot1.Text == "")
            {
                txtBoxMonot1.Text = "0";
                await Task.Run(() =>
                {
                    MessageBox.Show("Brak wartości dla pola Monotoniczność!");
                });
            }

            if (txtBoxMonot2.Text == "")
            {
                txtBoxMonot2.Text = "0";
                await Task.Run(() =>
                {
                    MessageBox.Show("Brak wartości dla pola Ekstrema!");
                });
            }
            if (txtBoxGranica.Text == "")
            {
                txtBoxGranica.Text = "0";
                await Task.Run(() =>
                {
                    MessageBox.Show("Brak wartości dla pola Granica!");
                });
            }
            if (txtBoxPochodna.Text == "")
            {
                txtBoxPochodna.Text = "0";
                await Task.Run(() =>
                {
                    MessageBox.Show("Brak wartości dla pola Pochodna!");
                });
            }

        }
        private async Task DrawPoints(double j, double k, Graphics grap)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 501; i += 25)
                {
                    grap.DrawLine(blackThin, i, 255, i, 245);
                    grap.DrawLine(blackThin, 245, i, 255, i);

                    grap.DrawString(j.ToString(), new Font("Calibri", 6), blackBrush, i - 2, 265);
                    grap.DrawString(k.ToString(), new Font("Calibri", 6), blackBrush, 235, i - 2);
                    j++;
                    k--;
                }
            });
        }
        private double setPunktGranica(string value)
        {
            return double.Parse(value);
        }
        private void showMessage()
        {
            MessageBox.Show("Trwa rysowanie wykresu. Proszę czekać.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string checkTrygFunc()
        {
            if ((f1.GetInput().Contains("tg") || f1.GetInput().Contains("tan")) && f1.GetInput().Contains("c") == false)
            {
                return "tg";
            }
            else if (f1.GetInput().Contains("ctg") || f1.GetInput().Contains("cotan"))
            {
                return "ctg";
            }
            return "";
        }
        private async Task drawFunction(Dictionary<double, double> Points, PointF point1, PointF point2, string trygFunc, Graphics grap, FunctionD fDane)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < Points.Count() - 1; i++)
                {
                    point1.X = float.Parse(Convert.ToString(Points.Keys.Skip(i).First())) * 25 + 250;
                    point1.Y = float.Parse(Convert.ToString(Points.Values.Skip(i).First())) * 25 + 250;

                    point2.X = float.Parse(Convert.ToString(Points.Keys.Skip(i + 1).First())) * 25 + 250;
                    point2.Y = float.Parse(Convert.ToString(Points.Values.Skip(i + 1).First())) * 25 + 250;
                    if (trygFunc != "tg" && trygFunc != "ctg" && !float.IsNaN(point1.Y) && !float.IsNaN(point2.Y))
                    {
                        grap.DrawLine(Function, point1, point2);
                    }
                    else if (trygFunc == "tg")
                    {
                        if (point1.Y > point2.Y)
                        {
                            grap.DrawLine(Function, point1, point2);
                        }
                    }
                    else if (trygFunc == "ctg")
                    {
                        if (point1.Y < point2.Y)
                        {
                            grap.DrawLine(Function, point1, point2);
                        }
                    }
                }
                if (fDane.dziedzinaFunkcji.Count() == 1)
                {
                    point1.X = float.Parse(fDane.dziedzinaFunkcji[0].ToString()) * 25 + 250;
                    point1.Y = 500;

                    point2.X = float.Parse(fDane.dziedzinaFunkcji[0].ToString()) * 25 + 250;
                    point2.Y = 0;

                    grap.DrawLine(Asymptota, point1, point2);
                }
            });

        }
        private void checkSwitchMonot(FunctionD fDane)
        {
            switch (fDane.monot)
            {
                case 0: txtMonot.Text = "Rosnąca"; break;
                case 1: txtMonot.Text = "Malejąca"; break;
                case 2: txtMonot.Text = "Stała"; break;
                case 3: txtMonot.Text = "Niemonotoniczna"; break;
            }
            switch (fDane.monotWPrzedziale)
            {
                case 0: txtMonotPrzedzial.Text = "Rosnąca"; break;
                case 1: txtMonotPrzedzial.Text = "Malejąca"; break;
                case 2: txtMonotPrzedzial.Text = "Stała"; break;
                case 3: txtMonotPrzedzial.Text = "Niemonotoniczna"; break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dokumentacja docs = new Dokumentacja();
            docs.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnXY_Click(object sender, EventArgs e)
        {
            if (XY.ShowDialog() == DialogResult.OK)
            {
                btnXY.BackColor = XY.Color;
                blackThick = new Pen(XY.Color, 2);
                blackThin = new Pen(XY.Color, 1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dokumentacja docs = new Dokumentacja();
            docs.Show();
            this.Hide();
        }
    }
}
