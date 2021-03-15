using EwsTennis.Contracts;
using System;

namespace EwsTennis
{
    public class GameInput : IGameInput
    {
        public int ReadPosition()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
