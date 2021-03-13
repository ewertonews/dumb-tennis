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
    }
}
