using Moq;
using NUnit.Framework;
using System;

namespace EwsTennis.Tests
{
    public class Tests
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
            Assert.That(winner, Is.EqualTo(player2));
        }
    }
}