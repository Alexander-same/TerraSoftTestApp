namespace TerrasoftTestApp.Metrics.Interfaces
{
    public interface ITextMetric
    {
        string Name { get; }
        string Process(string textResponseModel);
    }
}
