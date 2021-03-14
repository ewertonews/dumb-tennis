using System;
using System.Collections.Generic;

namespace EwsTennis
{
    public class ScoreBoard
    {
        public List<int> ScoreList = new List<int>() { 0, 15, 30, 40 };

        public int PlayerOneScore { private get; set; }
        public int PlayerTwoScore { private get; set; }

        public int GetPlayerOneScore()
        {
            return ScoreList[PlayerOneScore];
        }
    }
}
