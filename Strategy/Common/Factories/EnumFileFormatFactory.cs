using Strategy.Common.Enums;
using Strategy.Common.Interfaces;
using Strategy.Strategies.ClassicStrategy;

namespace Strategy.Common.Factories
{
    public class EnumFileFormatFactory
    {
        private static readonly Dictionary<FileFormat, Func<IFileFormat>> _fileFormatStrategies = 
            new Dictionary<FileFormat, Func<IFileFormat>>()
            {
                { FileFormat.Csv, () => new CsvFileFormat() },
                { FileFormat.Json, () => new JsonFileFormat() },
                { FileFormat.Xml, () => new XmlFileFormat() },
                { FileFormat.Yaml, () => new YamlFileFormat() }
            };

        public static IFileFormat GetFileFormat(FileFormat fileFormat)
        {
            var selectedStrategy = _fileFormatStrategies[fileFormat];
            return selectedStrategy();
        }
    }
}
