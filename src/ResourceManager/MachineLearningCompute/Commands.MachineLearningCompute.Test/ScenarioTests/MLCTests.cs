using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Test.ScenarioTests
{
    public class MLCTests : RMTestBase
    {
        private readonly XunitTracingInterceptor interceptor;

        public MLCTests(ITestOutputHelper output)
        {
            this.interceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(interceptor);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewGetRemove()
        {
            TestController.NewInstance.RunPsTest(this.interceptor, "Test-NewGetRemove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetKeys()
        {
            TestController.NewInstance.RunPsTest(this.interceptor, "Test-GetKeys");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateSystemServices()
        {
            TestController.NewInstance.RunPsTest(this.interceptor, "Test-UpdateSystemServices");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSet()
        {
            TestController.NewInstance.RunPsTest(this.interceptor, "Test-Set");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIncludeAllResources()
        {
            TestController.NewInstance.RunPsTest(this.interceptor, "Test-RemoveIncludeAllResources");
        }
    }
}
