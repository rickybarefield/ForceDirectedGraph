using AngleSharp.Dom;

namespace RickyBarefield.ForceDirectedGraph
{
    public interface IRender
    {
        IElement Render(IDocument document);
    }
}
