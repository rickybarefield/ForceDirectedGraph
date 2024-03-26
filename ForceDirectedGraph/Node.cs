﻿using AngleSharp.Dom;
using ForceDirectedGraph.SvgElements;

namespace ForceDirectedGraph
{
    public class Node : IRender
    {
        public required Point Center { get; init; }

        public required string Text { get; init; }

        public IElement Render(IDocument document)
        {
            return new Group
            {
                Center = Center,
                Children =
                {
                    new Circle
                    {
                        R = 53.6
                    },
                    new Text
                    {
                        Content = Text,
                        StrokeColor = Color.Red
                    }
                }
            }.Render(document);
        }

        public Point PointToLinkToOnNodeWhenOriginatingFrom(Point originatingPoint)
        {
            return new Circle
            {
                R = 60,
                Center = Center
            }.FindPointOnCircumferenceBetweenCenterAnd(originatingPoint);
        }
    }
}