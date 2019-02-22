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

namespace Co_ordinate_Geometry.Ellipse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Info : Page
    {
        public Info()
        {
            this.InitializeComponent();
            listBox.Items.Add("Relation 1");
            listBox.Items.Add("Relation 2");
            listBox.Items.Add("Relation 3");
            listBox.SelectedIndex = 0;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex == 0)
            {
                In_1.Text = "";
                T_2.Text = "b :";
                In_2.Text = "";
                T_3.Text = "c :";
                In_3.Text = "";
            }
            else if (listBox.SelectedIndex == 1)
            {
                In_1.Text = "";
                T_2.Text = "b :";
                In_2.Text = "";
                T_3.Text = "e :";
                In_3.Text = "";
            }
            else
            {
                In_1.Text = "";
                T_2.Text = "c :";
                In_2.Text = "";
                T_3.Text = "e :";
                In_3.Text = "";
            }
        }

        double a = 0, b = 0, c = 0, ec = 0, verify;

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            In_3.Text = "";
            if (!double.TryParse(In_1.Text, out verify) | !double.TryParse(In_2.Text, out verify))
            {
                In_3.Text = "Invalid Input";
            }
            else
            {
                a = double.Parse(In_1.Text);
                if (listBox.SelectedIndex == 0)
                {
                    b = double.Parse(In_2.Text);
                    if (a <= 0 | b <= 0 | b > a) In_3.Text = "Non-Possible Values";
                    else In_3.Text = Convert.ToString(Math.Sqrt(a * a - b * b));
                }
                else if (listBox.SelectedIndex == 1)
                {
                    b = double.Parse(In_2.Text);
                    if (a <= 0 | b <= 0 | b > a) In_3.Text = "Non-Possible Values";
                    else In_3.Text = Convert.ToString(Math.Sqrt(1 - (b * b / (a * a))));
                }
                else
                {
                    c = double.Parse(In_2.Text);
                    if (a <= 0 | c <= 0 | c > a) In_3.Text = "Non-Possible Values";
                    else In_3.Text = Convert.ToString(c / a);
                }
            }
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            In_2.Text = "";
            if (!double.TryParse(In_1.Text, out verify) | !double.TryParse(In_3.Text, out verify))
                In_2.Text = "Invalid Input";
            else
            {
                a = double.Parse(In_1.Text);
                if (listBox.SelectedIndex == 0)
                {
                    c = double.Parse(In_3.Text);
                    if (a <= 0 | c <= 0 | c > a) In_2.Text = "Non-Possible Values";
                    else
                    {
                        In_2.Text = Convert.ToString(Math.Sqrt(a * a - c * c));
                    }
                }
                else
                {
                    ec = double.Parse(In_3.Text);
                    if (a <= 0 | ec <= 0 | ec >= 1) In_2.Text = "Non-Possible Values";
                    else
                    {
                        if (listBox.SelectedIndex == 1) In_2.Text = Convert.ToString(Math.Sqrt(a * a * (1 - ec * ec)));
                        else In_2.Text = Convert.ToString(a * ec);
                    }
                        
                }
            }
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            In_1.Text = "";
            if (!double.TryParse(In_2.Text, out verify) | !double.TryParse(In_3.Text, out verify))
                In_1.Text = "Invalid Input";
            else
            {
                if (listBox.SelectedIndex == 0)
                {
                    b = double.Parse(In_2.Text); c = double.Parse(In_3.Text);
                    if (b <= 0 | c <= 0) In_1.Text = "Non-Possible Values";
                    else
                    {
                        In_1.Text = Convert.ToString(Math.Sqrt(b * b + c * c));
                    }
                }
                else if (listBox.SelectedIndex == 1)
                {
                    b = double.Parse(In_2.Text); ec = double.Parse(In_3.Text);
                    if (ec <= 0 | ec >= 1 | b <= 0) In_1.Text = "Non-Possible Values";
                    else
                    {
                        In_1.Text = Convert.ToString(b / (Math.Sqrt(1 - ec * ec)));
                    }
                }
                else
                {
                    c = double.Parse(In_2.Text); ec = double.Parse(In_3.Text);
                    if (ec >= 1 | ec <= 0 | c <= 0) In_1.Text = "Non-Possible Values";
                    else
                    {
                        In_1.Text = Convert.ToString(c / ec);
                    }
                }
            }
        }
    }
}
