using EwsTennis.Contracts;
using System;

namespace EwsTennis
{
    public class RandomNumber : IRandomNumber
    {
        private readonly Random random = new Random();

        public int Get(int from, int to)
        {
            return random.Next(from, to + 1);
        }

    }
}
