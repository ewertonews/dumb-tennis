using System.Collections.Generic;

namespace EwsTennis.Contracts
{
    public interface IScoreBoard
    {
        List<int> ScoreList { get; }

        int GetPlayerOneScore();
        int GetPlayerTwoScore();
        string ToString();
    }
}