namespace Strategy.Common.Interfaces
{
    public interface IFileFormat
    {
        public void WriteToFile<T>(IList<T> collection, string filePath) where T : class;
    }
}
