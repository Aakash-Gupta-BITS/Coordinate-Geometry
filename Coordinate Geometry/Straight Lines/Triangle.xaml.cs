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
    public sealed partial class Triangle : Page
    {
        public Triangle()
        {
            this.InitializeComponent();
        }
        double verify;
        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, x3, y1, y2, y3;
            double aa, ab, ac, ba, bb, bc, ca, cb, cc;
            if (!double.TryParse(A_x.Text, out verify) | !double.TryParse(A_y.Text, out verify) | !double.TryParse(B_x.Text, out verify) | !double.TryParse(B_y.Text, out verify) | !double.TryParse(C_x.Text, out verify) | !double.TryParse(C_y.Text, out verify)) { Output.Text = "Error in Values"; }
            else
            {
                x1 = Convert.ToDouble(A_x.Text); y1 = Convert.ToDouble(A_y.Text); x2 = Convert.ToDouble(B_x.Text); y2 = Convert.ToDouble(B_y.Text); x3 = Convert.ToDouble(C_x.Text); y3 = Convert.ToDouble(C_y.Text);
                double area = ((x3 - x2) * y1 + (x1 - x3) * y2 + (x2 - x1) * y3) * 0.5;
                if (area < 0) { area *= -1; }
                double c = distance(x1, y1, x2, y2), a = distance(x3, y3, x2, y2), b = distance(x1, y1, x3, y3);
                Output.Text = "Area is \t\t\t:\t" + area + "\n";
                {       //Angle
                    Output.Text = Output.Text + "\nAngle A \t\t\t:\t" + Math_Operations.Operations.Rad_Deg(Math.Acos((((Math.Pow(a, 2.0) * (-1.0)) + Math.Pow(b, 2.0) + Math.Pow(c, 2.0)) * Math.Pow(c, (-1.0)) * Math.Pow(b, (-1.0)) * 0.5)));
                    Output.Text = Output.Text + "\nAngle B \t\t\t:\t" + Math_Operations.Operations.Rad_Deg(Math.Acos(((Math.Pow(a, 2.0) + (Math.Pow(b, 2.0) * (-1.0)) + Math.Pow(c, 2.0)) * Math.Pow(c, (-1.0)) * Math.Pow(a, (-1.0)) * 0.5)));
                    Output.Text = Output.Text + "\nAngle C \t\t\t:\t" + Math_Operations.Operations.Rad_Deg(Math.Acos(((Math.Pow(a, 2.0) + Math.Pow(b, 2.0) + (Math.Pow(c, 2.0) * (-1.0))) * Math.Pow(b, (-1.0)) * Math.Pow(a, (-1.0)) * 0.5)));
                }
                Output.Text = Output.Text + "\n\nCentroid \t\t\t:\t" + (x1 + x2 + x3) / 3 + " , " + (y1 + y2 + y3) / 3 + "\n";
                Output.Text = Output.Text + "\nCircumcentre \t\t\t:\t" + (((((((x1 * (-1.0)) + x2) * (x1 + x2) * 0.5) + (((y1 * (-1.0)) + y2) * (y1 + y2) * 0.5)) * (y1 + (y3 * (-1.0)))) + (((((x1 * (-1.0)) + x3) * (x1 + x3) * 0.5) + (((y1 * (-1.0)) + y3) * (y1 + y3) * 0.5)) * ((y1 * (-1.0)) + y2))) * Math.Pow((((y1 + (y2 * (-1.0))) * (x1 + (x3 * (-1.0)))) + ((y1 + (y3 * (-1.0))) * (x1 + (x2 * (-1.0))) * (-1.0))), (-1.0))) + " , " + (((((((x1 * (-1.0)) + x2) * (x1 + x2) * 0.5) + (((y1 * (-1.0)) + y2) * (y1 + y2) * 0.5)) * (x1 + (x3 * (-1.0))) * (-1.0)) + (((((x1 * (-1.0)) + x3) * (x1 + x3) * 0.5) + (((y1 * (-1.0)) + y3) * (y1 + y3) * 0.5)) * (x1 + (x2 * (-1.0))))) * Math.Pow((((y1 + (y2 * (-1.0))) * (x1 + (x3 * (-1.0)))) + ((y1 + (y3 * (-1.0))) * (x1 + (x2 * (-1.0))) * (-1.0))), (-1.0))) + "\n";
                Output.Text = Output.Text + "Radius \t\t\t:\t" + distance(x2, y2, x3, y3) * distance(x1, y1, x3, y3) * distance(x1, y1, x2, y2) * Math.Pow((y1 * (x3 - x2) + (y2 * (x1 - x3)) + (y3 * (x2 - x1))), -1) * 0.5 + "\n";
                {
                    a = y2 - y1; b = x1 - x2; c = y1 * x2 - x1 * y2; Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "\nEquation AB \t\t\t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                    aa = a; ab = b; ac = c;
                    a = y3 - y2; b = x2 - x3; c = y2 * x3 - x2 * y3; Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "Equation BC \t\t\t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                    ba = a; bb = b; bc = c;
                    a = y3 - y1; b = x1 - x3; c = y1 * x3 - x1 * y3; Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "Equation CA \t\t\t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                    ca = a; cb = b; cc = c;
                }
                {
                    a = (-2 * y3) + y1 + y2; b = (2 * x3) - x1 - x2; c = -x3 * (y1 + y2) + y3 * (x1 + x2); Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "\n" + "Equation Median on AB \t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                    a = (-2 * y1) + y2 + y3; b = (2 * x1) - x2 - x3; c = -x1 * (y2 + y3) + y1 * (x2 + x3); Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "Equation Median on BC \t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                    a = (2 * y2) - y3 - y1; b = (-2 * x2) + x3 + x1; c = -y2 * (x1 + x3) + x2 * (y1 + y3); Math_Operations.Operations.HCF(ref a, ref b, ref c);
                    Output.Text = Output.Text + "Equation Median on CA \t:\t" + a + "x + " + b + "y + " + c + " = 0" + "\n";
                }
                c = distance(x1, y1, x2, y2); a = distance(x3, y3, x2, y2); b = distance(x1, y1, x3, y3);
                Output.Text = Output.Text + "\n" + "Incentre \t\t\t:\t" + ((a * x1) + (b * x2) + (c * x3)) / (a + b + c) + " , " + ((a * y1) + (b * y2) + (c * y3)) / (a + b + c) + "\n";
                Output.Text = Output.Text + "Radius \t\t\t:\t" + (Math.Pow((Math.Pow((Math.Pow(x1, 2.0) + (x2 * x1 * (-2.0)) + Math.Pow(x2, 2.0) + Math.Pow(y1, 2.0) + (y2 * y1 * (-2.0)) + Math.Pow(y2, 2.0)), 0.5) + Math.Pow((Math.Pow(x1, 2.0) + (x3 * x1 * (-2.0)) + Math.Pow(x3, 2.0) + Math.Pow(y1, 2.0) + (y3 * y1 * (-2.0)) + Math.Pow(y3, 2.0)), 0.5) + Math.Pow((Math.Pow(x2, 2.0) + (x3 * x2 * (-2.0)) + Math.Pow(x3, 2.0) + Math.Pow(y2, 2.0) + (y3 * y2 * (-2.0)) + Math.Pow(y3, 2.0)), 0.5)), (-1.0)) * ((y1 * x2 * (-1.0)) + (y1 * x3) + (y2 * x1) + (y2 * x3 * (-1.0)) + (((x1 * (-1.0)) + x2) * y3))) + "\n";

                Output.Text = Output.Text + "\n" + "Length AB \t\t\t:\t" + distance(x1, y1, x2, y2) + "\n";
                Output.Text = Output.Text + "Length BC \t\t\t:\t" + distance(x2, y2, x3, y3) + "\n";
                Output.Text = Output.Text + "Length CA \t\t\t:\t" + distance(x1, y1, x3, y3) + "\n";

                Output.Text = Output.Text + "\n" + "Slope AB \t\t\t:\t" + (y2 - y1) / (x2 - x1) + "\n";
                Output.Text = Output.Text + "Slope BC \t\t\t:\t" + (y3 - y2) / (x3 - x2) + "\n";
                Output.Text = Output.Text + "Slope CA \t\t\t:\t" + (y3 - y1) / (x3 - x1) + "\n";

                Output.Text = Output.Text + "\n" + "Orthocentre \t\t\t:\t" + ((((((x1 + (x3 * (-1.0))) * x2 * (-1.0)) + (((y1 * (-1.0)) + y3) * y2)) * (y1 + (y2 * (-1.0)))) + (((((x1 * (-1.0)) + x2) * x3 * (-1.0)) + ((y1 + (y2 * (-1.0))) * y3)) * ((y1 * (-1.0)) + y3) * (-1.0))) * Math.Pow((((y1 + (y2 * (-1.0))) * (x1 + (x3 * (-1.0))) * (-1.0)) + (((y1 * (-1.0)) + y3) * ((x1 * (-1.0)) + x2))), (-1.0))) + " , " + ((((((x1 + (x3 * (-1.0))) * x2 * (-1.0)) + (((y1 * (-1.0)) + y3) * y2)) * ((x1 * (-1.0)) + x2)) + (((((x1 * (-1.0)) + x2) * x3 * (-1.0)) + ((y1 + (y2 * (-1.0))) * y3)) * (x1 + (x3 * (-1.0))) * (-1.0))) * Math.Pow((((y1 + (y2 * (-1.0))) * (x1 + (x3 * (-1.0))) * (-1.0)) + (((y1 * (-1.0)) + y3) * ((x1 * (-1.0)) + x2))), (-1.0))) + "\n";
                if (!(x1 == x2 & x2 == x3) & !(y1 == y2 & y2 == y3))
                {
                    double max, min, zoom = 1;
                    if (double.TryParse(m_zoom.Text, out verify)) { zoom = double.Parse(m_zoom.Text); x1 *= zoom; y1 *= zoom; x2 *= zoom; y2 *= zoom; x3 *= zoom; y3 *= zoom; }
                    max = (x1 > x2 & x1 > x3) ? (x1) : ((x2 > x3) ? (x2) : (x3));       //find max value of x from entered values
                    min = (x1 < x2 & x1 < x3) ? (x1) : ((x2 < x3) ? (x2) : (x3));       //find min value of x from entered values
                    draw_line.Width = (max - min) * 100;                                //setting default width of grid
                    max = (y1 > y2 & y1 > y3) ? (y1) : ((y2 > y3) ? (y2) : (y3));
                    min = (y1 < y2 & y1 < y3) ? (y1) : ((y2 < y3) ? (y2) : (y3));
                    draw_line.Height = (max - min) * 100;

                    x1 = (x1 * 10 + draw_line.Width / 2);                               //converting entered points to grid axis
                    x2 = (x2 * 10 + draw_line.Width / 2);
                    x3 = (x3 * 10 + draw_line.Width / 2);
                    y1 = (-y1 * 10 + draw_line.Height / 2);
                    y2 = (-y2 * 10 + draw_line.Height / 2);
                    y3 = (-y3 * 10 + draw_line.Height / 2);

                    max = (x1 > x2 & x1 > x3) ? (x1) : ((x2 > x3) ? (x2) : (x3));       //minimizing grid from bottom right corner
                    draw_line.Width = max + 10;
                    max = (y1 > y2 & y1 > y3) ? (y1) : ((y2 > y3) ? (y2) : (y3));
                    draw_line.Height = max + 10;

                    min = (x1 < x2 & x1 < x3) ? (x1) : ((x2 < x3) ? (x2) : (x3));       //shifting triangle co-ordinates to left top
                    x1 = x1 - min + 10; x2 = x2 - min + 10; x3 = x3 - min + 10;
                    min = (y1 < y2 & y1 < y3) ? (y1) : ((y2 < y3) ? (y2) : (y3));
                    y1 = y1 - min + 10; y2 = y2 - min + 10; y3 = y3 - min + 10;

                    max = (x1 > x2 & x1 > x3) ? (x1) : ((x2 > x3) ? (x2) : (x3));       //again minimizing grid from bottom right corner
                    draw_line.Width = max + 100;
                    max = (y1 > y2 & y1 > y3) ? (y1) : ((y2 > y3) ? (y2) : (y3));
                    draw_line.Height = max + 100;

                    AB.X1 = x1; AB.X2 = x2; AB.Y1 = y1; AB.Y2 = y2;     //displaying values
                    BC.X1 = x2; BC.X2 = x3; BC.Y1 = y2; BC.Y2 = y3;
                    CA.X1 = x3; CA.X2 = x1; CA.Y1 = y3; CA.Y2 = y1;
                    {                                                                               //show axes
                        double char_size = 20;
                        if (double.TryParse(m_char.Text, out verify)) { char_size = double.Parse(m_char.Text); }
                        A.Margin = new Thickness(x1 - 5, y1 - 5, 0, 0);
                        A.FontSize = 20 * char_size;
                        B.Margin = new Thickness(x2 - 5, y2 - 5, 0, 0);
                        B.FontSize = 20 * char_size;
                        C.Margin = new Thickness(x3 - 5, y3 - 5, 0, 0);
                        C.FontSize = 20 * char_size;
                        x1 = Convert.ToDouble(A_x.Text); y1 = Convert.ToDouble(A_y.Text); x2 = Convert.ToDouble(B_x.Text); y2 = Convert.ToDouble(B_y.Text); x3 = Convert.ToDouble(C_x.Text); y3 = Convert.ToDouble(C_y.Text);
                        A.Text = "A(" + x1 + "," + y1 + ")";
                        B.Text = "B(" + x2 + "," + y2 + ")";
                        C.Text = "C(" + x3 + "," + y3 + ")";
                    }
                }
                else
                {
                    A.Text = ""; B.Text = ""; C.Text = ""; AB.X1 = 0; AB.Y1 = 0; BC.X1 = 0; BC.Y1 = 0; CA.X1 = 0; CA.Y1 = 0;
                }
                string s = ""; Display.Mathematica.Straight_Triangle(aa, ab, ac, ba, bb, bc, ca, cb, cc, ref s);
                Output.Text = Output.Text + "\n\n\nMathematica\t\t\t:\t" + s;
            }
        }
        private double distance(double a1, double b1, double a2, double b2)
        {
            return Math.Sqrt(Math.Pow((a1 - a2), 2) + Math.Pow((b1 - b2), 2));
        }

        private void In_a1_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_a1.Text, out verify) | !double.TryParse(In_b1.Text, out verify) | !double.TryParse(In_c1.Text, out verify) | !double.TryParse(In_a2.Text, out verify) | !double.TryParse(In_b2.Text, out verify) | !double.TryParse(In_c2.Text, out verify) | !double.TryParse(In_a3.Text, out verify) | !double.TryParse(In_b3.Text, out verify) | !double.TryParse(In_c3.Text, out verify))
            {
                A_x.Text = ""; A_y.Text = ""; B_x.Text = ""; B_y.Text = ""; C_x.Text = ""; C_y.Text = "";
            }
            else
            {
                double a1 = double.Parse(In_a1.Text), a2 = double.Parse(In_a2.Text), a3 = double.Parse(In_a3.Text);
                double b1 = double.Parse(In_b1.Text), b2 = double.Parse(In_b2.Text), b3 = double.Parse(In_b3.Text);
                double c1 = double.Parse(In_c1.Text), c2 = double.Parse(In_c2.Text), c3 = double.Parse(In_c3.Text);
                string s = "", t = "";
                intersection(a1, b1, c1, a2, b2, c2, ref s, ref t); A_x.Text = s; A_y.Text = t;
                intersection(a2, b2, c2, a3, b3, c3, ref s, ref t); B_x.Text = s; B_y.Text = t;
                intersection(a3, b3, c3, a1, b1, c1, ref s, ref t); C_x.Text = s; C_y.Text = t;
            }
        }
        private void intersection(double a1, double b1, double c1, double a2, double b2, double c2, ref string x_, ref string y_)
        {
            double x = ((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1));
            double y = ((c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1));
            x_ = Convert.ToString(x);
            y_ = Convert.ToString(y);
        }
    }
}
