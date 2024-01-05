using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBTest.Dto;

/// <summary>
/// 新增人員Dto
/// </summary>
public class AddPeopleDto
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("month")]
    public string Month { get; set; } = string.Empty;

    [BsonElement("type")]
    public int Type { get; set; }

    [BsonElement("value")]
    public int[] Value { get; set; } = Array.Empty<int>();
}

/// <summary>
/// 修改人員Dto
/// </summary>
public class UpdatePeopleDto : AddPeopleDto
{
}
