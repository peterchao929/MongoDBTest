using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBTest.Dto;
using MongoDBTest.MongoCollection;
using System.Collections.Generic;
using ZstdSharp;

namespace MongoDBTest.Services;

public sealed class PeopleService
{
    private readonly IMongoCollection<People> _peopleCollection;

    public PeopleService(IOptions<TestDatabaseSettings> testDatabaseSettings)
    {
        var mongoClient = new MongoClient(testDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(testDatabaseSettings.Value.DatabaseName);

        _peopleCollection = mongoDatabase.GetCollection<People>(testDatabaseSettings.Value.TestCollectionName);
    }

    /// <summary>
    /// 查詢人員清單
    /// </summary>
    /// <returns>人員清單</returns>
    public async Task<List<People>> GetList()
    {
        var people = await _peopleCollection.Find(_ => true).ToListAsync();

        return people ?? new List<People>();
    }

    /// <summary>
    /// 查詢單筆人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <returns>人員</returns>
    public async Task<People> GetPeopleById(string id)
    {
        var people = await _peopleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        return people;
    }

    /// <summary>
    /// 新增人員資料
    /// </summary>
    /// <param name="addPeople">新增資料</param>
    /// <returns>新增</returns>
    public async Task AddPeople(People addPeople)
    {
        await _peopleCollection.InsertOneAsync(addPeople);
    }

    /// <summary>
    /// 修改人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <param name="updatePeople">修改資料</param>
    /// <returns>修改</returns>
    public async Task UpdatePeople(string id, People updatePeople)
    {
        await _peopleCollection.ReplaceOneAsync(x => x.Id == id, updatePeople);
    }

    /// <summary>
    /// 刪除人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <returns>刪除</returns>
    public async Task DeletePeople(string id)
    {
        await _peopleCollection.DeleteOneAsync(x => x.Id == id);
    }
}
