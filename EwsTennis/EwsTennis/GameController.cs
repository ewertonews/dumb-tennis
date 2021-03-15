using EwsTennis.Contracts;
using System;
using System.Collections.Generic;

namespace EwsTennis
{
    public class GameController
    {
        private readonly IPlayerBuilder _playerBuilder;
        private readonly IPlayersDataReader _playersDataReader;

        public GameController(
            IPlayerBuilder playerBuilder,
            IPlayersDataReader playersDataReader)
        {
            _playerBuilder = playerBuilder;
            _playersDataReader = playersDataReader;
        }

        public List<Player> Players { get; } = new List<Player>();

        public void InitializePlayers(string[] programArgs)
        {
            if (programArgs.Length == 0)
            {
                throw new ArgumentException("Argument with file path cannot be null or empty");
            }

            var filePath = programArgs[0];
            var player1Data = _playersDataReader.GetPlayerOneData(filePath);
            var player2Data = _playersDataReader.GetPlayerTwoData(filePath);

            var player1 = _playerBuilder
                .WithName(player1Data[0])
                .WithLevel(player1Data[1])
                .WithEvenOrOddOption(player1Data[2])
                .AtPosition(Convert.ToInt16(player1Data[3]))
                .Build();

            var player2 = _playerBuilder
                .WithName(player2Data[0])
                .WithLevel(player2Data[1])
                .WithEvenOrOddOption(player2Data[2])
                .AtPosition(Convert.ToInt16(player2Data[3]))
                .Build();

            Players.Add(player1);
            Players.Add(player2);
        }
    }
}
