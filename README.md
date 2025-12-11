# Test Solutions for C# Dev Tools Extension

This repository contains comprehensive test solutions designed to validate the C# Dev Tools VS Code extension's Test Explorer functionality.

## Structure

```
TestSolutions/
├── NET8/                           # .NET 8 test solutions
│   ├── XUnit.Tests/               # xUnit test projects
│   │   ├── XUnit.BasicTests/
│   │   ├── XUnit.ParameterizedTests/
│   │   ├── XUnit.ComplexTests/
│   │   └── XUnit.TraitTests/
│   ├── NUnit.Tests/               # NUnit test projects
│   │   ├── NUnit.BasicTests/
│   │   ├── NUnit.ParameterizedTests/
│   │   ├── NUnit.CategoryTests/
│   │   └── NUnit.FixtureTests/
│   └── MSTest.Tests/              # MSTest test projects
│       ├── MSTest.BasicTests/
│       ├── MSTest.DataDrivenTests/
│       ├── MSTest.CategoryTests/
│       └── MSTest.LifecycleTests/
└── NET10-MTP/                     # .NET 10+ with Microsoft.Testing.Platform
    ├── XUnit.MTP.Tests/           # xUnit with MTP
    │   ├── XUnit.MTP.BasicTests/
    │   ├── XUnit.MTP.ParameterizedTests/
    │   ├── XUnit.MTP.ComplexTests/
    │   └── XUnit.MTP.TraitTests/
    ├── NUnit.MTP.Tests/           # NUnit with MTP
    │   ├── NUnit.MTP.BasicTests/
    │   ├── NUnit.MTP.ParameterizedTests/
    │   ├── NUnit.MTP.CategoryTests/
    │   └── NUnit.MTP.MixedTests/
    └── MSTest.MTP.Tests/          # MSTest with MTP
        ├── MSTest.MTP.BasicTests/
        ├── MSTest.MTP.DataDrivenTests/
        ├── MSTest.MTP.CategoryTests/
        └── MSTest.MTP.LifecycleTests/
```

## Summary

- **Total Solutions:** 6
- **Total Projects:** 24
- **Testing Frameworks:** xUnit, NUnit, MSTest
- **Target Frameworks:** .NET 8 and .NET 10+
- **MTP Support:** All .NET 10+ projects use Microsoft.Testing.Platform

## Test Coverage

Each solution contains tests covering:

### Basic Test Types
- Simple passing tests
- Failing tests with assertions
- Skipped/ignored tests
- Tests with various durations (quick to long-running)

### Parameterized Tests
- **xUnit:** Theory with InlineData, MemberData, ClassData
- **NUnit:** TestCase with multiple parameters
- **MSTest:** DataRow with data-driven tests

### Test Organization
- Multiple namespaces
- Nested test classes
- Category/trait-based organization
- Setup and teardown methods

### Test Scenarios
- Unit tests (arithmetic, string operations, collections)
- Integration tests (file system operations)
- Performance tests (large datasets, stress tests)
- Async tests
- Long-running tests (simulated with Task.Delay)

## Building the Solutions

### .NET 8 Solutions

```powershell
# Build all .NET 8 solutions
cd NET8\XUnit.Tests
dotnet build

cd ..\NUnit.Tests
dotnet build

cd ..\MSTest.Tests
dotnet build
```

### .NET 10+ MTP Solutions

```powershell
# Build all .NET 10+ MTP solutions
cd NET10-MTP\XUnit.MTP.Tests
dotnet build

cd ..\NUnit.MTP.Tests
dotnet build

cd ..\MSTest.MTP.Tests
dotnet build
```

## Running Tests

### Run all tests in a solution

```powershell
dotnet test XUnit.Tests.sln
```

### Run tests in a specific project

```powershell
dotnet test XUnit.BasicTests\XUnit.BasicTests.csproj
```

### Run tests with specific category/trait

```powershell
# xUnit
dotnet test --filter "Category=Unit"

# NUnit
dotnet test --filter "Category=Integration"

# MSTest
dotnet test --filter "TestCategory=Performance"
```

## Test Explorer Integration

These test solutions are designed to work seamlessly with the C# Dev Tools VS Code extension's Test Explorer:

1. **Test Discovery:** All tests should be automatically discovered
2. **Hierarchical Display:** Tests organized by namespace → class → method
3. **Run/Debug:** Support for running and debugging individual tests or groups
4. **Filtering:** Tests can be filtered by traits/categories
5. **Results:** Pass/fail/skip indicators with error messages and stack traces

## Test Characteristics

### Test Name Lengths
- Short names (5-20 characters)
- Normal names (20-80 characters)
- Long descriptive names (80-150 characters)
- Very long names (200+ characters for UI edge cases)

### Test Durations
- Quick tests: < 100ms
- Medium tests: 100ms - 2s
- Long tests: 2s - 10s
- Very long tests: 10s - 30s

### Test Results Distribution
Across all tests:
- ~83% passing tests
- ~11% failing tests (intentional)
- ~6% skipped tests

## Framework-Specific Features

### xUnit
- Fact and Theory attributes
- Traits for categorization
- Collection fixtures
- Nested test classes (3-4 levels deep)
- Constructor/Dispose for setup/teardown

### NUnit
- Test and TestCase attributes
- Categories for grouping
- SetUp/TearDown methods
- OneTimeSetUp/OneTimeTearDown
- TestFixture with parameters

### MSTest
- TestMethod and DataRow attributes
- TestCategory for organization
- TestInitialize/TestCleanup methods
- ClassInitialize/ClassCleanup
- Test context support

## Microsoft.Testing.Platform (MTP)

The .NET 10+ solutions demonstrate MTP integration:
- Modern test runner architecture
- Improved performance
- Enhanced test output
- Better diagnostics

## Validation Checklist

Use these solutions to validate:

- ✅ Test discovery across all frameworks
- ✅ Hierarchical test organization
- ✅ Parameterized test expansion
- ✅ Category/trait filtering
- ✅ Run individual tests
- ✅ Run test classes/namespaces
- ✅ Run all tests in project/solution
- ✅ Debug tests with breakpoints
- ✅ View test results (pass/fail/skip)
- ✅ Display error messages and stack traces
- ✅ Handle long-running tests
- ✅ Cancel test execution
- ✅ Refresh test list
- ✅ Handle large test suites (500+ tests)
- ✅ MTP mode detection and support

## Notes

- All projects target the latest SDK versions
- Tests include both synchronous and asynchronous patterns
- Error scenarios include various exception types
- Performance tests use Task.Delay for consistent timing
- Sample tests demonstrate best practices for each framework

## Documentation Reference

For complete test specifications and validation criteria, see [testsolutions.md](testsolutions.md).

## License

These test solutions are part of the C# Dev Tools extension development and testing infrastructure.
