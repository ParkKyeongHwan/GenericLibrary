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

        /// <summary>
        /// 객체 내부 데이터 일괄적 리턴 허용, C# 7.0 예약메서드
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        public void Deconstruct(out string name, out string hash)
        {
            name = Name;
            hash = Hash;
        }
    }
}