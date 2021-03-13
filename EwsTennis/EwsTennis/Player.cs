using EwsTennis.Enums;
using System;

namespace EwsTennis
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerLevel Level { get; set; }
        public int ReachOfHands { get; private set; }
        public int Position { get; set; }
        public EvenOrOddOption EvenOrOdd { get; set; }

        public int Serve()
        {
            return new Random().Next(1, 28);
        }
    }
}
