using TerrasoftTestApp.Metrics.Interfaces;
using TerrasoftTestApp.Metrics.TextMetrics.Constants;

namespace TerrasoftTestApp.Metrics.TextMetrics
{
    public class TextExclamationMarkCountMetric : ITextMetric
    {
        public string Name => TextMetricConstants.ExclamatorySentenceCount;

        public string Process(string text)
        {
            return (text.Split(new char[] { '!' }).Length - 1).ToString();
        }
    }
}
