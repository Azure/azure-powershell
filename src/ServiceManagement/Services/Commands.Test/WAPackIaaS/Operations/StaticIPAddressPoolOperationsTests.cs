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

using System;
using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Operations
{
    
    public class StaticIPAddressPoolOperationsTests
    {
        private const string baseURI = "/StaticIPAddressPools";

        private const string ipAddressRangeStart = "192.168.1.2";
        private const string ipAddressRangeEnd = "192.168.1.3";
        private const string staticIPAddressPoolName = "StaticIPAddressPool01";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldCreateOneStaticIPAddressPool()
        {
            var mockChannel = new MockRequestChannel();

            var staticIPAddressPoolToCreate = new StaticIPAddressPool()
            {
                Name = staticIPAddressPoolName,
                VMSubnetId = Guid.Empty,
                IPAddressRangeStart = ipAddressRangeStart,
                IPAddressRangeEnd = ipAddressRangeEnd,
                StampId = Guid.Empty
            };

            var staticIPAddressPoolToReturn = new StaticIPAddressPool()
            {
                Name = staticIPAddressPoolName,
                IPAddressRangeStart = ipAddressRangeStart,
                IPAddressRangeEnd = ipAddressRangeEnd,
                StampId = Guid.Empty
            };

            mockChannel.AddReturnObject(staticIPAddressPoolToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(new WebClientFactory(new Subscription(), mockChannel));
            var createdStaticIPAddressPool = staticIPAddressPoolOperations.Create(staticIPAddressPoolToCreate, out jobOut);

            Assert.NotNull(createdStaticIPAddressPool);
            Assert.True(createdStaticIPAddressPool is StaticIPAddressPool);
            Assert.Equal(staticIPAddressPoolToReturn.Name, createdStaticIPAddressPool.Name);
            Assert.Equal(staticIPAddressPoolToReturn.VMSubnetId, createdStaticIPAddressPool.VMSubnetId);
            Assert.Equal(staticIPAddressPoolToReturn.IPAddressRangeStart, createdStaticIPAddressPool.IPAddressRangeStart);
            Assert.Equal(staticIPAddressPoolToReturn.IPAddressRangeEnd, createdStaticIPAddressPool.IPAddressRangeEnd);
            Assert.Equal(staticIPAddressPoolToReturn.StampId, createdStaticIPAddressPool.StampId);

            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(HttpMethod.Post.ToString(), requestList[0].Item1.Method);

            // Check the URI
            Assert.Equal(baseURI, mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneStaticIPAddressPool()
        {
            var mockChannel = new MockRequestChannel();

            var staticIPAddressPoolToCreate = new StaticIPAddressPool()
            {
                Name = staticIPAddressPoolName,
                VMSubnetId = Guid.Empty,
                IPAddressRangeStart = ipAddressRangeStart,
                IPAddressRangeEnd = ipAddressRangeEnd,
                StampId = Guid.Empty
            };
            mockChannel.AddReturnObject(staticIPAddressPoolToCreate);

            var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readStaticIPAddressPool = staticIPAddressPoolOperations.Read(new VMSubnet(){ StampId = Guid.Empty, ID = Guid.Empty });
            Assert.Equal(1, readStaticIPAddressPool.Count);

            // Check the URI
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(baseURI, mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldDeleteStaticIPAddressPool()
        {
            var mockChannel = new MockRequestChannel();

            var existingStaticIPAddressPool = new StaticIPAddressPool()
            {
                Name = staticIPAddressPoolName,
                VMSubnetId = Guid.Empty,
                IPAddressRangeStart = ipAddressRangeStart,
                IPAddressRangeEnd = ipAddressRangeEnd,
                StampId = Guid.Empty
            };
            mockChannel.AddReturnObject(new Cloud() { StampId = Guid.NewGuid() });
            mockChannel.AddReturnObject(existingStaticIPAddressPool, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(new WebClientFactory(new Subscription(), mockChannel));
            staticIPAddressPoolOperations.Delete(Guid.Empty, out jobOut);

            Assert.Equal(2, mockChannel.ClientRequests.Count);
            Assert.Equal(HttpMethod.Delete.ToString(), mockChannel.ClientRequests[1].Item1.Method);

            // Check the URI
            var requestURI = mockChannel.ClientRequests[1].Item1.Address.AbsolutePath;
            Assert.Equal("/Clouds", mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(baseURI, mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1).Remove(requestURI.IndexOf('(') - 1));
        }
    }
}
