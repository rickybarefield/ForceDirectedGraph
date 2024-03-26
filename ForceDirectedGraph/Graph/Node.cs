using AngleSharp.Dom;
using ForceDirectedGraph.Graph.SvgElements;

namespace ForceDirectedGraph.Graph
{
    public class Node : IRender
    {
        public Point Center { get; init; }

        public IElement Render(IDocument document)
        {
            return new Group 
            { 
                Center = Center,
                Children =
                {
                    new Circle
                    {
                        R = 100
                    },
                    new Text
                    {
                        Content = "Some",
                        StrokeColor = Color.Red
                    }
                }
            }.Render(document);
        }
    }
}
