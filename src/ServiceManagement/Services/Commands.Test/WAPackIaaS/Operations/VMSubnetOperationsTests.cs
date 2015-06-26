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
    
    public class VMSubnetOperationsTests
    {
        private const string baseURI = "/VMSubnets";

        private const string subnet = "192.168.1.0/24";
        private const string vmNetworkName = "VNet01";
        private const string vmSubnetName = "VMSubnet01";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldCreateOneVMSubnet()
        {
            var mockChannel = new MockRequestChannel();

            var vmSubnetToCreate = new VMSubnet()
            {
                Name = vmSubnetName,
                VMNetworkName = vmNetworkName,
                VMNetworkId = Guid.Empty,
                Subnet = subnet,
                StampId = Guid.Empty
            };

            var vmSubnetToReturn = new VMSubnet()
            {
                Name = vmSubnetName,
                VMNetworkName = vmNetworkName,
                VMNetworkId = Guid.Empty,
                Subnet = subnet,
                StampId = Guid.Empty
            };

            mockChannel.AddReturnObject(vmSubnetToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var vmSubnetOperations = new VMSubnetOperations(new WebClientFactory(new Subscription(), mockChannel));
            var createdVMSubnet = vmSubnetOperations.Create(vmSubnetToCreate, out jobOut);

            Assert.NotNull(createdVMSubnet);
            Assert.True(createdVMSubnet is VMSubnet);
            Assert.Equal(vmSubnetToReturn.Name, createdVMSubnet.Name);
            Assert.Equal(vmSubnetToReturn.VMNetworkName, createdVMSubnet.VMNetworkName);
            Assert.Equal(vmSubnetToReturn.VMNetworkId, createdVMSubnet.VMNetworkId);
            Assert.Equal(vmSubnetToReturn.Subnet, createdVMSubnet.Subnet);
            Assert.Equal(vmSubnetToReturn.StampId, createdVMSubnet.StampId);

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
        public void ShouldReturnOneVMSubnet()
        {
            const string subnet = "192.168.1.0/24";
            const string vmNetworkName = "VNet01";
            const string vmSubnetName = "VMSubnet01";

            var mockChannel = new MockRequestChannel();

            var vmSubnetToCreate = new VMSubnet()
            {
                Name = vmSubnetName,
                VMNetworkName = vmNetworkName,
                VMNetworkId = Guid.Empty,
                Subnet = subnet,
                StampId = Guid.Empty
            };
            mockChannel.AddReturnObject(vmSubnetToCreate);

            var vmSubnetOperations = new VMSubnetOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readStaticIPAddressPool = vmSubnetOperations.Read(new VMNetwork() { StampId = Guid.Empty, ID = Guid.Empty });
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
        public void ShouldDeleteVMSubnet()
        {
            const string subnet = "192.168.1.0/24";
            const string vmNetworkName = "VNet01";
            const string vmSubnetName = "VMSubnet01";

            var mockChannel = new MockRequestChannel();

            var existingVMSubnet = new VMSubnet()
            {
                Name = vmSubnetName,
                VMNetworkName = vmNetworkName,
                VMNetworkId = Guid.Empty,
                Subnet = subnet,
                StampId = Guid.Empty
            };
            mockChannel.AddReturnObject(new Cloud() { StampId = Guid.NewGuid() });
            mockChannel.AddReturnObject(existingVMSubnet, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var vmSubnetOperations = new VMSubnetOperations(new WebClientFactory(new Subscription(), mockChannel));
            vmSubnetOperations.Delete(Guid.Empty, out jobOut);

            Assert.Equal(2, mockChannel.ClientRequests.Count);
            Assert.Equal(HttpMethod.Delete.ToString(), mockChannel.ClientRequests[1].Item1.Method);

            // Check the URI
            var requestURI = mockChannel.ClientRequests[1].Item1.Address.AbsolutePath;
            Assert.Equal("/Clouds", mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(baseURI, mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1).Remove(requestURI.IndexOf('(') - 1));
        }
    }
}
