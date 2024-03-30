using AngleSharp.Dom;

namespace RickyBarefield.ForceDirectedGraph.SvgElements
{
    public class Line : IRender
    {
        public required Point From { get; init; }
        public required Point To { get; init; }

        public string? MarkerEnd { get; set; }

        public Color Color { get; init; } = Color.Red;

        public IElement Render(IDocument document)
        {
            var pathElement = document.CreateElement("path");
            pathElement.SetAttribute("d", $"M {From.X} {From.Y}, {To.X} {To.Y}");
            pathElement.SetAttribute("stroke-width", "3");
            pathElement.SetAttribute("stroke", Color.ToString());

            if(MarkerEnd != null)
            {
                pathElement.SetAttribute("marker-end", $"url(#{MarkerEnd})");
            }

            return pathElement;
        }
    }
}
