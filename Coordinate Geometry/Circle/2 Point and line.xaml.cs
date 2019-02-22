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
    public sealed partial class _2_Point_and_line : Page
    {
        public _2_Point_and_line()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_x1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_x1.Text, out verify) | !double.TryParse(In_x2.Text, out verify) | !double.TryParse(In_y1.Text, out verify) | !double.TryParse(In_y2.Text, out verify) | !double.TryParse(In_a.Text, out verify) | !double.TryParse(In_b.Text, out verify) | !double.TryParse(In_c.Text, out verify))
                Output.Text = "";
            else
            { 
                double x1 = double.Parse(In_x1.Text), x2 = double.Parse(In_x2.Text), y1 = double.Parse(In_y1.Text), y2 = double.Parse(In_y2.Text), a = double.Parse(In_a.Text), b = double.Parse(In_b.Text), c = double.Parse(In_c.Text);
                double temp = (x1 * x1) + (y1 * y1) - (x2 * x2) - (y2 * y2);
                double k = -(a * (temp) - 2 * c * (x2 - x1)) / (2 * (a * (y2 - y1) - b * (x2 - x1)));
                double h = (-temp - 2 * k * (y2 - y1)) / (2 * (x2 - x1));
                double r = Math.Sqrt(Math.Pow(x2 - h, 2) + Math.Pow(y2 - k, 2));
                Output.Text = "x\t\t\t:\t" + Convert.ToString(h) + "\ny\t\t\t:\t" + Convert.ToString(k) + "\nRadius\t\t\t:\t" + Convert.ToString(r) + " = √" + Convert.ToString(Math.Pow(r, 2));
                Output.Text = Output.Text + "\n\nArea\t\t\t:\t" + Convert.ToString(Math.PI * r * r);
                Output.Text = Output.Text + "\nPerimeter\t\t:\t" + Convert.ToString(2 * Math.PI * r);
                Output.Text = Output.Text + "\n\nStandard Equation \t:\tx - (" + Convert.ToString(h) + ")² + y - (" + Convert.ToString(k) + ")² = (" + Convert.ToString(r) + ")²";
                Output.Text = Output.Text + "\n\nGeneral Equation \t:\tx² + y² + (" + Convert.ToString(-2 * h) + ")x + (" + Convert.ToString(-2 * k) + ")y + (" + Convert.ToString((h * h) + (k * k) - (r * r)) + ") = 0";
                Output.Text = Output.Text + "\n\nX-Intercept \t\t:\t(" + Convert.ToString(h + Math.Sqrt((r * r) - (k * k))) + " , 0) , (" + Convert.ToString(h - Math.Sqrt((r * r) - (k * k))) + " , 0)";
                Output.Text = Output.Text + "\nY-Intercept \t\t:\t(0 , " + Convert.ToString(k + Math.Sqrt((r * r) - (h * h))) + ") , (0 , " + Convert.ToString(k - Math.Sqrt((r * r) - (h * h))) + ")";
                string s = ""; Display.Mathematica.Circle_Equation(h, k, r, a, b, c, ref s);
                Output.Text = Output.Text + "\n\n\nMathematica\t\t:\t" + s;
            }
        }
    }
}
