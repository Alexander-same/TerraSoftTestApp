using System.Linq;
using TerrasoftTestApp.Metrics.Interfaces;
using TerrasoftTestApp.Metrics.TextMetrics.Constants;

namespace TerrasoftTestApp.Metrics.TextMetrics
{
    public class TextRemoveAllNumbersMetric : ITextMetric
    {
        public string Name => TextMetricConstants.RemoveAllNumbers;

        public string Process(string text)
        {
            return new string(text.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()); ;
        }
    }
}
