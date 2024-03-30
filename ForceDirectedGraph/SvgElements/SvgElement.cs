using AngleSharp.Dom;

namespace RickyBarefield.ForceDirectedGraph.SvgElements
{
    public abstract class SvgElement : IRender
    {
        public abstract IElement Render(IDocument document);
    }
}
