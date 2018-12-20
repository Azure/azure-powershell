using Microsoft.Azure.Commands.ManagedServiceIdentity.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.Test.ScenarioTests
{
    public class CrudTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public CrudTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrud()
        {
            new TestController().RunPsTest(_logger, "Test-CrudUserAssignedIdentity");
        }
    }
}
