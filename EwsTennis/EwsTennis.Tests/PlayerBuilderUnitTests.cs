using EwsTennis.Contracts;
using EwsTennis.Enums;
using EwsTennis.Exceptions;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class PlayerBuilderUnitTests
    {
        private IRandomNumber randomNumber = new RandomNumber();

        [Test]
        public void BuildShouldReturnPlayerInstance()
        {
            var playerBuilder = new PlayerBuilder(randomNumber);

            var player = playerBuilder.Build();

            Assert.That(player, Is.Not.Null);
        }

        [Test]
        public void BuildWithNameShouldReturnPlayerWithGivenName()
        {
            var playerName = "Raphael";
            var playerBuilder = new PlayerBuilder(randomNumber);

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
            var playerBuilder = new PlayerBuilder(randomNumber);

            var player = playerBuilder
                .WithLevel(level)
                .Build();

            Assert.That(player.Level, Is.EqualTo(PlayerLevel.Beginner));
        }

        [Test]
        public void BuildWithLevelShouldThrowInvalidLevelException()
        {
            var level = "iniciante";
            var playerBuilder = new PlayerBuilder(randomNumber);

            Assert.That(() => playerBuilder.WithLevel(level), Throws.TypeOf<InvalidLevelException>());                
        }

        [Test]
        public void BuildAtPositionShouldReturnPlayerWithGivenPosition()
        {
            var playerPosition = 15;
            var playerBuilder = new PlayerBuilder(randomNumber);

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
            var playerBuilder = new PlayerBuilder(randomNumber);

            Assert.That(() => playerBuilder.AtPosition(playerPosition), Throws.TypeOf<OutOfCourtBoundsException>());
        }

        [Test]
        [TestCase("Even", EvenOrOddOption.Even)]
        [TestCase("even", EvenOrOddOption.Even)]
        [TestCase("EVEN", EvenOrOddOption.Even)]
        [TestCase("Odd", EvenOrOddOption.Odd)]
        [TestCase("odd", EvenOrOddOption.Odd)]
        [TestCase("ODD", EvenOrOddOption.Odd)]
        public void BuildWithEvenOrOddOptionShouldReturnPlayerWithCorrectEvenOddOption(string evenOrOdd, EvenOrOddOption expectEnumOption)
        {
            var playerBuilder = new PlayerBuilder(randomNumber);

            var player = playerBuilder
                .WithEvenOrOddOption(evenOrOdd)
                .Build();

            Assert.That(player.EvenOrOdd, Is.EqualTo(expectEnumOption));
        }

        [Test]
        public void BuildWithEvenOrOddOptionShouldReturnPlayerWithCorrectEvenOddOption()
        {
            var playerBuilder = new PlayerBuilder(randomNumber);           

            Assert.That(() => playerBuilder.WithEvenOrOddOption("impar"), Throws.TypeOf<InvalidEvenOddOptionException>());
        }

    }
}
