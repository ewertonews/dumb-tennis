using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwsTennis.Tests
{
    public class TennisInputFileReaderUnitTests
    {
        private TennisInputFileReader _tennisInputFileReader;

        [SetUp]
        public void Setup()
        {
            _tennisInputFileReader = new TennisInputFileReader();
        }

        [Test]
        public void GetPlayerOneDataShouldReturnArrayOfStringWithLenghEquals4()
        {
            string[] playerOneData = _tennisInputFileReader.GetPlayerOneData();

            Assert.That(playerOneData.Length, Is.EqualTo(4));
        }
    }
}
