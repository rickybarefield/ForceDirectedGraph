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

        public bool Connects(Node a, Node b)
        {
            return a == Source && b == Target
                || a == Target && b == Source;
        }
    }
}
