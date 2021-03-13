using EwsTennis.Enums;
using System;

namespace EwsTennis
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerLevel Level { private get; set; }
        public int ReachOfLeftHand { get; private set; }
        public int ReachOfRightHand { get; private set; }
        public int Position { get; set; }
        public EvenOrOddOption EvenOrOdd { get; set; }

        public int Serve()
        {
            return new Random().Next(1, 28);
        }

        public void SetReachOfHands()
        {
            ReachOfLeftHand = 6;
            ReachOfRightHand = 14;
        }
    }
}
