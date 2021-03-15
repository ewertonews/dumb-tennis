using System.Collections.Generic;

namespace EwsTennis.Contracts
{
    public interface IGameController
    {
        Player Player1 { get; }
        Player Player2 { get; }
        List<Player> Players { get; }
        void InitializePlayers(string[] programArgs);
        void Play();
    }
}