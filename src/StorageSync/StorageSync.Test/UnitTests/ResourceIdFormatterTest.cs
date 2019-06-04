using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    /// <summary>
    /// TODO: complete test
    /// </summary>
    public class ResourceIdFormatterTest
    {

        /// <summary>
        /// Defines the test method ResourceIdFormatterTestSuccessful.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceIdFormatterTestSuccessful()
        {
            Guid subscriptionGuid = Guid.NewGuid();
            string myResourceGroupName = "rgName";
            IList<KeyValuePair<string, string>> resources = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("k1", "v1")
            };

            string actualValue = ResourceIdFormatter.GenerateResourceId(subscriptionGuid, myResourceGroupName, resources);
            string expectedValue = $"/subscriptions/{subscriptionGuid}/resourceGroups/{myResourceGroupName}/providers/Microsoft.StorageSync/{resources[0].Key}/{resources[0].Value}";
            Xunit.Assert.Equal(expectedValue, actualValue);

            actualValue = ResourceIdFormatter.GenerateResourceId(subscriptionGuid, myResourceGroupName, null);
            expectedValue = $"/subscriptions/{subscriptionGuid}/resourceGroups/{myResourceGroupName}";
            Xunit.Assert.Equal(expectedValue, actualValue);
        }

        /// <summary>
        /// Defines the test method ResourceIdFormatterTestFailed.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void ResourceIdFormatterTestFailed()
        {
            Xunit.Assert.Throws<ArgumentException>(() => ResourceIdFormatter.GenerateResourceId(Guid.NewGuid(), null, null));
        }
    }
}
