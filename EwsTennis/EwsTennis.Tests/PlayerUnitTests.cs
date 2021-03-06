using EwsTennis.Contracts;
using EwsTennis.Enums;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class PlayerUnitTests
    {
        private readonly IRandomNumber randomNumber = new RandomNumber();

        [Test]
        public void ServeShouldReturnNumerFrom1To27()
        {
            var player = new Player(randomNumber);

            var result = player.Serve();

            Assert.That(result, Is.GreaterThanOrEqualTo(1));
            Assert.That(result, Is.LessThanOrEqualTo(27));
        }

        [Test]
        public void SetReachOfHandShouldReturn6ForLeftAnd14ForRight()
        {
            var player = new Player(randomNumber)
            {
                Level = PlayerLevel.Experienced,
                Position = 10
            };

            player.SetReachOfHands();

            Assert.That(player.ReachOfLeftHand, Is.EqualTo(6));
            Assert.That(player.ReachOfRightHand, Is.EqualTo(14));
        }

        [Test]
        public void SetReachOfHandsShouldSetLeftToOneWhenPlayerIsAtTheLeftCornerOfCourt()
        {
            var player = new Player(randomNumber)
            {
                Level = PlayerLevel.Experienced,
                Position = 3
            };

            player.SetReachOfHands();

            Assert.That(player.ReachOfLeftHand, Is.EqualTo(1));
            Assert.That(player.ReachOfRightHand, Is.EqualTo(7));
        }

        [Test]
        public void SetReachOfHandsShouldSetRightToTwentySevenWhenPlayerIsAtTheRightCornerOfCourt()
        {
            var player = new Player(randomNumber)
            {
                Level = PlayerLevel.Experienced,
                Position = 25
            };

            player.SetReachOfHands();

            Assert.That(player.ReachOfLeftHand, Is.EqualTo(21));
            Assert.That(player.ReachOfRightHand, Is.EqualTo(27));
        }
    }
}
