using Xunit;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class QueryTests : OperationalInsightsScenarioTestBase
    {
        [Fact]
        public void TestSimpleQuery()
        {
            RunDataPowerShellTest("Test-SimpleQuery");
        }

        [Fact]
        public void TestSimpleQueryWithTimespan()
        {
            RunDataPowerShellTest("Test-SimpleQueryWithTimespan");
        }

        [Fact]
        public void TestExceptionWithSyntaxError()
        {
            RunDataPowerShellTest("Test-ExceptionWithSyntaxError");
        }

        [Fact]
        public void TestExceptionWithShortWait()
        {
            RunDataPowerShellTest("Test-ExceptionWithShortWait");
        }

        [Fact]
        public void TestAsJob()
        {
            RunDataPowerShellTest("Test-AsJob");
        }
    }
}
