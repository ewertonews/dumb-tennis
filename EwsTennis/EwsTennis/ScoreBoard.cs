using System;
using System.Collections.Generic;

namespace EwsTennis
{
    public class ScoreBoard
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private List<int> ScoreList = new List<int>() { 0, 15, 30, 40 };

        public ScoreBoard(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
        
        public int GetPlayerOneScore()
        {
            if (_player1.Score >= 4)
            {
                return _player1.Score;
            }
            return ScoreList[_player1.Score];
        }

        public int GetPlayerTwoScore()
        {
            if (_player2.Score >= 4)
            {
                return _player2.Score;
            }
            return ScoreList[_player2.Score];
        }

        private bool IsTie()
        {
            return _player1.Score == _player2.Score;
        }

        public bool IsInTieBreak()
        {
            return (GetPlayerOneScore() == 40 && IsTie()) 
                || (!ScoreList.Contains(GetPlayerOneScore()) || (!ScoreList.Contains(GetPlayerTwoScore())));
        }
    }
}
