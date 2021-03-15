using EwsTennis.Contracts;
using Moq;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class GameControllerUnitTests
    {
        private Mock<IPlayersDataReader> playerDataReaderMock = new Mock<IPlayersDataReader>();

        [Test]
        public void InitializePlayersShuouldAddTwoValidPlayersToPlayersList()
        {
            IRandomNumber randomNumber = new RandomNumber();
            IPlayerBuilder playerBuilder = new PlayerBuilder(randomNumber);
            var gameControler = new GameController(
                    playerBuilder, 
                    playerDataReaderMock.Object);

            var player1DataMock = new string[] { "Tonho", "Experienced", "Even", "25" };
            var player2DataMock = new string[] { "Zé", "Experienced", "Odd", "21" };
            playerDataReaderMock.Setup(pdr => pdr.GetPlayerOneData("fakeFilePath")).Returns(player1DataMock);
            playerDataReaderMock.Setup(pdr => pdr.GetPlayerTwoData("fakeFilePath")).Returns(player2DataMock);
            
            gameControler.InitializePlayers(new string[] {"fakeFilePath"});

            Assert.That(gameControler.Players, Is.Not.Empty);
            Assert.That(gameControler.Players.Count, Is.EqualTo(2));
            Assert.That(gameControler.Players[0], Is.Not.Null);
            Assert.That(gameControler.Players[1], Is.Not.Null);
            Assert.That(gameControler.Players[0].Position, Is.Not.Zero);
            Assert.That(gameControler.Players[1].Position, Is.Not.Zero);
            Assert.That(gameControler.Players[0].Level, Is.Not.Zero);
            Assert.That(gameControler.Players[1].Level, Is.Not.Zero);
            Assert.That(gameControler.Players[0].EvenOrOdd, Is.Not.Zero);
            Assert.That(gameControler.Players[1].EvenOrOdd, Is.Not.Zero);
        }
    }
}
