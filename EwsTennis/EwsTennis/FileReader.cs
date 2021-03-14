using System.IO;

namespace EwsTennis
{
    public class FileReader : IFileReader
    {
        public string[] GetFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
