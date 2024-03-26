using AngleSharp.Dom;

namespace ForceDirectedGraph
{
    public interface IRender
    {
        IElement Render(IDocument document);
    }
}
