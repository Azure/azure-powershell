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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.VMs
{
    public class GetBatchVMCommandTests
    {
        private GetBatchVMCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchVMCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchVMCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchVMTest()
        {
            // Setup cmdlet to get a vm by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.Name = "vm1";
            cmdlet.Filter = null;

            // Build a vm instead of querying the service on a GetTVM call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetTVMRequest)
                {
                    GetTVMResponse response = BatchTestHelpers.CreateGetTVMResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVM> pipeline = new List<PSVM>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSVM>())).Callback<object>(v => pipeline.Add((PSVM)v));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the vm returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchVMsByODataFilterTest()
        {
            // Setup cmdlet to list vms using an OData filter.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.Name = null;
            cmdlet.Filter = "state -eq 'idle'";

            string[] namesOfConstructedVMs = new[] { "vm1", "vm2" };

            // Build some vms instead of querying the service on a ListTVMs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMsRequest)
                {
                    ListTVMsResponse response = BatchTestHelpers.CreateListTVMsResponse(namesOfConstructedVMs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVM> pipeline = new List<PSVM>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVM>()))
                .Callback<object>(v => pipeline.Add((PSVM)v));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed vms to the pipeline
            Assert.Equal(2, pipeline.Count);
            int vmCount = 0;
            foreach (PSVM v in pipeline)
            {
                Assert.True(namesOfConstructedVMs.Contains(v.Name));
                vmCount++;
            }
            Assert.Equal(namesOfConstructedVMs.Length, vmCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchVMsWithoutFiltersTest()
        {
            // Setup cmdlet to list vms without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Pool = BatchTestHelpers.CreatePSCloudPool();
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedVMs = new[] { "vm1", "vm2", "vm3" };

            // Build some vms instead of querying the service on a ListTVMs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMsRequest)
                {
                    ListTVMsResponse response = BatchTestHelpers.CreateListTVMsResponse(namesOfConstructedVMs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVM> pipeline = new List<PSVM>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVM>()))
                .Callback<object>(v => pipeline.Add((PSVM)v));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed vms to the pipeline
            Assert.Equal(3, pipeline.Count);
            int vmCount = 0;
            foreach (PSVM v in pipeline)
            {
                Assert.True(namesOfConstructedVMs.Contains(v.Name));
                vmCount++;
            }
            Assert.Equal(namesOfConstructedVMs.Length, vmCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListVMsMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list vms without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Pool = BatchTestHelpers.CreatePSCloudPool();
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedVMs = new[] { "vm1", "vm2", "vm3" };

            // Build some vms instead of querying the service on a ListTVMs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMsRequest)
                {
                    ListTVMsResponse response = BatchTestHelpers.CreateListTVMsResponse(namesOfConstructedVMs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVM> pipeline = new List<PSVM>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVM>()))
                .Callback<object>(v => pipeline.Add((PSVM)v));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(namesOfConstructedVMs.Length, pipeline.Count);
        }
    }
}
