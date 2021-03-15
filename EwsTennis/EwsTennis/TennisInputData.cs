namespace EwsTennis
{
    public class TennisInputData
    {
        private readonly IFileReader _fileReader;
        public TennisInputData(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string[] GetPlayerOneData()
        {
            var fileContent = _fileReader.GetFileLines();
            return fileContent[0..4];
        }

        public string[] GetPlayerTwoData()
        {
            var fileContent = _fileReader.GetFileLines();
            return fileContent[4..8];
        }
    }
}
