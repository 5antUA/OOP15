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
                resultLabel1.Text = "введіть змінні!";
                return;
            }

            try
            {
                double X = Convert.ToDouble(boxX.Text);
                double Y = Convert.ToDouble(boxY.Text);

                if (X == -4 || X == 0)
                {
                    resultLabel1.Text = $"при X = {X} відповіді не існує!";
                    return;
                }

                double result = Math.Log10(Math.Abs((Y - Math.Sqrt(Math.Abs(X))) *
                    (X - (Y / (X + (X * X / 4))))));

                resultLabel1.Text = result.ToString();
            }
            catch (FormatException)
            {
                resultLabel1.Text = "невірний формат змінних!";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (numberBox.Text == string.Empty)
            {
                resultLabel2.Text = "введіть змінну!";
                return;
            }

            try
            {
                double num = Convert.ToDouble(numberBox.Text);

                resultLabel2.Text = 
                    $"{Math.Pow(num, 1)}; {Math.Pow(num, 2)}; {Math.Pow(num, 3)}; {Math.Pow(num, 4)}";
            }
            catch (FormatException)
            {
                resultLabel2.Text = "невірний формат змінної!";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (sideA.Text == string.Empty || sideB.Text == string.Empty || sideC.Text == string.Empty)
            {
                resultLabel3.Text = "введіть змінні!";
                return;
            }

            try
            {
                double A = Convert.ToDouble(sideA.Text);
                double B = Convert.ToDouble(sideB.Text);
                double C = Convert.ToDouble(sideC.Text);

                if (A <= 0 || B <= 0 || C <= 0 )
                {
                    resultLabel3.Text = "трикутника не існує";
                }
                else if (A == B || B == C || A == C)
                {
                    resultLabel3.Text = "трикутник рівнобедрений";
                }
                else
                {
                    resultLabel3.Text = "трикутник НЕ рівнобедрений";
                }
            }
            catch (FormatException)
            {
                resultLabel3.Text = "невірний формат змінних!";
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (numBox1.Text == string.Empty || numBox2.Text == string.Empty)
            {
                resultLabel4.Text = "введіть змінні!";
                return;
            }

            try
            {
                int num1 = Convert.ToInt32(numBox1.Text);
                int num2 = Convert.ToInt32(numBox2.Text);

                int result = num1 + num2;

                if (result > 32767)
                {
                    resultLabel4.Text = "переповнення!";
                }
                else
                {
                    resultLabel4.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                resultLabel4.Text = "невірний формат змінних!";
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (numBox.Text == string.Empty)
            {
                resultLabel5.Text = "введіть змінну!";
                return;
            }

            try
            {
                int N = Convert.ToInt32(numBox.Text);

                string result = "не знайдено";
                for (int i = 12; i <= N; i += 10)
                {
                    int temp1 = i / 10;
                    int temp2 = (int)Math.Pow(temp1, 2);

                    if (temp1 == temp2 % Math.Pow(10, i.ToString().Length - 1))
                    {
                        result = $"{i} = {temp2}; ";
                    }
                }
                resultLabel5.Text = result;
            }
            catch (FormatException)
            {
                resultLabel5.Text = "невірний формат змінної!";
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (pointX.Text == string.Empty || pointY.Text == string.Empty)
            {
                pointLabel.Text = "Введіть змінні!";
                return;
            }

            try
            {
                int X = Convert.ToInt32(pointX.Text);
                int Y = Convert.ToInt32(pointY.Text);

                Point.AddPoint(X, Y);
                pointList2.Text = Point.PrintArray();
                pointLabel.Text = "Точка додана!";
            }
            catch (FormatException)
            {
                pointLabel.Text = "Введіть змінні!";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (Point.Len < 2)
            {
                resultLabel6.Text = "Необхідно мати більше 2 точок!";
                return;
            }
            resultLabel6.Text = Point.MaxDistance();
        }
    }

    class Point
    {
        public int X;
        public int Y;

        static public Point[] points = new Point[30];
        static public int Len = 0;

        private static int maxDistanceIndex1 = 0;
        private static int maxDistanceIndex2 = 0;
        private static double maxDistance = 0;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static string PrintArray()
        {
            string result = string.Empty;
            for (int i = 0; i < Len; i++)
            {
                result += $"({points[i].X}; {points[i].Y}), ";
            }
            return result;
        }

        public static void AddPoint(int x, int y)
        {
            if (Len == 30)
                return;

            points[Len++] = new Point(x, y);
        }

        public static string MaxDistance()
        {
            for (int i = 0; i < Len; i++)
            {
                for (int j = i + 1; j < Len; j++)
                {
                    double distance = CalculateDistance(points[i], points[j]);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        maxDistanceIndex1 = i;
                        maxDistanceIndex2 = j;
                    }
                }
            }

            return $"Найбільша відстань між точками {maxDistanceIndex1 + 1} і {maxDistanceIndex2 + 1}";
        }

        private static double CalculateDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }
    }
}
