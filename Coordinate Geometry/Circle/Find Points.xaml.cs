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
    public sealed partial class Find_Points : Page
    {
        public Find_Points()
        {
            this.InitializeComponent();
        }
        double verify;
        private void Out_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_h.Text, out verify) | !double.TryParse(In_k.Text, out verify) | !double.TryParse(In_r.Text, out verify) | !double.TryParse(Out_x.Text, out verify))
            {
                Out_y.Text = "";
            }
            else
            {
                double x = double.Parse(Out_x.Text), h = double.Parse(In_h.Text), k = double.Parse(In_k.Text), r = double.Parse(In_r.Text);
                double y_1 = k + Math.Sqrt(r * r - (Math.Pow(h - x, 2))), y_2 = k - Math.Sqrt(r * r - (Math.Pow(h - x, 2)));
                Out_y.Text = Convert.ToString(y_1) + " , " + Convert.ToString(y_2);
            }
        }

        private void Out_y_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_h.Text, out verify) | !double.TryParse(In_k.Text, out verify) | !double.TryParse(In_r.Text, out verify) | !double.TryParse(Out_y.Text, out verify))
            {
                Out_x.Text = "";
            }
            else
            {
                double y = double.Parse(Out_y.Text), h = double.Parse(In_h.Text), k = double.Parse(In_k.Text), r = double.Parse(In_r.Text);
                double x_1 = h + Math.Sqrt(r * r - (Math.Pow(k - y, 2))), x_2 = h - Math.Sqrt(r * r - (Math.Pow(k - y, 2)));
                Out_x.Text = Convert.ToString(x_1) + " , " + Convert.ToString(x_2);
            }
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
        }

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
        }
    }
}