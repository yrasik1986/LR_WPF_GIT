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

namespace LR2_MovButton
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
     
       //логика программы построена таки образом, что вычисляются координаты центра кнопки и в зависимости от
       //того с какой стороны к кнопке будет подведен курсор мыши (сравниваем координаты курсора и координаты центра),
       //кнопка будет двигаться в противоположном направлении
       // при этом установлены ограничения, за которые кнопка не может выйти
        private void MoveButton(object sender, MouseEventArgs e)
        {
            double distanse = 30;// шаг перемещения          

            Point pointMouse = Mouse.GetPosition(this.can1);
           
            Point pointButtonReal = b1.TranslatePoint(new Point(0, 0), can1);// реальные координаты кнопки отн Canvas
            Point pointButtonCenter = b1.TranslatePoint(new Point(b1.ActualWidth / 2, 
                                                                  b1.ActualHeight/2), can1); // коорд центра кнопки
            
            Point minimum = new Point(0, 0);//координаты ограничения минимума приближения
            Point maximum = new Point(MainGrid.Width - b1.ActualWidth, 
                                      MainGrid.Height- b1.ActualHeight); // координаты ограничения макисмума приближения
            
            b1.Content = pointButtonReal; // отображаем координаты внутри кнопки

            if (pointMouse.Y <= pointButtonCenter.Y)     // если курсор подходит сверху кнопки      
            {         
                if(pointButtonReal.Y + distanse < maximum.Y)
                {
                    Canvas.SetTop(MyGrid, pointButtonReal.Y + distanse); 
                }
                else
                {
                    Canvas.SetTop(MyGrid, maximum.Y);
                }                                                         
            } 
            else // курсор подходит снизу
            {
                if(pointButtonReal.Y - distanse > minimum.Y)
                {
                    Canvas.SetTop(MyGrid, pointButtonReal.Y - distanse);
                }
                else 
                {
                    Canvas.SetTop(MyGrid, minimum.Y);
                }               
            }

            if (pointMouse.X <= pointButtonCenter.X)// курсор подходит слева к кнопке
            {
                if(pointButtonReal.X + distanse < maximum.X) // ограничение правой стенки Canavs
                {
                    Canvas.SetLeft(MyGrid, pointButtonReal.X + distanse);
                }
                else
                {
                    Canvas.SetLeft(MyGrid, maximum.X);
                }                        
            }
            else// справа
            {
                if (pointButtonReal.X - distanse > minimum.X) // ограничение правой стенки Canavs
                {
                    Canvas.SetLeft(MyGrid, pointButtonReal.X - distanse);
                }
                else
                {
                    Canvas.SetLeft(MyGrid, minimum.X);
                }            
            }
        }
    }
}
