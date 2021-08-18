using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericLibrary.Structures
{
    public class EventCollection : ICollection<Event>
    {
        private Event[] events;
        private int eventNumber = 0;

        public int Count => events.Length;

        public bool IsReadOnly => false;

        /// <summary>
        /// Collection Basic Constructor
        /// </summary>
        /// <param name="capacity">capacity for performance</param>
        public EventCollection(int capacity = 0)
        {
            Array.Resize(ref events, capacity);
        }

        public Event this[int index]
        {
            get
            {
                return events[index];
            }
            set
            {
                events[index] = value;
            }
        }

        public void Add(Event item)
        {
            if (eventNumber >= events.Length)
            {
                Array.Resize(ref events, eventNumber + 1);
            }

            events[eventNumber++] = item;
        }

        public void Clear()
        {
            Array.Clear(events, 0, 0);
            Array.Resize(ref events, 0);
            eventNumber = 0;
        }

        public bool Contains(Event item)
        {
            if (events.AsParallel().Any(s => s.Name == item.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTo(Event[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            Array.Copy(events, array, arrayIndex);
        }

        public bool Remove(Event item)
        {
            events = events.Where(r => !r.Equals(item)).ToArray();
            return true;
        }

        public bool Remove(string hasHash)
        {
            events = events.Where(r => !r.Hash.Equals(hasHash)).ToArray();
            return true;
        }

        public IEnumerator<Event> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EventEnum(events);
        }
    }
}
