using EwsTennis.Enums;
using System.Collections.Generic;
using System.Linq;

namespace EwsTennis.Tests
{
    internal class EvenOrOddMock : IEvenOrOdd
    {
        public Player Draw(Player player1, Player player2)
        {
            var players = new List<Player>() { player1, player2 };
            EvenOrOddOption result = EvenOrOddOption.ODD;

            var fakeRandomNumber = 5;
            if (fakeRandomNumber % 2 == 0)
            {
                result = EvenOrOddOption.EVEN;
            }

            return players.First(p => p.EvenOrOdd == result);
        }
    }
}