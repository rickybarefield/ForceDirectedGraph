namespace ForceDirectedGraph.Graph.SvgElements
{
    public record Color(double r, double g, double b)
    {
        public static Color Red = new Color(255, 0, 0);
        public static Color Green = new Color(0, 255, 0);
        public static Color Blue = new Color(0, 0, 255);
        public static Color Black = new Color(0, 0, 0);
        public static Color White = new Color(255, 255, 255);

        public override string ToString()
        {
            return $"rgb({r}, {g}, {b})";
        }
    }
}
