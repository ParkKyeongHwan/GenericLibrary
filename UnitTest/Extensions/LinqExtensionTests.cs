using GenericLibrary.Structures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.Extensions
{
    [TestFixture]
    public class LinqExtensionTests
    {
        [Test]
        public void AddAll_ShouldAppendThisEnumerable_WhenArgumentIsEnumerable()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event("Test1"));
            events.Add(new Event("Test2"));
            events.Add(new Event("Test3"));

            List<Event> toBeCopied = new List<Event>();

            toBeCopied.AddAll(events);

            CollectionAssert.AreEqual(events, toBeCopied);
        }

        [Test]
        public void IndexOf_ShouldReturnIndexOfList_WhenLambdaConditionsAreTrue()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event("Test1"));
            events.Add(new Event("Test2"));
            events.Add(new Event("Test3"));

            Assert.AreEqual(0, events.IndexOf(r => r.Name is "Test1"));
            Assert.AreEqual(1, events.IndexOf(r => r.Name is "Test2"));
            Assert.AreEqual(2, events.IndexOf(r => r.Name is "Test3"));
        }
        
        [Test]
        public void Swap_ShouldSwap0And2_IfArgumentAre0And2()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event("Test1"));
            events.Add(new Event("Test2"));
            events.Add(new Event("Test3"));

            IReadOnlyCollection<Event> readOnlyEvents = events;

            events.Swap(0, 2);

            Assert.AreEqual("Test3", events[0].Name);
            Assert.AreEqual("Test1", events[2].Name);
        }
    }
}
