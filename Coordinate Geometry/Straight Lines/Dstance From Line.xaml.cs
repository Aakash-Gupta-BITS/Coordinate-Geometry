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
    public sealed partial class Dstance_From_Line : Page
    {
        public Dstance_From_Line()
        {
            this.InitializeComponent();
        }
        double verify;
        private void In_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            //Setting value of slope if slope is not editable
            if (double.TryParse(In_a.Text, out verify) & double.TryParse(In_b.Text, out verify) & checkbox.IsChecked == true)
                In_Slope.Text = Convert.ToString(Convert.ToDouble(In_b.Text) / Convert.ToDouble(In_a.Text));
            //Display Output
            if (!double.TryParse(In_x.Text, out verify) | !double.TryParse(In_y.Text, out verify) | !double.TryParse(In_a.Text, out verify) | !double.TryParse(In_b.Text, out verify) | !double.TryParse(In_c.Text, out verify) | !double.TryParse(In_Slope.Text, out verify))
                Output.Text = "";
            else
            {
                double x = double.Parse(In_x.Text), y = double.Parse(In_y.Text), a = double.Parse(In_a.Text), b = double.Parse(In_b.Text), c = double.Parse(In_c.Text), m = double.Parse(In_Slope.Text);
                double distance;
                if (checkbox.IsChecked == true | In_Slope.Text== Convert.ToString(Convert.ToDouble(In_b.Text) / Convert.ToDouble(In_a.Text)))         //if slope is not entered by the user
                {
                    distance = (Math.Abs((c + (x * a) + (y * b))) * Math.Pow((Math.Pow(a, 2.0) + Math.Pow(b, 2.0)), -0.5));
                    Output.Text = "Distance \t\t\t:\t" + Convert.ToString(Math.Abs((c + (x * a) + (y * b)))) + " / √" + Convert.ToString(Math.Pow(a, 2.0) + Math.Pow(b, 2.0)) + " = " + Convert.ToString(distance);
                }
                else
                {
                    distance = (Math.Abs((c + (x * a) + (y * b))) * Math.Pow(Math.Abs((a + (m * b))), (-1.0)) * Math.Pow((1.0 + Math.Pow(m, 2.0)), 0.5));
                    Output.Text = "Distance \t\t\t:\t" + Convert.ToString(Math.Abs((c + (x * a) + (y * b))) * Math.Pow(Math.Abs((a + (m * b))), (-1.0))) + " / √" + Convert.ToString(1.0 + Math.Pow(m, 2.0)) + " = " + Convert.ToString(distance);
                }
            }
        }
        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            In_Slope.Visibility = Visibility.Collapsed;
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            In_Slope.Visibility = Visibility.Visible;
        }
    }
}
