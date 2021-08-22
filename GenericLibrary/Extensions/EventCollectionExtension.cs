using GenericLibrary.Structures;
using System;
using System.IO;
using System.Text;

namespace GenericLibrary.Extensions
{
    public static class EventCollectionExtension
    {
        public static void ExportCSVTo(this EventCollection collection, string fullPath)
        {
            CanMake(collection);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Event @event in collection)
            {
                stringBuilder.Append(ConvertCSV(@event));
                stringBuilder.Append(Environment.NewLine);
            }

            File.WriteAllText(fullPath, stringBuilder.ToString());
        }

        private static void CanMake(EventCollection events)
        {
            if (events.Count is 0)
            {
                throw new ArgumentOutOfRangeException(nameof(events), "No Has Data");
            }
        }

        private static string ConvertCSV(Event @event)
        {
            (string eventName, string hash) = @event;
            string newLine = $"{eventName},{hash}";
            return newLine;
        }
        
    }
}
