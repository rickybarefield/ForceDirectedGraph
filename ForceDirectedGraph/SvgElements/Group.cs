using AngleSharp.Dom;

namespace ForceDirectedGraph.SvgElements
{
    public class Group : SvgElement
    {
        public List<SvgElement> Children { get; init; } = new List<SvgElement>();

        public Point Center { get; init; } = new Point(0, 0);

        public override IElement Render(IDocument document)
        {
            var groupElement = document.CreateElement("g");
            groupElement.SetAttribute("transform", $"translate({Center.X},{Center.Y})");

            Children.ForEach(c => groupElement.AppendChild(c.Render(document)));

            return groupElement;
        }
    }
}
