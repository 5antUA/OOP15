﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP15
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (boxX.Text == string.Empty || boxY.Text == string.Empty)
            {
                resultLabel1.Text = "Результат: введіть змінні!";
                return;
            }

            try
            {
                double X = Convert.ToDouble(boxX.Text);
                double Y = Convert.ToDouble(boxY.Text);

                if (X == -4 || X == 0)
                {
                    resultLabel1.Text = $"Результат: при X = {X} відповіді не існує!";
                    return;
                }

                double result = Math.Log10(Math.Abs((Y - Math.Sqrt(Math.Abs(X))) *
                    (X - (Y / (X + (X * X / 4))))));

                resultLabel1.Text = $"Результат: {result}";
            }
            catch (FormatException)
            {
                resultLabel1.Text = "Результат: невірний формат змінних!";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (numberBox.Text == string.Empty)
            {
                resultLabel2.Text = "Результат: введіть змінну!";
                return;
            }

            try
            {
                double num = Convert.ToDouble(numberBox.Text);

                resultLabel2.Text = $"Результат: \n" +
                    $"{Math.Pow(num, 1)}; {Math.Pow(num, 2)}; {Math.Pow(num, 3)}; {Math.Pow(num, 4)}";
            }
            catch (FormatException)
            {
                resultLabel2.Text = "Результат: невірний формат змінних!";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (sideA.Text == string.Empty || sideB.Text == string.Empty || sideC.Text == string.Empty)
            {
                resultLabel3.Text = "Результат: введіть змінну!";
                return;
            }

            try
            {
                double A = Convert.ToDouble(sideA.Text);
                double B = Convert.ToDouble(sideB.Text);
                double C = Convert.ToDouble(sideC.Text);

                if (A <= 0 || B <= 0 || C <= 0 )
                {
                    resultLabel3.Text = "Результат: трикутника не існує";
                }
                else if (A == B || B == C || A == C)
                {
                    resultLabel3.Text = "Результат: трикутник рівнобедрений";
                }
                else
                {
                    resultLabel3.Text = "Результат: трикутник НЕ рівнобедрений";
                }
            }
            catch (FormatException)
            {
                resultLabel3.Text = "Результат: невірний формат змінних!";
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (numBox1.Text == string.Empty || numBox2.Text == string.Empty)
            {
                resultLabel4.Text = "Результат: введіть змінну!";
                return;
            }

            try
            {
                int num1 = Convert.ToInt32(numBox1.Text);
                int num2 = Convert.ToInt32(numBox2.Text);

                int result = num1 + num2;

                if (result > 32767)
                {
                    resultLabel4.Text = "Результат: переповнення!";
                }
                else
                {
                    resultLabel4.Text = $"Результат: {result}";
                }
            }
            catch (FormatException)
            {
                resultLabel4.Text = "Результат: невірний формат змінних!";
            }
        }
    }
}
