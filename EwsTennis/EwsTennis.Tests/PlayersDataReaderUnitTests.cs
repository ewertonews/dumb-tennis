using EwsTennis.Contracts;
using Moq;
using NUnit.Framework;

namespace EwsTennis.Tests
{
    public class PlayersDataReaderUnitTests
    {
        private PlayersDataReader _tennisInputFileReader;
        private Mock<IFileReader> _fileReaderMock;
        private string[] _fakeFileLines;

        [SetUp]
        public void Setup()
        {
            _fileReaderMock = new Mock<IFileReader>();
            _tennisInputFileReader = new PlayersDataReader(_fileReaderMock.Object);
            _fakeFileLines
                = new string[] { "Tonho", "Experienced", "Even", "25", "Zé", "Experienced", "Odd", "21" };
        }

        [Test]
        public void GetPlayerOneDataShouldReturnArrayOfStringWithLenghEquals4()
        {
            _fileReaderMock.Setup(fr => fr.GetFileLines("fakePath")).Returns(_fakeFileLines);
            var expectedPlayerData = new string[] { "Tonho", "Experienced", "Even", "25" };

            string[] playerOneData = _tennisInputFileReader.GetPlayerOneData("fakePath");

            Assert.That(playerOneData.Length, Is.EqualTo(4));
            Assert.That(playerOneData, Is.EqualTo(expectedPlayerData));
        }

        [Test]
        public void GetPlayerTwoDataShouldReturnArrayOfStringWithLenghEquals4()
        {
            _fileReaderMock.Setup(fr => fr.GetFileLines("fakePath")).Returns(_fakeFileLines);
            var expectedPlayerData = new string[] { "Zé", "Experienced", "Odd", "21" };

            string[] playerTwoData = _tennisInputFileReader.GetPlayerTwoData("fakePath");

            Assert.That(playerTwoData.Length, Is.EqualTo(4));
            Assert.That(playerTwoData, Is.EquivalentTo(expectedPlayerData));
        }
    }
}
