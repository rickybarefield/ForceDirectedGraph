using AngleSharp.Dom;

namespace ForceDirectedGraph.Graph.SvgElements
{
    public abstract class SvgElement : IRender
    {
        public abstract IElement Render(IDocument document);
    }
}
