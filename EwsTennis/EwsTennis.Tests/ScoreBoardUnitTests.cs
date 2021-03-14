using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class ScoreBoardUnitTests
    {
        private readonly PlayerBuilder playerBuilder = new PlayerBuilder();

        [Test]
        public void GetPlayerOneScoreShouldReturnCorrectTennisScore()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 1;
            var player2 = playerBuilder.Build();
            var scoreBoard = new ScoreBoard(player1, player2);
            scoreBoard.PlayerOneScore = 1;

            var result = scoreBoard.GetPlayerOneScore();

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void GetPlayerTwoScoreShouldReturnCorrectTennisScore()
        {
            var player1 = playerBuilder.Build();
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            var scoreBoard = new ScoreBoard(player1, player2);

            var result = scoreBoard.GetPlayerTwoScore();

            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void IsTieShouldReturnTrueWhenPlayersScoreAreTheSame()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 1;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            var scoreBoard = new ScoreBoard(player1, player2);

            Assert.That(Is.True, scoreBoard.IsTie());
        }
    }
}
