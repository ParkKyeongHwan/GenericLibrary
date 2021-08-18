namespace GenericLibrary.Structures
{
    public struct Event
    {
        public string Name { get; private set; }
        public string Hash { get; private set; }

        public Event(string name, string hash)
        {
            Name = name;
            Hash = hash;
        }
    }
}
