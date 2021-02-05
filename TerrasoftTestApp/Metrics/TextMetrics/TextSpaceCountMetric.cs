using System;
using TerrasoftTestApp.Metrics.Interfaces;
using TerrasoftTestApp.Metrics.TextMetrics.Constants;

namespace TerrasoftTestApp.Metrics
{
    public class TextSpaceCountMetric : ITextMetric
    {
        public string Name => TextMetricConstants.SpaceCount;

        public string Process(string text)
        {
            return (text.Split(new char[] { ' ' }).Length - 1).ToString();
        }
    }
}
