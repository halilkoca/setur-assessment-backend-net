using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Text.Json.Serialization;

namespace SharedLibrary.Model
{
    public class LocationReportModel
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UUID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public ReportStatus Status { get; set; }

        public string Location { get; set; }
        public int LocationCount { get; set; }
        public int PeopleCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportStatus
    {
        Preparing = 1,
        Completed,
        Error
    }
}
