using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTest.MongoCollection;

[BsonIgnoreExtraElements]
public sealed class People
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("month")]
    public string Month { get; set; } = string.Empty;

    [BsonElement("type")]
    public int Type { get; set; }

    [BsonElement("value")]
    public double[] Value { get; set; } = Array.Empty<double>();
}
