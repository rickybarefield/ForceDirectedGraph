using AngleSharp;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace ForceDirectedGraph
{
    public partial class Graph : ComponentBase
    {
        private IDocument document;

        [Parameter]
        public required List<Node> Nodes { get; init; }

        private List<Edge> edges;

        [Parameter]
        public required List<(Node source, Node target)> Connections
        {
            init
            {
                this.edges = value.Select(c => new Edge { Source = c.source, Target = c.target }).ToList();
            }
        }

        private List<IElement> NodeElements
        {
            get
            {
                return Nodes.Select(n => n.Render(document)).ToList();
            }
        }

        private List<IElement> EdgeElements
        {
            get
            {
                return edges.Select(n => n.Render(document)).ToList();
            }
        }

        protected async override Task OnInitializedAsync()
        {
            document = await BrowsingContext.New().OpenAsync(res => res.Content($"<svg></svg>"));
            await base.OnInitializedAsync();
        }
    }
}
