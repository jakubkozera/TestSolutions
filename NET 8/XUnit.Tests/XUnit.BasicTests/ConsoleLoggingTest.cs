using System;
using Xunit;

namespace XUnit.BasicTests.Unit
{
    public class ConsoleLoggingTest
    {
        [Fact]
        public void Logs_SampleLines_And_PassesException()
        {
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestExceptio: Failed to bind parameter \"Guid quoteId\" from \"not-a-guid\".");


            Assert.True(true);
        }
        [Fact]
        public void Logs_ComplexLines_And_PassesException()
        {
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter \"Guid quoteId\" from \"not-a-guid\".");
            Console.WriteLine("xUnit.net Console Runner (64-bit .NET)");
            Console.WriteLine("  Failed   XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException");
            Console.WriteLine("  Error Message:");
            Console.WriteLine("  Assert.Equal() Failure");
            Console.WriteLine("  Expected: True");
            Console.WriteLine("  Actual:   False");
            Console.WriteLine("  Stack Trace:");
            Console.WriteLine("     at XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException() in C:\\Users\\Jakub\\source\\repos\\TestSolutions\\NET 8\\XUnit.Tests\\XUnit.BasicTests\\ConsoleLoggingTest.cs:line 25");

            Console.WriteLine(); // spacer

            Console.WriteLine("MSTest V2 Test Run");
            Console.WriteLine("  Failed   XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException");
            Console.WriteLine("  Result Message: Assert.IsTrue failed.");
            Console.WriteLine("  Stack Trace:");
            Console.WriteLine("     at XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException() in C:\\Users\\Jakub\\source\\repos\\TestSolutions\\NET 8\\XUnit.Tests\\XUnit.BasicTests\\ConsoleLoggingTest.cs:line 25");

            Console.WriteLine(); // spacer

            Console.WriteLine("NUnit3 Test Runner");
            Console.WriteLine("1) XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException");
            Console.WriteLine("   Expected: True");
            Console.WriteLine("   But was:  False");
            Console.WriteLine("   at XUnit.BasicTests.Unit.ConsoleLoggingTest.Logs_ComplexLines_And_PassesException() in C:\\Users\\Jakub\\source\\repos\\TestSolutions\\NET 8\\XUnit.Tests\\XUnit.BasicTests\\ConsoleLoggingTest.cs:line 25");

            Console.WriteLine(); // summary
            Console.WriteLine("Failed!  - Failed: 1  Passed: 1  Total: 2  Duration: 00:00:01");

            Assert.True(true);
        }
    }
}
