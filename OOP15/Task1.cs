using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP15
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        // === ЗАВДАННЯ 1 ===
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double X = Convert.ToDouble(boxX.Text);
                double Y = Convert.ToDouble(boxY.Text);

                if (X == -4 || X == 0)
                {
                    resultLabel1.Text = $"При X = {X} відповіді не існує!";
                    return;
                }

                double result = Math.Log10(Math.Abs((Y - Math.Sqrt(Math.Abs(X))) *
                    (X - (Y / (X + (X * X / 4))))));

                resultLabel1.Text = result.ToString();
            }
            catch (FormatException)
            {
                resultLabel1.Text = "Невірний формат змінних!";
            }
        }

        // === TASK 2 ===
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(numberBox.Text);

                resultLabel2.Text =
                    $"{Math.Pow(num, 1)}; {Math.Pow(num, 2)}; {Math.Pow(num, 3)}; {Math.Pow(num, 4)}";
            }
            catch (FormatException)
            {
                resultLabel2.Text = "Невірний формат змінної!";
            }
        }

        // === ЗАВДАННЯ 3 ===
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double A = Convert.ToDouble(sideA.Text);
                double B = Convert.ToDouble(sideB.Text);
                double C = Convert.ToDouble(sideC.Text);

                if (A <= 0 || B <= 0 || C <= 0)
                {
                    resultLabel3.Text = "Трикутника не існує";
                }
                else if (A == B || B == C || A == C)
                {
                    resultLabel3.Text = "Трикутник рівнобедрений";
                }
                else
                {
                    resultLabel3.Text = "Трикутник НЕ рівнобедрений";
                }
            }
            catch (FormatException)
            {
                resultLabel3.Text = "Невірний формат змінних!";
            }
        }

        // === ЗАВДАННЯ 4 ===
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(numBox1.Text);
                int num2 = Convert.ToInt32(numBox2.Text);

                int result = num1 + num2;

                if (result > 32767)
                {
                    resultLabel4.Text = "Переповнення!";
                }
                else
                {
                    resultLabel4.Text = result.ToString();
                }
            }
            catch (FormatException)
            {
                resultLabel4.Text = "Невірний формат змінних!";
            }
        }

        // === ЗАВДАННЯ 5 ===
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int N = Convert.ToInt32(numBox.Text);

                string result = "Не знайдено";
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
                resultLabel5.Text = "Невірний формат змінної!";
            }
        }

        // === ЗАВДАННЯ 6 ===
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int X = Convert.ToInt32(pointX.Text);
                int Y = Convert.ToInt32(pointY.Text);

                Point.AddPoint(X, Y);
                Point.PrintArray(pointList2);
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
                resultLabel6.Text = "Необхідно мати більше ніж одну точку!";
                return;
            }
            resultLabel6.Text = Point.MaxDistance();
        }

        // === ЗАВДАННЯ 7 ===
        private void button8_Click(object sender, EventArgs e)
        {
            string dictSkip = " ,:;-"; // список розділових знаків
            string dictBreak = ".!?"; // список знаків, на яких повинне закінчуватися речення

            string str = stringBox.Text;
            if (str == string.Empty)
            {
                resultLabel7.Text = "Необхідно ввести інформацію в поле!";
                return;
            }
            if (!dictBreak.Contains(str.Last()))
            {
                resultLabel7.Text = "Рядок повинен закінчуватися символом!";
                return;
            }
            resultLabel7.Text = string.Empty;

            string temp = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (dictBreak.Contains(str[i]))
                    break;
                if (dictSkip.Contains(str[i]))
                    continue;

                temp += str[i];
                if (dictSkip.Contains(str[i + 1]) || dictBreak.Contains(str[i + 1]))
                {
                    if (temp.Length == 3)
                    {
                        resultLabel7.Text += temp + ", ";
                    }
                    temp = string.Empty;
                }
            }
        }
    }

    // === КЛАС POINT ДЛЯ ЗАВДАННЯ 6 ==
    class Point
    {
        private readonly int X; // поле для зберігання X
        private readonly int Y; // поле для зберігання Y

        private static Point[] points = new Point[30]; // масив точок (кількість точок = 30)
        public static int Len = 0; // змінна вказує скільки точок знаходиться в масиві

        private static int maxDistanceIndex1 = 0;
        private static int maxDistanceIndex2 = 0;
        private static double maxDistance = 0;

        // конструктор
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // метод для виводу точок
        public static void PrintArray(Label label)
        {
            string result = string.Empty;
            for (int i = 0; i < Len; i++)
            {
                result += $"({points[i].X}; {points[i].Y}), ";
            }
            label.Text = result;
        }

        // метод для додавання точки в масив
        public static void AddPoint(int x, int y)
        {
            if (Len == 30)
                return;

            points[Len++] = new Point(x, y);
        }

        // знаходження точок з найбільшою відстанню
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
            return $"Найбільша відстань між точками [{maxDistanceIndex1 + 1}] та [{maxDistanceIndex2 + 1}]";
        }

        // знаходження найбільшої відстані між двома точками
        private static double CalculateDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }
    }
}
