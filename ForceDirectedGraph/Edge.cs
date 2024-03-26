using ForceDirectedGraph.SvgElements;

namespace ForceDirectedGraph
{
    public class Edge : IRender
    {
        public required Node Source { get; init; }
        public required Node Target { get; init; }

        public AngleSharp.Dom.IElement Render(AngleSharp.Dom.IDocument document)
        {
            return new Line
            {
                From = Source.Center,
                To = Target.PointToLinkToOnNodeWhenOriginatingFrom(Source.Center),
                MarkerEnd = "arrow-head"
            }.Render(document);
        }
    }
}
