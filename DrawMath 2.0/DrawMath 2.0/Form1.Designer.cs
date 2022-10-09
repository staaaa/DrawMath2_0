
namespace DrawMath_2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fBox = new System.Windows.Forms.PictureBox();
            this.txtBoxPrzedzial = new System.Windows.Forms.TextBox();
            this.txtBoxMonot1 = new System.Windows.Forms.TextBox();
            this.txtBoxMonot2 = new System.Windows.Forms.TextBox();
            this.txtBoxGranica = new System.Windows.Forms.TextBox();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BoxDokladnosc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnXY = new System.Windows.Forms.Button();
            this.btnF = new System.Windows.Forms.Button();
            this.btnT = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOy = new System.Windows.Forms.Label();
            this.txtMonot = new System.Windows.Forms.Label();
            this.txtMonotPrzedzial = new System.Windows.Forms.Label();
            this.txtZerowe = new System.Windows.Forms.Label();
            this.txtGranicaPunkt = new System.Windows.Forms.Label();
            this.txtGraniceKoniec = new System.Windows.Forms.Label();
            this.txtEkstrema = new System.Windows.Forms.Label();
            this.txtDziedzina = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fBox
            // 
            this.fBox.Location = new System.Drawing.Point(57, 28);
            this.fBox.Name = "fBox";
            this.fBox.Size = new System.Drawing.Size(500, 500);
            this.fBox.TabIndex = 0;
            this.fBox.TabStop = false;
            // 
            // txtBoxPrzedzial
            // 
            this.txtBoxPrzedzial.Location = new System.Drawing.Point(786, 46);
            this.txtBoxPrzedzial.Name = "txtBoxPrzedzial";
            this.txtBoxPrzedzial.Size = new System.Drawing.Size(54, 23);
            this.txtBoxPrzedzial.TabIndex = 1;
            // 
            // txtBoxMonot1
            // 
            this.txtBoxMonot1.Location = new System.Drawing.Point(684, 118);
            this.txtBoxMonot1.Name = "txtBoxMonot1";
            this.txtBoxMonot1.Size = new System.Drawing.Size(54, 23);
            this.txtBoxMonot1.TabIndex = 3;
            // 
            // txtBoxMonot2
            // 
            this.txtBoxMonot2.Location = new System.Drawing.Point(881, 118);
            this.txtBoxMonot2.Name = "txtBoxMonot2";
            this.txtBoxMonot2.Size = new System.Drawing.Size(54, 23);
            this.txtBoxMonot2.TabIndex = 4;
            // 
            // txtBoxGranica
            // 
            this.txtBoxGranica.Location = new System.Drawing.Point(684, 215);
            this.txtBoxGranica.Name = "txtBoxGranica";
            this.txtBoxGranica.Size = new System.Drawing.Size(54, 23);
            this.txtBoxGranica.TabIndex = 5;
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(684, 339);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(251, 23);
            this.txtBoxInput.TabIndex = 6;
            this.txtBoxInput.TextChanged += new System.EventHandler(this.txtBoxInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "przedzial, w ktorym funkcja ma zostac narysowana";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "przedzial, w ktorym ma zostac ustalona monotonicznosc i ekstrema";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "X, w którym ma zostać policzona granica";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(684, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "wzór funkcji";
            // 
            // BoxDokladnosc
            // 
            this.BoxDokladnosc.FormattingEnabled = true;
            this.BoxDokladnosc.Items.AddRange(new object[] {
            "Mała dokładność",
            "Średnia dokładność",
            "Duża dokładność"});
            this.BoxDokladnosc.Location = new System.Drawing.Point(684, 450);
            this.BoxDokladnosc.Name = "BoxDokladnosc";
            this.BoxDokladnosc.Size = new System.Drawing.Size(251, 23);
            this.BoxDokladnosc.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(684, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "dokładność wykresu";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(680, 491);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 12;
            this.btnDraw.Text = "Rysuj";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(802, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Eksportuj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(684, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 14;
            // 
            // btnXY
            // 
            this.btnXY.BackColor = System.Drawing.Color.Black;
            this.btnXY.Location = new System.Drawing.Point(684, 277);
            this.btnXY.Name = "btnXY";
            this.btnXY.Size = new System.Drawing.Size(20, 20);
            this.btnXY.TabIndex = 15;
            this.btnXY.UseVisualStyleBackColor = false;
            this.btnXY.Click += new System.EventHandler(this.btnXY_Click);
            // 
            // btnF
            // 
            this.btnF.BackColor = System.Drawing.Color.Red;
            this.btnF.Location = new System.Drawing.Point(718, 277);
            this.btnF.Name = "btnF";
            this.btnF.Size = new System.Drawing.Size(20, 20);
            this.btnF.TabIndex = 16;
            this.btnF.UseVisualStyleBackColor = false;
            this.btnF.Click += new System.EventHandler(this.btnF_Click);
            // 
            // btnT
            // 
            this.btnT.BackColor = System.Drawing.Color.White;
            this.btnT.Location = new System.Drawing.Point(755, 277);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(20, 20);
            this.btnT.TabIndex = 17;
            this.btnT.UseVisualStyleBackColor = false;
            this.btnT.Click += new System.EventHandler(this.btnT_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 548);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Punkt przecięcia z osią OY:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 588);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Monotoniczność funkcji:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 627);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Monotoniczność funkcji w przedziale:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 661);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Miejsca zerowe:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 701);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Granica w punkcie:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 737);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 15);
            this.label12.TabIndex = 23;
            this.label12.Text = "Granice na końcach przedziału:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(414, 548);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "Ekstrema funkcji w przedziale:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(479, 588);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 15);
            this.label14.TabIndex = 25;
            this.label14.Text = "Dziedzina funkcji:";
            // 
            // txtOy
            // 
            this.txtOy.AutoSize = true;
            this.txtOy.Location = new System.Drawing.Point(165, 548);
            this.txtOy.Name = "txtOy";
            this.txtOy.Size = new System.Drawing.Size(147, 15);
            this.txtOy.TabIndex = 26;
            this.txtOy.Text = "Punkt przecięcia z osią OY:";
            // 
            // txtMonot
            // 
            this.txtMonot.AutoSize = true;
            this.txtMonot.Location = new System.Drawing.Point(156, 588);
            this.txtMonot.Name = "txtMonot";
            this.txtMonot.Size = new System.Drawing.Size(147, 15);
            this.txtMonot.TabIndex = 27;
            this.txtMonot.Text = "Punkt przecięcia z osią OY:";
            // 
            // txtMonotPrzedzial
            // 
            this.txtMonotPrzedzial.AutoSize = true;
            this.txtMonotPrzedzial.Location = new System.Drawing.Point(223, 627);
            this.txtMonotPrzedzial.Name = "txtMonotPrzedzial";
            this.txtMonotPrzedzial.Size = new System.Drawing.Size(147, 15);
            this.txtMonotPrzedzial.TabIndex = 28;
            this.txtMonotPrzedzial.Text = "Punkt przecięcia z osią OY:";
            // 
            // txtZerowe
            // 
            this.txtZerowe.AutoSize = true;
            this.txtZerowe.Location = new System.Drawing.Point(108, 661);
            this.txtZerowe.Name = "txtZerowe";
            this.txtZerowe.Size = new System.Drawing.Size(0, 15);
            this.txtZerowe.TabIndex = 29;
            // 
            // txtGranicaPunkt
            // 
            this.txtGranicaPunkt.AutoSize = true;
            this.txtGranicaPunkt.Location = new System.Drawing.Point(125, 701);
            this.txtGranicaPunkt.Name = "txtGranicaPunkt";
            this.txtGranicaPunkt.Size = new System.Drawing.Size(147, 15);
            this.txtGranicaPunkt.TabIndex = 30;
            this.txtGranicaPunkt.Text = "Punkt przecięcia z osią OY:";
            // 
            // txtGraniceKoniec
            // 
            this.txtGraniceKoniec.AutoSize = true;
            this.txtGraniceKoniec.Location = new System.Drawing.Point(188, 737);
            this.txtGraniceKoniec.Name = "txtGraniceKoniec";
            this.txtGraniceKoniec.Size = new System.Drawing.Size(0, 15);
            this.txtGraniceKoniec.TabIndex = 31;
            // 
            // txtEkstrema
            // 
            this.txtEkstrema.AutoSize = true;
            this.txtEkstrema.Location = new System.Drawing.Point(582, 548);
            this.txtEkstrema.Name = "txtEkstrema";
            this.txtEkstrema.Size = new System.Drawing.Size(147, 15);
            this.txtEkstrema.TabIndex = 32;
            this.txtEkstrema.Text = "Punkt przecięcia z osią OY:";
            // 
            // txtDziedzina
            // 
            this.txtDziedzina.AutoSize = true;
            this.txtDziedzina.Location = new System.Drawing.Point(584, 588);
            this.txtDziedzina.Name = "txtDziedzina";
            this.txtDziedzina.Size = new System.Drawing.Size(147, 15);
            this.txtDziedzina.TabIndex = 33;
            this.txtDziedzina.Text = "Punkt przecięcia z osią OY:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.txtDziedzina);
            this.Controls.Add(this.txtEkstrema);
            this.Controls.Add(this.txtGraniceKoniec);
            this.Controls.Add(this.txtGranicaPunkt);
            this.Controls.Add(this.txtZerowe);
            this.Controls.Add(this.txtMonotPrzedzial);
            this.Controls.Add(this.txtMonot);
            this.Controls.Add(this.txtOy);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnF);
            this.Controls.Add(this.btnXY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BoxDokladnosc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.txtBoxGranica);
            this.Controls.Add(this.txtBoxMonot2);
            this.Controls.Add(this.txtBoxMonot1);
            this.Controls.Add(this.txtBoxPrzedzial);
            this.Controls.Add(this.fBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fBox;
        private System.Windows.Forms.TextBox txtBoxPrzedzial;
        private System.Windows.Forms.TextBox txtBoxMonot1;
        private System.Windows.Forms.TextBox txtBoxMonot2;
        private System.Windows.Forms.TextBox txtBoxGranica;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BoxDokladnosc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnXY;
        private System.Windows.Forms.Button btnF;
        private System.Windows.Forms.Button btnT;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label txtOy;
        private System.Windows.Forms.Label txtMonot;
        private System.Windows.Forms.Label txtMonotPrzedzial;
        private System.Windows.Forms.Label txtZerowe;
        private System.Windows.Forms.Label txtGranicaPunkt;
        private System.Windows.Forms.Label txtGraniceKoniec;
        private System.Windows.Forms.Label txtEkstrema;
        private System.Windows.Forms.Label txtDziedzina;
    }
}

