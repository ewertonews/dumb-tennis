using EwsTennis.Enums;

namespace EwsTennis
{
    public interface IPlayerBuilder
    {
        PlayerBuilder AtPosition(int playerPosition);
        Player Build();
        PlayerBuilder WithLevel(string playerLevel);
        PlayerBuilder WithName(string playerName);
    }
}