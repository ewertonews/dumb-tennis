using EwsTennis.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void BuildWithLevelShouldReturnPlayerWithGivenLevel()
        {
            var playerLevel = PlayerLevel.Beginner;
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder
                .WithLevel(playerLevel)
                .Build();

            Assert.That(player.Level, Is.EqualTo(playerLevel));
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
