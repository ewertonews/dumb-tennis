using EwsTennis.Contracts;
using EwsTennis.Enums;
using EwsTennis.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace EwsTennis
{
    public class EvenOrOdd : IEvenOrOdd
    {
        private readonly IRandomNumber _randomNumber;

        public EvenOrOdd(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
        }

        public Player Draw(Player player1, Player player2)
        {
            if (player1.EvenOrOdd == player2.EvenOrOdd)
            {
                string mensagemErro = "Jogadores não podem ter mesma opção de par ou impar";
                throw new InvalidEvenOddOptionException(mensagemErro);
            }
            var players = new List<Player>() { player1, player2 };
            EvenOrOddOption result = EvenOrOddOption.Odd;

            var resultRandomNumberOneToTen = _randomNumber.Get(1, 10);
            if (resultRandomNumberOneToTen % 2 == 0)
            {
                result = EvenOrOddOption.Even;
            }

            return players.First(p => p.EvenOrOdd == result);
        }
    }
}
