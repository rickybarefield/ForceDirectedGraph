using AngleSharp.Dom;

namespace ForceDirectedGraph.SvgElements
{
    public abstract class SvgElement : IRender
    {
        public abstract IElement Render(IDocument document);
    }
}
