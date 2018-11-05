using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ByteRangerLogbook.Data
{
    public enum LogType
    {
        Aeroplane = 0,
        Glider = 1
    }

    public class LogEntry
    {
        [BsonId]
        public int ID { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("Type")]
        public LogType Type { get; set; }
        [BsonElement("Registration")]
        public string Registration { get; set; }
        [BsonElement("HoursP1")]
        public double HoursP1 { get; set; }
        [BsonElement("HoursP2")]
        public double HoursP2 { get; set; }
        [BsonElement("Comment")]
        public string Comment { get; set; }
    }
}
