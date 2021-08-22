using GenericLibrary.Structures;
using NUnit.Framework;

namespace UnitTest.Structures
{
    [TestFixture]
    public class EventTests
    {
        [Test(Description ="Deconstruct is a reserved language method used by c# 7.0 ")]
        public void Desconstruct_ShoudReturnThisAsTuple_ThisMethodIsCalled()
        {
            Event @event = new Event("Test");
            
            // Act Deconstruct method.
            var (eventName, hash) = @event;

            Assert.AreEqual("Test", eventName);
            Assert.NotNull(hash);
            Assert.NotZero(hash.Length);
        }
    }
}