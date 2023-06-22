using Strategy.Common.Factories;
using Strategy.Common.Interfaces;

namespace Strategy.Common.Services
{
    public class FileWriter
    {
        public FileWriter()
        { 
            BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        public string BaseDirectory { get; set; }

        // public string StringFileFormat { get; set; }
        // public FileFormat EnumFileFormat { get; set; }

        public void Write<T>(IList<T> resources, string fileName) where T : class
        {
            var fileFormat = Path.GetExtension(fileName).Substring(1);

            try
            {
                // Note: Strategies can be obtained from string and enum factories too.
                // var strategy = StringFileFormatFactory.GetFileFormat(StringFileFormat);
                // var strategy = EnumFileFormatFactory.GetFileFormat(EnumFileFormat);

                var strategy = DynamicFileFormatFactory.Instantiate<IFileFormat>(fileFormat);
                strategy.WriteToFile(resources, Path.Combine(BaseDirectory, fileName));
                Console.WriteLine($"{ fileName } has been created.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{fileName} could not be created. Extension is not supported.");
            }
        }
    }
}
