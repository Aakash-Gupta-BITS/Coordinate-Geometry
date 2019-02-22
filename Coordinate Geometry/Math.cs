using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    class Mathematica
    {
        public static void Circle(double h, double k, double r, ref string s)
        {
            if (r < 0) { r *= -1; }
            string s_h = Convert.ToString(h), s_k = Convert.ToString(k), s_r = Convert.ToString(r);
            double x_1 = Math.Abs(h + r), x_2 = Math.Abs(h - r), y_1 = Math.Abs(k + r), y_2 = Math.Abs(k - r);
            double max;
            if (x_1 >= x_2 && x_1 >= y_1 && x_1 >= y_2) { max = x_1; }
            else if (x_2 >= x_1 && x_2 >= y_1 && x_2 >= y_2) { max = x_2; }
            else if (y_1 >= x_1 && y_1 >= x_2 && y_1 >= y_2) { max = y_1; }
            else { max = y_2; }
            s = "ContourPlot[(x - " + s_h + ")^2 + (y - " + s_k + ")^2 == " + Convert.ToString(Math.Pow(r , 2)) + ", {x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "}, PlotLegends -> {(x - " + s_h + ")^2 + (y - " + s_k + ")^2 == " + Convert.ToString(Math.Pow(r, 2)) + "}, Axes -> True, GridLines -> Automatic]";
        }                                                       //For Simple Plot Of Circle

        public static void Circle_Equation(double h, double k, double r, double a, double b, double c, ref string s)
        {
            if (r < 0) { r *= -1; }
            string s_h = Convert.ToString(h), s_k = Convert.ToString(k), s_r = Convert.ToString(r);
            double x_1 = Math.Abs(h + r), x_2 = Math.Abs(h - r), y_1 = Math.Abs(k + r), y_2 = Math.Abs(k - r);
            double max;
            if (x_1 >= x_2 && x_1 >= y_1 && x_1 >= y_2) { max = x_1; }
            else if (x_2 >= x_1 && x_2 >= y_1 && x_2 >= y_2) { max = x_2; }
            else if (y_1 >= x_1 && y_1 >= x_2 && y_1 >= y_2) { max = y_1; }
            else { max = y_2; }
            s = "ContourPlot[{(x - " + s_h + ")^2 + (y - " + s_k + ")^2 == " + Convert.ToString(Math.Pow(r, 2)) + "," + a + " * x + " + b + " * y + " + c + " == 0}, {x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "}, PlotLegends -> {(x - " + s_h + ")^2 + (y - " + s_k + ")^2 == " + Convert.ToString(Math.Pow(r, 2)) + "," + a + " * x + " + b + " * y + " + c + " == 0" + "}, Axes -> True, GridLines -> Automatic]";
        }                //For Plot of Circle With line pass through radius

        public static void Straight(double a, double b, double c, ref string s)
        {
            double x_intercept = -c / b, y_intercept = -c / a;
            double max = (x_intercept > y_intercept) ? Math.Abs(x_intercept) : Math.Abs(y_intercept);
            max += 25;
            s = "ContourPlot[{" + a + " * x + " + b + " * y +" + c + " == 0}, {x, -" + max + ", " + max + "}, {y, -" + max + ", " + max + "},  PlotLegends-> { " + a + " * x + " + b + " * y == " + -c + "}, Axes->True,  GridLines->Automatic]";
        }                                                     //For Plot of Line from the Equation

        public static void Straight_Triangle(double a1, double b1, double c1, double a2, double b2, double c2, double a3, double b3, double c3, ref string s)
        {
            double x1 = 0, x2 = 0, x3 = 0, y1 = 0, y2 = 0, y3 = 0;
            Operations.intersection(a1, b1, c1, a2, b2, c2, ref x1, ref y1);
            Operations.intersection(a2, b2, c2, a3, b3, c3, ref x2, ref y2);
            Operations.intersection(a3, b3, c3, a1, b1, c1, ref x3, ref y3);
            double max_y = (y1 >= y2 && y1 >= y3) ? y1 : ((y2 >= y1 && y2 >= y3) ? y2 : y3); 
            double max_x = (x1 >= x2 && x1 >= x3) ? x1 : ((x2 >= x1 && x2 >= x3) ? x2 : x3);
            double max = (max_x > max_y) ? max_x : max_y;
            double r = 0;
            if (max == 1 / r) { max = 100; }
            string eq1 = "", eq2 = "", eq3 = "";
            Operations.Eq_tri(a1, b1, c1, ref eq1); Operations.Eq_tri(a2, b2, c2, ref eq2); Operations.Eq_tri(a3, b3, c3, ref eq3);
            s = "ContourPlot[{" + eq1 + ", " + eq2 + ", " + eq3 + "}, {x," + -max + ", " + max + "}, {y," + -max + ", " + max + "}, PlotLegends-> {" + eq1 + ", " + eq2 + ", " + eq3 + "}, Axes -> True, GridLines -> Automatic]";
            }       //For pLot of triangle by Equation

        public static void Parabola_R_Left(double a, ref string s)
        {
            double max = 4 * a;
            s = "ContourPlot[{y^2 == " + Convert.ToString(4 * a) + "*x, x == " + -a + ", x == " + a + "}, {x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "}, PlotLegends -> {y^2 == " + Convert.ToString(4 * a) + " x, Directrix, Latus Rectum }, Axes -> True, GridLines -> Automatic]";
        }

        public static void Parabola_U_Down(double a, ref string s)
        {
            double max = 4 * a;
            s = "ContourPlot[{x^2 == " + Convert.ToString(4 * a) + "*y, y == " + -a + ", y == " + a + "}, {x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "}, PlotLegends -> {x^2 == " + Convert.ToString(4 * a) + " y, Directrix, Latus Rectum }, Axes -> True, GridLines -> Automatic]";
        }

        public static void Parabola_focus_directrix(double x_2, double y_2, double x, double y, double xy, double c, double h, double k, ref string s)
        {
            double max = (h > k) ? h + 25 : k + 25;
            s = "ContourPlot[{"+ x_2 + "*x^2 + " + y_2 + "*y^2 + " + x + "*x + " + y + "*y + " + xy + "*x*y + " + c + " == 0},{x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "}, Axes -> True, GridLines -> Automatic]";
        }

        public static void Ellipse(double a, double b, double c, double e, ref string s)
        {
            double max = (a > b) ? Math.Round(a / e, 5) + 1 : Math.Round(b / e, 5) + 1;
            double dir = (a > b) ? Math.Round(a / e, 5) : Math.Round(b / e, 5);
            if (a > b)
                s = "ContourPlot[{x^2/" + a * a + " + y^2/ " + b * b + " == 1, x == " + dir + ", x == -" + dir + ", x == " + Math.Round(a * e, 5) + ", x == -" + Math.Round(a * e, 5) + "},{x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "},  PlotLegends-> { x^2 /" + a * a + " + y^2 /" + b * b + " == 1, Directrix == " + dir + ", Directrix == -" + dir + ", Focus == " + Math.Round(a * e, 5) + ", Focus == -" + Math.Round(a * e, 5) + "}, Axes->True,  GridLines->Automatic]";
            else
                s = "ContourPlot[{x^2/" + a * a + " + y^2/ " + b * b + " == 1, y == " + dir + ", y == -" + dir + ", y == " + Math.Round(b * e, 5) + ", y == -" + Math.Round(a * e, 5) + "},{x, " + -max + ", " + max + "}, {y, " + -max + ", " + max + "},  PlotLegends-> { x^2 /" + a * a + " + y^2 /" + b * b + " == 1, Directrix == " + dir + ", Directrix == -" + dir + ", Focus == " + Math.Round(b * e, 5) + ", Focus == -" + Math.Round(b * e, 5) + "}, Axes->True,  GridLines->Automatic]";
        }
    }

    class Operations
    {
        public static void Eq_tri(double a, double b, double c, ref string eq)
        {
            eq = a + "* x +" + b + "* y + " + c + " == 0";
        }                                                      //For Conversion a,b,c to ax+by+c

        public static void intersection(double a1, double b1, double c1, double a2, double b2, double c2, ref double x, ref double y)
        {
            x = ((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1));
            y = ((c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1));
            x = Math.Abs(x); y = Math.Abs(y);
        }
    }
}




namespace Math_Operations
{
    class Operations
    {
        public static double Mod(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
        public static double Rad_Deg(double radian)
        {
            return radian * 180 / 3.141592653589793238;
        }
        public static double Deg_Rad(double degree)
        {
            return degree * Math.PI / 180;
        }
        public static void HCF(ref double a, ref double b, ref double c)
        {
            if ((a % 1) != 0 | (c % 1) != 0 | (b % 1) != 0)
            {
                //do nothing
            }
            else
            {
                double h = 0;
                for (int i = 1; i <= a || i <= b || i <= c; ++i)
                {
                    if (a % i == 0 & b % i == 0 & c % i == 0)
                    {
                        h = i;
                    }
                }
                a /= h; b /= h; c /= h;
            }
        }
        public static void HCF_2(ref double a, ref double b)
        {
            if ((a % 1) != 0 | (b % 1) != 0)
            {
                //do nothing
            }
            else
            {
                double h = 0;
                for (int i = 1; i <= a || i <= b; ++i)
                {
                    if (a % i == 0 & b % i == 0)
                    {
                        h = i;
                    }
                }
                a /= h; b /= h;
            }
        }
    }

    class Constants
    {
        public static double Pi()
        {
            return 3.14159265358979323846;
        }
    }
}