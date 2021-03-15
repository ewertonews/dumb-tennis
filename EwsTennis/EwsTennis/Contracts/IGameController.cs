using System.Collections.Generic;

namespace EwsTennis.Contracts
{
    public interface IGameController
    {
        bool FirstServe { get; set; }
        Player Player1 { get; }
        Player Player2 { get; }
        List<Player> Players { get; }
        void InitializePlayers(string[] programArgs);
        void Round();
    }
}