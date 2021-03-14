using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class ScoreBoardUnitTests
    {
        [Test]
        public void GetPlayerOneScoreShouldReturnCorrectTennisScore()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.PlayerOneScore = 1;

            var result = scoreBoard.GetPlayerOneScore();

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void GetPlayerTwoScoreShouldReturnCorrectTennisScore()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.PlayerTwoScore = 2;

            var result = scoreBoard.GetPlayerTwoScore();

            Assert.That(result, Is.EqualTo(30));
        }
    }
}
