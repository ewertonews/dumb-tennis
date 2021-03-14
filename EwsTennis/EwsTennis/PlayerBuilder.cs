using EwsTennis.Enums;
using System;

namespace EwsTennis
{
    public class PlayerBuilder
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
            _player.Position = playerPosition;
            return this;
        }
    }
}
