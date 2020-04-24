using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftNum = "0";
        string rightNum = "";
        string oldRightNum = "0";
        string operation = "";
        string oldOperation = "";
        double resalt = 0;
        string gradOrRad = "rad";

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = "0";
        }

        private void Button_Number(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();

            if (Display.Text == "0" && s != ",")
            {
                Display.Text = "";
                leftNum = "";
            }
            if (operation == "")
            {
                leftNum += s;
                Display.Text = leftNum;
            }
            else
            {
                rightNum += s;
                Display.Text = rightNum;
                oldRightNum = rightNum;
            }
        }

        private void Button_Operation(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            operation = s;
            if (rightNum != "" && oldOperation != operation)
            {
                if (oldOperation != "=")
                {
                    resalt = GetResaltOperation(Double.Parse(leftNum), Double.Parse(rightNum), operation);
                    leftNum = resalt.ToString();
                }
                rightNum = resalt.ToString();
                Display.Text = resalt.ToString();
                oldOperation = operation;
            }
        }

        private void Button_Resalt(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            oldOperation = s;
            resalt = GetResaltOperation(Double.Parse(leftNum), Double.Parse(oldRightNum), operation);
            Display.Text = resalt.ToString();
            leftNum = resalt.ToString();
            rightNum = "";
        }

        private void Button_Trigonom(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            if ((operation != "" && rightNum == "") || (operation == "" && leftNum != ""))
            {
                resalt = GetTrigonometryResalt(s, leftNum, gradOrRad);
                leftNum = resalt.ToString();
            }
            else
            if (operation != "" && rightNum != "")
            {
                resalt = GetTrigonometryResalt(s, rightNum, gradOrRad);
                resalt = GetResaltOperation(Double.Parse(leftNum), resalt, operation);
                leftNum = resalt.ToString();
                rightNum = "";
            }
            Display.Text = resalt.ToString();
        }
        private void Button_PlasMines(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                leftNum = (Double.Parse(leftNum) * -1).ToString();
                Display.Text = leftNum;
            }
            else
            {
                if (rightNum != "")
                {
                    rightNum = (Double.Parse(rightNum) * -1).ToString();
                }
                Display.Text = rightNum;
            }
        }

        private void Button_other(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            if ((operation != "" && rightNum == "") || (operation == "" && leftNum != ""))
            {
                resalt = GetOtherOperation(s, leftNum);
                leftNum = resalt.ToString();
            }
            else
           if (operation != "" && rightNum != "")
            {
                resalt = GetOtherOperation(s, rightNum);
                resalt = GetResaltOperation(Double.Parse(leftNum), resalt, operation);
                leftNum = resalt.ToString();
                rightNum = "0";
            }
            Display.Text = resalt.ToString();
        }

        private void Button_Switch_Clear(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            switch (s)
            {
                case "rad":
                    gradOrRad = "grad";
                    ((Button)sender).Content = "grad";
                    break;
                case "grad":
                    gradOrRad = "rad";
                    ((Button)sender).Content = "rad";
                    break;
                case "C":
                    ClearDisplay();
                    break;
            }
        }

        private double GetTrigonometryResalt(string fun, string value, string typeDegree)
        {
            double angle = Double.Parse(value);
            double resalt = 0;
            if (typeDegree == "grad")
            {
                angle = Math.PI * angle / 180;
            }
            switch (fun)
            {
                case "sin":
                    resalt = Math.Sin(angle);
                    break;
                case "cos":
                    resalt = Math.Cos(angle);
                    break;
                case "tan":
                    double ex = Math.Round(angle, 4);
                    try
                    {
                        if (ex == 1.5708)
                        {
                            throw new Exception("tan(90) не сущесвует!");
                        }
                        resalt = Math.Tan(angle);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        ClearDisplay();
                    }
                    break;
            }
            return resalt;
        }

        private double GetOtherOperation(string fun, string value)
        {
            double val = Double.Parse(value);
            double resalt = 0;
            switch (fun)
            {
                case "sqrt":
                    try
                    {
                        if (val < 0)
                        {
                            throw new Exception("корень от отрицательного числа невозможен!");
                        }
                        resalt = Math.Sqrt(val);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        ClearDisplay();
                    }
                    resalt = Math.Sqrt(val);
                    break;
                case "x^2":
                    resalt = Math.Pow(val, 2.0);
                    break;
                case "1/x":
                    try
                    {
                        if (val == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        resalt = 1 / val;
                    }
                    catch (DivideByZeroException e)
                    {
                        MessageBox.Show(e.Message);
                        ClearDisplay();
                    }
                    break;
            }
            return resalt;
        }

        private double GetResaltOperation(double left, double right, string operation)
        {
            double returnResalt = 0;
            switch (operation)
            {
                case "+":
                    returnResalt = left + right;
                    break;
                case "-":
                    returnResalt = left - right;
                    break;
                case "x":
                    returnResalt = left * right;
                    break;
                case "/":
                    try
                    {
                        if (right == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        returnResalt = left / right;
                    }
                    catch (DivideByZeroException e)
                    {
                        MessageBox.Show(e.Message);
                        ClearDisplay();
                    }

                    break;
            }
            return returnResalt;
        }
        private void ClearDisplay()
        {
            rightNum = "";
            leftNum = "0";
            operation = "";
            Display.Text = "0";
            resalt = 0;
        }
    }
}
