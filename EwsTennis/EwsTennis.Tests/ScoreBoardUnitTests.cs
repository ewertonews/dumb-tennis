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
    }
}
