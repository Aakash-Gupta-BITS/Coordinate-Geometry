using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
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
    public sealed partial class Center_and_Point : Page
    {
        public Center_and_Point()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_h.Text, out verify) | !double.TryParse(In_k.Text, out verify) | !double.TryParse(In_y.Text, out verify) | !double.TryParse(In_x.Text, out verify))
            {
                Output.Text = "Error in Values";
            }
            else
            {
                double h = double.Parse(In_h.Text), k = double.Parse(In_k.Text), y = double.Parse(In_y.Text), x = double.Parse(In_x.Text);
                double r = Math.Abs(Math.Sqrt(Math.Pow(x - h, 2) + Math.Pow(y - k, 2)));
                Output.Text = "x \t\t: \t" + Convert.ToString(h);
                Output.Text = Output.Text + "\ny \t\t: \t" + Convert.ToString(k);
                Output.Text = Output.Text + "\nRadius\t\t:\t" + Convert.ToString(r) + " = √" + Convert.ToString(Math.Pow(r, 2));
                Output.Text = Output.Text + "\n\nArea\t\t\t:\t" + Convert.ToString(Math.PI * r * r);
                Output.Text = Output.Text + "\nPerimeter\t\t:\t" + Convert.ToString(2 * Math.PI * r);
                Output.Text = Output.Text + "\n\nStandard Equation \t:\tx - (" + Convert.ToString(h) + ")² + y - (" + Convert.ToString(k) + ")² = (" + Convert.ToString(r) + ")²";
                Output.Text = Output.Text + "\n\nGeneral Equation \t:\tx² + y² + (" + Convert.ToString(-2 * h) + ")x + (" + Convert.ToString(-2 * k) + ")y + (" + Convert.ToString((h * h) + (k * k) - (r * r)) + ") = 0";
                Output.Text = Output.Text + "\n\nX-Intercept \t\t:\t(" + Convert.ToString(h + Math.Sqrt((r * r) - (k * k))) + " , 0) , (" + Convert.ToString(h - Math.Sqrt((r * r) - (k * k))) + " , 0)";
                Output.Text = Output.Text + "\nY-Intercept \t\t:\t(0 , " + Convert.ToString(k + Math.Sqrt((r * r) - (h * h))) + ") , (0 , " + Convert.ToString(k - Math.Sqrt((r * r) - (h * h))) + ")";
                string s = ""; Display.Mathematica.Circle(h, k, r, ref s);
                Output.Text = Output.Text + "\n\n\nMathematica\t\t:\t" + s;
            }
        }
    }
}
