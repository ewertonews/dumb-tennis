﻿using EwsTennis.Contracts;
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
        public void IsInTieBreakShouldReturnTrueWhenPlayersScoreAreBoth40()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            Assert.That(referee.IsInTieBreak(), Is.True);
        }

        [Test]
        public void IsInTieBreakShouldReturnTrueWhenPlayerOneScoredMoreThan3Points()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 4;
            var scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            Assert.That(referee.IsInTieBreak(), Is.True);
        }

        [Test]
        public void IsInTieBreakShouldReturnTrueWhenPlayerTwoScoredMoreThan3Points()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 4;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            var scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            Assert.That(referee.IsInTieBreak(), Is.True);
        }

        [Test]
        public void IsInTieBreakShouldReturnFalseWhenOneOfPlayersScoreIsLessThan40()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 3;
            var player2 = playerBuilder.Build();
            player2.Score = 2;
            var scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            Assert.That(referee.IsInTieBreak(), Is.Not.True);
        }

        [Test]
        public void OnPlayerScoredShouldChangeScoreListOfScoreBoardAndZeroPlayrsScore()
        {
            var player1 = playerBuilder.Build();
            player1.Score = 4;
            var player2 = playerBuilder.Build();
            player2.Score = 3;
            var scoreBoard = new ScoreBoard(player1, player2);
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
            var scoreBoard = new ScoreBoard(player1, player2);
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
            var scoreBoard = new ScoreBoard(player1, player2);
            referee = new Referee(scoreBoard);

            scoreBoard.PlayerScored += referee.OnPlayerScored;
            scoreBoard.SetPlayerTwoScore();

            Assert.That(referee.GameEnded);
        }
    }
}
