﻿using EwsTennis.Contracts;
using Moq;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class GameControllerUnitTests
    {
        private Mock<IPlayersDataReader> playerDataReaderMock = new Mock<IPlayersDataReader>();
        private Mock<IEvenOrOdd> evenOrOddMock = new Mock<IEvenOrOdd>();
        private Mock<IScoreBoard> scoreBoardMock = new Mock<IScoreBoard>();
        private Mock<IReferee> refereeMock = new Mock<IReferee>();
        private IGameController _gameController;

        [SetUp]
        public void Setup()
        {
            IRandomNumber randomNumber = new RandomNumber();
            IPlayerBuilder playerBuilder = new PlayerBuilder(randomNumber);
            _gameController = new GameController(
                    playerBuilder,
                    playerDataReaderMock.Object,
                    evenOrOddMock.Object,
                    scoreBoardMock.Object,
                    refereeMock.Object);
        }

        [Test]
        public void InitializePlayersShuouldAddTwoValidPlayersToPlayersList()
        {

            var player1DataMock = new string[] { "Tonho", "Experienced", "Even", "25" };
            var player2DataMock = new string[] { "Zé", "Experienced", "Odd", "21" };
            playerDataReaderMock.Setup(pdr => pdr.GetPlayerOneData("fakeFilePath")).Returns(player1DataMock);
            playerDataReaderMock.Setup(pdr => pdr.GetPlayerTwoData("fakeFilePath")).Returns(player2DataMock);

            _gameController.InitializePlayers(new string[] {"fakeFilePath"});

            Assert.That(_gameController.Players, Is.Not.Empty);
            Assert.That(_gameController.Players.Count, Is.EqualTo(2));
            Assert.That(_gameController.Players[0], Is.Not.Null);
            Assert.That(_gameController.Players[1], Is.Not.Null);
            Assert.That(_gameController.Players[0].Position, Is.Not.Zero);
            Assert.That(_gameController.Players[1].Position, Is.Not.Zero);
            Assert.That(_gameController.Players[0].Level, Is.Not.Zero);
            Assert.That(_gameController.Players[1].Level, Is.Not.Zero);
            Assert.That(_gameController.Players[0].EvenOrOdd, Is.Not.Zero);
            Assert.That(_gameController.Players[1].EvenOrOdd, Is.Not.Zero);
        }

        [Test]
        public void InitializePlayersShouldThrowArgumentExceptionForEmptyArrayOfArgs()
        {
            string[] args = new string[]{};

            Assert.That(() => _gameController.InitializePlayers(args), Throws.ArgumentException);
        }
    }
}
