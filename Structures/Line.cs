using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures.Helpers;

namespace Structures
{
    public class Line
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Line(Point p1, Point p2)
        {
            if (p1.Equals(p2))
                throw new ArgumentException(string.Format("Both points of input are same : {0}", p1));

            A = p1.Y - p2.Y;
            B = p2.X - p1.X;
            C = -p1.Y * B - p1.X * A;
        }
    }
}
