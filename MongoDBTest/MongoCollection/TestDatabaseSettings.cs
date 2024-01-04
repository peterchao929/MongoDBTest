﻿namespace MongoDBTest.MongoCollection;

public sealed class TestDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set;} = null!;

    public string TestCollectionName { get; set; } = null!;
}
