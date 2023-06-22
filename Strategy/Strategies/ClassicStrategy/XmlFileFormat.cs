using Strategy.Common.Interfaces;
using System.Xml.Serialization;

namespace Strategy.Strategies.ClassicStrategy
{
    public class XmlFileFormat : IFileFormat
    {
        public void WriteToFile<T>(IList<T> collection, string filePath) where T : class
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            var file = new StreamWriter(filePath);
            serializer.Serialize(file, collection);
            file.Close();
        }
    }
}
