using Xunit;

namespace XUnit.ComplexTests.CollectionFixtures;

// Collection fixture definition
public class DatabaseFixture : IDisposable
{
    public string ConnectionString { get; private set; }
    public bool IsConnected { get; private set; }

    public DatabaseFixture()
    {
        // Simulate database setup
        ConnectionString = "Server=localhost;Database=TestDb";
        IsConnected = true;
    }

    public void Dispose()
    {
        // Cleanup
        IsConnected = false;
    }
}

// Define collection
[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class is never instantiated
}

// Tests using the collection
[Collection("Database collection")]
public class DatabaseTests1
{
    private readonly DatabaseFixture _fixture;

    public DatabaseTests1(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_UsesSharedDatabaseFixture_1()
    {
        Assert.NotNull(_fixture.ConnectionString);
        Assert.True(_fixture.IsConnected);
    }

    [Fact]
    public void Test_UsesSharedDatabaseFixture_2()
    {
        Assert.Contains("localhost", _fixture.ConnectionString);
    }

    [Fact]
    public void Test_UsesSharedDatabaseFixture_3()
    {
        Assert.True(_fixture.IsConnected);
    }
}

[Collection("Database collection")]
public class DatabaseTests2
{
    private readonly DatabaseFixture _fixture;

    public DatabaseTests2(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_SharedFixture_WorksAcrossClasses_1()
    {
        Assert.NotNull(_fixture.ConnectionString);
    }

    [Fact]
    public void Test_SharedFixture_WorksAcrossClasses_2()
    {
        Assert.Contains("TestDb", _fixture.ConnectionString);
    }

    [Fact]
    public void Test_SharedFixture_WorksAcrossClasses_3()
    {
        Assert.True(_fixture.IsConnected);
    }
}

// Another collection fixture
public class ApiClientFixture : IDisposable
{
    public string BaseUrl { get; private set; }
    public Dictionary<string, string> Headers { get; private set; }

    public ApiClientFixture()
    {
        BaseUrl = "https://api.example.com";
        Headers = new Dictionary<string, string>
        {
            ["Authorization"] = "Bearer token123",
            ["Content-Type"] = "application/json"
        };
    }

    public void Dispose()
    {
        Headers.Clear();
    }
}

[CollectionDefinition("API collection")]
public class ApiCollection : ICollectionFixture<ApiClientFixture>
{
}

[Collection("API collection")]
public class ApiTests1
{
    private readonly ApiClientFixture _fixture;

    public ApiTests1(ApiClientFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_ApiClient_HasBaseUrl()
    {
        Assert.NotNull(_fixture.BaseUrl);
        Assert.StartsWith("https://", _fixture.BaseUrl);
    }

    [Fact]
    public void Test_ApiClient_HasHeaders()
    {
        Assert.NotEmpty(_fixture.Headers);
        Assert.True(_fixture.Headers.ContainsKey("Authorization"));
    }

    [Fact]
    public void Test_ApiClient_HeadersContainToken()
    {
        Assert.Contains("Bearer", _fixture.Headers["Authorization"]);
    }
}

[Collection("API collection")]
public class ApiTests2
{
    private readonly ApiClientFixture _fixture;

    public ApiTests2(ApiClientFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_SharedApiFixture_WorksInAnotherClass()
    {
        Assert.Equal("https://api.example.com", _fixture.BaseUrl);
    }

    [Fact]
    public void Test_SharedApiFixture_HasContentTypeHeader()
    {
        Assert.True(_fixture.Headers.ContainsKey("Content-Type"));
        Assert.Equal("application/json", _fixture.Headers["Content-Type"]);
    }
}

// Class fixture (different from collection fixture)
public class LoggerFixture : IDisposable
{
    public List<string> Logs { get; private set; }

    public LoggerFixture()
    {
        Logs = new List<string>();
    }

    public void Log(string message)
    {
        Logs.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
    }

    public void Dispose()
    {
        Logs.Clear();
    }
}

public class ClassFixtureTests : IClassFixture<LoggerFixture>
{
    private readonly LoggerFixture _logger;

    public ClassFixtureTests(LoggerFixture logger)
    {
        _logger = logger;
    }

    [Fact]
    public void Test_ClassFixture_Test1()
    {
        _logger.Log("Test 1 executed");
        Assert.NotEmpty(_logger.Logs);
    }

    [Fact]
    public void Test_ClassFixture_Test2()
    {
        _logger.Log("Test 2 executed");
        Assert.True(_logger.Logs.Count > 0);
    }

    [Fact]
    public void Test_ClassFixture_Test3()
    {
        _logger.Log("Test 3 executed");
        Assert.All(_logger.Logs, log => Assert.NotEmpty(log));
    }
}
