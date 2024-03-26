using AngleSharp.Dom;

namespace ForceDirectedGraph.Graph
{
    public interface IRender
    {
        IElement Render(IDocument document);
    }
}
