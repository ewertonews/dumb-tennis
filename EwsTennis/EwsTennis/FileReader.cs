using EwsTennis.Contracts;
using EwsTennis.Exceptions;
using System.IO;

namespace EwsTennis
{
    public class FileReader : IFileReader
    {
        public string[] GetFileLines(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath);
            if(fileLines.Length < 8)
            {
                throw new InvalidFileException("O arquivo fornecido com os dados dos jogadores é inválido.");
            }

            return fileLines;
        }
    }
}
