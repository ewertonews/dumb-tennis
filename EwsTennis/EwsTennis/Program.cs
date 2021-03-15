using EwsTennis.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace EwsTennis
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = SetupServices();
            var gameController = services.GetService<IGameController>();
            gameController.InitializePlayers(args);
            gameController.Play();
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
                .AddSingleton<IGameInput, GameInput>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
