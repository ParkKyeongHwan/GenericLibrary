using GenericLibrary.Structures;
using NUnit.Framework;
using System;
using System.Reflection;
using UnitTest.TestHelper;

namespace UnitTest
{
    [TestFixture]
    public class EventEnumTests
    {
        [Test]
        public void Current_ShouldThrowException_WhenImmediatelyAfterConstruction()
        {
            EventEnum eventEnum = new EventEnum(new Event[2]
            {
                new Event("Test1", "Test1".GetHash()),
                new Event("Test2", "Test2".GetHash())
            });

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // dummy is not used.
                var dummy = eventEnum.Current;
            });
        }

        [Test]
        public void MoveNext_ShouldReturnTrue_IfCurrentPositionIsLessThanArray()
        {
            EventEnum eventEnum = new EventEnum(new Event[2]
            {
                new Event("Test1", "Test1".GetHash()),
                new Event("Test2", "Test2".GetHash())
            });

            Assert.IsTrue(eventEnum.MoveNext());
        }

        [Test]
        public void MoveNext_ShouldReturnFalse_IfCurrentPositionIsGreatherThanArray()
        {
            EventEnum eventEnum = new EventEnum(new Event[1]
            {
                new Event("Test1", "Test1".GetHash())
            });

            eventEnum.MoveNext();
            
            // Act and Assertion
            Assert.IsFalse(eventEnum.MoveNext());
        }

        [Test]
        public void Reset_ShouldBeInitializedPosition_WhenThisMethodIsCalled()
        {
            // initialized position is -1
            int position = -1;

            EventEnum eventEnum = new EventEnum(new Event[3]
            {
                new Event("Test1", "Test1".GetHash()),
                new Event("Test2", "Test2".GetHash()),
                new Event("Test3", "Test3".GetHash())
            });

            // change position to 0.
            eventEnum.MoveNext();

            position = eventEnum.GetFieldValue<int>("position");

            Warn.If(position == -1);

            // Act.
            eventEnum.Reset();

            position = eventEnum.GetFieldValue<int>("position");

            Assert.AreEqual(-1, position);
        }
    }
}
