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

namespace Co_ordinate_Geometry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calculator : Page
    {
        public Calculator()
        {
            this.InitializeComponent();
        }
        double verify;
        private void A_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (B.Text == "")
            {
                A_B.Text = "Enter value of B"; A_Multi_B.Text = "Enter value of B";
            }
            else if (!double.TryParse(A.Text, out verify) | !double.TryParse(B.Text, out verify))
            {
                A_B.Text = "Enter Properly";
                A_Multi_B.Text = "Enter Properly";
            }
            else
            {
                A_B.Text = Convert.ToString(Convert.ToDouble(A.Text) / Convert.ToDouble(B.Text));
                B_A.Text = Convert.ToString(Convert.ToDouble(B.Text) / Convert.ToDouble(A.Text));
                A_Multi_B.Text = Convert.ToString(Convert.ToDouble(A.Text) * Convert.ToDouble(B.Text));
            }

            if (!double.TryParse(A.Text, out verify))
            {
                SQRT_A.Text = "Enter Properly";
            }
            else
            {
                double input_a = Convert.ToDouble(A.Text);
                SQRT_A.Text = Convert.ToString(Math.Sqrt(input_a));
            }
        }

        private void B_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (A.Text == "")
            {
                A_B.Text = "Enter value of A"; A_Multi_B.Text = "Enter value of A";
            }
            else if (!double.TryParse(A.Text, out verify) | !double.TryParse(B.Text, out verify))
            {
                A_B.Text = "Enter Properly"; A_Multi_B.Text = "Enter Properly";
            }
            else
            {
                A_B.Text = Convert.ToString(Convert.ToDouble(A.Text) / Convert.ToDouble(B.Text));
                B_A.Text = Convert.ToString(Convert.ToDouble(B.Text) / Convert.ToDouble(A.Text));
                A_Multi_B.Text = Convert.ToString(Convert.ToDouble(A.Text) * Convert.ToDouble(B.Text));
            }

            if (!double.TryParse(B.Text, out verify))
            {
                SQRT_B.Text = "Enter Properly";
            }
            else
            {
                double input_b = Convert.ToDouble(B.Text);
                SQRT_B.Text = Convert.ToString(Math.Sqrt(input_b));
            }
        }

        private void constant_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            uint verify;
            if (!uint.TryParse(repeated.Text, out verify) | !uint.TryParse(constant.Text, out verify))
            {
                output.Text = ""; repeat_lab.Text = "";
            }
            else
            {
                double x = Convert.ToDouble(repeated.Text);
                double y = Math.Pow(10, repeated.Text.Length) - 1;
                double Constant = Convert.ToDouble(constant.Text);
                for (int i = 1; i <= y; ++i)
                {
                    if (x % i == 0 & y % i == 0)
                    {
                        x = x / i;
                        y = y / i;
                    }
                }
                output.Text = Convert.ToString(y * Constant + x) + " / " + Convert.ToString(y);
                string s = "";
                for (int i = 0; i <= 12 & s.Length < 12; ++i) { s = s + repeated.Text; }
                repeat_lab.Text = constant.Text + "." + s + "...";
            }
        }
    }
}
