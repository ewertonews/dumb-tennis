using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwsTennis.Exceptions
{

    [Serializable]
    public class InvalidLevelException : Exception
    {
        public InvalidLevelException(string message) : base(message) { }       
    }
}
