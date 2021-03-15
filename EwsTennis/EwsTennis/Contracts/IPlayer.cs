using EwsTennis.Enums;

namespace EwsTennis.Contracts
{
    public interface IPlayer
    {
        EvenOrOddOption EvenOrOdd { get; set; }
        PlayerLevel Level { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        int ReachOfLeftHand { get; }
        int ReachOfRightHand { get; }
        int Score { get; set; }

        int Serve();
        void SetReachOfHands();
    }
}