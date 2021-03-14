using EwsTennis.Contracts;
using System.Collections.Generic;

namespace EwsTennis
{
    public class Referee : IReferee
    {
        private readonly IScoreBoard _scoreBoard;

        public Referee(IScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }

        private bool IsTie()
        {
            return _scoreBoard.GetPlayerOneScore() == _scoreBoard.GetPlayerTwoScore();
        }

        public bool IsInTieBreak()
        {
            var player1Score = _scoreBoard.GetPlayerOneScore();
            var player2Score = _scoreBoard.GetPlayerTwoScore();
            List<int> scoreList = _scoreBoard.ScoreList;
            return (player1Score == 40 && IsTie())
                || (!scoreList.Contains(_scoreBoard.GetPlayerOneScore()) || (!scoreList.Contains(player2Score)));
        }
    }
}
