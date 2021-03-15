using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class GameControllerUnitTests
    {
        [Test]
        public void InitializePlayersShuouldAddTwoValidPlayersToPlayersList()
        {
            var gameControler = new GameController();

            gameControler.InitializePlayers(string[] programArgs);

            Assert.That(gameControler.Players, Is.Not.Empty);
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
