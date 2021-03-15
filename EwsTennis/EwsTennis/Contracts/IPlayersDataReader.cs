namespace EwsTennis.Contracts
{
    public interface IPlayersDataReader
    {
        string[] GetPlayerOneData();
        string[] GetPlayerTwoData();
    }
}