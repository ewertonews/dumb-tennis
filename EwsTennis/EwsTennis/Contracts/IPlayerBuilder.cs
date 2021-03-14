using EwsTennis.Enums;

namespace EwsTennis
{
    public interface IPlayerBuilder
    {
        PlayerBuilder AtPosition(int playerPosition);
        Player Build();
        PlayerBuilder WithLevel(PlayerLevel playerLevel);
        PlayerBuilder WithName(string playerName);
    }
}