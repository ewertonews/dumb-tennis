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
            var fileReader = new FileReader("TestFiles/PlayersTestFileOk.txt");

            var lines = fileReader.GetFileLines();

            Assert.That(lines, Is.Not.Empty);
            Assert.That(lines.Count, Is.EqualTo(8));
        }

        [Test]
        [TestCase("TestFiles/PlayersTestFileIncomplete.txt")]
        [TestCase("TestFiles/PlayersTestFileEmpty.txt")]
        public void GetFileLinesShouldThrowInvalidFileExceptionForInvalidFileInput(string filePath)
        {
            var fileReader = new FileReader(filePath);

            Assert.That(() => fileReader.GetFileLines(), Throws.TypeOf<InvalidFileException>());
        }
    }
}
