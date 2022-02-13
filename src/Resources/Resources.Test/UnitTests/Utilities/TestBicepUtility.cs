using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class TestBicepUtility
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepFile()
        {
            Assert.True(BicepUtility.IsBicepFile("test.bicep"));
            Assert.False(BicepUtility.IsBicepFile("test.json"));
        }
    }
}
