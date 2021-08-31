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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double xCoorNum;
        double yCoorNum;
        double diameterNum;
        String tempXStr;
        String tempYStr;
        String tempDStr;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.Duration = TimeSpan.FromSeconds(1.0d);
            fadeAnimation.From = 0.0d;
            fadeAnimation.To = 1.0d;
            MainGrid.BeginAnimation(Grid.OpacityProperty, fadeAnimation);


        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            //Ellipse circle;
            //Ellipse[] ellipses;
            MainCanvas.Children.Clear();

            tempXStr = xTextBox.Text;
            xCoorNum = (double)Convert.ToDecimal(tempXStr);

            tempYStr = yTextBox.Text;
            yCoorNum = (double)Convert.ToDecimal(tempYStr);

            tempDStr = dTextBox.Text;
            diameterNum = (double)Convert.ToDecimal(tempDStr);

            textBlock1.Text = "You Entered X: " + xCoorNum + ", Y: " + yCoorNum + ", D: " + diameterNum;

            Draw_Circles(MainCanvas, xCoorNum, yCoorNum, diameterNum);

            

            //ellipses = new Ellipse[iterationNum];

            //for(int i = 0; i < iterationNum; i++)
            //{
            //    ellipses[i] = new Ellipse() { Width = 50, Height = 50, Stroke = Brushes.Black };
            //    MainCanvas.Children.Add(ellipses[i]);
            //}

            //for (int j = 0; j < iterationNum; j++)
            //{
            //    Canvas.SetLeft(ellipses[j], 50 * j * 0.5);
            //    Canvas.SetTop(ellipses[j], MainCanvas.ActualHeight / 2.0);
            //}
                
                
            //circle = new Ellipse() { Width = 50, Height = 50, Stroke = Brushes.Black };
            //MainCanvas.Children.Add(circle);
            //circle.SetValue(Canvas.LeftProperty, MainCanvas.ActualWidth / 2.0);
            //circle.SetValue(Canvas.TopProperty, MainCanvas.ActualHeight / 2.0);
        }

        static Ellipse Draw_Circles(Canvas mCanvas, double x, double y, double d)
        {
            Ellipse e = new Ellipse() { Width = d, Height = d, Stroke = Brushes.Black };
            mCanvas.Children.Add(e);
            Canvas.SetLeft(e, x);
            Canvas.SetTop(e, y);
            if (d > 2)
            {
                Draw_Circles(mCanvas, x + d * 0.5, y, d * 0.5);
                Draw_Circles(mCanvas, x - d * 0.5, y, d * 0.5);
                Draw_Circles(mCanvas, x , y + d * 0.5, d * 0.5);
                //Draw_Circles(mCanvas, x , y - d * 0.5, d * 0.5);
            }
            
            return e;
        }
    }
}
