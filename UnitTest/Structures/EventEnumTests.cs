using GenericLibrary.Structures;
using NUnit.Framework;
using System;
using System.Reflection;
using UnitTest.TestHelper;

namespace UnitTest.Structures
{
    [TestFixture]
    public class EventEnumTests
    {
        [Test, Category(TestInfo.NEGATIVE)]
        public void Current_ShouldThrowException_WhenImmediatelyAfterConstruction()
        {
            EventEnum eventEnum = new EventEnum(new Event[2]
            {
                new Event("Test1"),
                new Event("Test2")
            });

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // dummy is not used.
                var dummy = eventEnum.Current;
            });
        }

        [Test, Category(TestInfo.POSITIVE)]
        public void MoveNext_ShouldReturnTrue_IfCurrentPositionIsLessThanArray()
        {
            EventEnum eventEnum = new EventEnum(new Event[2]
            {
                new Event("Test1"),
                new Event("Test2")
            });

            Assert.IsTrue(eventEnum.MoveNext());
        }

        [Test, Category(TestInfo.NEGATIVE)]
        public void MoveNext_ShouldReturnFalse_IfCurrentPositionIsGreatherThanArray()
        {
            EventEnum eventEnum = new EventEnum(new Event[1]
            {
                new Event("Test1")
            });

            eventEnum.MoveNext();
            
            // Act and Assertion
            Assert.IsFalse(eventEnum.MoveNext());
        }

        [Test, Category(TestInfo.POSITIVE)]
        public void Reset_ShouldBeInitializedPosition_WhenThisMethodIsCalled()
        {
            // initialized position is -1
            int position = -1;

            EventEnum eventEnum = new EventEnum(new Event[3]
            {
                new Event("Test1"),
                new Event("Test2"),
                new Event("Test3")
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
