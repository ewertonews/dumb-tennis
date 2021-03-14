using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class RandomNumberUnitTests
    {
        [Test]
        public void GetShouldReturnRandomNumberInTheGivenRange()
        {
            var randomNumber = new RandomNumber();

            var result = randomNumber.Get(1, 2);

            Assert.That((result == 1 || result == 2), Is.True);
        }
    }
}
