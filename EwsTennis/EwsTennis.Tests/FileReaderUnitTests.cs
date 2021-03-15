using EwsTennis.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwsTennis.Tests
{
    public class FileReaderUnitTests
    {
        [Test]
        public void GetFileLinesShouldReturnLinesOfCorrectFile()
        {
            var fileReader = new FileReader();

            var lines = fileReader.GetFileLines("TestFiles/PlayersTestFileOk.txt");

            Assert.That(lines, Is.Not.Empty);
            Assert.That(lines.Count, Is.EqualTo(8));
        }

        [Test]
        [TestCase("TestFiles/PlayersTestFileIncomplete.txt")]
        [TestCase("TestFiles/PlayersTestFileEmpty.txt")]
        public void GetFileLinesShouldThrowInvalidFileExceptionForInvalidFileInput(string filePath)
        {
            var fileReader = new FileReader();

            Assert.That(() => fileReader.GetFileLines(filePath), Throws.TypeOf<InvalidFileException>());
        }
    }
}
