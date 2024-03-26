using AngleSharp.Dom;

namespace ForceDirectedGraph.Graph.SvgElements
{
    public class Circle : SvgElement
    {
        public Point Center { get; init; } = new Point(0, 0);

        public double R { get; init; }

        public override IElement Render(IDocument document)
        {
            var circleElement = document.CreateElement("circle");

            circleElement.SetAttribute("cx", Center.X.ToString());
            circleElement.SetAttribute("cy", Center.Y.ToString());
            circleElement.SetAttribute("r", R.ToString());

            return circleElement;
        }
    }
}
