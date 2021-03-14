using EwsTennis.Contracts;
using EwsTennis.Enums;
using EwsTennis.Exceptions;
using System;

namespace EwsTennis
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private Player _player;
        private readonly IRandomNumber _randomNumber;

        public PlayerBuilder(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
            _player = new Player(_randomNumber);

        }

        public Player Build()
        {
            var player = new Player(_randomNumber)
            {
                Name = _player.Name,
                Level = _player.Level,
                Position = _player.Position,
                EvenOrOdd = _player.EvenOrOdd
            };
            _player = new Player(_randomNumber);
            return player;
        }

        public PlayerBuilder WithName(string playerName)
        {
            _player.Name = playerName;
            return this;
        }

        public PlayerBuilder WithLevel(string playerLevel)
        {
            PlayerLevel level;
            if(!Enum.TryParse(playerLevel, true, out level))
            {
                throw new InvalidLevelException("O nível definido para o jogador é inválido.");
            }
            _player.Level = level;
            return this;
        }

        public PlayerBuilder AtPosition(int playerPosition)
        {
            if (playerPosition < 0 || playerPosition > 27)
            {
                throw new OutOfCourtBoundsException("A posição do jogador precisa ser entre 1 e 27");
            }
            _player.Position = playerPosition;
            return this;
        }

        public PlayerBuilder WithEvenOrOddOption(string evenOrOdd)
        {
            EvenOrOddOption optionEvenOdd;
            if (!Enum.TryParse(evenOrOdd, true, out optionEvenOdd))
            {
                throw new InvalidEvenOddOptionException("A opção para o par ou impar deve ser 'even' para par ou 'odd' para ímpar");
            }
            _player.EvenOrOdd = optionEvenOdd;
            return this;
        }
    }
}
