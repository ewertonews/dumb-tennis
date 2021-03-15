using EwsTennis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EwsTennis
{
    public class Referee : IReferee
    {
        private readonly IScoreBoard _scoreBoard;
        public bool GameEnded { get; private set; } = false;

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

        public void OnPlayerScored(object source, EventArgs eventArgs)
        {
            bool doesNotContainPlayerScore = !_scoreBoard.ScoreList.Contains(_scoreBoard.Player1.Score);
                
            if (IsTie() && doesNotContainPlayerScore)
            {
                _scoreBoard.ScoreList = Enumerable.Range(0, 100).ToList();
                _scoreBoard.Player1.Score = 0;
                _scoreBoard.Player2.Score = 0;
            }

            CheckWinner();
        }

        private void CheckWinner()
        {
            var scorePlayer1 = _scoreBoard.Player1.Score;
            var scorePlayer2 = _scoreBoard.Player2.Score;

            if (scorePlayer1 >= 3 && scorePlayer1 - scorePlayer2 >= 2 
                || scorePlayer2 >= 3 && scorePlayer2 - scorePlayer1 >= 2)
            {
                GameEnded = true;
            }            
        }
    }
}
