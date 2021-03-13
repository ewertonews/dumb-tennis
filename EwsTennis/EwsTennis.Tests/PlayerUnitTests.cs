﻿using EwsTennis.Enums;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class PlayerUnitTests
    {
        [Test]
        public void ServeShouldReturnNumerFromOneToTwentySeven()
        {
            var player = new Player();

            var result = player.Serve();

            Assert.That(result, Is.GreaterThanOrEqualTo(1));
            Assert.That(result, Is.LessThanOrEqualTo(27));
        }

        [Test]
        public void SetReachOfHandShouldReturnSevenNineOrElevenBasedOnLevel()
        {
            var player = new Player()
            {
                Level = PlayerLevel.Experienced,
                Position = 10
            };

            player.SetReachOfHands();

            Assert.That(player.ReachOfLeftHand, Is.EqualTo(6));
            Assert.That(player.ReachOfRightHand, Is.EqualTo(14));
        }
    }
}