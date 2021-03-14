using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwsTennis
{
    public class TennisInputData
    {
        private readonly IFileReader _fileReader;
        public TennisInputData(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string[] GetPlayerOneData()
        {
            throw new NotImplementedException();
        }
    }
}
