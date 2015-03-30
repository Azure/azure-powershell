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
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Operations
{
    
    public class VirtualMachineOperationsTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-Negative")]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnEmptyOnNoResult()
        {
            var vmOperations = new VirtualMachineOperations(new WebClientFactory(
                new Subscription(),
                MockRequestChannel.Create()));

            Assert.False(vmOperations.Read().Any());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneVM()
        {
            var vmOperations = new VirtualMachineOperations(new WebClientFactory(
                new Subscription(),
                MockRequestChannel.Create()
                    .AddReturnObject(new VirtualMachine { Name = "vm1", ID = Guid.NewGuid() })));

            Assert.Equal(1, vmOperations.Read().Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-Negative")]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldThrowGetByIdNoResult()
        {
            var vmOperations = new VirtualMachineOperations(new WebClientFactory(
                new Subscription(),
                MockRequestChannel.Create()));

            Assert.Throws<WAPackOperationException>(()=>vmOperations.Read(Guid.NewGuid()));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneVMGetById()
        {
            var expectedVmId = Guid.NewGuid();
            var vmOperations = new VirtualMachineOperations(new WebClientFactory(
                new Subscription(),
                MockRequestChannel.Create()
                    .AddReturnObject(new VirtualMachine { Name = "vm1", ID = expectedVmId })));

            var vm = vmOperations.Read(expectedVmId);
            Assert.Equal(expectedVmId, vm.ID);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnMultipleVMsGetByName()
        {
            const string expectedVmName = "myVM";
            var expectedVmIds = new[] { Guid.NewGuid(), Guid.NewGuid() };
            var vmOperations = new VirtualMachineOperations(new WebClientFactory(
                new Subscription(),
                new MockRequestChannel()
                    .AddReturnObject(new List<object>
                        {new VirtualMachine { Name = expectedVmName, ID = expectedVmIds[1] },
                        new VirtualMachine { Name = expectedVmName, ID = expectedVmIds[0] }})));

            var vmList = vmOperations.Read(expectedVmName);
            Assert.Equal(expectedVmIds.Length, vmList.Count);
            Assert.True(vmList.All(vm => vm.Name == expectedVmName));
            Assert.Equal(expectedVmIds.OrderBy(g => g), vmList.Select(v => v.ID).OrderBy(g => g).ToArray());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void CreateVMFromVHD()
        {
            var mockChannel = new MockRequestChannel();
            
            var testCloud = new Cloud { ID = Guid.NewGuid(), StampId = Guid.NewGuid() };
            mockChannel.AddReturnObject(testCloud);

            var vmToCreate = new VirtualMachine { VirtualHardDiskId = Guid.NewGuid(), Name = "Test" };
            var vmToReturn = new VirtualMachine
                {
                    ID = Guid.NewGuid(),
                    Name = vmToCreate.Name,
                    CloudId = testCloud.ID,
                    StampId = testCloud.StampId
                };
            
            mockChannel.AddReturnObject(vmToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            var vmOps = new VirtualMachineOperations(new WebClientFactory(new Subscription(), mockChannel));
            
            Guid? jobOut;
            var resultVM = vmOps.Create(vmToCreate, out jobOut);

            //Check the results that client returns
            Assert.NotNull(resultVM);
            Assert.True(resultVM is VirtualMachine);
            Assert.Equal(resultVM.ID, vmToReturn.ID);
            Assert.Equal(resultVM.Name, vmToReturn.Name);
            Assert.Equal(resultVM.CloudId, vmToReturn.CloudId);
            Assert.Equal(resultVM.StampId, vmToReturn.StampId);

            //Check the requests that the client made
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(requestList.Count, 2);
            Assert.Equal(requestList[1].Item1.Method, HttpMethod.Post.ToString());
            Assert.True(requestList[1].Item1.RequestUri.ToString().TrimEnd(new[]{'/'}).EndsWith("/VirtualMachines"));

            var sentVM = mockChannel.DeserializeClientPayload<VirtualMachine>(requestList[1].Item2);
            Assert.NotNull(sentVM);
            Assert.True(sentVM.Count == 1);
            Assert.Equal(sentVM[0].CloudId, testCloud.ID);
            Assert.Equal(sentVM[0].StampId, testCloud.StampId);
            Assert.Equal(sentVM[0].Name, vmToCreate.Name);
            Assert.Equal(sentVM[0].VirtualHardDiskId, vmToCreate.VirtualHardDiskId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void CreateVMFromTemplate()
        {
            var mockChannel = new MockRequestChannel();

            var testCloud = new Cloud { ID = Guid.NewGuid(), StampId = Guid.NewGuid() };
            mockChannel.AddReturnObject(testCloud);

            var vmToCreate = new VirtualMachine { VMTemplateId = Guid.NewGuid(), Name = "Test" };
            var vmToReturn = new VirtualMachine
            {
                ID = Guid.NewGuid(),
                Name = vmToCreate.Name,
                CloudId = testCloud.ID,
                StampId = testCloud.StampId
            };
            mockChannel.AddReturnObject(vmToReturn, new WebHeaderCollection { "x-ms-request-id:" + Guid.NewGuid() });

            var vmOps = new VirtualMachineOperations(new WebClientFactory(new Subscription(), mockChannel));

            Guid? jobOut;
            var resultVM = vmOps.Create(vmToCreate, out jobOut);

            //Check the results that client returns
            Assert.NotNull(resultVM);
            Assert.True(resultVM is VirtualMachine);
            Assert.Equal(resultVM.ID, vmToReturn.ID);
            Assert.Equal(resultVM.Name, vmToReturn.Name);
            Assert.Equal(resultVM.CloudId, vmToReturn.CloudId);
            Assert.Equal(resultVM.StampId, vmToReturn.StampId);

            //Check the requests that the client made
            var requestList = mockChannel.ClientRequests;
            Assert.Equal(requestList.Count, 2);
            Assert.Equal(requestList[1].Item1.Method, HttpMethod.Post.ToString());
            Assert.True(requestList[1].Item1.RequestUri.ToString().TrimEnd(new[] { '/' }).EndsWith("/VirtualMachines"));

            var sentVM = mockChannel.DeserializeClientPayload<VirtualMachine>(requestList[1].Item2);
            Assert.NotNull(sentVM);
            Assert.True(sentVM.Count == 1);
            Assert.Equal(sentVM[0].CloudId, testCloud.ID);
            Assert.Equal(sentVM[0].StampId, testCloud.StampId);
            Assert.Equal(sentVM[0].Name, vmToCreate.Name);
            Assert.Equal(sentVM[0].VMTemplateId, vmToCreate.VMTemplateId);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-Negative")]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void VmCreateShouldThrowIfNoVhdAndNoTemplateSupplied()
        {
            var channel = new MockRequestChannel();
            var testCloud = new Cloud { ID = Guid.NewGuid(), StampId = Guid.NewGuid() };
            channel.AddReturnObject(testCloud);

            var sub = new Subscription();
            var vmOps = new VirtualMachineOperations(new WebClientFactory(sub, channel));

            var vmToCreate = new VirtualMachine {Name = "Test"};

            Guid? jobOut;
            Assert.Throws<WAPackOperationException>(() => vmOps.Create(vmToCreate, out jobOut));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-Negative")]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void VmCreateShouldThrowWhenNoObjectReturned()
        {
            var mockChannel = new MockRequestChannel();

            var testCloud = new Cloud { ID = Guid.NewGuid(), StampId = Guid.NewGuid() };
            mockChannel.AddReturnObject(testCloud);

            var vmOps = new VirtualMachineOperations(new WebClientFactory(new Subscription(), mockChannel));

            var vmToCreate = new VirtualMachine { VirtualHardDiskId = Guid.NewGuid(), Name = "Test" };

            Guid? jobOut;
            Assert.Throws<WAPackOperationException>(() => vmOps.Create(vmToCreate, out jobOut));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-Negative")]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void VmUpdateShouldThrowWhenNoObjectReturned()
        {
            var mockChannel = new MockRequestChannel();

            var vmOps = new VirtualMachineOperations(new WebClientFactory(new Subscription(), mockChannel));

            var vmToUpdate = new VirtualMachine { VirtualHardDiskId = Guid.NewGuid(), Name = "Test" };

            Guid? jobOut;
            Assert.Throws<WAPackOperationException>(() => vmOps.Update(vmToUpdate, out jobOut));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void DeleteVM()
        {
            var sub = new Subscription();
            var channel = new MockRequestChannel();

            //Response to client getting /Clouds (client needs stampId, gets it from clouds)
            var testCloud = new Cloud { ID = Guid.NewGuid(), StampId = Guid.NewGuid() };
            channel.AddReturnObject(testCloud);

            //Response to the DELETE
            channel.AddReturnObject(null, new WebHeaderCollection {"x-ms-request-id:" + Guid.NewGuid()});

            var vmOps = new VirtualMachineOperations(new WebClientFactory(sub, channel));

            Guid toDelete = Guid.NewGuid();
            Guid? jobOut;

            vmOps.Delete(toDelete, out jobOut);

            //Check the requests the client generated
            Assert.Equal(channel.ClientRequests.Count, 2);
            Assert.Equal(channel.ClientRequests[1].Item1.Method, HttpMethod.Delete.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void StartVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Start(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Start", mockChannel, testVM);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void StopVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Stop(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Stop", mockChannel, testVM);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void RestartVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Restart(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Reset", mockChannel, testVM);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShutdownVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Shutdown(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Shutdown", mockChannel, testVM);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void SuspendVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Suspend(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Suspend", mockChannel, testVM);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ResumeVM()
        {
            var mockChannel = new MockRequestChannel();

            VirtualMachineOperations vmOperations;
            var testVM = InitVirtualMachineOperation(mockChannel, out vmOperations);

            Guid? jobOut;
            vmOperations.Resume(testVM.ID, out jobOut);

            CheckVirtualMachineOperationResult("Resume", mockChannel, testVM);
        }

        private static VirtualMachine InitVirtualMachineOperation(MockRequestChannel mockChannel, out VirtualMachineOperations vmOperations)
        {
            //Cloud for return value of first request (client gets cloud to get stampId)
            var testCloud = new Cloud {ID = Guid.NewGuid(), StampId = Guid.NewGuid()};
            mockChannel.AddReturnObject(testCloud);

            //VM for return value of second request (client updates VM with operation)
            var testVM = new VirtualMachine {ID = Guid.NewGuid(), StampId = testCloud.StampId};
            mockChannel.AddReturnObject(testVM, new WebHeaderCollection {"x-ms-request-id:" + Guid.NewGuid()});

            var factory = new WebClientFactory(new Subscription(), mockChannel);
            vmOperations = new VirtualMachineOperations(factory);

            return testVM;
        }

        private static void CheckVirtualMachineOperationResult(string operation, MockRequestChannel mockChannel, VirtualMachine testVM)
        {
            var requests = mockChannel.ClientRequests;
            Assert.Equal(requests.Count, 2);
            Assert.Equal(requests[1].Item1.Method, HttpMethod.Put.ToString());

            var clientSentVM = mockChannel.DeserializeClientPayload<VirtualMachine>(requests[1].Item2);
            Assert.NotNull(clientSentVM);
            Assert.True(clientSentVM.Count == 1);
            Assert.Equal(testVM.ID, clientSentVM[0].ID);
            Assert.Equal(testVM.StampId, clientSentVM[0].StampId);
            Assert.Equal(clientSentVM[0].Operation, operation);
        }
    }
}
