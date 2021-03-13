using EwsTennis.Enums;
using EwsTennis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EwsTennis
{
    public class EvenOrOdd : IEvenOrOdd
    {
        private readonly Random random = new Random();

        public Player Draw(Player player1, Player player2)
        {
            if (player1.EvenOrOdd == player2.EvenOrOdd)
            {
                string mensagemErro = "Jogadores não pode ter mesma opção de par ou impar";
                throw new InvalidEvenOddOptionException(mensagemErro);
            }
            var players = new List<Player>() { player1, player2 };
            EvenOrOddOption result = EvenOrOddOption.ODD;

            var resultRandomNumberOneToTen = random.Next(1, 11);
            if (resultRandomNumberOneToTen % 2 == 0)
            {
                result = EvenOrOddOption.EVEN;
            }

            return players.First(p => p.EvenOrOdd == result);
        }
    }
}
