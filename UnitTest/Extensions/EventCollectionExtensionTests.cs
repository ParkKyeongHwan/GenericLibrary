using GenericLibrary.Extensions;
using GenericLibrary.Structures;
using NUnit.Framework;
using System;
using System.IO;
using UnitTest.TestHelper;

namespace UnitTest.Extensions
{
    [TestFixture]
    public class EventCollectionExtensionTests
    {
        [Test, Category(TestInfo.POSITIVE)]
        public void ExportCSVTo_ShouldCreateCSVFileToPath_IfEventsHas()
        {
            EventCollection events = new EventCollection();
            events.Add(new Event("Test1"));
            events.Add(new Event("Test2"));

            string fullPath = GetTestPath();

            File.Delete(fullPath);

            events.ExportCSVTo(fullPath);

            string[] lines = File.ReadAllLines(fullPath);

            Assert.IsTrue(lines.Length is 2);

            string expectedLine1 = string.Concat(events[0].Name, ",", events[0].Hash);
            string expectedLine2 = string.Concat(events[1].Name, ",", events[1].Hash);

            Assert.AreEqual(expectedLine1, lines[0]);
            Assert.AreEqual(expectedLine2, lines[1]);

            File.Delete(fullPath);
        }

        [Test, Category(TestInfo.POSITIVE)]
        public void ExportCSVTo_ShouldThrowArgumentOutOfRangeException_IfThereIsNoData()
        {
            EventCollection events = new EventCollection();

            string fullPath = GetTestPath();

            File.Delete(fullPath);

            Assert.Throws<ArgumentOutOfRangeException>(() => events.ExportCSVTo(fullPath));

            Assert.IsFalse(File.Exists(fullPath));
        }

        private string GetTestPath()
        {
            string path = Path.GetTempPath();
            string fileName = "test";
            string fileType = ".csv";

            return string.Concat(path, fileName, fileType);
        }
    }
}
