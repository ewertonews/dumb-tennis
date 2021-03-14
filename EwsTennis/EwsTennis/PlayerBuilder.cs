using EwsTennis.Enums;
using EwsTennis.Exceptions;
using System;

namespace EwsTennis
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private readonly Player _player;

        public PlayerBuilder()
        {
            _player = new Player();
        }

        public Player Build()
        {
            return _player;
        }

        public PlayerBuilder WithName(string playerName)
        {
            _player.Name = playerName;
            return this;
        }

        public PlayerBuilder WithLevel(PlayerLevel playerLevel)
        {
            _player.Level = playerLevel;
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
