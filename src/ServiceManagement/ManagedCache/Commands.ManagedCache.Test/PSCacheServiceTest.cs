// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ManagedCache.Models;
using Microsoft.Azure.Management.ManagedCache.Models;
using Xunit;

namespace Microsoft.Azure.Commands.ManagedCache.Test
{
    public class PSCacheServiceTest
    {
        [Fact]
        public void InitializeAllFieldsFromResponseObject()
        {
            //Arrange
            string testState = "Started";
            string testSubState = "Active";
            string testName = "Dummy";
            string testLocation = "West US";
            CacheServiceSkuType testSku = CacheServiceSkuType.Premium;
            int testSkuCount = 2; //This will be mapped to 10GB display value 
            string expectedMemoryInfo = "10GB";

            CloudServiceResource resource = new CloudServiceResource();
            resource.State = testState;
            resource.SubState = testSubState;
            resource.Name = testName;

            IntrinsicSettings intrinsic = new IntrinsicSettings();
            IntrinsicSettings.CacheServiceInput cacheInput = new IntrinsicSettings.CacheServiceInput();
            intrinsic.CacheServiceInputSection = cacheInput;
            resource.IntrinsicSettingsSection = intrinsic;
            cacheInput.Location = testLocation;
            cacheInput.SkuCount = testSkuCount;
            cacheInput.SkuType = testSku;
           
            //Act
            PSCacheService service = new PSCacheService(resource);

            //Assert
            Assert.Equal(testSubState, service.State);
            Assert.Equal(testName, service.Name);
            Assert.Equal(testLocation, service.Location);
            Assert.Equal(expectedMemoryInfo, service.Memory);
            Assert.Equal(testSku, service.Sku);
        }
    }
}
