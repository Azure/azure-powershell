using Microsoft.Azure.Commands.ApiManagement.Helpers;
using Microsoft.Azure.Commands.ApiManagement.Models;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.Test.UnitTests
{
    public class PsApiManagementTests
    {
        public PsApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void MapSku_AllowsStandardV2()
        {
            Assert.Equal(SkuType.StandardV2, Mappers.MapSku(SkuType.StandardV2));
        }

        [Fact]
        public void MapPsApiManagement_UsesStandardV2Sku()
        {
            var apiManagement = new PsApiManagement(new ApiManagementServiceResource
            {
                Location = "eastus",
                PublisherEmail = "admin@contoso.com",
                PublisherName = "Contoso",
                VirtualNetworkType = VirtualNetworkType.None,
                Sku = new ApiManagementServiceSkuProperties(SkuType.Developer, 1)
            })
            {
                Sku = SkuType.StandardV2,
                Capacity = 1
            };

            var mappedResource = Mappers.MapPsApiManagement(apiManagement);

            Assert.Equal(SkuType.StandardV2, mappedResource.Sku.Name);
            Assert.Equal(1, mappedResource.Sku.Capacity);
        }
    }
}
