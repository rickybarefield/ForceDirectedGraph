using AngleSharp;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace ForceDirectedGraph
{
    public partial class Graph : ComponentBase
    {
        private IDocument document;

        private static double EdgeSpringConstant = 1;
        private static double EdgeSpringLength = 200;
        private static double NodeRepulsion = 800;
        private static int InitialIterations = 200;

        [Parameter]
        public required List<Node> Nodes { get; init; }

        private List<Edge> edges;

        public Point MinPoint { get; private set; } = new Point(0, 0);
        public Point MaxPoint { get; private set; } = new Point(1000, 1000);

        public double Width { get => MaxPoint.X - MinPoint.X; }
        public double Height { get => MaxPoint.Y - MinPoint.Y; }

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
            RandomizeNodePositions();
            for (var i = 0; i < InitialIterations; i++)
            {
                await ApplyForcesAsync();
            }
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;


            while (true)
            {
                await ApplyForcesAsync();
                StateHasChanged();
                await Task.Delay(100);
            }
        }

        private void RandomizeNodePositions()
        {
            Nodes.ForEach(n =>
            {
                n.Center = new Point(Random.Shared.NextDouble() * 500, Random.Shared.NextDouble() * 500);
            });
        }

        private bool AreConnected(Node a, Node b)
        {
            return edges.Any(e => e.Connects(a, b));
        }

        public Task ApplyForcesAsync() 
        {
            MinPoint = Nodes.First().Center;
            MaxPoint = Nodes.First().Center;

            Nodes.ForEach(n =>
            {
                double mx = 0;
                double my = 0;
                Nodes.Where(o => o != n).ToList().ForEach(o =>
                {
                    double dx = n.Center.X - o.Center.X;
                    double dy = n.Center.Y - o.Center.Y;
                    double d = Math.Sqrt(dx * dx + dy * dy);

                    double force;
                    if (AreConnected(n, o))
                    {
                        force = EdgeSpringConstant * Math.Log(d / EdgeSpringLength);
                    }
                    else
                    {
                        force = -(NodeRepulsion / (d * d));
                    }

                    mx -= dx * 0.1 * force;
                    my -= dy * 0.1 * force;
                });

                var newCenter = n.Center.Translate(mx, my);

                MinPoint = new Point(Math.Min(newCenter.X, MinPoint.X), Math.Min(newCenter.Y, MinPoint.Y));
                MaxPoint = new Point(Math.Max(newCenter.X, MaxPoint.X), Math.Max(newCenter.Y, MaxPoint.Y));

                n.Center = newCenter;
            });

            return Task.CompletedTask;
        }
    }
}
