
namespace ForceDirectedGraph
{
    public record Point(double X, double Y)
    {
        internal double XDistanceTo(Point otherPoint)
        {
            return Math.Abs(otherPoint.X - X);
        }
        internal double YDistanceTo(Point otherPoint)
        {
            return Math.Abs(otherPoint.Y - Y);
        }

        internal double DistanceTo(Point otherPoint)
        {
            return Math.Sqrt(SquareOfDifference(otherPoint.X, X) + SquareOfDifference(otherPoint.Y, Y));
        }

        private static double SquareOfDifference(double a, double b)
        {
            return Math.Pow(Math.Abs(a - b), 2);
        }

        internal Point Translate(double xDistanceFromOriginatingPoint, double yDistanceFromOriginatingPoint)
        {
            return new Point(X + xDistanceFromOriginatingPoint, Y + yDistanceFromOriginatingPoint);
        }
    }
}
