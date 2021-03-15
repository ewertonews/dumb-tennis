using System;

namespace EwsTennis.Contracts
{
    public interface IReferee
    {
        bool IsInTieBreak();
        bool GameEnded { get; }
        void OnPlayerScored(object source, EventArgs eventArgs);
        bool IsAdvantage();
        bool IsDeuce();
    }
}