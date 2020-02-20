﻿using Microsoft.Azure.Commands.RedisCache.Models;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    public class UtilityTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateResourceGroupAndResourceName_InvalidResourceGroup()
        {
            string resourceGroup = "subscriptions/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa/resourceGroups/Default-Storage-NorthEurope";
            string name = "cache-name";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("ResourceGroupName should not contain '/'. Name should be the plain, short name of the resource group, e.g. 'myResourceGroup'. (Not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateResourceGroupAndResourceName_InvalidRedisCacheName_FullName()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "cache-name.redis.cache.windows.net";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("Name should not contain '/' or '.'. Name should be the plain, short name of the redis cache, e.g. 'mycache'. (Not a fully qualified DNS name, and not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateResourceGroupAndResourceName_InvalidRedisCacheName_ID()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "subscriptions/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa/resourceGroups/Default-Storage-NorthEurope/cache-name";

            var ex = Assert.Throws<ArgumentException>(() => Utility.ValidateResourceGroupAndResourceName(resourceGroup, name));
            Assert.Contains("Name should not contain '/' or '.'. Name should be the plain, short name of the redis cache, e.g. 'mycache'. (Not a fully qualified DNS name, and not an Azure resource identifier.)", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateResourceGroupAndResourceName_Success()
        {
            string resourceGroup = "Default-Storage-NorthEurope";
            string name = "cache-name";

            Utility.ValidateResourceGroupAndResourceName(resourceGroup, name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateSize_InvalidSizePremium()
        {
            string sku = "Premium";
            string size = "C1";

            var ex = Assert.Throws<ArgumentException>(() => SizeConverter.ValidateSize(size.ToUpper(), SkuName.Premium.Equals(sku)));
            Assert.Contains("Invalid Size. Example for valid values: For Standard or Basic Sku: (C0, C1, C2, C3, C4, C5, C6), for Premium Sku: (P1, P2, P3, P4, P5)", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateSize_InvalidSizeStandard()
        {
            string sku = "Standard";
            string size = "P1";

            var ex = Assert.Throws<ArgumentException>(() => SizeConverter.ValidateSize(size.ToUpper(), SkuName.Premium.Equals(sku)));
            Assert.Contains("Invalid Size. Example for valid values: For Standard or Basic Sku: (C0, C1, C2, C3, C4, C5, C6), for Premium Sku: (P1, P2, P3, P4, P5)", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateSize_Success()
        {
            string sku = "Premium";
            string size = "P1";

            SizeConverter.ValidateSize(size.ToUpper(), SkuName.Premium.Equals(sku));            
        }
    }
}
