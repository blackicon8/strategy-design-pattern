using Strategy.Common.Interfaces;
using Strategy.Strategies.ClassicStrategy;

namespace Strategy.Common.Factories
{
    public class StringFileFormatFactory
    {
        private static readonly Dictionary<string, Func<IFileFormat>> _fileFormatStrategies =
            new Dictionary<string, Func<IFileFormat>>()
            {
                { "csv", () => new CsvFileFormat() },
                { "json", () => new JsonFileFormat() },
                { "xml", () => new XmlFileFormat() },
                { "yaml", () => new YamlFileFormat() }
            };

        public static IFileFormat GetFileFormat(string fileFormat)
        {
            var selectedStrategy = _fileFormatStrategies[fileFormat];
            return selectedStrategy();
        }
    }
}
