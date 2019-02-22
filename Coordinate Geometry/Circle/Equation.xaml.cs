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

namespace Co_ordinate_Geometry.Circle
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Equation : Page
    {
        public Equation()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_h_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            In_x.Text = "1"; In_y.Text = "1";

            if (double.TryParse(In_h.Text, out verify))
                In_A.Text = Convert.ToString(-2 * Convert.ToDouble(In_h.Text));
            else
                In_A.Text = "-";

            if (double.TryParse(In_k.Text, out verify))
                In_B.Text = Convert.ToString(-2 * Convert.ToDouble(In_k.Text));
            else
                In_B.Text = "-";

            if (double.TryParse(In_h.Text, out verify) & double.TryParse(In_k.Text, out verify) & double.TryParse(In_r.Text, out verify))
            {
                double h = double.Parse(In_h.Text), k = double.Parse(In_k.Text), r = double.Parse(In_r.Text);
                In_C.Text = Convert.ToString((h * h) + (k * k) - (r * r));
            }
            else
                In_C.Text = "-";
            output_eq_2();
        }

        private void In_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_x.Text, out verify) | !double.TryParse(In_y.Text, out verify) | !double.TryParse(In_A.Text, out verify) | !double.TryParse(In_B.Text, out verify) | !double.TryParse(In_C.Text, out verify))
            {
                In_h.Text = ""; In_k.Text = ""; In_r.Text = "";
            }
            else
            {
                double x = double.Parse(In_x.Text), y = double.Parse(In_y.Text), A = double.Parse(In_A.Text), B = double.Parse(In_B.Text), C = double.Parse(In_C.Text);
                if (x != y)
                {
                    In_h.Text = ""; In_k.Text = ""; In_r.Text = "";
                }
                else
                {
                    C /= x; B /= x; A /= x; y /= x; x /= x;
                    In_h.Text = Convert.ToString(A / -2);
                    In_k.Text = Convert.ToString(B / -2);
                    In_r.Text = Convert.ToString(Math.Sqrt((-C) + (A / -2) * (A / -2) + (B / -2) * (B / -2)));
                }
            }
            output_eq_2();
        }

        private void output_eq_2()
        {
            if (!double.TryParse(In_x.Text, out verify) | !double.TryParse(In_y.Text, out verify) | !double.TryParse(In_A.Text, out verify) | !double.TryParse(In_B.Text, out verify) | !double.TryParse(In_C.Text, out verify))
                Output.Text = "";
            else
            {
                double x = double.Parse(In_x.Text), y = double.Parse(In_y.Text), A = double.Parse(In_A.Text), B = double.Parse(In_B.Text), C = double.Parse(In_C.Text);
                if (x != y)
                    Output.Text = "This Equation is not a valid equation because coefficients of x and y are not equal.";
                else if ((Math.Pow((A / x), 2.0) + Math.Pow((B / x), 2.0) + ((C / x) * (-4.0))) < 0)
                    Output.Text = "This Equation is not a valid equation because Radius is Imaginary";
                else
                {
                    double h = Convert.ToDouble(In_h.Text); double k = Convert.ToDouble(In_k.Text); double r = Convert.ToDouble(In_r.Text);
                    Output.Text = "x \t\t: \t" + Convert.ToString(-A) + "/ " + Convert.ToString(2 * x) + "\ny \t\t:\t" + Convert.ToString(-B) + "/ " + Convert.ToString(2 * x) + "\nRadius \t:\t√" + Convert.ToString(Math.Pow(Convert.ToDouble(In_r.Text), 2));
                    Output.Text = Output.Text + "\n\nArea \t\t\t:\t" + Convert.ToString(Math.PI * r * r);
                    Output.Text = Output.Text + "\nPerimeter \t\t:\t" + Convert.ToString(2 * Math.PI * r);
                    Output.Text = Output.Text + "\n\nX-Intercept \t\t:\t(" + Convert.ToString(h + Math.Sqrt((r * r) - (k * k))) + " , 0) , (" + Convert.ToString(h - Math.Sqrt((r * r) - (k * k))) + " , 0)";
                    Output.Text = Output.Text + "\nY-Intercept \t\t:\t(0 , " + Convert.ToString(k + Math.Sqrt((r * r) - (h * h))) + ") , (0 , " + Convert.ToString(k - Math.Sqrt((r * r) - (h * h))) + ")";
                    string s = ""; Display.Mathematica.Circle(h, k, r, ref s);
                    Output.Text = Output.Text + "\n\n\nMathematica\t\t:\t" + s;
                }
            }
        }
    }
}
