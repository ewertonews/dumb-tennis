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
        public void BuildWithNameShouldReturnUserWithGivenName()
        {
            var playerName = "Raphael";
            var playerBuilder = new PlayerBuilder();

            var player = playerBuilder
                .WithName(playerName)
                .Build();

            Assert.That(player.Name, Is.EqualTo(playerName));
        }

    }
}
