using GenericLibrary.Helper;

namespace GenericLibrary.Structures
{
    public struct Event
    {
        public string Name { get; private set; }
        public string Hash { get; private set; }

        public Event(string name)
        {
            Name = name;
            Hash = name.GetHash();
        }
    }
}
