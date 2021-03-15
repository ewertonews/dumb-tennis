using EwsTennis.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace EwsTennis
{
    public class GameController : IGameController
    {
        private readonly IPlayerBuilder _playerBuilder;
        private readonly IPlayersDataReader _playersDataReader;
        private readonly IEvenOrOdd _evenOrOdd;
        private readonly IScoreBoard _scoreBoard;
        private readonly IReferee _referee;
        private readonly IGameInput _gameInput;

        private bool FirstServe = true;
        private bool PrintedTieBreakMessage { get; set; } = false;

        public List<Player> Players { get; } = new List<Player>();
        public Player Player1 => Players[0];
        public Player Player2 => Players[1];

        public GameController(
            IPlayerBuilder playerBuilder,
            IPlayersDataReader playersDataReader,
            IEvenOrOdd evenOrOdd,
            IScoreBoard scoreBoard,
            IReferee referee,
            IGameInput gameInput)
        {
            _playerBuilder = playerBuilder;
            _playersDataReader = playersDataReader;
            _evenOrOdd = evenOrOdd;
            _scoreBoard = scoreBoard;
            _referee = referee;
            scoreBoard.PlayerScored += referee.OnPlayerScored;
            _gameInput = gameInput;
        }

        public void InitializePlayers(string[] programArgs)
        {
            if (programArgs.Length == 0)
            {
                throw new ArgumentException("Argument with file path cannot be null or empty");
            }

            var filePath = programArgs[0];
            var player1Data = _playersDataReader.GetPlayerOneData(filePath);
            var player2Data = _playersDataReader.GetPlayerTwoData(filePath);

            var player1 = _playerBuilder
                .WithName(player1Data[0])
                .WithLevel(player1Data[1])
                .WithEvenOrOddOption(player1Data[2])
                .AtPosition(Convert.ToInt16(player1Data[3]))
                .Build();

            var player2 = _playerBuilder
                .WithName(player2Data[0])
                .WithLevel(player2Data[1])
                .WithEvenOrOddOption(player2Data[2])
                .AtPosition(Convert.ToInt16(player2Data[3]))
                .Build();

            _scoreBoard.Player1 = player1;
            _scoreBoard.Player2 = player2;

            Players.Add(player1);
            Players.Add(player2);
        }

        public void Play()
        {
            int indexOfAtackingPlayer = -1;
            int indexOfDefendingPlayer = -1;
            string playerAction = string.Empty;
            Player atackingPlayer;
            if (FirstServe)
            {
                ConfigureFirstRound(
                    out indexOfAtackingPlayer,
                    out indexOfDefendingPlayer,
                    out playerAction);
            }

            while (!_referee.GameEnded)
            {
                Player defendingPlayer;
                int atackingPlayerServe;

                SetAtackAndDefense(
                    indexOfAtackingPlayer,
                    indexOfDefendingPlayer,
                    playerAction,
                    out atackingPlayer,
                    out defendingPlayer,
                    out atackingPlayerServe);

                if (IsSuccessfulDefense(defendingPlayer, atackingPlayerServe))
                {
                    playerAction = "hit back!";
                    WriteLine($"{defendingPlayer.Name} {playerAction}!");
                    SwapIndexesOfPlayers(ref indexOfAtackingPlayer, ref indexOfDefendingPlayer);
                }
                else
                {
                    WriteLine($"The ball went to position {atackingPlayerServe} at the court!");
                    SetPlayerScore(atackingPlayer);
                    PrintScore(atackingPlayer);
                    playerAction = "served";
                }
            }
        }

        private void SetAtackAndDefense(int indexOfAtackingPlayer, int indexOfDefendingPlayer, string playerAction, out Player atackingPlayer, out Player defendingPlayer, out int atackingPlayerServe)
        {
            atackingPlayer = Players[indexOfAtackingPlayer];
            defendingPlayer = Players[indexOfDefendingPlayer];
            atackingPlayerServe = atackingPlayer.Serve();
            WriteLine($"{atackingPlayer.Name} sent ball to position {atackingPlayerServe}");
            if (playerAction == "served")
            {
                WriteLine($"{Players[indexOfAtackingPlayer].Name} {playerAction}!");
            }

            WriteLine($"Type the position {defendingPlayer.Name} should run to (1 to 27):");
            var positionOfDefenfingPlayer = _gameInput.ReadPosition();
            defendingPlayer.Position = positionOfDefenfingPlayer;
        }

        private void ConfigureFirstRound(out int indexOfAtackingPlayer, out int indexOfDefendingPlayer, out string playerAction)
        {
            indexOfAtackingPlayer = StartGameAndReturnIndexOfAtackinPlayer();
            var atackingPlayer = Players[indexOfAtackingPlayer];

            DefineStarterIndexOfPlayers(
                atackingPlayer,
                out indexOfAtackingPlayer,
                out indexOfDefendingPlayer);

            playerAction = "served";
            FirstServe = false;
        }

        private void SetPlayerScore(Player atackingPlayer)
        {
            if (atackingPlayer.Equals(Player1))
            {
                _scoreBoard.SetPlayerOneScore();
            }
            else
            {
                _scoreBoard.SetPlayerTwoScore();
            }
        }

        private void PrintScore(Player atackingPlayer)
        {
            WriteLine($"{atackingPlayer.Name} scored!");
            WriteLine(@"\o/\o/\o/\o/\o/\o/");
            if (_referee.GameEnded)
            {
                WriteLine($"================ {atackingPlayer.Name.ToUpper()} IS THE WINNER!! ================");
            }
            else
            {
                WriteLine("~~~~~~~~~~~~~~~~~~~~ ");
                WriteLine(_scoreBoard.ToString());
                WriteLine("~~~~~~~~~~~~~~~~~~~~ ");
                PrintGameStatus(atackingPlayer);
            }
        }

        private void PrintGameStatus(Player atackingPlayer)
        {
            if (_referee.IsInTieBreak() && !PrintedTieBreakMessage)
            {
                WriteLine("TIE BREAK STARTED!");
                WriteLine("~~~~~~~~~~~~~~~~~~~~ ");
                PrintedTieBreakMessage = true;
            }
            if (_referee.IsAdvantage())
            {
                WriteLine($"{atackingPlayer.Name} IN ADVANTAGE!");
            }
            if (_referee.IsDeuce())
            {
                WriteLine("~~~ DEUCE! ~~~");
            }
        }

        private void DefineStarterIndexOfPlayers(Player atackingPlayer, out int indexOfAtackingPlayer, out int indexOfDefendingPlayer)
        {
            if (atackingPlayer.Equals(Player1))
            {
                indexOfAtackingPlayer = 0;
                indexOfDefendingPlayer = 1;
            }
            else
            {
                indexOfAtackingPlayer = 1;
                indexOfDefendingPlayer = 0;
            }
        }

        private void SwapIndexesOfPlayers(ref int indexOfAtackingPlayer, ref int indexOfDefendingPlayer)
        {
            int tempIndex = indexOfAtackingPlayer;
            indexOfAtackingPlayer = indexOfDefendingPlayer;
            indexOfDefendingPlayer = tempIndex;
        }

        private bool IsSuccessfulDefense(Player defendingPlayer, int starterPlayerServe)
        {
            return starterPlayerServe >= defendingPlayer.ReachOfLeftHand
                && starterPlayerServe <= defendingPlayer.ReachOfRightHand;
        }

        private int StartGameAndReturnIndexOfAtackinPlayer()
        {
            WriteLine("Let's start the Tennis Match!");
            WriteLine("==============================================================");
            Player evenOrOddWinnerPlayer = DrawEvenOrOdd();
            WriteLine($"{evenOrOddWinnerPlayer.Name} will start the game!");
            WriteLine("Players are now moving to their starting position...");
            Thread.Sleep(1500);
            return Players.IndexOf(evenOrOddWinnerPlayer);
        }

        private Player DrawEvenOrOdd()
        {
            WriteLine($"{Player1.Name} is {Player1.EvenOrOdd}");
            WriteLine($"{Player2.Name} is {Player2.EvenOrOdd}");
            WriteLine("Drawing Even or Odd...");
            Thread.Sleep(2000);
            var evenOrOddWinnerPlayer = _evenOrOdd.Draw(Player1, Player2);
            return evenOrOddWinnerPlayer;
        }
    }
}
