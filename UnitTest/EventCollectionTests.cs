using GenericLibrary.Structures;
using NUnit.Framework;
using System;
using System.Diagnostics;
using UnitTest.TestHelper;

namespace UnitTest
{
    [TestFixture]
    public class EventCollectionTests
    {
        [Test]
        public void Count_CanCountEventCollection_IfHasEvent()
        {
            EventCollection events = new EventCollection();
            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Assert.NotZero(events.Count);
        }

        [Test]
        public void Add_ShouldBeDynamicallyAllocated_IfEventAreNotEnough()
        {
            EventCollection events = new EventCollection();

            Warn.If(events.Count > 0);

            var firstEvent = new Event("Test1", "Test1".GetHash());
            var secondEvent = new Event("Test2", "Test2".GetHash());
            events.Add(firstEvent);
            events.Add(secondEvent);

            Assert.AreEqual(firstEvent, events[0]);
            Assert.AreEqual(secondEvent, events[1]);

            Assert.NotZero(events.Count);
        }

        [Test]
        public void Clear_ShouldDeleteAllOfThem_WhenThisMethodIsCalled()
        {
            EventCollection events = new EventCollection();

            Warn.If(events.Count > 0);

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Warn.If(events.Count != 2);

            events.Clear();

            Assert.Zero(events.Count);

            int eventNumber = events.GetFieldValue<int>("eventNumber");
            Assert.AreEqual(0, eventNumber);
        }

        [Test]
        public void Add_ShouldBePossibleToAdd_WhenAfterClear()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Warn.If(events.Count < 0);

            events.Clear();

            events.Add(new Event("Test3", "Test3".GetHash()));

            Assert.NotZero(events.Count);
            Assert.AreEqual(events[0].Name, "Test3");

            int eventNumber = events.GetFieldValue<int>("eventNumber");
            Assert.AreEqual(1, eventNumber);
        }

        [Test]
        public void Contains_ShouldReturnTrue_IfHasEventOfArgument()
        {
            EventCollection events = new EventCollection();

            var toFind = new Event("Test1", "Test1".GetHash());

            events.Add(toFind);
            events.Add(new Event("Test2", "Test2".GetHash()));

            Assert.IsTrue(events.Contains(toFind));
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenThereIsNoEventToFind()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Assert.IsFalse(events.Contains(new Event("Test3", "Test3".GetHash())));
        }

        [Test]
        public void CopyTo_ShouldCopyArray_FromZeroToIndex_WhenIndexIsGiven()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Event[] toBeCopied = new Event[3];

            events.CopyTo(toBeCopied, 2);

            Assert.AreEqual(events[0], toBeCopied[0]);
            Assert.AreEqual(events[1], toBeCopied[1]);
            Assert.IsNull(toBeCopied[2].Name);
            Assert.IsNull(toBeCopied[2].Hash);
        }

        [Test]
        public void CopyTo_ShouldThrowArgumentException_IfIndexExceedsArraysOfEvents()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));

            Event[] toBeCopied = new Event[3];

            // Currently, there is only one event.
            // But it is trying to copy 2 index.
            Assert.Throws<ArgumentException>(() => events.CopyTo(toBeCopied, 2));
        }

        [Test]
        public void CopyTo_ShouldThrowArgumentException_IfToBeCopiedIsSmaller_ThenEventArray()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            Event[] toBeCopied = new Event[1];

            // Currently, there is only one event.
            // But it is trying to copy 2 index.
            ArgumentException ex = Assert.Throws<ArgumentException>(() => events.CopyTo(toBeCopied, 2));
            Assert.AreEqual("The destination array has fewer elements than the collection."
                , ex.Message);
        }

        [Test]
        public void Contains_ShouldReturnResult_In500mSec_WhenCollectionHasThousand()
        {
            EventCollection events = new EventCollection(0);

            var toFind = new Event("Test1", "Test1".GetHash());

            for (int index = 0; index < 1000; index++)
            {
                events.Add(new Event("Test2", "Test2".GetHash()));
            }
            events.Add(toFind);

            var timer = Stopwatch.StartNew();
            events.Contains(toFind);
            timer.Stop();

            // TimeSpan(0,0,0,0,30) = 0.05 second.
            // It actually takes about 0.3 seconds.
            TimeSpan tenTick = new TimeSpan(0, 0, 0, 0, 50);

            Assert.GreaterOrEqual(tenTick, timer.Elapsed);
        }

        [Test]
        public void Remove_ShouldReturnTrue_AndDeleteItemOfEventArray_WhenGivenEvent()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            events.Remove(new Event("Test1", "Test1".GetHash()));

            Assert.AreEqual("Test2", events[0].Name);
            Assert.AreEqual("Test2".GetHash(), events[0].Hash);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // dummy is not used.
                var dummy = events[1];
            });

            int eventNumber = events.GetFieldValue<int>("eventNumber");
            Assert.AreEqual(1, eventNumber);
        }

        [Test]
        public void Remove_ShouldReturnTrue_AndDeleteItemOfEventArray_WhenGivenHashAsString()
        {
            EventCollection events = new EventCollection();

            events.Add(new Event("Test1", "Test1".GetHash()));
            events.Add(new Event("Test2", "Test2".GetHash()));

            events.Remove("Test1".GetHash());

            Assert.AreEqual("Test2", events[0].Name);
            Assert.AreEqual("Test2".GetHash(), events[0].Hash);
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // dummy is not used.
                var dummy = events[1];
            });

            int eventNumber = events.GetFieldValue<int>("eventNumber");
            Assert.AreEqual(1, eventNumber);
        }
    }
}
