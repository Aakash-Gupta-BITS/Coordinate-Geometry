using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Co_ordinate_Geometry.Parabola
{
    public sealed partial class Right_Left_Parabola : Page
    {
        public Right_Left_Parabola()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_Equation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_Equation.Text, out verify))
            {
                In_Directrix.Text = "";
                In_Focus.Text = "";
                In_Latus.Text = "";
                In_Point_x.Text = "";
                In_Point_y.Text = "";
                Output.Text = "";
            }
            else
            {
                double a = double.Parse(In_Equation.Text) / 4;
                In_Directrix.Text = Convert.ToString(-a);
                In_Focus.Text = Convert.ToString(a);
                In_Latus.Text = In_Equation.Text;
                output();
            }
        }

        private void output()
        {
            if (double.TryParse(In_Equation.Text, out verify))
            {
                double a = double.Parse(In_Equation.Text) / 4;
                string s = "";
                Output.Text = "Co-Ordinates\n\tFocus\t\t\t:\t(" + Convert.ToString(a) + " , 0)" + "\n\tVertex\t\t\t:\t(0 , 0)\n\tLatus Rectum \t\t:\t(" + a + " , ±" + Math.Abs(2 * a) + ")";
                Output.Text = Output.Text + "\n\nEquation\n\tParabola\t\t:\ty² = " + In_Equation.Text + " * x" + "\n\tAxis Of Parabola\t:\ty = 0" + "\n\tDirectrix\t\t:\tx = " + Convert.ToString(-4 * a) + "/ 4 = " + Convert.ToString(-a);
                Output.Text = Output.Text + "\n\nLatus Rectum (Length)\t:\t" + Convert.ToString(Math.Abs(4 * a));
                Output.Text = Output.Text + "\n\nTriangle\n\tEquilateral\n\t\tSide\t\t:\t" + 8 * a + " * √3 = " + Math.Sqrt(3) * 8 * a + "\n\t\tArea\t\t:\t" + 48 * a * a + " * √3 = " + 48 * Math.Sqrt(3) * a * a;
                Output.Text = Output.Text + "\n\tLatus Rectum\n\t\tSide\t\t:\t" + a + " * √5 = " + Math.Sqrt(5) * a + "\n\t\tArea\t\t:\t" + a * a * 2;
                Display.Mathematica.Parabola_R_Left(a, ref s);
                Output.Text = Output.Text + "\n\nMathematica\t\t\t:\t" + s;
            }
            else
                Output.Text = "";
        }

        private void In_Focus_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_Focus.Text, out verify))
            {
                In_Directrix.Text = "";
                In_Equation.Text = "";
                In_Latus.Text = "";
                In_Point_x.Text = "";
                In_Point_y.Text = "";
                Output.Text = "";
            }
            else
            {
                double a = double.Parse(In_Focus.Text);
                In_Equation.Text = Convert.ToString(4 * a);
            }
        }

        private void In_Directrix_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_Directrix.Text, out verify))
            {
                In_Equation.Text = "";
                In_Focus.Text = "";
                In_Latus.Text = "";
                In_Point_x.Text = "";
                In_Point_y.Text = "";
                Output.Text = "";
            }
            else
            {
                double a = -1 * double.Parse(In_Directrix.Text);
                In_Equation.Text = Convert.ToString(4 * a);
            }
        }

        private void In_Latus_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_Latus.Text, out verify))
            {
                In_Equation.Text = "";
                In_Directrix.Text = "";
                In_Focus.Text = "";
                In_Point_x.Text = "";
                In_Point_y.Text = "";
                Output.Text = "";
            }
            else
            {
                double a = double.Parse(In_Latus.Text) / 4;
                In_Equation.Text = Convert.ToString(4 * a);
            }
        }

        private void In_Point_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_Point_x.Text, out verify) | !double.TryParse(In_Point_y.Text, out verify))
            {
                In_Equation.Text = "";
                In_Directrix.Text = "";
                In_Focus.Text = "";
                In_Latus.Text = "";
                Output.Text = "";
            }
            else
            {
                double x = double.Parse(In_Point_x.Text), y = double.Parse(In_Point_y.Text);
                double a = (y * y) / (4 * x);
                In_Equation.Text = Convert.ToString(4 * a);
            }
        }

        private void Find_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(Find_x.Text, out verify) | !double.TryParse(In_Focus.Text, out verify))
            {
                Find_Length.Text = "";
                Find_y.Text = "";
            }
            else
            {
                double a = double.Parse(In_Focus.Text), y = 0;
                if (a > 0 & Convert.ToDouble(Find_x.Text) > 0)
                {
                    y = Math.Sqrt(4 * a * Convert.ToDouble(Find_x.Text));
                    Find_y.Text = "±" + Convert.ToString(y);
                    Find_Length.Text = Convert.ToString(y * 2);
                }
                else if (a < 0 & Convert.ToDouble(Find_x.Text) < 0)
                {
                    y = Math.Sqrt(-1 * 4 * a * Convert.ToDouble(Find_x.Text));
                    Find_y.Text = "±" + Convert.ToString(y);
                    Find_Length.Text = Convert.ToString(y * 2);
                }
                else
                {
                    Find_y.Text = "Invalid";
                }
            }
        }

        private void Find_y_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(Find_y.Text, out verify) | !double.TryParse(In_Focus.Text, out verify))
            {
                Find_Length.Text = "";
                Find_x.Text = "";
            }
            else
            {
                double a = double.Parse(In_Focus.Text), y = double.Parse(Find_y.Text);
                double x = (y * y) / (4 * a);
                Find_x.Text = Convert.ToString(x);
                Find_Length.Text = Convert.ToString(y * 2);
            }
        }
    }
}