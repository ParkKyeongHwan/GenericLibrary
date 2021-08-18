using System.Collections;

namespace GenericLibrary.Structures
{
    public class EventEnum : IEnumerator
    {
        private Event[] _events;
        private int position = -1;
        public EventEnum(Event[] events)
        {
            _events = events;
        }
        public object Current => _events[position];

        public bool MoveNext()
        {
            position++;
            return (position < _events.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
