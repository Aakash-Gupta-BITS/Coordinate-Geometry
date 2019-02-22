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
    public sealed partial class Trigonometry : Page
    {
        public Trigonometry()
        {
            this.InitializeComponent();
        }
        const double pi = Math.PI;
        double verify;
        private void Deg_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Rad.Text = "";
            Sin.Text = "";
            Cos.Text = "";
            Tan.Text = "";
            
            if (!double.TryParse(Deg.Text, out verify))
            {
                Rad.Text = "Error in Entered Value";
                Sin.Text = "Error in Entered Value";
                Cos.Text = "Error in Entered Value";
                Tan.Text = "Error in Entered Value";
            }
            else
            {
                double degree_entered = Convert.ToDouble(Deg.Text);
                Rad.Text = Convert.ToString(degree_entered * pi / 180);
                Sin.Text = Convert.ToString(Math.Sin(Convert.ToDouble(Rad.Text)));
                Cos.Text = Convert.ToString(Math.Cos(Convert.ToDouble(Rad.Text)));
                Tan.Text = Convert.ToString(Math.Tan(Convert.ToDouble(Rad.Text)));
            }
        }

        private void Rad_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Deg.Text = "";
            Sin.Text = "";
            Cos.Text = "";
            Tan.Text = "";
            
            if (!double.TryParse(Rad.Text, out verify))
            {
                Deg.Text = "Error in Entered Value";
                Sin.Text = "Error in Entered Value";
                Cos.Text = "Error in Entered Value";
                Tan.Text = "Error in Entered Value";
            }
            else
            {
                double rad_entered = Convert.ToDouble(Rad.Text);
                Deg.Text = Convert.ToString(rad_entered * 180 / pi);
                Sin.Text = Convert.ToString(Math.Sin(Convert.ToDouble(Rad.Text)));
                Cos.Text = Convert.ToString(Math.Cos(Convert.ToDouble(Rad.Text)));
                Tan.Text = Convert.ToString(Math.Tan(Convert.ToDouble(Rad.Text)));
            }
        }

        private void Sin_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Deg.Text = "";
            Rad.Text = "";
            Cos.Text = "";
            Tan.Text = "";
            
            if (!double.TryParse(Sin.Text, out verify))
            {
                Deg.Text = "Error in Entered Value";
                Rad.Text = "Error in Entered Value";
                Cos.Text = "Error in Entered Value";
                Tan.Text = "Error in Entered Value";
            }
            else
            {
                double sin_entered = Convert.ToDouble(Sin.Text);
                Rad.Text = Convert.ToString(Math.Asin(sin_entered));
                Deg.Text = Convert.ToString(Convert.ToDouble(Rad.Text) * 180 / pi);
                Cos.Text = Convert.ToString(Math.Cos(Convert.ToDouble(Rad.Text)));
                Tan.Text = Convert.ToString(Math.Tan(Convert.ToDouble(Rad.Text)));
            }
        }

        private void Cos_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Deg.Text = "";
            Rad.Text = "";
            Sin.Text = "";
            Tan.Text = "";
            
            if (!double.TryParse(Cos.Text, out verify))
            {
                Deg.Text = "Error in Entered Value";
                Rad.Text = "Error in Entered Value";
                Sin.Text = "Error in Entered Value";
                Tan.Text = "Error in Entered Value";
            }
            else
            {
                double cos_entered = Convert.ToDouble(Cos.Text);
                Rad.Text = Convert.ToString(Math.Acos(cos_entered));
                Deg.Text = Convert.ToString(Convert.ToDouble(Rad.Text) * 180 / pi);
                Sin.Text = Convert.ToString(Math.Sin(Convert.ToDouble(Rad.Text)));
                Tan.Text = Convert.ToString(Math.Tan(Convert.ToDouble(Rad.Text)));
            }
        }

        private void Tan_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            Deg.Text = "";
            Rad.Text = "";
            Cos.Text = "";
            Sin.Text = "";
            
            if (!double.TryParse(Tan.Text, out verify))
            {
                Deg.Text = "Error in Entered Value";
                Rad.Text = "Error in Entered Value";
                Sin.Text = "Error in Entered Value";
                Cos.Text = "Error in Entered Value";
            }
            else
            {
                double tan_entered = Convert.ToDouble(Tan.Text);
                Rad.Text = Convert.ToString(Math.Atan(tan_entered));
                Deg.Text = Convert.ToString(Convert.ToDouble(Rad.Text) * 180 / pi);
                Sin.Text = Convert.ToString(Math.Sin(Convert.ToDouble(Rad.Text)));
                Cos.Text = Convert.ToString(Math.Cos(Convert.ToDouble(Rad.Text)));
            }
        }
    }
}
