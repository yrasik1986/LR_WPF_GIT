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
using System.Collections.ObjectModel;

namespace LR3
{
   
    public partial class MainWindow : Window
    {
        ObservableCollection<string> result;
        Values val;
        public MainWindow()
        {
            InitializeComponent();
            val = new Values();
            grid.DataContext = val;

            result = new ObservableCollection<string>();
            ListBox1.DataContext = result;
        }

        double Factorial (int n)
        {
            int r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }
     
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (val.XStart < val.XStop)
                {
                    if (val.Step <= 0)
                    {
                        throw new ArgumentException("Значение Step быть больше нуля!");
                    }
                }
                else if (val.Step >= 0)
                {
                    throw new ArgumentException("Значение Step быть меньше нуля!");
                }
               
                for (double x = val.XStart; x != val.XStop; x += val.Step)
                {
                    double Y = Math.Pow(3, x) - 1;
                    double S = 0;
                    for (int k = 0; k <= val.N; ++k)
                    {
                        S += (Math.Pow(Math.Log(3), (double)k) / Factorial(k)) * Math.Pow(x, (double)k);
                    }
                    result.Add("S = " + S + " | Y = " + Y);
                }

            } catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
          
           
        }
    }
}
