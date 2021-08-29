using GenericLibrary.Structures;
using System;
using System.Collections;

namespace GenericLibrary
{
    public class StringParser
    {
        public static bool IsEvent(string @event)
        {
            if (@event is nameof(@event))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class EventCollection2 : ICollection
    {
        private Array array = Array.CreateInstance(typeof(Event), 5);
        public int CurrentIndex = 0;

        public int Count => CurrentIndex;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void Add(Event @event)
        {
            array.SetValue(@event, CurrentIndex++);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
