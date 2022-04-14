using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Contact.API.Model
{
    public class ContactInformationModel : BaseMongoModel
    {

        [BsonRepresentation(BsonType.String)]
        public InformationType Type { get; set; }
        public string Value { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InformationType
    {
        PhoneNumber = 1,
        EmailAddress,
        Location
    }
}
