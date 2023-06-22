using CsvHelper;
using CsvHelper.Configuration;
using Strategy.Common.Interfaces;
using System.Globalization;

namespace Strategy.Strategies.ClassicStrategy
{
    public class CsvFileFormat : IFileFormat
    {
        public void WriteToFile<T>(IList<T> collection, string filePath) where T : class
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteRecords(collection);
                    }
                }
            }
        }
    }
}
