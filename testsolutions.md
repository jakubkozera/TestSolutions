# Test Structure Documentation for Test Explorer Validation

## Overview

This document describes a comprehensive test solution structure designed to fully validate the C# Dev Tools extension's Test Explorer functionality. The structure covers all supported testing frameworks, scenarios, and edge cases.

## Root Structure

```
TestSolutions/
├── NET8/                           # .NET 8 test solutions
│   ├── XUnit.Tests/                # xUnit framework tests (.NET 8)
│   ├── NUnit.Tests/                # NUnit framework tests (.NET 8)
│   └── MSTest.Tests/               # MSTest framework tests (.NET 8)
└── NET10-MTP/                      # .NET 10+ with Microsoft.Testing.Platform
    ├── XUnit.MTP.Tests/            # xUnit with MTP (.NET 10+)
    ├── NUnit.MTP.Tests/            # NUnit with MTP (.NET 10+)
    └── MSTest.MTP.Tests/           # MSTest with MTP (.NET 10+)
```

## Test Scenarios to Cover

### 1. Basic Test Types

#### Test Methods

- **Simple passing tests** - Basic test methods that always pass
- **Simple failing tests** - Tests that always fail with assertions
- **Skipped tests** - Tests marked with Skip/Ignore attributes

#### Test Organization

- **Single-level tests** - Tests directly in a class
- **Nested test classes** - Test classes within test classes (xUnit nested classes)
- **Multiple namespaces** - Tests organized across different namespaces
- **Multiple test classes** - Several test classes in one file

### 2. Parameterized Tests

#### xUnit Theory Tests

- **InlineData** - Theory with inline data attributes
- **MemberData** - Theory with member data source
- **ClassData** - Theory with class data source
- **Long parameter lists** - Theory with many parameters (10+)
- **Complex parameter types** - Theory with objects, arrays, collections

#### NUnit TestCase Tests

- **Simple TestCase** - Basic parameterized test
- **Multiple TestCase** - Multiple test cases for one method
- **Combined attributes** - TestCase with other attributes
- **Complex parameters** - TestCase with complex types

#### MSTest DataRow Tests

- **DataRow attribute** - Parameterized tests with data rows
- **DynamicData** - Data-driven tests with dynamic data
- **Multiple data sources** - Combining different data sources

### 3. Test Duration Scenarios

#### Quick Tests (< 100ms)

- Simple arithmetic tests
- String manipulation tests
- Boolean logic tests

#### Medium Tests (100ms - 2s)

- File I/O operations
- Simple data processing
- Basic database queries (mocked)

#### Long Tests (2s - 10s)

- Simulated API calls using `Task.Delay`
- Complex calculations
- Batch operations

#### Very Long Tests (10s - 30s)

- Integration scenarios
- End-to-end simulations
- Performance tests

### 4. Test Names and Descriptions

#### Name Length Variations

- **Short names** - 5-10 characters (e.g., `Test_Add`)
- **Normal names** - 20-50 characters (e.g., `Should_ReturnSum_When_AddingTwoNumbers`)
- **Long names** - 80-150 characters (descriptive BDD-style names)
- **Very long names** - 200+ characters (edge case for UI rendering)

#### Special Characters in Names

- Underscores: `Test_Method_With_Underscores`
- Spaces (via DisplayName): `Test Method With Spaces`
- Numbers: `Test123_WithNumbers_456`
- Unicode characters: `Test_Ñoño_ÜmlaÜt` (if supported)

### 5. Test Categories and Traits

#### xUnit Traits

```csharp
[Trait("Category", "Unit")]
[Trait("Category", "Integration")]
[Trait("Category", "Performance")]
[Trait("Priority", "High")]
[Trait("Priority", "Low")]
[Trait("Component", "Database")]
[Trait("Component", "API")]
```

#### NUnit Categories

```csharp
[Category("Unit")]
[Category("Integration")]
[Category("Performance")]
[Category("Smoke")]
[Category("Regression")]
```

#### MSTest TestCategory

```csharp
[TestCategory("Unit")]
[TestCategory("Integration")]
[TestCategory("Performance")]
[TestCategory("E2E")]
```

### 6. Test Results Variations

#### Passing Tests

- All assertions pass
- No exceptions thrown
- Expected return values

#### Failing Tests

- **Simple assertion failures** - Basic Assert.Equal failures
- **Multiple assertion failures** - Tests with several assertions
- **Exception assertions** - Assert.Throws scenarios
- **Custom exception messages** - Detailed failure messages

#### Skipped Tests

- xUnit: `[Fact(Skip = "Reason")]`
- NUnit: `[Ignore("Reason")]`
- MSTest: `[Ignore]` or `Assert.Inconclusive()`

#### Error Scenarios

- **NullReferenceException** - Common runtime error
- **ArgumentException** - Invalid arguments
- **InvalidOperationException** - Invalid state
- **Custom exceptions** - Domain-specific exceptions

### 7. Test Nesting Levels

#### Level 0: Project

```
MyProject.Tests
```

#### Level 1: Namespace

```
MyProject.Tests.Unit
MyProject.Tests.Integration
```

#### Level 2: Test Class

```
MyProject.Tests.Unit.CalculatorTests
MyProject.Tests.Integration.DatabaseTests
```

#### Level 3: Test Method

```
MyProject.Tests.Unit.CalculatorTests.Add_ShouldReturnSum
```

#### Level 4: Theory/TestCase (parameterized tests)

```
MyProject.Tests.Unit.CalculatorTests.Add_Theory(1, 2, 3)
MyProject.Tests.Unit.CalculatorTests.Add_Theory(5, 5, 10)
```

#### Deep Nesting (xUnit nested classes - Level 5+)

```csharp
public class OuterTests
{
    public class MiddleTests
    {
        public class InnerTests
        {
            [Fact]
            public void DeepNestedTest() { }
        }
    }
}
```

### 8. Special Test Types

#### Async Tests

- Simple async/await tests
- Tests with ConfigureAwait
- Tests with multiple awaits
- Long-running async operations

#### Setup/Teardown Tests

- xUnit: Constructor/Dispose
- NUnit: SetUp/TearDown
- MSTest: TestInitialize/TestCleanup
- Class-level fixtures

#### Collection Fixtures (xUnit)

- Shared context across tests
- Collection definitions
- Multiple collections

## Detailed Test Project Specifications

### .NET 8 Solutions

#### 1. XUnit.Tests (.NET 8)

**Solution File:** `NET8/XUnit.Tests.sln`

**Projects:**

- `XUnit.BasicTests` - Basic test scenarios
- `XUnit.ParameterizedTests` - Theory and data-driven tests
- `XUnit.PerformanceTests` - Long-running tests
- `XUnit.ComplexTests` - Nested classes and complex scenarios

**Test Count Target:** 150-200 tests

**Key Features:**

- Fact and Theory tests
- Trait-based categorization
- Nested test classes (3-4 levels)
- Collection fixtures
- Async tests
- Tests with various durations (1ms - 20s)

**Sample Test Structure:**

```
XUnit.BasicTests/
├── Unit/
│   ├── Arithmetic/
│   │   ├── AdditionTests.cs (10 tests, < 10ms each)
│   │   ├── SubtractionTests.cs (10 tests, < 10ms each)
│   │   ├── MultiplicationTests.cs (10 tests, < 10ms each)
│   │   └── DivisionTests.cs (15 tests, includes error cases)
│   ├── StringOperations/
│   │   ├── ConcatenationTests.cs (8 tests)
│   │   ├── SubstringTests.cs (12 tests)
│   │   └── RegexTests.cs (10 tests, 50-200ms each)
│   └── Collections/
│       ├── ListTests.cs (15 tests)
│       ├── DictionaryTests.cs (12 tests)
│       └── QueueTests.cs (10 tests)
├── Integration/
│   ├── FileSystemTests.cs (15 tests, 100-500ms each)
│   ├── DatabaseTests.cs (20 tests, 500-2000ms each)
│   └── ApiTests.cs (25 tests, 1s-10s with Task.Delay)
└── Performance/
    ├── LargeDatasetTests.cs (10 tests, 3s-15s each)
    └── StressTests.cs (5 tests, 10s-30s each)
```

**Theory Test Examples:**

```csharp
[Theory]
[InlineData(1, 2, 3)]
[InlineData(-1, 1, 0)]
[InlineData(100, 200, 300)]
[InlineData(int.MaxValue, 0, int.MaxValue)]
public void Add_Theory_WithInlineData(int a, int b, int expected)
{
    var result = a + b;
    Assert.Equal(expected, result);
}

[Theory]
[MemberData(nameof(GetComplexTestData))]
public void ComplexTheory_WithMemberData(ComplexObject obj, string expected)
{
    // Test implementation
}

public static IEnumerable<object[]> GetComplexTestData()
{
    yield return new object[] { new ComplexObject(), "result1" };
    yield return new object[] { new ComplexObject(), "result2" };
    // ... 20 more cases
}
```

#### 2. NUnit.Tests (.NET 8)

**Solution File:** `NET8/NUnit.Tests.sln`

**Projects:**

- `NUnit.BasicTests` - Basic test scenarios
- `NUnit.ParameterizedTests` - TestCase tests
- `NUnit.CategoryTests` - Category-based organization
- `NUnit.FixtureTests` - Test fixtures and setup/teardown

**Test Count Target:** 150-200 tests

**Key Features:**

- Test and TestCase attributes
- Category attributes for grouping
- SetUp, TearDown, OneTimeSetUp, OneTimeTearDown
- TestFixture with parameters
- Sequential and parallel test execution

**Sample Test Structure:**

```
NUnit.BasicTests/
├── Unit/
│   ├── [Category("Unit")] classes
│   └── Quick tests (< 50ms)
├── Integration/
│   ├── [Category("Integration")] classes
│   └── Medium tests (100ms-2s)
└── E2E/
    ├── [Category("E2E")] classes
    └── Long tests (2s-20s)
```

**TestCase Examples:**

```csharp
[TestCase(1, 2, 3)]
[TestCase(10, 20, 30)]
[TestCase(-5, 5, 0)]
[TestCase(int.MaxValue, 1, ExpectedException = typeof(OverflowException))]
public void Add_TestCase(int a, int b, int expected)
{
    Assert.AreEqual(expected, a + b);
}

[TestCase("short")]
[TestCase("This is a medium length test name with underscores_and_numbers_123")]
[TestCase("This_is_a_very_long_test_name_that_exceeds_normal_expectations_and_should_test_the_UI_rendering_capabilities_of_the_test_explorer_when_dealing_with_extremely_long_test_method_names")]
public void TestNameLengths(string testName)
{
    Assert.IsNotEmpty(testName);
}
```

#### 3. MSTest.Tests (.NET 8)

**Solution File:** `NET8/MSTest.Tests.sln`

**Projects:**

- `MSTest.BasicTests` - Basic test scenarios
- `MSTest.DataDrivenTests` - DataRow tests
- `MSTest.CategoryTests` - TestCategory organization
- `MSTest.LifecycleTests` - Lifecycle methods

**Test Count Target:** 150-200 tests

**Key Features:**

- TestMethod and DataRow attributes
- TestCategory for grouping
- TestInitialize, TestCleanup, ClassInitialize, ClassCleanup
- Assert.Inconclusive for skipped tests
- DeploymentItem for data files

**Sample Test Structure:**

```
MSTest.BasicTests/
├── Unit/
│   ├── [TestCategory("Unit")] classes
│   └── Synchronous tests
├── Integration/
│   ├── [TestCategory("Integration")] classes
│   └── Database/file operations
└── Async/
    ├── [TestCategory("Async")] classes
    └── Async/await tests
```

**DataRow Examples:**

```csharp
[DataRow(1, 2, 3)]
[DataRow(10, 20, 30)]
[DataRow(-1, -1, -2)]
[DataRow(0, 0, 0)]
[DataTestMethod]
public void Add_DataRow(int a, int b, int expected)
{
    Assert.AreEqual(expected, a + b);
}

[DataRow(1)] // Quick test
[DataRow(1000)] // 1 second delay
[DataRow(5000)] // 5 second delay
[DataRow(10000)] // 10 second delay
[TestMethod]
public async Task LongRunningTest_WithDelay(int delayMs)
{
    await Task.Delay(delayMs);
    Assert.IsTrue(true);
}
```

### .NET 10+ MTP Solutions

#### 1. XUnit.MTP.Tests (.NET 10+)

**Solution File:** `NET10-MTP/XUnit.MTP.Tests.sln`

**Projects:**

- Same structure as .NET 8 XUnit tests
- Uses Microsoft.Testing.Platform
- `EnableMSTestRunner` property in csproj

**Key Differences:**

- Microsoft.Testing.Platform output format
- Different test result parsing
- Enhanced performance with MTP

#### 2. NUnit.MTP.Tests (.NET 10+)

**Solution File:** `NET10-MTP/NUnit.MTP.Tests.sln`

**Projects:**

- Same structure as .NET 8 NUnit tests
- Uses Microsoft.Testing.Platform
- MTP-compatible NUnit adapter

#### 3. MSTest.MTP.Tests (.NET 10+)

**Solution File:** `NET10-MTP/MSTest.MTP.Tests.sln`

**Projects:**

- Same structure as .NET 8 MSTest tests
- Native MTP support (MSTest has best MTP integration)

## Test Execution Matrix

### Test Discovery Scenarios

| Scenario | Description | Expected Behavior |
|----------|-------------|-------------------|
| Empty solution | Solution with no test projects | No tests discovered |
| Single test project | One test project in solution | All tests discovered |
| Multiple test projects | 3-5 test projects | All tests from all projects |
| Mixed frameworks | xUnit + NUnit + MSTest | All frameworks supported |
| Nested namespaces | 5+ levels of namespaces | Hierarchical display |
| Large test suite | 500+ tests | Efficient discovery |

### Test Execution Scenarios

| Scenario | Description | Expected Result |
|----------|-------------|-----------------|
| Run single test | Execute one test method | Single result |
| Run test class | Execute all tests in class | Multiple results |
| Run namespace | Execute all tests in namespace | All namespace tests |
| Run project | Execute all project tests | All project tests |
| Run solution | Execute all tests | All solution tests |
| Debug single test | Debug one test with breakpoint | Debugger attached |
| Run with filter | Use @unit, @integration | Filtered execution |

### Test Result Scenarios

| Scenario | Description | Display |
|----------|-------------|---------|
| All passing | 100% success rate | Green checkmarks |
| Mixed results | Pass, fail, skip mix | Colored indicators |
| All failing | 100% failure rate | Red X marks |
| All skipped | All tests ignored | Gray skip indicators |
| With stack traces | Failing tests with traces | Detailed error info |
| Long error messages | 1000+ character errors | Scrollable error display |

### Performance Scenarios

| Scenario | Test Count | Duration | Notes |
|----------|-----------|----------|-------|
| Quick test suite | 100 tests | < 5s | Unit tests |
| Medium test suite | 200 tests | 30s-1m | Mixed tests |
| Long test suite | 500 tests | 2-5m | With integration |
| Very long suite | 1000+ tests | 10m+ | Full coverage |
| Parallel execution | 100 tests | Varies | Framework-dependent |

## Implementation Guidelines

### Project Setup

Each test project should include:

1. **Target Framework**

   ```xml
   <TargetFramework>net8.0</TargetFramework>
   <!-- OR -->
   <TargetFramework>net10.0</TargetFramework>
   ```

2. **Test Framework Package**

   ```xml
   <!-- xUnit -->
   <PackageReference Include="xunit" Version="2.6.0" />
   <PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" />
   
   <!-- NUnit -->
   <PackageReference Include="NUnit" Version="4.0.1" />
   <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
   
   <!-- MSTest -->
   <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
   <PackageReference Include="MSTest.TestAdapter" Version="3.1.1" />
   ```

3. **Test SDK**

   ```xml
   <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
   ```

4. **MTP Support (for .NET 10+)**

   ```xml
   <PropertyGroup>
     <EnableMSTestRunner>true</EnableMSTestRunner>
     <OutputType>Exe</OutputType>
   </PropertyGroup>
   ```

### Test Naming Conventions

Use descriptive names following these patterns:

- **xUnit:** `MethodName_Scenario_ExpectedBehavior`
- **NUnit:** `MethodName_WithCondition_ReturnsExpected`
- **MSTest:** `MethodName_StateUnderTest_ExpectedResult`

### Duration Implementation

Use `Task.Delay` for consistent timing:

```csharp
// Quick test (< 100ms)
[Fact]
public async Task QuickTest()
{
    await Task.Delay(10);
    Assert.True(true);
}

// Medium test (1-2s)
[Fact]
public async Task MediumTest()
{
    await Task.Delay(1500);
    Assert.True(true);
}

// Long test (5-10s)
[Fact]
public async Task LongTest()
{
    await Task.Delay(5000);
    Assert.True(true);
}

// Very long test (15-30s)
[Fact]
public async Task VeryLongTest()
{
    await Task.Delay(5000);
    Assert.True(true);
}
```

### Error Message Patterns

Create varied error messages:

```csharp
// Simple error
Assert.Equal(5, 4); // "Expected 5, actual 4"

// Detailed error
Assert.True(false, "This is a detailed error message explaining what went wrong");

// Multi-line error
var expected = "Line 1\nLine 2\nLine 3";
var actual = "Line 1\nLine X\nLine 3";
Assert.Equal(expected, actual);

// Exception with stack trace
throw new InvalidOperationException("Custom error with stack trace");
```

## Validation Checklist

Use this checklist to verify Test Explorer functionality:

### Discovery

- [ ] Tests discovered in all projects
- [ ] Tests organized hierarchically
- [ ] Correct test counts displayed
- [ ] Icons showing test status
- [ ] Refresh updates test list

### Execution

- [ ] Single test execution works
- [ ] Class execution works
- [ ] Namespace execution works
- [ ] Project execution works
- [ ] Solution execution works
- [ ] Debug mode attaches correctly
- [ ] Test output appears in Test Results panel

### Filtering

- [ ] Filter by test name works
- [ ] Filter by @category works
- [ ] Filter by @unit, @integration works
- [ ] Custom trait filters work
- [ ] Combined filters work

### Results

- [ ] Passing tests show green checkmark
- [ ] Failing tests show red X
- [ ] Skipped tests show gray indicator
- [ ] Error messages display correctly
- [ ] Stack traces are readable
- [ ] Test duration shows accurately

### Performance

- [ ] Quick tests (< 100ms) run fast
- [ ] Long tests (> 5s) don't freeze UI
- [ ] Progress indicators update
- [ ] Cancel button stops tests
- [ ] Multiple test runs don't conflict

### Edge Cases

- [ ] Very long test names display
- [ ] Deep nesting (5+ levels) works
- [ ] Large test suites (500+) perform
- [ ] Unicode characters in names
- [ ] Special characters handled
- [ ] Empty test classes handled

### Framework-Specific

- [ ] xUnit Theory tests expand correctly
- [ ] NUnit TestCase tests expand correctly
- [ ] MSTest DataRow tests expand correctly
- [ ] xUnit nested classes work
- [ ] NUnit categories filter
- [ ] MSTest TestCategory filters

### MTP Mode (.NET 10+)

- [ ] MTP mode detected correctly
- [ ] Test output parsing works
- [ ] Performance improvements visible
- [ ] All features work in MTP mode

## Expected Test Counts by Solution

| Solution | Projects | Total Tests | Pass | Fail | Skip |
|----------|----------|-------------|------|------|------|
| XUnit.Tests (.NET 8) | 4 | 180 | 150 | 20 | 10 |
| NUnit.Tests (.NET 8) | 4 | 180 | 150 | 20 | 10 |
| MSTest.Tests (.NET 8) | 4 | 180 | 150 | 20 | 10 |
| XUnit.MTP.Tests (.NET 10+) | 4 | 180 | 150 | 20 | 10 |
| NUnit.MTP.Tests (.NET 10+) | 4 | 180 | 150 | 20 | 10 |
| MSTest.MTP.Tests (.NET 10+) | 4 | 180 | 150 | 20 | 10 |
| **TOTAL** | **24** | **1080** | **900** | **120** | **60** |

## Directory Structure Summary

```
TestSolutions/
├── README.md (points to this doc)
├── NET8/
│   ├── XUnit.Tests/
│   │   ├── XUnit.Tests.sln
│   │   ├── XUnit.BasicTests/
│   │   │   ├── XUnit.BasicTests.csproj
│   │   │   ├── Unit/ (50 tests)
│   │   │   ├── Integration/ (30 tests)
│   │   │   └── Performance/ (10 tests)
│   │   ├── XUnit.ParameterizedTests/
│   │   │   ├── XUnit.ParameterizedTests.csproj
│   │   │   ├── TheoryTests/ (40 tests)
│   │   │   └── MemberDataTests/ (20 tests)
│   │   ├── XUnit.ComplexTests/
│   │   │   ├── XUnit.ComplexTests.csproj
│   │   │   ├── NestedClasses/ (20 tests, 3-4 levels)
│   │   │   └── AsyncTests/ (15 tests)
│   │   └── XUnit.TraitTests/
│   │       ├── XUnit.TraitTests.csproj
│   │       ├── UnitTests/ [Trait("Category", "Unit")]
│   │       ├── IntegrationTests/ [Trait("Category", "Integration")]
│   │       └── PerformanceTests/ [Trait("Category", "Performance")]
│   ├── NUnit.Tests/ (similar structure)
│   └── MSTest.Tests/ (similar structure)
└── NET10-MTP/
    ├── XUnit.MTP.Tests/ (mirrors NET8/XUnit.Tests with MTP)
    ├── NUnit.MTP.Tests/ (mirrors NET8/NUnit.Tests with MTP)
    └── MSTest.MTP.Tests/ (mirrors NET8/MSTest.Tests with MTP)
```

## Conclusion

This comprehensive test structure provides complete coverage of:

- ✅ All supported test frameworks (xUnit, NUnit, MSTest)
- ✅ Both .NET 8 and .NET 10+ MTP modes
- ✅ All test organizational patterns (namespaces, classes, nesting)
- ✅ Parameterized tests (Theory, TestCase, DataRow)
- ✅ Various test durations (1ms to 30s)
- ✅ Different test results (pass, fail, skip)
- ✅ Trait/category filtering
- ✅ Test name variations (short to very long)
- ✅ Deep nesting scenarios (5+ levels)
- ✅ Large test suites (1000+ tests total)
- ✅ Async and synchronous tests
- ✅ Setup/teardown patterns
- ✅ Error scenarios and stack traces

This structure ensures thorough validation of the Test Explorer controller's functionality across all supported scenarios and edge cases.
