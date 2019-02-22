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
    public sealed partial class Convert_Equation : Page
    {
        public Convert_Equation()
        {
            this.InitializeComponent();
        }
        double verify;
        private void a_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(b.Text, out verify))
                m_1.Text = "";
            else
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(a.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(c.Text, out verify))
                d_2.Text = "";
            else
                d_2.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(a.Text));
            a_3.Text = d_2.Text;
            m_2.Text = m_1.Text;
            output();
        }

        private void b_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(b.Text, out verify))
                m_1.Text = "";
            else
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(a.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(b.Text, out verify) | !double.TryParse(c.Text, out verify))
                c_1.Text = "";
            else
                c_1.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(b.Text));
            b_3.Text = c_1.Text;
            m_2.Text = m_1.Text;
            output();
        }

        private void c_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(b.Text, out verify) | !double.TryParse(c.Text, out verify))
                c_1.Text = "";
            else
                c_1.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(c.Text, out verify))
                d_2.Text = "";
            else
                d_2.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(a.Text));
            a_3.Text = d_2.Text;
            b_3.Text = c_1.Text;
            output();
        }

        private void m_1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            m_2.Text = m_1.Text; general_find();
        }

        private void c_1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            b_3.Text = c_1.Text;
            if (!double.TryParse(c_1.Text, out verify) | !double.TryParse(m_1.Text, out verify))
                d_2.Text = "";
            else
                d_2.Text = Convert.ToString(-1 * Convert.ToDouble(c_1.Text) / Convert.ToDouble(m_1.Text));
            a_3.Text = d_2.Text; general_find();
        }

        private void m_2_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            m_1.Text = m_2.Text; general_find();
        }

        private void d_2_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            a_3.Text = d_2.Text;
            if (!double.TryParse(d_2.Text, out verify) | !double.TryParse(m_2.Text, out verify))
                c_1.Text = "";
            else
                c_1.Text = Convert.ToString(-1 * Convert.ToDouble(d_2.Text) * Convert.ToDouble(m_2.Text));
            b_3.Text = c_1.Text; general_find();
        }

        private void a_3_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            d_2.Text = a_3.Text;
            if (double.TryParse(c_1.Text, out verify) & double.TryParse(d_2.Text, out verify))
            {
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(c_1.Text) / Convert.ToDouble(d_2.Text));
            }
            m_2.Text = m_1.Text; general_find();
        }

        private void b_3_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            c_1.Text = b_3.Text;
            if (double.TryParse(c_1.Text, out verify) & double.TryParse(d_2.Text, out verify))
            {
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(c_1.Text) / Convert.ToDouble(d_2.Text));
            }
            m_2.Text = m_1.Text; general_find();
        }

        private void general_find()
        {
            Output.Text = "";
            if (double.TryParse(c_1.Text, out verify) & double.TryParse(d_2.Text, out verify))
            {
                double a_ = -1 * double.Parse(c_1.Text), b_ = -1 * double.Parse(d_2.Text), c_ = a_ * b_;
                Math_Operations.Operations.HCF(ref a_, ref b_, ref c_);
                if (a_ < 0) { a_ *= -1; b_ *= -1; c_ *= -1; }
                a.Text = Convert.ToString(a_);
                b.Text = Convert.ToString(b_);
                c.Text = Convert.ToString(c_);
                output();
            }
        }

        private void output()
        {
            Output.Text = "";
            if (double.TryParse(m_1.Text, out verify) & double.TryParse(c_1.Text, out verify) & double.TryParse(d_2.Text, out verify))
            {
                double angle = Math_Operations.Operations.Rad_Deg(Math.Atan(Convert.ToDouble(m_1.Text))); if (angle < 0) { angle += 180; }
                Output.Text = "Angle \t\t\t\t:\t" + Convert.ToString(angle);
                double c_ = double.Parse(c_1.Text), d_ = double.Parse(d_2.Text);
                double omega = Math_Operations.Operations.Rad_Deg(Math.Atan(-1 / Convert.ToDouble(m_1.Text)));
                if (c_ < 0 & d_ > 0) { omega *= -1; }
                if (c_ > 0 & d_ < 0) { omega += 180; }
                if (c_ < 0 & d_ < 0) { omega -= 180; }
                Output.Text = Output.Text + "\nAngle With Origin\t\t:\t" + Convert.ToString(omega);
                Output.Text = Output.Text + "\n\nArea Under Axes \t\t:\t" + Convert.ToString(c_ * d_ / 2);
                Output.Text = Output.Text + "\n\nDistance b/w Intercepts \t:\t" + Convert.ToString(Math.Sqrt(Math.Pow(c_, 2) + Math.Pow(d_, 2)));
                Output.Text = Output.Text + "\n\nDistance from Origin \t\t:\t" + Convert.ToString(Math.Abs(c_ * d_) / (Math.Sqrt(Math.Pow(c_, 2) + Math.Pow(d_, 2))));
                Output.Text = Output.Text + "\n\nIntercept x \t\t\t:\t" + d_2.Text + "\nIntercept y \t\t\t:\t" + c_1.Text;
                Output.Text = Output.Text + "\n\nSlope \t\t\t\t:\t" + m_2.Text;
                {
                    if (double.TryParse(a.Text, out verify) & double.TryParse(b.Text, out verify) & double.TryParse(c.Text, out verify))
                    {
                        string s = ""; Display.Mathematica.Straight(double.Parse(a.Text), double.Parse(b.Text), double.Parse(c.Text), ref s);
                        Output.Text = Output.Text + "\n\n\nMathematica\t\t:\t" + s;
                    }
                }
            }
        }

        private void a_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(b.Text, out verify))
                m_1.Text = "";
            else
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(a.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(c.Text, out verify))
                d_2.Text = "";
            else
                d_2.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(a.Text));
            a_3.Text = d_2.Text;
            m_2.Text = m_1.Text;
            output();
        }

        private void b_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(b.Text, out verify))
                m_1.Text = "";
            else
                m_1.Text = Convert.ToString(-1 * Convert.ToDouble(a.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(b.Text, out verify) | !double.TryParse(c.Text, out verify))
                c_1.Text = "";
            else
                c_1.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(b.Text));
            b_3.Text = c_1.Text;
            m_2.Text = m_1.Text;
            output();
        }

        private void c_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(b.Text, out verify) | !double.TryParse(c.Text, out verify))
                c_1.Text = "";
            else
                c_1.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(b.Text));
            if (!double.TryParse(a.Text, out verify) | !double.TryParse(c.Text, out verify))
                d_2.Text = "";
            else
                d_2.Text = Convert.ToString(-1 * Convert.ToDouble(c.Text) / Convert.ToDouble(a.Text));
            a_3.Text = d_2.Text;
            b_3.Text = c_1.Text;
            output();
        }

        private void eq_m_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(eq_m.Text, out verify) | !double.TryParse(eq_y.Text, out verify) | !double.TryParse(eq_x.Text, out verify))
                clear_all();
            else
            {
                double m = double.Parse(eq_m.Text), x = double.Parse(eq_x.Text), y = double.Parse(eq_y.Text);
                if (m > 0)
                {
                    a.Text = Convert.ToString(m); b.Text = "-1"; c.Text = Convert.ToString((-m * x) + y);
                }
                else
                {
                    a.Text = Convert.ToString(-m); b.Text = "1"; c.Text = Convert.ToString(m * x - y);
                }
            }
        }

        private void clear_all()
        {
            a.Text = "";
            b.Text = "";
            c.Text = "";
            m_1.Text = "";
            m_2.Text = "";
            c_1.Text = "";
            d_2.Text = "";
            a_3.Text = "";
            b_3.Text = "";
            Output.Text = "";
        }

        private void eq_x1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(eq_x1.Text, out verify) | !double.TryParse(eq_x2.Text, out verify) | !double.TryParse(eq_y1.Text, out verify) | !double.TryParse(eq_y2.Text, out verify))
            {
                clear_all();
            }
            else
            {
                double x1 = double.Parse(eq_x1.Text), x2 = double.Parse(eq_x2.Text), y1 = double.Parse(eq_y1.Text), y2 = double.Parse(eq_y2.Text);
                if (y2 - y1 > 0)
                {
                    a.Text = Convert.ToString(y2 - y1); b.Text = Convert.ToString(x1 - x2); c.Text = Convert.ToString(y1 * (x2 - x1) - x1 * (y2 - y1));
                }
                else
                {
                    a.Text = Convert.ToString(y1 - y2); b.Text = Convert.ToString(x2 - x1); c.Text = Convert.ToString(x1 * (y2 - y1) - y1 * (x2 - x1));
                }
            }
        }
    }
}