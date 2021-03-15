using System;
using System.Collections.Generic;

namespace EwsTennis.Contracts
{
    public interface IScoreBoard
    {
        Player Player1 { get;  set; }
        Player Player2 { get;  set; }
        List<int> ScoreList { get; set; }

        event EventHandler PlayerScored;

        int GetPlayerOneScore();
        int GetPlayerTwoScore();
        void SetPlayerOneScore();
        void SetPlayerTwoScore();
        string ToString();
    }
}