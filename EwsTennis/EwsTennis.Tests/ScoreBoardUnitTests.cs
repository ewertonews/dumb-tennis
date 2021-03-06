using EwsTennis.Contracts;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class ScoreBoardUnitTests
    {
        private IPlayerBuilder playerBuilder;
        private IRandomNumber randomNumber;

        [SetUp]
        public void Setup()
        {
            randomNumber = new RandomNumber();
            playerBuilder = new PlayerBuilder(randomNumber);
        }

        [Test]
        public void GetPlayerOneScoreShouldReturnCorrectTennisScore()
        {            
            var player1 = playerBuilder.Build();
            player1.Score = 1;
            var player2 = playerBuilder.Build();
            var scoreBoard = new ScoreBoard(player1, player2);

            var result = scoreBoard.GetPlayerOneScore();

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void GetPlayerOneScoreShouldReturnNormalIntegerScore()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 4;
            var player2 = playerBuilder.Build();
            var scoreBoard = new ScoreBoard(player1, player2);

            var result = scoreBoard.GetPlayerOneScore();

            Assert.That(result, Is.EqualTo(4));
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
        public void GetPlayerTwoScoreShouldReturnNormalIntegerScore()
        {
            var player1 = playerBuilder.Build();            
            var player2 = playerBuilder.Build();
            player2.Score = 4;
            var scoreBoard = new ScoreBoard(player1, player2);

            var result = scoreBoard.GetPlayerTwoScore();

            Assert.That(result, Is.EqualTo(4));
        }        

        [Test]
        public void SetPlayer1ScoreShouldIncreadScoreOfPlayerByOne()
        {
            var player1 = playerBuilder
               .WithName("Ewerton")
               .Build();
            var player2 = playerBuilder
               .WithName("Guga")
               .Build();
            var scoreBoard = new ScoreBoard(player1, player2);

            scoreBoard.SetPlayerOneScore();

            Assert.That(player1.Score, Is.EqualTo(1));
            Assert.That(player2.Score, Is.EqualTo(0));

        }

        [Test]
        public void SetPlayer2ScoreShouldIncreadScoreOfPlayerByOne()
        {
            var player1 = playerBuilder
               .WithName("Ewerton")
               .Build();
            var player2 = playerBuilder
               .WithName("Guga")
               .Build();
            var scoreBoard = new ScoreBoard(player1, player2);

            scoreBoard.SetPlayerTwoScore();

            Assert.That(player2.Score, Is.EqualTo(1));
            Assert.That(player1.Score, Is.EqualTo(0));
        }


        [Test]
        public void ToStringShouldReturnScoreBoardInTVFormaForPlayer1Winning()
        {
            var player1 = playerBuilder
                .WithName("Ewerton")
                .Build();
            player1.Score = 3;
            var player2 = playerBuilder
                .WithName("Guga")
                .Build();
            player2.Score = 2;
            var scoreBoard = new ScoreBoard(player1, player2);
            string expectedScoreBoardString = "Ewerton 40 x 30 Guga";

            string scoreBoardString = scoreBoard.ToString();

            Assert.That(scoreBoardString, Is.EqualTo(expectedScoreBoardString));
        }

        [Test]
        public void ToStringShouldReturnScoreBoardInTVFormaForPlayer2Winning()
        {
            var player1 = playerBuilder
                .WithName("Ewerton")
                .Build();
            player1.Score = 2;
            var player2 = playerBuilder
                .WithName("Guga")
                .Build();
            player2.Score = 3;
            var scoreBoard = new ScoreBoard(player1, player2);
            string expectedScoreBoardString = "Guga 40 x 30 Ewerton";

            string scoreBoardString = scoreBoard.ToString();

            Assert.That(scoreBoardString, Is.EqualTo(expectedScoreBoardString));
        }

    }
}
