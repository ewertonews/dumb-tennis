using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
