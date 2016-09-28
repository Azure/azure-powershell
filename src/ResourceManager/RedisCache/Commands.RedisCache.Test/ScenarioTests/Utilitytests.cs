using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    public class UtilityTests
    {
        [Fact]
        public void ValidateResourceGroupAndResourceName_InvalidResourceGroup()
        {
            string resourceGroup = "subscriptions/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa/resourceGroups/Default-Storage-NorthEurope";
            string name = "cache-name";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("ResourceGroupName should not contain '/'. Name should be the plain, short name of the resource group, e.g. 'myResourceGroup'. (Not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        public void ValidateResourceGroupAndResourceName_InvalidRedisCacheName_FullName()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "cache-name.redis.cache.windows.net";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("Name should not contain '/' or '.'. Name should be the plain, short name of the redis cache, e.g. 'mycache'. (Not a fully qualified DNS name, and not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        public void ValidateResourceGroupAndResourceName_InvalidRedisCacheName_ID()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "subscriptions/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa/resourceGroups/Default-Storage-NorthEurope/cache-name";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("Name should not contain '/' or '.'. Name should be the plain, short name of the redis cache, e.g. 'mycache'. (Not a fully qualified DNS name, and not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        public void ValidateResourceGroupAndResourceName_Success()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "cache-name";

            Utility.ValidateResourceGroupAndResourceName(resourceGroup, name);
        }
    }
}
