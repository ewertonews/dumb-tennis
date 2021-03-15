using EwsTennis.Contracts;
using System.IO;

namespace EwsTennis
{
    public class FileReader : IFileReader
    {
        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public string[] GetFileLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
