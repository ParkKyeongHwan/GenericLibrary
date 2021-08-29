using GenericLibrary;
using GenericLibrary.Structures;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class StringParserTests
    {
        [Test]
        public void IsEvent_ShouldReturnTrue_WhenArgumentIsEventsString()
        {

            bool v = StringParser.IsEvent(typeof(Event).Name);
        }

        [Test]
        public void IsEvent_ShouldReturnFalse_WhenArgumentIsStringEmpty()
        {
            Assert.IsFalse(StringParser.IsEvent(string.Empty));
        }

        [Test]
        public void Count_ShouldReturnNumberTwo_IfHasArrayTwo()
        {
            EventCollection2 eventCollection = new EventCollection2();
            eventCollection.Add(new Event("Test"));
            eventCollection.Add(new Event("Test"));

            Assert.AreEqual(2, eventCollection.Count);
        }
    }
}
