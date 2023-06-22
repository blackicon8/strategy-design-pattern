using System.Reflection;

namespace Strategy.Common.Factories
{
    public class DynamicFileFormatFactory
    {
        private const string StrategiesNamespace = "strategy.Strategies.ClassicStrategy";

        public static T? Instantiate<T>(string fileFormat)
        {
            var className = fileFormat.ToLower() + "fileformat";

            Type typeImplemented = typeof(T);
            Type selectedType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && t.Namespace == StrategiesNamespace)
            .First(t => typeImplemented.IsAssignableFrom(t) && t.Name.ToLower() == className);

            return (T?)Activator.CreateInstance(selectedType);
        }
    }
}
