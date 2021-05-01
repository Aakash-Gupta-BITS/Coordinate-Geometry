using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures.Helpers
{
    public class Point
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);

        public override bool Equals(object obj) => obj is Point p && p.X == X && p.Y == Y;

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => string.Format("({0}, {1})", X, Y);
    }
}
