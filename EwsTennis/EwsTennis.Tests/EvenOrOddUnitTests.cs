using EwsTennis.Contracts;
using EwsTennis.Enums;
using EwsTennis.Exceptions;
using Moq;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class EvenOrOddUnitTests
    {
        private Mock<IRandomNumber> mockRandomNumber;
        private IEvenOrOdd evenOrOdd;

        [SetUp]
        public void Setup() {
            mockRandomNumber = new Mock<IRandomNumber>();
            evenOrOdd = new EvenOrOdd(mockRandomNumber.Object);
        }

        [Test]
        public void DrawEvenOrOddShoudReturnCorrectWinnerPlayerForEven()
        {
            //Arrange
            var player1 = new Player() {
                EvenOrOdd = EvenOrOddOption.Even
            };
            var player2 = new Player() {
                EvenOrOdd = EvenOrOddOption.Odd
            };
            mockRandomNumber.Setup(mrn => mrn.Get(1, 10)).Returns(4);

            //Act
            Player winner = evenOrOdd.Draw(player1, player2);

            //Assert
            Assert.That(winner.EvenOrOdd, Is.EqualTo(player1.EvenOrOdd));
        }

        [Test]
        public void DrawEvenOrOddShoudReturnCorrectWinnerPlayerForOdd()
        {
            //Arrange
            var player1 = new Player()
            {
                EvenOrOdd = EvenOrOddOption.Even
            };
            var player2 = new Player()
            {
                EvenOrOdd = EvenOrOddOption.Odd
            };
            mockRandomNumber.Setup(mrn => mrn.Get(1, 10)).Returns(5);

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