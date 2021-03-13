using EwsTennis.Enums;
using EwsTennis.Exceptions;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class EvenOrOddUnitTests
    {
        private IEvenOrOdd evenOrOdd;

        [SetUp]
        public void Setup() => evenOrOdd = new EvenOrOddMock();

        [Test]
        public void DrawEvenOrOddShoudReturnCorrectWinnerPlayer()
        {
            //Arrange
            var player1 = new Player() {
                EvenOrOdd = EvenOrOddOption.Even
            };
            var player2 = new Player() {
                EvenOrOdd = EvenOrOddOption.Odd
            };

            //Act
            Player winner = evenOrOdd.Draw(player1, player2);

            //Assert
            Assert.That(winner.EvenOrOdd, Is.EqualTo(player2.EvenOrOdd));
        }

        [Test]
        public void DrawEvenOrOddShoudThrowInvalidEvenOddOptionExcepion()
        {
            //Arrange
            var player1 = new Player()
            {
                EvenOrOdd = EvenOrOddOption.Even
            };
            var player2 = new Player()
            {
                EvenOrOdd = EvenOrOddOption.Even
            };

            //Act & Assert
            Assert.That(() => evenOrOdd.Draw(player1, player2),
                Throws.Exception.TypeOf<InvalidEvenOddOptionException>());

        }
    }
}