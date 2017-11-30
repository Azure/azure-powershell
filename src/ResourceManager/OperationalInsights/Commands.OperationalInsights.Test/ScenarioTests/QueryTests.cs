using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.OperationalInsights;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class QueryTests : RMTestBase
    {
        static QueryTests()
        {
            //Uncomment this to regenerate the SessionRecords
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
        }

        private EnvironmentSetupHelper helper;

        public QueryTests()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2)))
            {
                var credentials = new ApiKeyClientCredentials("DEMO_KEY");
                var client = new OperationalInsightsDataClient(credentials, HttpMockServer.CreateInstance());
                helper.SetupManagementClients(client);

                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.OperationalInsights.psd1"),
                    "AzureRM.Resources.ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        [Fact]
        public void TestSimpleQuery()
        {
            RunPowerShellTest("Test-SimpleQuery");
        }

        [Fact]
        public void TestSimpleQueryWithTimespan()
        {
            RunPowerShellTest("Test-SimpleQueryWithTimespan");
        }

        [Fact]
        public void TestExceptionWithSyntaxError()
        {
            RunPowerShellTest("Test-ExceptionWithSyntaxError");
        }

        [Fact]
        public void TestExceptionWithShortWait()
        {
            RunPowerShellTest("Test-ExceptionWithShortWait");
        }
    }
}
