using EwsTennis.Contracts;

namespace EwsTennis
{
    public class PlayersDataReader : IPlayersDataReader
    {
        private readonly IFileReader _fileReader;
        public PlayersDataReader(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string[] GetPlayerOneData(string filePath)
        {
            var fileContent = _fileReader.GetFileLines(filePath);
            return fileContent[0..4];
        }

        public string[] GetPlayerTwoData(string filePath)
        {
            var fileContent = _fileReader.GetFileLines(filePath);
            return fileContent[4..8];
        }
    }
}
