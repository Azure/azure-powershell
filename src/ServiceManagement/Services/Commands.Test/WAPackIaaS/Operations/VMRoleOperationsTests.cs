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
    
    public class VMRoleOperationsTests
    {
        private const string genericBaseUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles";
        private const string specificBaseUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles/{1}";
        private const string vmsUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles/{1}/VMs";

        private const string vmRoleName = "VMRole01";
        private const string vmRoleLabel = "VMRole01-Label";
        private const string cloudServiceName = "CloudService01";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldCreateOneVMRole()
        {
            var mockChannel = new MockRequestChannel();

            var vmRoleToCreate = new VMRole 
            {
                Name = vmRoleName,
                Label = vmRoleLabel
            };

            var vmRoleToReturn = new VMRole
            {
                Name = vmRoleName,
                Label = vmRoleLabel,
            };
            mockChannel.AddReturnObject(vmRoleToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            var createdVMRole = vmRoleOperations.Create(cloudServiceName, vmRoleToCreate, out jobOut);

            Assert.NotNull(createdVMRole);
            Assert.Equal(vmRoleToReturn.Name, createdVMRole.Name);
            Assert.Equal(vmRoleToReturn.Label, createdVMRole.Label);

            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(HttpMethod.Post.ToString(), requestList[0].Item1.Method);

            // Check the URI (for Azure consistency)
            Assert.Equal(String.Format(genericBaseUri,cloudServiceName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneVMRole()
        {
            var mockChannel = new MockRequestChannel();
            mockChannel.AddReturnObject(new VMRole { Name = vmRoleName, Label = vmRoleLabel });

            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            Assert.Equal(1, vmRoleOperations.Read(cloudServiceName).Count);

            // Check the URI (for Azure consistency)
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(2, requestList.Count);
            Assert.Equal(String.Format(genericBaseUri, cloudServiceName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(String.Format(vmsUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneVMRoleByName()
        {
            var mockChannel = new MockRequestChannel();
            mockChannel.AddReturnObject(new VMRole { Name = vmRoleName, Label = vmRoleLabel });

            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            Assert.Equal(vmRoleName, vmRoleOperations.Read(cloudServiceName, vmRoleName).Name);

            // Check the URI (for Azure consistency)
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(2, requestList.Count);
            Assert.Equal(String.Format(specificBaseUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(String.Format(vmsUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnMultipleVMRole()
        {
            const string vmRoleName01 = "VMRole01";
            const string vmRoleName02 = "VMRole02";
            const string vmRoleLabel01 = "VMRole01-Label";
            const string vmRoleLabel02 = "VMRole02-Label";
            const string cloudServiceName = "CloudService01";

            var mockChannel = new MockRequestChannel();
            var vmRoles = new List<object>
            {
                new VMRole { Name = vmRoleName01, Label = vmRoleLabel01 },
                new VMRole { Name = vmRoleName02, Label = vmRoleLabel02 }
            };
            mockChannel.AddReturnObject(vmRoles);

            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            var vmRoleList = vmRoleOperations.Read(cloudServiceName);

            Assert.Equal(vmRoles.Count, vmRoleList.Count);
            Assert.True(vmRoleList[0].Name == vmRoleName01);
            Assert.True(vmRoleList[1].Name == vmRoleName02);

            // Check the URI (for Azure consistency)
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(3, requestList.Count);
            Assert.Equal(String.Format(genericBaseUri, cloudServiceName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(String.Format(vmsUri, cloudServiceName, vmRoleName01), mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(String.Format(vmsUri, cloudServiceName, vmRoleName02), mockChannel.ClientRequests[2].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnMultipleVMRoleVMs()
        {
            var mockChannel = new MockRequestChannel();
            var vmRole = new VMRole 
            {
                Name = vmRoleName,
                Label = vmRoleLabel
            };
            var vmList = new List<VM> { new VM() { Id = Guid.Empty }, new VM() { Id = Guid.Empty } };
            vmRole.VMs.Load(vmList);
            mockChannel.AddReturnObject(vmRole);

            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            var readVMRole = vmRoleOperations.Read(cloudServiceName, vmRoleName);
            Assert.Equal(vmRoleName, readVMRole.Name);
            Assert.Equal(vmList.Count, readVMRole.VMs.Count);

            // Check the URI (for Azure consistency)
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(2, requestList.Count);
            Assert.Equal(String.Format(specificBaseUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
            Assert.Equal(String.Format(vmsUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[1].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldDeleteVMRole()
        {
            var mockChannel = new MockRequestChannel();
            mockChannel.AddReturnObject(new VMRole { Name = vmRoleName, Label = vmRoleLabel }, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            Guid? jobOut;
            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), mockChannel));
            vmRoleOperations.Delete(cloudServiceName, vmRoleName, out jobOut);

            Assert.Equal(mockChannel.ClientRequests.Count, 1);
            Assert.Equal(HttpMethod.Delete.ToString(), mockChannel.ClientRequests[0].Item1.Method);

            // Check the URI (for Azure consistency)
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(1, requestList.Count);
            Assert.Equal(String.Format(specificBaseUri, cloudServiceName, vmRoleName), mockChannel.ClientRequests[0].Item1.Address.AbsolutePath.Substring(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        [Trait("Type", "WAPackIaaS-Negative")]
        public void ShouldReturnEmptyOnNoResult()
        {
            var vmRoleOperations = new VMRoleOperations(new WebClientFactory(new Subscription(), MockRequestChannel.Create()));
            Assert.False(vmRoleOperations.Read().Any());
        }
    }
}
