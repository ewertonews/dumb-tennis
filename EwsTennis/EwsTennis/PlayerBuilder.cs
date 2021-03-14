using EwsTennis.Contracts;
using EwsTennis.Enums;
using EwsTennis.Exceptions;
using System;

namespace EwsTennis
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private Player _player;

        public PlayerBuilder()
        {
            _player = new Player();
        }

        public Player Build()
        {
            var player = new Player()
            {
                Name = _player.Name,
                Level = _player.Level,
                Position = _player.Position                
            };
            _player = new Player();
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
    }
}
