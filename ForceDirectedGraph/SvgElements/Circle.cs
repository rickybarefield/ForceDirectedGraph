using AngleSharp.Dom;

namespace ForceDirectedGraph.SvgElements
{
    public class Circle : SvgElement
    {
        public Point Center { get; init; } = new Point(0, 0);

        public double R { get; init; }

        public Color FillColor { get; init; } = Color.White;

        public Color OutlineColor { get; init; } = Color.Black;

        public override IElement Render(IDocument document)
        {
            var circleElement = document.CreateElement("circle");

            circleElement.SetAttribute("cx", Center.X.ToString());
            circleElement.SetAttribute("cy", Center.Y.ToString());
            circleElement.SetAttribute("r", R.ToString());
            circleElement.SetAttribute("fill", FillColor.ToString());
            circleElement.SetAttribute("stroke", OutlineColor.ToString());

            return circleElement;
        }

        internal Point FindPointOnCircumferenceBetweenCenterAnd(Point originatingPoint)
        {
            var distanceBetweenCenterAndOriginatingPoint = Center.DistanceTo(originatingPoint);

            var oppositeToAngle = originatingPoint.XDistanceTo(Center);
            var adjacentToAngle = originatingPoint.YDistanceTo(Center);
            var angle = Math.Atan(oppositeToAngle / adjacentToAngle);
            
            var distanceFromOriginatingPointToCircumference = distanceBetweenCenterAndOriginatingPoint - R;

            var XDistanceFromOriginatingPoint = Math.Sin(angle) * distanceFromOriginatingPointToCircumference;
            var YDistanceFromOriginatingPoint = Math.Cos(angle) * distanceFromOriginatingPointToCircumference;

            var xTranslation = originatingPoint.X < Center.X
                ? XDistanceFromOriginatingPoint
                : 0 - XDistanceFromOriginatingPoint;

            var yTranslation = originatingPoint.Y < Center.Y
                ? YDistanceFromOriginatingPoint
                : 0 - YDistanceFromOriginatingPoint;

            return originatingPoint.Translate(xTranslation, yTranslation);
        }
    }
}
