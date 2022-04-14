using System;
using System.Text.Json.Serialization;

namespace Report.API.Model
{
    public class LocationReport : BaseMongoModel
    {
        public DateTime CompletedOn { get; set; }
        public ReportStatus Status { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportStatus
    {
        Preparing = 1,
        Completed
    }
}
