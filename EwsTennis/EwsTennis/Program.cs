using EwsTennis.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EwsTennis
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var services = SetupServices();
                var gameController = services.GetService<IGameController>();
                gameController.InitializePlayers(args);
                gameController.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static ServiceProvider SetupServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPlayer, Player>()
                .AddSingleton<IFileReader, FileReader>()
                .AddSingleton<IPlayersDataReader, PlayersDataReader>()
                .AddSingleton<IRandomNumber, RandomNumber>()
                .AddSingleton<IEvenOrOdd, EvenOrOdd>()
                .AddSingleton<IPlayerBuilder, PlayerBuilder>()
                .AddSingleton<IReferee, Referee>()
                .AddSingleton<IScoreBoard, ScoreBoard>()
                .AddSingleton<IGameController, GameController>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
