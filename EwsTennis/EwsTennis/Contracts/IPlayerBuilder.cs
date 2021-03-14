namespace EwsTennis.Contracts
{
    public interface IPlayerBuilder
    {
        PlayerBuilder AtPosition(int playerPosition);
        Player Build();
        PlayerBuilder WithLevel(string playerLevel);
        PlayerBuilder WithName(string playerName);
    }
}