using AngleSharp.Dom;

namespace ForceDirectedGraph.Graph.SvgElements
{
    public class Text : SvgElement
    {
        public required string Content { get; init; }

        public Point Center { get; init; } = new Point(0, 0);

        public Color StrokeColor { get; init; } = Color.Black;

        public override IElement Render(IDocument document)
        {
            var textElement = document.CreateElement("text");
            textElement.TextContent = Content;
            textElement.SetAttribute("text-anchor", "middle");
            textElement.SetAttribute("x", Center.X.ToString());
            textElement.SetAttribute("y", Center.Y.ToString());
            textElement.SetAttribute("stroke-color", StrokeColor.ToString());

            return textElement;
        }
    }
}
