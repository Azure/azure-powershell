using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class TestResourceTypeUtility
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputIsNull()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceType(null);

            Assert.Null(resourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputTopLevelResourceTypeSingle()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceType("virtualMachines");

            Assert.Equal("virtualMachines", resourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputTopLevelResourceTypeAndSubResourceType()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceType("virtualMachines/networking");

            Assert.Equal("virtualMachines", resourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputProviderNull()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceTypeWithProvider(null);

            Assert.Null(resourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputProviderAndTopLevelResourceType()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceTypeWithProvider("Microsoft.Compute/virtualMachines");

            Assert.Equal("virtualMachines", resourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInputProviderAndTopLevelResourceTypeAndSubLevelResourceType()
        {
            string resourceType = ResourceTypeUtility.GetTopLevelResourceTypeWithProvider("Microsoft.Compute/virtualMachines/networking");

            Assert.Equal("virtualMachines", resourceType);
        }
    }
}
