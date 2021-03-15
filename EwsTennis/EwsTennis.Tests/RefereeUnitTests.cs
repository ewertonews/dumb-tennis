using EwsTennis.Contracts;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class RefereeUnitTests
    {
        private IRandomNumber randomNumber;
        private IPlayerBuilder playerBuilder;
        private IScoreBoard scoreBoard;
        private IReferee referee;

        [SetUp]
        public void SetUp()
        {
            randomNumber = new RandomNumber();
            playerBuilder = new PlayerBuilder(randomNumber);
        }

        [Test]
        public void IsInTieBreakShouldReturnTrueWhenPlayerOneTies()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 2;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerOneScore();

            Assert.That(referee.IsInTieBreak(), Is.True);
        }

        [Test]
        public void IsInTieBreakShouldReturnTrueWhenPlayerTwoTies()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();

            Assert.That(referee.IsInTieBreak(), Is.True);
        }

        [Test]
        public void IsInTieBreakShouldReturnFalseWhenOneOfPlayersScoreIsLessThan40()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            Assert.That(referee.IsInTieBreak(), Is.Not.True);
        }

        [Test]
        public void OnPlayerScoredShouldChangeScoreListOfScoreBoardAndZeroPlayrsScore()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();

            Assert.That(scoreBoard.Player1.Score, Is.EqualTo(0));
            Assert.That(scoreBoard.Player2.Score, Is.EqualTo(0));
        }

        [Test]
        public void OnPlayerScoredShouldSetGameEndedToTrueWhenPlayer1Wins()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 4;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerOneScore();

            Assert.That(referee.GameEnded);
        }

        [Test]
        public void OnPlayerScoredShouldSetGameEndedToTrueWhenPlayer2Wins()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 4;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();

            Assert.That(referee.GameEnded);
        }

        [Test]
        public void OnPlayerScoredShouldChangeTheScoreListWhenStartingTieBreakByPlayer1()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 2;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerOneScore();

            Assert.That(scoreBoard.ScoreList[1], Is.EqualTo(1));
            Assert.That(scoreBoard.ScoreList.Count, Is.EqualTo(100));
        }

        [Test]
        public void OnPlayerScoredShouldChangeTheScoreListWhenStartingTieBreakByPlayer2()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();

            Assert.That(scoreBoard.ScoreList[1], Is.EqualTo(1));
            Assert.That(scoreBoard.ScoreList.Count, Is.EqualTo(100));
        }

        [Test]
        public void IsAdvantageShoulfReturnTrueWhenPlayer1UntiesDuringTieBreak()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 2;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerOneScore();
            scoreBoard.SetPlayerOneScore();

            Assert.That(referee.IsAdvantage(), Is.True);
        }

        [Test]
        public void IsAdvantageShoulfReturnTrueWhenPlayer2UntiesDuringTieBreak()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();
            scoreBoard.SetPlayerTwoScore();
            

            Assert.That(referee.IsAdvantage(), Is.True);
        }

        [Test]
        public void IsAdvantageShoulfReturnFalseWhenTieingDuringTieBreak()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();
            scoreBoard.SetPlayerTwoScore();
            scoreBoard.SetPlayerOneScore();

            Assert.That(referee.IsAdvantage(), Is.False);
        }

        [Test]
        public void IsDeuceShouldReturnTrueWhenPlayer1TiesDuringTieBreak()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();
            scoreBoard.SetPlayerOneScore();
            scoreBoard.SetPlayerTwoScore();

            Assert.That(referee.IsDeuce(), Is.True);

        }

    }
}
