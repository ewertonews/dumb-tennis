namespace EwsTennis.Contracts
{
    public interface IPlayersDataReader
    {
        string[] GetPlayerOneData(string filePath);
        string[] GetPlayerTwoData(string filePath);
    }
}