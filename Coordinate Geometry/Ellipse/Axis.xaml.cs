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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Co_ordinate_Geometry.Ellipse
{
    public sealed partial class Axis : Page
    {
        public Axis()
        {
            this.InitializeComponent();
            Output.TextWrapping = TextWrapping.Wrap;
            _x.IsChecked = true;
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear_eq_1();
            clear_eq_2();
        }

        double verify;

        private void out_x(double a, double b, double c, double e)
        {
            Output.Text = "Variables\n\ta\t\t\t\t:\t√" + Math.Pow(a, 2) + " = " + a + "\n\tb\t\t\t\t:\t√" + Math.Pow(b, 2) + " = " + b + "\n\tc\t\t\t\t:\t√" + Math.Pow(c, 2) + " = " + c + "\n\te (c / a)\t\t\t:\t" + Math.Round(c, 5) + " / " + Math.Round(a, 5) + " = " + Math.Round(e, 5);
            Output.Text = Output.Text + "\n\nEquations\n\tAxis\t\t\t\t:\ty = 0\n\tStandard\t\t\t:\tx²/" + Math.Round(a * a, 5) + " + y²/" + Math.Round(b * b, 5) + " = 1\n\tGeneral\t\t\t:\t" + Math.Round(b * b, 5) + "x² + " + Math.Round(a * a, 5) + "y² = " + Math.Round(a * a * b * b, 5) + "\n\tDirectrix\t\t\t:\tx = ±a/e = ±" + Math.Round(a, 5) + " / " + Math.Round(e, 5) + " = ±" + Math.Round(Math.Abs(a / e), 5);
            Output.Text = Output.Text + "\n\nLengths\n\tLatus Rectum(2b²/a)\t\t:\t" + 2 * b * b / a + "\n\tMajor-Axis\t\t\t:\t" + 2 * a + "\n\tMinor-Axis\t\t\t:\t" + 2 * b;
            Output.Text = Output.Text + "\n\nPoints\n\tCenter\t\t\t\t:\t(0 , 0)\n\tFocus\t\t\t\t:\t(±" + c + " , 0)\n\tVertex\t\t\t\t:\t(±" + a + " , 0)";
            string s = "";
            Display.Mathematica.Ellipse(a, b, c, e, ref s);
            Output.Text += "\n\nMathematica\t\t\t\t:\t" + s;
        }

        private void out_y(double a, double b, double c, double e)
        {
            Output.Text = "Variables\n\ta\t\t\t\t:\t√" + Math.Pow(b, 2) + " = " + b + "\n\tb\t\t\t\t:\t√" + Math.Pow(a, 2) + " = " + a + "\n\tc\t\t\t\t:\t√" + Math.Pow(c, 2) + " = " + c + "\n\te (c / a)\t\t\t:\t" + Math.Round(c, 5) + " / " + Math.Round(b, 5) + " = " + Math.Round(e, 5);
            Output.Text = Output.Text + "\n\nEquations\n\tAxis\t\t\t\t:\ty = 0\n\tStandard\t\t\t:\tx²/" + Math.Round(a * a, 5) + " + y²/" + Math.Round(b * b, 5) + " = 1\n\tGeneral\t\t\t:\t" + Math.Round(b * b, 5) + "x² + " + Math.Round(a * a, 5) + "y² = " + Math.Round(a * a * b * b, 5) + "\n\tDirectrix\t\t\t:\ty = ±a/e = ±" + Math.Round(b, 5) + " / " + Math.Round(e, 5) + " = ±" + Math.Round(Math.Abs(b / e), 5);
            Output.Text = Output.Text + "\n\nLenghts\n\tLatus Rectum(2b²/a)\t\t:\t" + 2 * a * a / b + "\n\tMajor-Axis\t\t\t:\t" + 2 * b + "\n\tMinor-Axis\t\t\t:\t" + 2 * a;
            Output.Text = Output.Text + "\n\nPoints\n\tCenter\t\t\t\t:\t(0 , 0)\n\tFocus\t\t\t\t:\t(0 , ±" + c + ")\n\tVertex\t\t\t\t:\t(0 , ±" + b + ")";
            string s = "";
            Display.Mathematica.Ellipse(a, b, c, e, ref s);
            Output.Text += "\n\nMathematica\t\t\t\t:\t" + s;
        }

        public void clear_eq_1()
        {
            Output.Text = "";
            In_eq2_m.Text = "";
            In_eq2_n.Text = "";
            In_eq2_o.Text = "";
            In_Ax.Text = "";
            In_Ay.Text = "";
            In_Bx.Text = "";
            In_By.Text = "";
            In_c.Text = "";
            In_a.Text = "";
            In_b.Text = "";
            In_c_2.Text = "";
            In_a_2.Text = "";
            In_b_2.Text = "";
            In_2a.Text = "";
            In_2b.Text = "";
            In_2a_2.Text = "";
            In_2b_2.Text = "";
        }

        public void clear_eq_2()
        {
            Output.Text = "";
            In_eq_a2.Text = "";
            In_eq_b2.Text = "";
            In_Ax.Text = "";
            In_Ay.Text = "";
            In_Bx.Text = "";
            In_By.Text = "";
            In_c.Text = "";
            In_a.Text = "";
            In_b.Text = "";
            In_c_2.Text = "";
            In_a_2.Text = "";
            In_b_2.Text = "";
            In_2a.Text = "";
            In_2b.Text = "";
            In_2a_2.Text = "";
            In_2b_2.Text = "";
        }

        public void clear_eq_3()
        {
            Output.Text = "";
            In_eq_a2.Text = "";
            In_eq_b2.Text = "";
            In_eq2_m.Text = "";
            In_eq2_n.Text = "";
            In_eq2_o.Text = "";
            In_c.Text = "";
            In_a.Text = "";
            In_b.Text = "";
            In_c_2.Text = "";
            In_a_2.Text = "";
            In_b_2.Text = "";
            In_2a.Text = "";
            In_2b.Text = "";
            In_2a_2.Text = "";
            In_2b_2.Text = "";
        }

        public void clear_eq_4()
        {
            Output.Text = "";
            In_eq_a2.Text = "";
            In_eq_b2.Text = "";
            In_eq2_m.Text = "";
            In_eq2_n.Text = "";
            In_eq2_o.Text = "";
            In_Ax.Text = "";
            In_Ay.Text = "";
            In_Bx.Text = "";
            In_By.Text = "";
            In_b.Text = "";
            In_c_2.Text = "";
            In_a_2.Text = "";
            In_b_2.Text = "";
            In_2b.Text = "";
            In_2a_2.Text = "";
            In_2b_2.Text = "";
        }

        public void clear_eq_5()
        {
            Output.Text = "";
            In_eq_a2.Text = "";
            In_eq_b2.Text = "";
            In_eq2_m.Text = "";
            In_eq2_n.Text = "";
            In_eq2_o.Text = "";
            In_Ax.Text = "";
            In_Ay.Text = "";
            In_Bx.Text = "";
            In_By.Text = "";
            In_c.Text = "";
            In_a.Text = "";
            In_2a.Text = "";
            In_a_2.Text = "";
            In_2a_2.Text = "";
            In_b_2.Text = "";
            In_2b_2.Text = "";
        }

        public void clear_eq_6()
        {
            Output.Text = "";
            In_eq_a2.Text = "";
            In_eq_b2.Text = "";
            In_eq2_m.Text = "";
            In_eq2_n.Text = "";
            In_eq2_o.Text = "";
            In_Ax.Text = "";
            In_Ay.Text = "";
            In_Bx.Text = "";
            In_By.Text = "";
            In_c.Text = "";
            In_a.Text = "";
            In_2a.Text = "";
            In_c_2.Text = "";
            In_b.Text = "";
            In_2b.Text = "";
        }

        public void fill_a(double a)
        {
            In_a.Text = Convert.ToString(a);
            In_2a.Text = Convert.ToString(2 * a);
            In_a_2.Text = Convert.ToString(a);
            In_2a_2.Text = Convert.ToString(2 * a);
        }

        public void fill_b(double b)
        {
            In_b.Text = Convert.ToString(b);
            In_2b.Text = Convert.ToString(2 * b);
            In_b_2.Text = Convert.ToString(b);
            In_2b_2.Text = Convert.ToString(2 * b);
        }

        private void In_eq_a2_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_eq_a2.Text, out verify) | !double.TryParse(In_eq_b2.Text, out verify))
            { clear_eq_1(); }
            else if (double.Parse(In_eq_a2.Text) <= 0 | double.Parse(In_eq_b2.Text) <= 0)
                clear_eq_1();
            else
            {
                double a = Math.Sqrt(double.Parse(In_eq_a2.Text)), b = Math.Sqrt(double.Parse(In_eq_b2.Text));
                if (a > b)
                {
                    _x.IsChecked = true;
                    double e_ = Math.Sqrt(1 - b * b / (a * a)), c = Math.Sqrt(Math.Abs(a * a - b * b));
                    In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    In_c.Text = Convert.ToString(a * e_); In_a.Text = Convert.ToString(a); In_b.Text = Convert.ToString(b);
                    In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                    In_2a.Text = Convert.ToString(2 * a); In_2b.Text = Convert.ToString(2 * b);
                    In_2a_2.Text = In_2a.Text; In_2b_2.Text = In_2b.Text;
                    out_x(a, b, c, e_);
                }
                else if (a < b)
                {
                    _y.IsChecked = true;
                    double e_ = Math.Sqrt(1 - a * a / (b * b)), c = Math.Sqrt(b * b - a * a);
                    In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    In_c.Text = Convert.ToString(b * e_); In_a.Text = Convert.ToString(b); In_b.Text = Convert.ToString(a);
                    In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                    In_2a.Text = Convert.ToString(2 * b); In_2b.Text = Convert.ToString(2 * a);
                    In_2b_2.Text = In_2b.Text; In_2a_2.Text = In_2a.Text;
                    out_y(a, b, c, e_);
                }
            }
        }

        private void In_eq2_m_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_eq2_m.Text, out verify) | !double.TryParse(In_eq2_n.Text, out verify) | !double.TryParse(In_eq2_o.Text, out verify))
                clear_eq_2();
            else if (double.Parse(In_eq2_m.Text) <= 0 | double.Parse(In_eq2_n.Text) <= 0 | double.Parse(In_eq2_o.Text) <= 0)
                clear_eq_2();
            else
            {
                double a = Math.Sqrt(double.Parse(In_eq2_o.Text) / double.Parse(In_eq2_m.Text)), b = Math.Sqrt(double.Parse(In_eq2_o.Text) / double.Parse(In_eq2_n.Text));
                if (a > b)
                {
                    _x.IsChecked = true;
                    double e_ = Math.Sqrt(1 - b * b / (a * a)), c = Math.Sqrt(Math.Abs(a * a - b * b));
                    In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                    In_c.Text = Convert.ToString(a * e_); In_a.Text = Convert.ToString(a); In_b.Text = Convert.ToString(b);
                    In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                    In_2a.Text = Convert.ToString(2 * a); In_2b.Text = Convert.ToString(2 * b);
                    In_2a_2.Text = In_2a.Text; In_2b_2.Text = In_2b.Text;
                    out_x(a, b, c, e_);
                }
                else if (a < b)
                {
                    _y.IsChecked = true;
                    double e_ = Math.Sqrt(1 - a * a / (b * b)), c = Math.Sqrt(b * b - a * a);
                    In_eq_a2.Text = Convert.ToString(b * b); In_eq_b2.Text = Convert.ToString(a * a);
                    In_c.Text = Convert.ToString(b * e_); In_a.Text = Convert.ToString(b); In_b.Text = Convert.ToString(a);
                    In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                    In_2a.Text = Convert.ToString(2 * b); In_2b.Text = Convert.ToString(2 * a);
                    In_2b_2.Text = In_2b.Text; In_2a_2.Text = In_2a.Text;
                    out_y(a, b, c, e_);
                }
            }
        }

        private void In_Ax_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_Ax.Text, out verify) | !double.TryParse(In_Ay.Text, out verify) | !double.TryParse(In_Bx.Text, out verify) | !double.TryParse(In_By.Text, out verify))
                clear_eq_3();
            else
            {
                double x1 = double.Parse(In_Ax.Text), x2 = double.Parse(In_Bx.Text), y1 = double.Parse(In_Ay.Text), y2 = double.Parse(In_By.Text);
                if (_x.IsChecked == true)
                {
                    double a_2 = 0, b_2 = 0;
                    if (y2 - y1 == 0 & x2 - x1 != 0) { b_2 = (x1 * x1 * y2 * y2 - x2 * x2 * y1 * y1) / (x1 * x1 - x2 * x2); a_2 = b_2 * b_2 * x1 * x1 / (b_2 * b_2 - y1 * y1); }
                    else if (x2 - x1 == 0 & y2 - y1 != 0) { a_2 = (x2 * x2 * y1 * y1 - x1 * x1 * y2 * y2) / (y1 * y1 - y2 * y2); b_2 = a_2 * a_2 * y1 * y1 / (a_2 * a_2 - x1 * x1); }
                    else { a_2 = (x2 * x2 * y1 * y1 - x1 * x1 * y2 * y2) / (y1 * y1 - y2 * y2); b_2 = (x1 * x1 * y2 * y2 - x2 * x2 * y1 * y1) / (x1 * x1 - x2 * x2); }
                    if (a_2 <= 0 | b_2 <= 0) clear_eq_3();
                    else
                    {
                        double a = Math.Sqrt(a_2), b = Math.Sqrt(b_2);
                        double e_ = Math.Sqrt(1 - b * b / (a * a)), c = Math.Sqrt(Math.Abs(a * a - b * b));
                        In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                        In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                        In_c.Text = Convert.ToString(c); In_a.Text = Convert.ToString(a); In_b.Text = Convert.ToString(b);
                        In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                        In_2a.Text = Convert.ToString(2 * a); In_2b.Text = Convert.ToString(2 * b);
                        In_2a_2.Text = In_2a.Text; In_2b_2.Text = In_2b.Text;
                        out_x(a, b, c, e_);
                    }
                }
                else if (_y.IsChecked == true)
                {
                    double a_2 = 0, b_2 = 0;
                    if (y2 - y1 == 0 & x2 - x1 != 0) { b_2 = (x1 * x1 * y2 * y2 - x2 * x2 * y1 * y1) / (x1 * x1 - x2 * x2); a_2 = b_2 * b_2 * x1 * x1 / (b_2 * b_2 - y1 * y1); }
                    else if (x2 - x1 == 0 & y2 - y1 != 0) { a_2 = (x2 * x2 * y1 * y1 - x1 * x1 * y2 * y2) / (y1 * y1 - y2 * y2); b_2 = a_2 * a_2 * y1 * y1 / (a_2 * a_2 - x1 * x1); }
                    else { a_2 = (x2 * x2 * y1 * y1 - x1 * x1 * y2 * y2) / (y1 * y1 - y2 * y2); b_2 = (x1 * x1 * y2 * y2 - x2 * x2 * y1 * y1) / (x1 * x1 - x2 * x2); }
                    if (a_2 <= 0 | b_2 <= 0) clear_eq_3();
                    else
                    {
                        double a = Math.Sqrt(a_2), b = Math.Sqrt(b_2);
                        double e_ = Math.Sqrt(1 - a * a / (b * b)), c = Math.Sqrt(b * b - a * a);
                        In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                        In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                        In_c.Text = Convert.ToString(c); In_a.Text = Convert.ToString(b); In_b.Text = Convert.ToString(a);
                        In_c_2.Text = In_c.Text; In_a_2.Text = In_a.Text; In_b_2.Text = In_b.Text;
                        In_2a.Text = Convert.ToString(2 * b); In_2b.Text = Convert.ToString(2 * a);
                        In_2b_2.Text = In_2b.Text; In_2a_2.Text = In_2a.Text;
                        out_y(a, b, c, e_);
                    }
                }
            }
        }

        private void In_c_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_c.Text, out verify) | !double.TryParse(In_a.Text, out verify) | !double.TryParse(In_2a.Text, out verify))
                clear_eq_4();
            else if (double.Parse(In_c.Text) <= 0 | double.Parse(In_a.Text) <= 0 | double.Parse(In_a.Text) * 2 != double.Parse(In_2a.Text))
                clear_eq_4();
            else
            {
                double c = double.Parse(In_c.Text), a = double.Parse(In_a.Text);
                if (_x.IsChecked == true)
                {
                    if (c >= a) clear_eq_4();
                    else
                    {
                        double b = Math.Sqrt(a * a - c * c);
                        double e_ = c / a;
                        In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                        In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                        In_c_2.Text = Convert.ToString(c); In_b.Text = Convert.ToString(b); In_b_2.Text = Convert.ToString(2 * b);
                        In_a_2.Text = In_a.Text; In_2a_2.Text = In_2a.Text; In_2b_2.Text = In_2b.Text; In_b_2.Text = In_b.Text;
                        out_x(a, b, c, e_);
                    }
                }
                else if (_y.IsChecked == true)
                {
                    if (c >= a) clear_eq_4();
                    else
                    {
                        double b = double.Parse(In_a.Text);
                        a = Math.Sqrt(b * b - c * c);
                        double e_ = Math.Sqrt(1 - a * a / (b * b));
                        In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                        In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                        In_c_2.Text = In_c.Text; In_b.Text = Convert.ToString(a); In_b_2.Text = In_b.Text; In_2b.Text = Convert.ToString(2 * a); In_2b_2.Text = In_b.Text;
                        In_a_2.Text = In_a.Text; In_2a_2.Text = In_2a.Text;
                        out_y(a, b, c, e_);
                    }
                }
            }
        }

        private void In_c_2_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_c_2.Text, out verify) | !double.TryParse(In_b.Text, out verify) | !double.TryParse(In_2b.Text, out verify))
                clear_eq_5();
            else if (double.Parse(In_c_2.Text) <= 0 | double.Parse(In_b.Text) <= 0 | double.Parse(In_b.Text) * 2 != double.Parse(In_2b.Text))
                clear_eq_5();
            else
            {
                double c = double.Parse(In_c_2.Text), b = double.Parse(In_b.Text);
                if (_x.IsChecked == true)
                {
                    double a = Math.Sqrt(b * b + c * c);
                    double e_ = c / a;
                    In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                    In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    In_c.Text = Convert.ToString(c); In_a.Text = Convert.ToString(a); In_a_2.Text = Convert.ToString(2 * a);
                    In_a_2.Text = In_a.Text; In_2a_2.Text = In_2a.Text; In_2b_2.Text = In_2b.Text; In_b_2.Text = In_b.Text;
                    out_x(a, b, c, e_);
                }
                else if (_y.IsChecked == true)
                {
                    double a = double.Parse(In_b.Text); b = Math.Sqrt(a * a + c * c);
                    double e_ = Math.Sqrt(1 - a * a / (b * b));
                    In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                    In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    In_c.Text = In_c_2.Text; In_a.Text = Convert.ToString(a); In_2b.Text = Convert.ToString(2 * a); In_2b_2.Text = In_b.Text;
                    In_a_2.Text = In_a.Text; In_2a_2.Text = In_2a.Text; In_b_2.Text = In_b.Text;
                    out_y(a, b, c, e_);
                }
            }
        }

        private void In_a_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_a.Text, out verify)) { In_2a.Text = ""; }
            else
            {
                double a = double.Parse(In_a.Text);
                if (a > 0)
                {
                    fill_a(a);
                }
            }
        }

        private void In_a_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_a_2.Text, out verify)) { In_2a_2.Text = ""; }
            else
            {
                double a = double.Parse(In_a_2.Text);
                if (a > 0)
                {
                    fill_a(a);
                }
            }
        }

        private void In_b_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_b.Text, out verify)) { In_2b.Text = ""; }
            else
            {
                double b = double.Parse(In_b.Text);
                if (b > 0)
                {
                    fill_b(b);
                }
            }
        }

        private void In_b_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_b_2.Text, out verify)) { In_2b_2.Text = ""; }
            else
            {
                double b = double.Parse(In_b_2.Text);
                if (b > 0)
                {
                    fill_b(b);
                }
            }
        }

        private void In_2a_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_2a.Text, out verify)) { In_a.Text = ""; }
            else
            {
                double a = double.Parse(In_2a.Text) / 2;
                if (a > 0)
                {
                    fill_a(a);
                }
            }
        }

        private void In_2a_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_2a_2.Text, out verify)) { In_a_2.Text = ""; }
            else
            {
                double a = double.Parse(In_2a_2.Text) / 2;
                if (a > 0)
                {
                    fill_a(a);
                }
            }
        }

        private void In_2b_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_2b.Text, out verify)) { In_b.Text = ""; }
            else
            {
                double b = double.Parse(In_2b.Text) / 2;
                if (b > 0)
                {
                    fill_b(b);
                }
            }
        }

        private void In_2b_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(In_2b_2.Text, out verify)) { In_b_2.Text = ""; }
            else
            {
                double b = double.Parse(In_2b_2.Text) / 2;
                if (b > 0)
                {
                    fill_b(b);
                }
            }
        }

        private void In_a_2_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_a_2.Text, out verify) | !double.TryParse(In_2a_2.Text, out verify) | !double.TryParse(In_b_2.Text, out verify) | !double.TryParse(In_2b_2.Text, out verify))
                clear_eq_6();
            else if (double.Parse(In_a_2.Text) < double.Parse(In_b_2.Text))
                clear_eq_6();
            else
            {
                double a = double.Parse(In_a_2.Text), b = double.Parse(In_b_2.Text);
                double e_ = Math.Sqrt(1 - (b * b) / (a * a)), c = a * e_;
                In_c.Text = Convert.ToString(c); In_c_2.Text = In_c.Text;
                In_a.Text = Convert.ToString(a); In_b.Text = Convert.ToString(b);
                In_2a.Text = Convert.ToString(2 * a); In_2b.Text = Convert.ToString(2 * b);
                if (_x.IsChecked == true)
                {
                    In_eq_a2.Text = Convert.ToString(a * a); In_eq_b2.Text = Convert.ToString(b * b);
                    In_eq2_m.Text = Convert.ToString(b * b); In_eq2_n.Text = Convert.ToString(a * a); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    out_x(a, b, c, e_);
                }
                else if (_y.IsChecked == true)
                {
                    In_eq_a2.Text = Convert.ToString(b * b); In_eq_b2.Text = Convert.ToString(a * a);
                    In_eq2_m.Text = Convert.ToString(a * a); In_eq2_n.Text = Convert.ToString(b * b); In_eq2_o.Text = Convert.ToString(a * a * b * b);
                    out_y(b, a, c, e_);
                }
            }
        }
    }
}