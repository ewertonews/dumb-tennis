using EwsTennis.Contracts;
using EwsTennis.Exceptions;
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
            var fileLines = File.ReadAllLines(_filePath);
            if(fileLines.Length < 8)
            {
                throw new InvalidFileException("O arquivo fornecido com os dados dos jogadores é inválido.");
            }

            return fileLines;
        }
    }
}
