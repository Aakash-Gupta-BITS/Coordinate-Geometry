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
    public sealed partial class Find_Intersection : Page
    {
        public Find_Intersection()
        {
            this.InitializeComponent();
        }
        double verify;
        private void a1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_b1.Text, out verify) | !double.TryParse(In_c1.Text, out verify) | !double.TryParse(In_a1.Text, out verify) | !double.TryParse(In_a2.Text, out verify) | !double.TryParse(In_b2.Text, out verify) | !double.TryParse(In_c2.Text, out verify))
                outp.Text = "Error in Values";
            else
            {
                double a1 = double.Parse(In_a1.Text), b1 = double.Parse(In_b1.Text), c1 = double.Parse(In_c1.Text), a2 = double.Parse(In_a2.Text), b2 = double.Parse(In_b2.Text), c2 = double.Parse(In_c2.Text);
                {       //Simple 
                    double x = ((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1)), y = ((c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1));
                    if (x % 1 == 0)
                        outp.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , ";
                    else
                        outp.Text = "(x,y) \t\t:\t( " + Convert.ToString(b1 * c2 - b2 * c1) + "/" + Convert.ToString(a1 * b2 - a2 * b1) + " , ";
                    if (y % 1 == 0)
                        outp.Text = outp.Text + Convert.ToString(y) + " )";
                    else
                        outp.Text = outp.Text + Convert.ToString(c1 * a2 - c2 * a1) + "/" + Convert.ToString(a1 * b2 - a2 * b1) + " )";
                }
            }
        }

        private void _2_m1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(_2_m1.Text, out verify) | !double.TryParse(_2_c1.Text, out verify) | !double.TryParse(_2_m2.Text, out verify) | !double.TryParse(_2_c2.Text, out verify))
                outp_2.Text = "Error in Values";
            else
            {
                double m1 = double.Parse(_2_m1.Text), m2 = double.Parse(_2_m2.Text), c1 = double.Parse(_2_c1.Text), c2 = double.Parse(_2_c2.Text);
                {
                    double x = (c1 - c2) / (m2 - m1), y = ((c1 * m2) - (m1 * c2)) / (m2 - m1);
                    if (x % 1 == 0)
                        outp_2.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , ";
                    else
                        outp_2.Text = "(x,y) \t\t:\t( " + Convert.ToString(c1 - c2) + "/" + Convert.ToString(m2 - m1) + " , ";
                    if (y % 1 == 0)
                        outp_2.Text = outp_2.Text + Convert.ToString(y) + " )";
                    else
                        outp_2.Text = outp_2.Text + Convert.ToString((c1 * m2) - (m1 * c2)) + "/" + Convert.ToString(m2 - m1) + " )";
                }
            }
        }

        private void _3_m1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(_3_m1.Text, out verify) | !double.TryParse(_3_d1.Text, out verify) | !double.TryParse(_3_m2.Text, out verify) | !double.TryParse(_3_d2.Text, out verify))
                outp_3.Text = "Error in Values";
            else
            {
                double m1 = double.Parse(_3_m1.Text), m2 = double.Parse(_3_m2.Text), d1 = double.Parse(_3_d1.Text), d2 = double.Parse(_3_d2.Text);
                {
                    double x = (d1 * m1 - d2 * m2) / (m1 - m2), y = (m1 * m2 * (d1 - d2)) / (m1 - m2);
                    if (x % 1 == 0)
                        outp_3.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , ";
                    else
                        outp_3.Text = "(x,y) \t\t:\t( " + Convert.ToString(d1 * m1 - d2 * m2) + "/" + Convert.ToString(m1 - m2) + " , ";
                    if (y % 1 == 0)
                        outp_3.Text = outp_3.Text + Convert.ToString(y) + " )";
                    else
                        outp_3.Text = outp_3.Text + Convert.ToString(d1 * m1 - d2 * m2) + "/" + Convert.ToString(m1 - m2) + " )";
                }
            }
        }

        private void _4_x1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(_4_x1.Text, out verify) | !double.TryParse(_4_y1.Text, out verify) | !double.TryParse(_4_x2.Text, out verify) | !double.TryParse(_4_y2.Text, out verify) | !double.TryParse(_4_x3.Text, out verify) | !double.TryParse(_4_y3.Text, out verify) | !double.TryParse(_4_x4.Text, out verify) | !double.TryParse(_4_y4.Text, out verify))
                outp_4.Text = "Error in Values";
            else
            {
                double x1 = double.Parse(_4_x1.Text), x2 = double.Parse(_4_x2.Text), x3 = double.Parse(_4_x3.Text), x4 = double.Parse(_4_x4.Text), y1 = double.Parse(_4_y1.Text), y2 = double.Parse(_4_y2.Text), y3 = double.Parse(_4_y3.Text), y4 = double.Parse(_4_y4.Text);
                {
                    double x = (((x3 - x4) * (x1 * y2 - y1 * x2)) + ((x2 - x1) * (x3 * y4 - y3 * x4))) / (((x4 - x3) * (y1 - y2)) - ((x2 - x1) * (y3 - y4))), y = (((x1 * y2 - y1 * x2) * (y3 - y4)) - ((y1 - y2) * (x3 * y4 - y3 * x4))) / (((x4 - x3) * (y1 - y2)) - ((x2 - x1) * (y3 - y4)));
                    if (x % 1 == 0)
                        outp_4.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , ";
                    else
                        outp_4.Text = "(x,y) \t\t:\t( " + Convert.ToString(((x3 - x4) * (x1 * y2 - y1 * x2)) + ((x2 - x1) * (x3 * y4 - y3 * x4))) + "/" + Convert.ToString(((x4 - x3) * (y1 - y2)) - ((x2 - x1) * (y3 - y4))) + " , ";
                    if (y % 1 == 0)
                        outp_4.Text = outp_4.Text + Convert.ToString(y) + " )";
                    else
                        outp_4.Text = outp_4.Text + Convert.ToString(((x1 * y2 - y1 * x2) * (y3 - y4)) - ((y1 - y2) * (x3 * y4 - y3 * x4))) + "/" + Convert.ToString(((x4 - x3) * (y1 - y2)) - ((x2 - x1) * (y3 - y4))) + " )";
                }
            }
        }

        private void _5_a1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(_5_a1.Text, out verify) | !double.TryParse(_5_a2.Text, out verify) | !double.TryParse(_5_b1.Text, out verify) | !double.TryParse(_5_b2.Text, out verify) | !double.TryParse(_5_c1.Text, out verify) | !double.TryParse(_5_c2.Text, out verify))
                outp_5.Text = "Error in Values";
            else
            {
                double b1 = double.Parse(_5_a1.Text), b2 = double.Parse(_5_a2.Text), a1 = double.Parse(_5_b1.Text), a2 = double.Parse(_5_b2.Text), c1 = -1 * double.Parse(_5_c1.Text) * a1 * b1, c2 = -1 * double.Parse(_5_c2.Text) * a2 * b2;
                {       //Simple 
                    double x = ((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1)), y = ((c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1));
                    if (x % 1 == 0)
                        outp_5.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , ";
                    else
                        outp_5.Text = "(x,y) \t\t:\t( " + Convert.ToString(b1 * c2 - b2 * c1) + "/" + Convert.ToString(a1 * b2 - a2 * b1) + " , ";
                    if (y % 1 == 0)
                        outp_5.Text = outp_5.Text + Convert.ToString(y) + " )";
                    else
                        outp_5.Text = outp_5.Text + Convert.ToString(c1 * a2 - c2 * a1) + "/" + Convert.ToString(a1 * b2 - a2 * b1) + " )";
                }
            }
        }

        private void th_1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(th_1.Text, out verify) | !double.TryParse(p.Text, out verify) | !double.TryParse(q.Text, out verify) | !double.TryParse(th_2.Text, out verify))
                outp_th.Text = "Error in Values";
            else
            {
                double p1 = double.Parse(p.Text), q1 = double.Parse(q.Text), th1 = Math_Operations.Operations.Deg_Rad(double.Parse(th_1.Text)), th2 = Math_Operations.Operations.Deg_Rad(double.Parse(th_2.Text));
                {
                    double x = Math.Round((q1 * Math.Sin(th1) - p1 * Math.Sin(th2)) / (Math.Sin(th1 - th2)), 5);
                    double y = Math.Round((-q1 * Math.Cos(th1) + p1 * Math.Cos(th2)) / (Math.Sin(th1 - th2)), 5);
                    outp_th.Text = "(x,y) \t\t:\t( " + Convert.ToString(x) + " , " + Convert.ToString(y) + " )";
                }
            }
        }
    }
}
