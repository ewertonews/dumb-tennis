using EwsTennis.Contracts;
using EwsTennis.Enums;
using System;

namespace EwsTennis
{
    public class Player
    {
        private readonly IRandomNumber _randonNumber;

        public Player(IRandomNumber randonNumber)
        {
            _randonNumber = randonNumber;
        }

        public string Name { get; set; }
        public PlayerLevel Level { get; set; } = PlayerLevel.Beginner;
        public int ReachOfLeftHand { get; private set; }
        public int ReachOfRightHand { get; private set; }
        public int Position { get; set; }
        public EvenOrOddOption EvenOrOdd { get; set; }
        public int Score { get; set; }


        public int Serve()
        {
            return _randonNumber.Get(1, 27);
        }

        public void SetReachOfHands()
        {
            var resultLeft = Position - (int)Level;
            if (resultLeft <= 0)
            {
                resultLeft = 1;
            }
            ReachOfLeftHand = resultLeft;

            var resultRight = Position + (int)Level;
            if (resultRight > 27)
            {
                resultRight = 27;
            }
            ReachOfRightHand = resultRight;
        }
    }
}
