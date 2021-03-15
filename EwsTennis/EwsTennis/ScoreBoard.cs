using EwsTennis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EwsTennis
{
    public class ScoreBoard : IScoreBoard
    {
        private IPlayer _player1;
        private IPlayer _player2;

        public ScoreBoard(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
             
        }

        public Player Player1 { get => (Player)_player1;  set => _player1 = value; }
        public Player Player2 { get => (Player)_player2;   set => _player2 = value; }


        public List<int> ScoreList { get; set; } = new List<int>() { 0, 15, 30, 40 };

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
        public void SetPlayerOneScore()
        {
            _player1.Score++;
            OnPlayerScored();
        }

        public void SetPlayerTwoScore()
        {
            _player2.Score++;
            OnPlayerScored();
        }

        public event EventHandler PlayerScored;

        protected virtual void OnPlayerScored()
        {
            if (PlayerScored != null)
            {
                PlayerScored(this, EventArgs.Empty);
            }
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

    }
}
