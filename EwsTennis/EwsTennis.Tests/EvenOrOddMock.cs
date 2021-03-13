using EwsTennis.Enums;

namespace EwsTennis.Tests
{
    internal class EvenOrOddMock : IEvenOrOdd
    {
        public Player Draw(Player player1, Player player2)
        {
            return new Player()
            {
                EvenOrOdd = EvenOrOddOption.ODD
            };
        }
    }
}