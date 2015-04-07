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
using System.Collections.Generic;
using System.Linq;
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
    
    public class VMNetworkOperationsTest
    {
        private const string baseURI = "/VMNetworks";

        private const string vNetName = "VNet01";
        private const string vNetDescription = "VNet01 - Description";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldCreateOneVMNetwork()
        {
            Guid VNetLogicalNetworkId = Guid.NewGuid();
            Guid StampId= Guid.NewGuid();

            var mockChannel = new MockRequestChannel();

            var vmNetworkToCreate = new VMNetwork()
            {
                Name = vNetName,
                Description = vNetDescription,
                LogicalNetworkId = VNetLogicalNetworkId,
                StampId = StampId,            
            };

            var vmNetworkToReturn = new VMNetwork()
            {
                Name = vNetName,
                Description = vNetDescription,
                LogicalNetworkId = VNetLogicalNetworkId,
                StampId = StampId,            
            };

            mockChannel.AddReturnObject(vmNetworkToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var VMNetworkOperations = new VMNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var createdVMNetwork = VMNetworkOperations.Create(vmNetworkToCreate, out jobOut);

            Assert.NotNull(createdVMNetwork);
            Assert.Equal(vmNetworkToReturn.Name, vmNetworkToCreate.Name);
            Assert.Equal(vmNetworkToReturn.Description, vmNetworkToCreate.Description);
            Assert.Equal(vmNetworkToReturn.LogicalNetworkId, vmNetworkToCreate.LogicalNetworkId);
            Assert.Equal(vmNetworkToReturn.StampId, vmNetworkToCreate.StampId);

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
        public void ShouldReturnOneVMNetworkByID()
        {
            var mockChannel = new MockRequestChannel();

            var vmNetworkToReturn = new VMNetwork()
            {
                Name = vNetName,
                Description = vNetDescription,
                LogicalNetworkId = Guid.Empty,
                StampId = Guid.Empty,
            };
            mockChannel.AddReturnObject(vmNetworkToReturn);

            var VMNetworkOperations = new VMNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readVMNetwork = VMNetworkOperations.Read(Guid.Empty);
            Assert.Equal(Guid.Empty, readVMNetwork.ID);

            // Check the URI
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(baseURI, mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneVMNetworkByName()
        {
            var mockChannel = new MockRequestChannel();

            var vmNetworkToReturn = new VMNetwork()
            {
                Name = vNetName,
                Description = vNetDescription,
                LogicalNetworkId = Guid.Empty,
                StampId = Guid.Empty,
            };
            mockChannel.AddReturnObject(vmNetworkToReturn);

            var filter = new Dictionary<string, string>()
            {
                {"Name", vNetName}
            };
            var VMNetworkOperations = new VMNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readVMNetwork = VMNetworkOperations.Read(filter);
            Assert.Equal(1, readVMNetwork.Count);
            Assert.Equal(vNetName, readVMNetwork.First().Name);

            // Check the URI
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(baseURI, mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnMultipleVMNetworks()
        {
            var mockChannel = new MockRequestChannel();
            var vmNetworkList = new List<object>
            {
                new VMNetwork { Name = vNetName, Description = vNetDescription },
                new VMNetwork { Name = vNetName, Description = vNetDescription }
            };
            mockChannel.AddReturnObject(vmNetworkList);

            var VMNetworkOperations = new VMNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readVMNetwork = VMNetworkOperations.Read();

            Assert.Equal(2, readVMNetwork.Count);
            Assert.True(readVMNetwork.All(vmNetwork => vmNetwork.Name == vNetName));

            // Check the URI
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(baseURI, mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldDeleteStaticVMNetwork()
        {
            var mockChannel = new MockRequestChannel();

            var existingVmNetwork = new VMNetwork()
            {
                Name = vNetName,
                Description = vNetDescription,
                LogicalNetworkId = Guid.Empty,
                StampId = Guid.Empty,
            };
            mockChannel.AddReturnObject(new Cloud() { StampId = Guid.NewGuid() });
            mockChannel.AddReturnObject(existingVmNetwork, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var VMNetworkOperations = new VMNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            VMNetworkOperations.Delete(Guid.Empty, out jobOut);

            Assert.Equal(2, mockChannel.ClientRequests.Count);
            Assert.Equal(HttpMethod.Delete.ToString(), mockChannel.ClientRequests[1].Item1.Method);

            // Check the URI
            var requestURI = mockChannel.ClientRequests[1].Item1.Address.AbsolutePath;
            Assert.Equal("/Clouds", mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(baseURI, mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1).Remove(requestURI.IndexOf('(') - 1));
        }
    }
}
