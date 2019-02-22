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

namespace Co_ordinate_Geometry.Straight_Lines
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class _2_Points : Page
    {
        public _2_Points()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_x1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_x1.Text, out verify) | !double.TryParse(In_x2.Text, out verify) | !double.TryParse(In_y1.Text, out verify) | !double.TryParse(In_y2.Text, out verify))
            { In_x3.Text = "-"; In_y3.Text = "-"; output.Text = "-"; }
            else
            {
                double x1 = Convert.ToDouble(In_x1.Text), x2 = Convert.ToDouble(In_x2.Text), y1 = Convert.ToDouble(In_y1.Text), y2 = Convert.ToDouble(In_y2.Text);
                {   //Ratio
                    if (!double.TryParse(In_m.Text, out verify) | !double.TryParse(In_n.Text, out verify)) { In_x3.Text = "-"; In_y3.Text = "-"; }
                    else
                    {
                        double m = Convert.ToDouble(In_m.Text), n = Convert.ToDouble(In_n.Text);
                        In_x3.Text = Convert.ToString((m * x2 + n * x1) / (m + n));
                        In_y3.Text = Convert.ToString((m * y2 + n * y1) / (m + n));
                    }
                }
                {
                    double angle = Math_Operations.Operations.Rad_Deg(Math.Atan((y2 - y1) / (x2 - x1))), slope = (y2 - y1) / (x2 - x1);
                    double x_intercept = ((y1 * x2) - (x1 * y2)) / (y1 - y2);
                    double y_intercept = ((x2 * y1) - (x1 * y2)) / (x2 - x1);
                    if (slope < 0) { angle = angle + 180; }
                    output.Text = "Angle \t\t\t\t:\t" + Convert.ToString(angle);

                    output.Text = output.Text + "\n\nArea under Axes \t\t:\t" + Convert.ToString(Math.Abs((x_intercept * y_intercept) / 2));

                    double distance = Math.Pow((Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)), 0.5);
                    output.Text = output.Text + "\n\nDistance \t\t\t:\t" + Convert.ToString(distance);

                    if (slope % 1 == 0)
                        output.Text = output.Text + "\n\nSlope\t\t\t\t:\t" + Convert.ToString(slope);
                    else
                        output.Text = output.Text + "\n\nSlope\t\t\t\t:\t" + Convert.ToString(y2 - y1) + "/" + Convert.ToString(x2 - x1) + " = " + Convert.ToString(slope);

                    output.Text = output.Text + "\n\nIntercept (x,y)\t\t\t:\t";
                    if (x_intercept % 1 == 0) output.Text = output.Text + "(" + Convert.ToString(x_intercept) + " , ";
                    else output.Text = output.Text + "(" + Convert.ToString((y1 * x2) - (x1 * y2)) + "/" + Convert.ToString(y1 - y2) + " = " + Convert.ToString(x_intercept) + " , ";
                    if (y_intercept % 1 == 0) output.Text = output.Text + Convert.ToString(y_intercept) + ")";
                    else output.Text = output.Text + Convert.ToString((x2 * y1) - (x1 * y2)) + "/" + Convert.ToString(x2 - x1) + " = " + Convert.ToString(y_intercept) + ")";
                    double gen_eq_a = (y1 - y2), gen_eq_b = (x2 - x1), gen_eq_c = (x1 * y2 - y1 * x2);
                    {       //GeneraL Equation
                        Math_Operations.Operations.HCF(ref gen_eq_a, ref gen_eq_b, ref gen_eq_c);
                        if (gen_eq_a < 0) { gen_eq_a *= -1; gen_eq_b *= -1; gen_eq_c *= -1; }
                        output.Text = output.Text + "\n\nEquation\n\tGeneral\t\t:\t";

                        if (gen_eq_a == 0) { }
                        else if (gen_eq_a == 1) { output.Text = output.Text + "x"; }
                        else output.Text = output.Text + Convert.ToString(gen_eq_a) + "x";

                        if (gen_eq_b == 0) { }
                        else if (gen_eq_b == 1) { output.Text = output.Text + " + y"; }
                        else if (gen_eq_b == -1) { output.Text = output.Text + " - y"; }
                        else if (gen_eq_b > 0) { output.Text = output.Text + " + " + Convert.ToString(gen_eq_b) + "y"; }
                        else output.Text = output.Text = output.Text + " - " + Convert.ToString(-gen_eq_b) + "y";

                        if (gen_eq_c > 0) { output.Text = output.Text + " + " + Convert.ToString(gen_eq_c) + " = 0"; }
                        else if (gen_eq_c == 0) { output.Text = output.Text + " = 0"; }
                        else output.Text = output.Text + " - " + Convert.ToString(-gen_eq_c) + " = 0"; ;
                    }
                    {       //Slope Equation
                        double m = (y2 - y1) / (x2 - x1);
                        output.Text = output.Text + "\n\tSlope Form (1)\t:\ty = ";

                        if (m == 0) { }
                        else if (m == 1) { output.Text = output.Text + "x "; }
                        else if (m == -1) { output.Text = output.Text + "-x "; }
                        else if (m > 0) { output.Text = output.Text + Convert.ToString(m) + "x "; }
                        else if (m < 0) { output.Text = output.Text + "-" + Convert.ToString(-m) + "x "; }

                        if (y_intercept == 0) { }
                        else if (y_intercept > 0) { output.Text = output.Text + "+ " + Convert.ToString(y_intercept); }
                        else if (y_intercept < 0) { output.Text = output.Text + "- " + Convert.ToString(-y_intercept); }
                        output.Text = output.Text + "\n\tSlope Form (2)\t:\ty = ";

                        if (m == 0) { }
                        else if (m == 1) { output.Text = output.Text + "( x "; }
                        else if (m == -1) { output.Text = output.Text + "-( x "; }
                        else if (m > 0) { output.Text = output.Text + Convert.ToString(m) + "( x "; }
                        else if (m < 0) { output.Text = output.Text + "-" + Convert.ToString(-m) + "( x "; }

                        if (m != 0)
                        {
                            if (x_intercept == 0) { output.Text = output.Text + ")"; }
                            else if (x_intercept > 0) { output.Text = output.Text + "- " + Convert.ToString(x_intercept) + " )"; }
                            else if (x_intercept < 0) { output.Text = output.Text + "+ " + Convert.ToString(-x_intercept) + " )"; }
                        }
                    }
                    {       //Intercept 
                        output.Text = output.Text + "\n\tIntercept Form\t:\t";

                        if (x_intercept == 1) { output.Text = output.Text + "x"; }
                        else if (x_intercept == -1) { output.Text = output.Text + "-x"; }
                        else if (x_intercept > 0) { output.Text = output.Text + "x/" + Convert.ToString(x_intercept); }
                        else if (x_intercept < 0) { output.Text = output.Text + "-x/" + Convert.ToString(-x_intercept); }

                        if (y_intercept == 1) { output.Text = output.Text + " + y = 1"; }
                        else if (y_intercept == -1) { output.Text = output.Text + " - y = 1"; }
                        else if (y_intercept > 0) { output.Text = output.Text + " + y/" + Convert.ToString(y_intercept) + " = 1"; }
                        else if (y_intercept < 0) { output.Text = output.Text + " - y/" + Convert.ToString(-y_intercept) + " = 1"; }

                        if (x_intercept == 0 & y_intercept == 0) { output.Text = output.Text + "x/0 + y/0 = 1"; }
                    }
                    output.Text = output.Text + "\n\tNormal Form\t\t:\tx*Cos(Angle) + y*Sin(Angle) = " + Convert.ToString((Math.Abs(((y1 * x2 * (-1.0)) + (y2 * x1))) * Math.Pow((Math.Pow(x1, 2.0) + (x2 * x1 * (-2.0)) + Math.Pow(x2, 2.0) + Math.Pow(y1, 2.0) + (y2 * y1 * (-2.0)) + Math.Pow(y2, 2.0)), -0.5)));
                    string s = ""; Display.Mathematica.Straight(gen_eq_a, gen_eq_b, gen_eq_c, ref s);
                    output.Text = output.Text + "\n\n\nMathematica\t\t:\t" + s;
                }
            }
        }
        private void In_m_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_m.Text, out verify) | !double.TryParse(In_n.Text, out verify) | !double.TryParse(In_x1.Text, out verify) | !double.TryParse(In_x2.Text, out verify) | !double.TryParse(In_y1.Text, out verify) | !double.TryParse(In_y2.Text, out verify))
            { In_x3.Text = "-"; In_y3.Text = "-"; }
            else
            {
                double x1 = Convert.ToDouble(In_x1.Text), x2 = Convert.ToDouble(In_x2.Text), y1 = Convert.ToDouble(In_y1.Text), y2 = Convert.ToDouble(In_y2.Text), m = Convert.ToDouble(In_m.Text), n = Convert.ToDouble(In_n.Text);
                In_x3.Text = Convert.ToString((m * x2 + n * x1) / (m + n));
                In_y3.Text = Convert.ToString((m * y2 + n * y1) / (m + n));
                move_point(m, n);
            }
        }
        private void In_x3_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_x1.Text, out verify) | !double.TryParse(In_x2.Text, out verify) | !double.TryParse(In_x3.Text, out verify) | !double.TryParse(In_y1.Text, out verify) | !double.TryParse(In_y2.Text, out verify))
            { In_m.Text = "-"; In_n.Text = "-"; }
            else
            {
                double x1 = Convert.ToDouble(In_x1.Text), x2 = Convert.ToDouble(In_x2.Text), x3 = Convert.ToDouble(In_x3.Text);
                In_m.Text = Convert.ToString(x3 - x1);
                In_n.Text = Convert.ToString(x2 - x3);
                double m = double.Parse(In_m.Text), n = double.Parse(In_n.Text), y1 = double.Parse(In_y1.Text), y2 = double.Parse(In_y2.Text);
                In_y3.Text = Convert.ToString((m * y2 + n * y1) / (m + n));
                move_point(m, n);
            }
        }
        private void In_y3_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_y1.Text, out verify) | !double.TryParse(In_y2.Text, out verify) | !double.TryParse(In_y3.Text, out verify) | !double.TryParse(In_x1.Text, out verify) | !double.TryParse(In_x2.Text, out verify))
            { In_m.Text = "-"; In_n.Text = "-"; }
            else
            {
                double y1 = Convert.ToDouble(In_y1.Text), y2 = Convert.ToDouble(In_y2.Text), y3 = Convert.ToDouble(In_y3.Text);
                In_m.Text = Convert.ToString(y3 - y1);
                In_n.Text = Convert.ToString(y2 - y3);
                double m = double.Parse(In_m.Text), n = double.Parse(In_n.Text), x1 = double.Parse(In_x1.Text), x2 = double.Parse(In_x2.Text);
                move_point(m, n);
                In_x3.Text = Convert.ToString((m * x2 + n * x1) / (m + n));
            }
        }
        private void move_point(double m, double n)
        {
            double min = 145, max = 755;
            double new_point = (m * max + n * min) / (m + n);
            point_c.Margin = new Thickness(new_point, 0, 0, 0);
            if (new_point < 24)
            {
                double increment = Math.Abs(new_point) + 24;
                Line.Margin = new Thickness(157 + increment, 6, 0, 0);
                point_a.Margin = new Thickness(145 + increment, 0, 0, 0);
                point_b.Margin = new Thickness(755 + increment, 0, 0, 0);
                point_c.Margin = new Thickness(new_point + increment, 0, 0, 0);
            }
            else
            {
                Line.Margin = new Thickness(157, 6, 0, 0);
                point_a.Margin = new Thickness(145, 0, 0, 0);
                point_b.Margin = new Thickness(755, 0, 0, 0);
            }
        }
    }
}
