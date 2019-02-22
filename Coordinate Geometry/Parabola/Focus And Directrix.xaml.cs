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

namespace Co_ordinate_Geometry.Parabola
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Focus_And_Directrix : Page
    {
        public Focus_And_Directrix()
        {
            this.InitializeComponent();
        }
        double verify;
        private void Find_x_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!double.TryParse(In_h.Text, out verify) | !double.TryParse(In_k.Text, out verify) | !double.TryParse(In_a.Text, out verify) | !double.TryParse(In_b.Text, out verify) | !double.TryParse(In_c.Text, out verify))
            {
                Output.Text = "";
            }
            else
            {
                double h = double.Parse(In_h.Text), k = double.Parse(In_k.Text), a = double.Parse(In_a.Text), b = double.Parse(In_b.Text), c = double.Parse(In_c.Text);
                double v_x = ((h / 2) + (a * c - b * (b * h - a * k)) / (-2 * (a * a + b * b))), v_y = (k / 2) + (b * c + a * (b * h - a * k)) / (-2 * (a * a + b * b));
                Output.Text = "Equation\n\tAxis\t\t\t:\t(" + b + ") * x + (" + -a + ") * y + (" + (a * k - b * h) + ") = 0";
                Output.Text = Output.Text + "\n\tLatus Rectum\t\t:\t(" + a + ") * x + (" + b + ") * y + (" + -1 * (a * h + b * k) + ") = 0";
                Output.Text = Output.Text + "\n\tParabola\t\t:\t(" + b * b + ") * x² + (" + a * a + ") * y² + (" + -2 * (a * c + h * (a * a + b * b)) + ") * x + (" + -2 * (b * c + k * (a * a + b * b)) + ") * y + (" + -2 * a * b + ") * xy + (" + ((h * h + k * k) * (a * a + b * b) - c * c) + ") = 0";
                Output.Text = Output.Text + "\n\tTangent on Vertex\t:\t(" + 2 * a + ") * x + (" + 2 * b + ") * y + (" + (c - a * h - b * k) + ") = 0";
                Output.Text = Output.Text + "\n\nPoints\n\tFocus\t\t\t:\t(" + In_h.Text + " , " + In_k.Text + ")\n\tVertex\t\t\t:\t(" + ((h / 2) + (a * c - b * (b * h - a * k)) / (-2 * (a * a + b * b))) + " , " + ((k / 2) + (b * c + a * (b * h - a * k)) / (-2 * (a * a + b * b))) + ")";
                Output.Text = Output.Text + "\n\tPoint on Directrix\t:\t(" + (2 * v_x - h) + " , " + (2 * v_y - k) + ")";
                Output.Text = Output.Text + "\n\tLatus Rectum\n\t\tA\t\t:\t(" + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * ((k * Math.Pow(h, 2.0) * (-2.0)) + (Math.Pow(k, 3.0) * (-2.0)) + (v_x * k * h * 4.0) + (Math.Pow(v_x, 2.0) * k * (-2.0)) + (v_y * Math.Pow(h, 2.0) * 2.0) + (v_y * Math.Pow(k, 2.0) * 6.0) + (v_y * v_x * h * (-4.0)) + (v_y * Math.Pow(v_x, 2.0) * 2.0) + (Math.Pow(v_y, 2.0) * k * (-6.0)) + (Math.Pow(v_y, 3.0) * 2.0) + (Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))) * h))) + " , " + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * ((Math.Pow(h, 3.0) * 2.0) + (Math.Pow(k, 2.0) * h * 2.0) + (v_x * Math.Pow(h, 2.0) * (-6.0)) + (v_x * Math.Pow(k, 2.0) * (-2.0)) + (Math.Pow(v_x, 2.0) * h * 6.0) + (Math.Pow(v_x, 3.0) * (-2.0)) + (v_y * k * h * (-4.0)) + (v_y * v_x * k * 4.0) + (Math.Pow(v_y, 2.0) * h * 2.0) + (Math.Pow(v_y, 2.0) * v_x * (-2.0)) + (Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))) * k))) + ")";
                Output.Text = Output.Text + "\n\t\tB\t\t:\t(" + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * ((k * Math.Pow(h, 2.0) * 2.0) + (Math.Pow(k, 3.0) * 2.0) + (v_x * k * h * (-4.0)) + (Math.Pow(v_x, 2.0) * k * 2.0) + (v_y * Math.Pow(h, 2.0) * (-2.0)) + (v_y * Math.Pow(k, 2.0) * (-6.0)) + (v_y * v_x * h * 4.0) + (v_y * Math.Pow(v_x, 2.0) * (-2.0)) + (Math.Pow(v_y, 2.0) * k * 6.0) + (Math.Pow(v_y, 3.0) * (-2.0)) + (Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))) * h))) + " , " + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * ((Math.Pow(h, 3.0) * (-2.0)) + (Math.Pow(k, 2.0) * h * (-2.0)) + (v_x * Math.Pow(h, 2.0) * 6.0) + (v_x * Math.Pow(k, 2.0) * 2.0) + (Math.Pow(v_x, 2.0) * h * (-6.0)) + (Math.Pow(v_x, 3.0) * 2.0) + (v_y * k * h * 4.0) + (v_y * v_x * k * (-4.0)) + (Math.Pow(v_y, 2.0) * h * (-2.0)) + (Math.Pow(v_y, 2.0) * v_x * 2.0) + (Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))) * k))) + ")";
                Output.Text = Output.Text + "\n\nLength\n\tLatus Rectum\t\t:\t" + ((Math.Pow((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0)), 0.5) * 4.0));
                Output.Text = Output.Text + "\n\ta\t\t\t:\t" + (Math.Pow((Math.Pow(((h * (-1.0)) + v_x), 2.0) + Math.Pow(((k * (-1.0)) + v_y), 2.0)), 0.5));
                Output.Text = Output.Text + "\n\nTriangle\n\tLatus Rectum\n\t\tSide\t\t:\t" + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * Math.Pow(Math.Pow((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0)), 3.0), 0.5) * Math.Pow(5.0, 0.5));
                Output.Text = Output.Text + "\n\t\tArea\t\t:\t" + (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * Math.Pow((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0)), 2.0) * 2.0);
                double area_equi = (Math.Pow(Math.Abs((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0))), (-1.0)) * Math.Pow(Math.Pow((Math.Pow(h, 2.0) + Math.Pow(k, 2.0) + (v_x * h * (-2.0)) + Math.Pow(v_x, 2.0) + (v_y * k * (-2.0)) + Math.Pow(v_y, 2.0)), 3.0), 0.5) * Math.Pow(3.0, 0.5) * 8.0);
                Output.Text = Output.Text + "\n\tEquilateral\n\t\tSide\t\t:\t" + Convert.ToString(area_equi);
                Output.Text = Output.Text + "\n\t\tArea\t\t:\t" + Math.Sqrt(3) / 4 * area_equi * area_equi;
                string s = "";
                Display.Mathematica.Parabola_focus_directrix(b * b, a * a, -2 * (a * c + h * (a * a + b * b)), -2 * (b * c + k * (a * a + b * b)), -2 * a * b, ((h * h + k * k) * (a * a + b * b) - c * c), h, k, ref s);
                Output.Text = Output.Text + "\n\nMathematica\t\t\t:\t" + s;
            }
        }
    }
}
