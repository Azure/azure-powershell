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

using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Compute.ScenarioTest;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Test
{
    public class GetAzureVMSizeCommandTests
    {
        private MemoryDataStore _dataStore;
        private MockCommandRuntime _commandRuntimeMock;
        
        private Mock<IVirtualMachineSizesOperations> vmSizesMock;

        public GetAzureVMSizeCommandTests()
        {
            _dataStore = new MemoryDataStore();
            _commandRuntimeMock = new MockCommandRuntime();
        }
        private IPage<T> GetPagableType<T>(List<T> collection)
        {
            var pagableResult = new Page<T>();
            pagableResult.SetItemValue<T>(collection);
            return pagableResult;
        }

        private void SetupListForVirtualMachineSizeAsync(string name, List<VirtualMachineSize> result)
        {
            vmSizesMock.Setup(f => f.ListWithHttpMessagesAsync(name, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<IPage<VirtualMachineSize>>
                {
                    Body = GetPagableType(result)
                }));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetVirtualMachineSizesFromLocation()
        {
            var computeManagementClientMock = new Mock<IComputeManagementClient>();
            vmSizesMock = new Mock<IVirtualMachineSizesOperations>();
            computeManagementClientMock.Setup(f => f.VirtualMachineSizes).Returns(vmSizesMock.Object);
            var vmSizeList = new List<VirtualMachineSize>
            {
                new VirtualMachineSize
                {
                    Name = "1",
                    MaxDataDiskCount = 1,
                    MemoryInMB = 1,
                    NumberOfCores = 1,
                    OsDiskSizeInMB = 1,
                    ResourceDiskSizeInMB = 1
                },
                new VirtualMachineSize
                {
                    Name = "2",
                    MaxDataDiskCount = 2,
                    MemoryInMB = 2,
                    NumberOfCores = 2,
                    OsDiskSizeInMB = 2,
                    ResourceDiskSizeInMB = 2
                }
            };
            SetupListForVirtualMachineSizeAsync("westus", vmSizeList);

            var progressLoggerMock = new Mock<Action<string>>();
            var errorLoggerMock = new Mock<Action<string>>();
            var computeClient = new ComputeClient(computeManagementClientMock.Object)
            {
                VerboseLogger = progressLoggerMock.Object,
                ErrorLogger = errorLoggerMock.Object
            };

            var profile = new AzureRMProfile(_dataStore);
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.Context = new AzureContext(new AzureSubscription(), new AzureAccount(), profile.Environments["foo"]);
            GetAzureVMSizeCommand cmdlet = new GetAzureVMSizeCommand
            {
                ComputeClient = computeClient,
                Location = "westus"
            };
            cmdlet.DataStore = _dataStore;
            cmdlet.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlet.DefaultProfile = profile;

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            var runtime = cmdlet.GetCommandRuntimeMock() as MockCommandRuntime;
            Assert.True(runtime.OutputPipeline.Count == vmSizeList.Count);
            for (int i = 0; i < runtime.OutputPipeline.Count; i++)
            {
                var item = runtime.OutputPipeline[i] as VirtualMachineSize;
                Assert.True(item.Name == vmSizeList[i].Name);
                Assert.True(item.MaxDataDiskCount == vmSizeList[i].MaxDataDiskCount);
                Assert.True(item.MemoryInMB == vmSizeList[i].MemoryInMB);
                Assert.True(item.NumberOfCores == vmSizeList[i].NumberOfCores);
                Assert.True(item.OsDiskSizeInMB == vmSizeList[i].OsDiskSizeInMB);
                Assert.True(item.ResourceDiskSizeInMB == vmSizeList[i].ResourceDiskSizeInMB);
            }
            
            return;
        }
    }
}
