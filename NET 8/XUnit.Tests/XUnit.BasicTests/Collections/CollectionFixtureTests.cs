using Xunit;

namespace XUnit.BasicTests.Collections;

[Collection("Database Collection")]
public class DatabaseCollectionTests1
{
    private readonly DatabaseFixture _fixture;

    public DatabaseCollectionTests1(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Database_SharedFixture_Test1()
    {
        await Task.Delay(100);
        Assert.NotNull(_fixture.ConnectionString);
    }

    [Fact]
    public async Task Database_SharedFixture_Test2()
    {
        await Task.Delay(120);
        Assert.True(_fixture.IsConnected);
    }

    [Fact]
    public async Task Database_SharedFixture_Test3()
    {
        await Task.Delay(150);
        Assert.Equal("TestDatabase", _fixture.DatabaseName);
    }
}

[Collection("Database Collection")]
public class DatabaseCollectionTests2
{
    private readonly DatabaseFixture _fixture;

    public DatabaseCollectionTests2(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Database_SharedFixture_Test4()
    {
        await Task.Delay(100);
        Assert.NotNull(_fixture.ConnectionString);
    }

    [Fact]
    public async Task Database_SharedFixture_Test5()
    {
        await Task.Delay(130);
        Assert.True(_fixture.IsConnected);
    }

    [Fact]
    public async Task Database_SharedFixture_Test6()
    {
        await Task.Delay(140);
        var recordCount = _fixture.GetRecordCount();
        Assert.True(recordCount >= 0);
    }
}

[Collection("Database Collection")]
public class DatabaseCollectionTests3
{
    private readonly DatabaseFixture _fixture;

    public DatabaseCollectionTests3(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Database_SharedFixture_Test7()
    {
        await Task.Delay(110);
        Assert.NotEmpty(_fixture.GetTableNames());
    }

    [Fact]
    public async Task Database_SharedFixture_Test8()
    {
        await Task.Delay(160);
        var version = _fixture.GetDatabaseVersion();
        Assert.NotEmpty(version);
    }

    [Fact]
    public async Task Database_SharedFixture_Test9()
    {
        await Task.Delay(140);
        Assert.True(_fixture.CanExecuteQueries());
    }
}

// Collection definition
[CollectionDefinition("Database Collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
}

// Shared fixture
public class DatabaseFixture : IDisposable
{
    public string ConnectionString { get; }
    public bool IsConnected { get; private set; }
    public string DatabaseName { get; }

    public DatabaseFixture()
    {
        ConnectionString = "Server=localhost;Database=TestDb;";
        DatabaseName = "TestDatabase";
        IsConnected = true;
        
        // Simulate database initialization
        Task.Delay(500).Wait();
    }

    public int GetRecordCount()
    {
        return 100;
    }

    public List<string> GetTableNames()
    {
        return new List<string> { "Users", "Orders", "Products" };
    }

    public string GetDatabaseVersion()
    {
        return "1.0.0";
    }

    public bool CanExecuteQueries()
    {
        return IsConnected;
    }

    public void Dispose()
    {
        IsConnected = false;
    }
}
