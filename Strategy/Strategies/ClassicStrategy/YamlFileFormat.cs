using Strategy.Common.Interfaces;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Strategy.Strategies.ClassicStrategy
{
    internal class YamlFileFormat : IFileFormat
    {
        public void WriteToFile<T>(IList<T> collection, string filePath) where T : class
        {
            var serializer = new SerializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();

            var yaml = new StringBuilder();

            using (var textWriter = new StringWriter(yaml))
            {
                serializer.Serialize(textWriter, collection);
                File.WriteAllText(filePath, textWriter.ToString());
            }
        }
    }
}
