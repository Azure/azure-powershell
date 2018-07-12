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
    using Xunit;
    using System;
    using System.Linq;
    using System.IO;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    namespace Version2016_04_preview
    {
        public class ComputeManagementClientShould
        {
            public ComputeManagementClientShould()
            {
                HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            }

            [Fact]
            [Trait(Category.RunType, Category.CheckIn)]
            public void ListVirtualMachine()
            {
                using (var context = MockContext.Start(this.GetType().FullName))
                {
                    var client = context.GetServiceClient<ComputeManagementClient>();
                    var vmClient = client.VirtualMachines;
                    var vms = vmClient.ListAll().ToList();
                    Assert.True(vms.Count > 0);
                }
            }

            [Fact]
            [Trait(Category.RunType, Category.CheckIn)]
            public void ListVirtualMachineSizes()
            {
                using (var context = MockContext.Start(this.GetType().FullName))
                {
                    var client = context.GetServiceClient<ComputeManagementClient>();
                    var vmSizeClient = client.VirtualMachineSizes;
                    var vmSizes = vmSizeClient.List("WestUs").ToList();
                    Assert.True(vmSizes.Count > 0);
                }
            }

            [Fact]
            [Trait(Category.RunType, Category.CheckIn)]
            public void ListVirtualMachineImagePublishers()
            {
                using (var context = MockContext.Start(this.GetType().FullName))
                {
                    var client = context.GetServiceClient<ComputeManagementClient>();
                    var vmImagesClient = client.VirtualMachineImages;
                    var vmImagePublisers = vmImagesClient.ListPublishers("WestUs").ToList();
                    Assert.True(vmImagePublisers.Count > 0);
                }
            }

            [Fact]
            [Trait(Category.RunType, Category.CheckIn)]
            public void ListDisks()
            {
                using (var context = MockContext.Start(this.GetType().FullName))
                {
                    var client = context.GetServiceClient<ComputeManagementClient>();
                    var disksClient = client.Disks;
                    var disks = disksClient.List().ToList();
                    Assert.True(disks.Count > 0);
                }
            }
        }
    }
}
