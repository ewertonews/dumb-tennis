﻿using System;
using System.Collections.Generic;

namespace EwsTennis
{
    public class ScoreBoard
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public ScoreBoard(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public List<int> ScoreList = new List<int>() { 0, 15, 30, 40 };

        public int PlayerOneScore { private get; set; }
        public int PlayerTwoScore { private get; set; }


        public int GetPlayerOneScore()
        {
            return ScoreList[_player1.Score];
        }

        public int GetPlayerTwoScore()
        {
            return ScoreList[_player2.Score];
        }
       
    }
}
