using Strategy.Common.Interfaces;
using System.Text.Json;

namespace Strategy.Strategies.ClassicStrategy
{
    public class JsonFileFormat : IFileFormat
    {
        public void WriteToFile<T>(IList<T> collection, string filePath) where T : class
        {
            var json = JsonSerializer.Serialize(collection);
            File.WriteAllText(filePath, json);
        }
    }
}
