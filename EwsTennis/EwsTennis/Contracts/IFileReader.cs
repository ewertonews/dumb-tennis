namespace EwsTennis.Contracts
{
    public interface IFileReader
    {
        string[] GetFileLines(string filePath);
    }
}