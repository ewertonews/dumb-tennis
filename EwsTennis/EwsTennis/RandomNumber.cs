using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
