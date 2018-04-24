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



namespace Microsoft.Azure.Commands.Common.Compute.Tests
{
    using Compute.Version2016_04_preview;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using System.Linq;

    namespace Version2016_04_preview
    {
        public class ComputeManagementClientShould
        {
            private IComputeManagementClient Client {get;} 

            public ComputeManagementClientShould()
            {
                var credManager = CredentialManager.FromServicePrincipalEnvVariable();
                Client = new ComputeManagementClient(credManager.TokenCredentials)
                {
                    SubscriptionId = credManager.SubscriptionId
                };
            }

            [Fact]
            [Trait(Category.RunType, Category.LiveOnly)]
            public void ListVirtualMachine()
            {
                var vmClient = Client.VirtualMachines;
                var vms = vmClient.ListAll().ToList();
                Assert.True(vms.Count > 0);
            }

            [Fact]
            [Trait(Category.RunType, Category.LiveOnly)]
            public void ListVirtualMachineSizes()
            {
                var vmSizeClient = Client.VirtualMachineSizes;
                var vmSizes = vmSizeClient.List("WestUs").ToList();
                Assert.True(vmSizes.Count > 0);
            }

            [Fact]
            [Trait(Category.RunType, Category.LiveOnly)]
            public void ListVirtualMachineImagePublishers()
            {
                var vmImagesClient = Client.VirtualMachineImages;
                var vmImagePublisers = vmImagesClient.ListPublishers("WestUs").ToList();
                Assert.True(vmImagePublisers.Count > 0);
            }

            [Fact]
            [Trait(Category.RunType, Category.LiveOnly)]
            public void ListDisks()
            {
                var disksClient = Client.Disks;
                var disks = disksClient.List().ToList();
                Assert.True(disks.Count > 0);
            }
        }
    }
}
