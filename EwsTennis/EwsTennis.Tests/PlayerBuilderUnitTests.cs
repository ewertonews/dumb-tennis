using EwsTennis.Enums;
using EwsTennis.Exceptions;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class PlayerBuilderUnitTests
    {
        [Test]
        public void BuildShouldReturnPlayerInstance()
        {
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder.Build();

            Assert.That(player, Is.Not.Null);
        }

        [Test]
        public void BuildWithNameShouldReturnPlayerWithGivenName()
        {
            var playerName = "Raphael";
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder
                .WithName(playerName)
                .Build();

            Assert.That(player.Name, Is.EqualTo(playerName));
        }

        [Test]
        [TestCase("Beginner")]
        [TestCase("beginner")]
        [TestCase("BEGINNER")]
        public void BuildWithLevelShouldReturnPlayerWithGivenLevelIndependentlyOfCase(string level)
        {
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder
                .WithLevel(level)
                .Build();

            Assert.That(player.Level, Is.EqualTo(PlayerLevel.Beginner));
        }

        [Test]
        public void BuildWithLevelShouldThrowInvalidLevelException()
        {
            var level = "iniciante";
            var playerBuilder = new PlayerBuilder();

            Assert.That(() => playerBuilder.WithLevel(level), Throws.TypeOf<InvalidLevelException>());                
        }

        [Test]
        public void BuildAtPositionShouldReturnPlayerWithGivenPosition()
        {
            var playerPosition = 15;
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder
                .AtPosition(playerPosition)
                .Build();

            Assert.That(player.Position, Is.EqualTo(playerPosition));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(28)]
        public void BuildAtPositionShoulThrowOutOfCourtBoundsException(int playerPosition)
        {
            var playerBuilder = new PlayerBuilder();

            Assert.That(() => playerBuilder.AtPosition(playerPosition), Throws.TypeOf<OutOfCourtBoundsException>());
        }

    }
}
