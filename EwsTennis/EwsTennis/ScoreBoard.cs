using EwsTennis.Contracts;
using System.Collections.Generic;

namespace EwsTennis
{
    public class ScoreBoard : IScoreBoard
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public ScoreBoard(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
        public List<int> ScoreList { get; } = new List<int>() { 0, 15, 30, 40 };

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

        public override string ToString()
        {
            var scoreString = $"{_player1.Name} {GetPlayerOneScore()} x {GetPlayerTwoScore()} {_player2.Name}";
            if (GetPlayerTwoScore() > GetPlayerOneScore())
            {
                scoreString = $"{_player2.Name} {GetPlayerTwoScore()} x {GetPlayerOneScore()} {_player1.Name}";
            }
            return scoreString;
        }

        public void SetPlayerOneScore()
        {
            _player1.Score++;
        }
    }
}
