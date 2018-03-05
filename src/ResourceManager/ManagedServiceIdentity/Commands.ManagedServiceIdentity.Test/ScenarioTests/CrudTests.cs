using Microsoft.Azure.Commands.ManagedServiceIdentity.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.Test.ScenarioTests
{
    public class CrudTests : RMTestBase
    {
        public CrudTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            var helper = new EnvironmentSetupHelper
            {
                TracingInterceptor =new XunitTracingInterceptor(output)
            };
            XunitTracingInterceptor.AddToContext(helper.TracingInterceptor);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrud()
        {
            new TestController().RunPsTest("Test-CrudUserAssignedIdentity");
        }
    }
}
