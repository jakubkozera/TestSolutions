using System;
using Xunit;

namespace XUnit.MTP.BasicTests
{
    public class ConsoleLoggingTest
    {
        [Fact]
        public void LogLines_ArePrinted_AndTestPasses()
        {
            // Print the provided log lines to the console
            Console.WriteLine("[14:46:57 ERR] HTTP GET /quotes/not-a-guid responded 500 in 3.8755 ms");
            Console.WriteLine("ORDER BY [s].[Id], [s].[Id0], [s].[Id1], [s].[Id2], [p2].[Id], [p3].[Id], [s0].[Id]");
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter \"Guid quoteId\" from \"not-a-guid\".");
            Console.WriteLine("   at lambda_method6602(Closure, Object, HttpContext)");
            Console.WriteLine("2025-12-15 14:46:59.487 [info] ❌ Microsoft.AspNetCore.Http.BadHttpRequestException - failed (?s)");
            Console.WriteLine("2025-12-15 14:47:00.047 [info] (DbType = Int32), @p56='?' (Precision = 10) (Scale = 2) (DbType = D");
            Console.WriteLine("2025-12-15 14:47:17.061 [info] [14:47:17 ERR] HTTP GET /propositions/invalid-guid/products responded 500 in 0.2783 ms");
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter \"Guid propositionInstanceId\" from \"invalid-guid\".");
            Console.WriteLine("   at lambda_method8635(Closure, Object, HttpContext)");
            Console.WriteLine("2025-12-15 14:47:21.607 [info] [14:47:21 ERR] HTTP POST /purchase responded 500 in 11676.7698 ms");
            Console.WriteLine("Purchasing.Application.Features.Purchases.CreatePurchase.Exceptions.PaymentException: Payment failed");
            Console.WriteLine("Purchasing.Application.Features.Purchases.CreatePurchase.Exceptions.PaymentException: Payment failed");
            Console.WriteLine("   at Purchasing.Application.Features.Purchases.CreatePurchase.CreatePurcha");
            Console.WriteLine("2025-12-15 14:47:54.565 [info] [14:47:54 ERR] HTTP GET /purchase/4345 responded 500 in 13.4389 ms");
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter \"Guid purchaseId\" from \"4345\".");
            Console.WriteLine("   at lambda_method14735(Closure, Object, HttpContext)");
            Console.WriteLine("2025-12-15 14:48:04.173 [info] [14:48:04 ERR] HTTP GET /transactions responded 500 in 0.3625 ms");
            Console.WriteLine("Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to bind parameter \"Guid customerId\" from \"1234\".");
            Console.WriteLine("   at lambda_method15227(Closure, Object, HttpContext)");
            Console.WriteLine("2025-12-15 14:48:44.634 [info] [14:48:44 ERR] HTTP POST /purchase responded 500 in 11389.8933 ms");
            Console.WriteLine("Purchasing.Application.Features.Purchases.CreatePurchase.Exceptions.SetPreferencesException: Set customer preferences failed");
            Console.WriteLine("   at Purchasing.Application.Features.Purchases.CreatePurchase.CreatePurchaseCommandHandler.SetCustomerContactPreferencesAsync(Guid customerId, Boolean allowEmails) in c:\\BasecampRepos\\tenzing.core.purchasing\\src\\Purchasing.Application\\Features\\Purchases\\CreatePurchase\\CreatePurchaseCommandHandler.cs:line 289");
            Console.WriteLine("Failed XUnit.BasicTests.Unit.FailingTests.SimpleAssertion_ShouldFail [102 ms]");

            // Assert true so the test passes
            Assert.True(true);
        }
    }
}
