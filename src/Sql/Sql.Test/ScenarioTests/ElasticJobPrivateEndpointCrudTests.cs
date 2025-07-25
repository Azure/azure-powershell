
using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ElasticJobPrivateEndpointCrudTests : SqlTestRunner
    {
        public ElasticJobPrivateEndpointCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateEndpointCreate()
        {
            TestRunner.RunTestScript("Test-CreateJobPrivateEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateEndpointGet()
        {
            TestRunner.RunTestScript("Test-GetJobPrivateEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateEndpointRemove()
        {
            TestRunner.RunTestScript("Test-RemoveJobPrivateEndpoint");
        }
    }
}
