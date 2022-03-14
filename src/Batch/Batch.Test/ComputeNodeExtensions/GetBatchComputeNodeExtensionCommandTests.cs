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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodeExtensions
{
    public class GetBatchComputeNodeExtensionCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchComputeNodeExtensionCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchComputeNodeExtensionCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchComputeNodeExtensionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeExtensionTest()
        {
            string extensionName = "testExtension";
            string publisher = "testPublisher";
            string type = "testType";

            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "testComputeNode";
            cmdlet.Name = extensionName;

            VMExtension extension = new VMExtension(extensionName, publisher, type);

            // Build an extension instead of querying the service on a Get ComputeNodeExtension call
            AzureOperationResponse<ProxyModels.NodeVMExtension, ProxyModels.ComputeNodeExtensionGetHeaders> response = BatchTestHelpers.CreateComputeNodeExtensionGetResponse(extension);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeExtensionGetOptions,
                AzureOperationResponse<ProxyModels.NodeVMExtension, ProxyModels.ComputeNodeExtensionGetHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeVMExtension> pipeline = new List<PSNodeVMExtension>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSNodeVMExtension>())).Callback<object>(c => pipeline.Add((PSNodeVMExtension)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the compute node returned from the OM to the pipeline
            Assert.Single(pipeline);
            
            PSVMExtension pipelineExtension = pipeline[0].VmExtension;
            Assert.NotNull(pipelineExtension);
            Assert.Equal("testExtension", pipelineExtension.Name);
            Assert.Equal("testPublisher", pipelineExtension.Publisher);
            Assert.Equal("testType", pipelineExtension.Type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeExtensionODataTest()
        {
            string extensionName = "testExtension";
            string publisher = "testPublisher";
            string type = "testType";

            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "testComputeNode";
            cmdlet.Name = extensionName;
            cmdlet.Select = "ExtensionName,Publisher";

            VMExtension extension = new VMExtension(extensionName, publisher, type);

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            AzureOperationResponse<ProxyModels.NodeVMExtension, ProxyModels.ComputeNodeExtensionGetHeaders> getResponse = BatchTestHelpers.CreateComputeNodeExtensionGetResponse(extension);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeExtensionGetOptions,
                AzureOperationResponse<ProxyModels.NodeVMExtension, ProxyModels.ComputeNodeExtensionGetHeaders>>(getResponse);

            string requestSelect = null;

            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.ComputeNodeExtensionGetOptions options = (ProxyModels.ComputeNodeExtensionGetOptions)request.Options;
                requestSelect = options.Select;

                return Task.FromResult(response);
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchComputeNodeExtensionsTest()
        {
            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "testComputeNode";

            int count = 5;

            // Build an extension instead of querying the service on a Get ComputeNodeExtension call
            AzureOperationResponse<IPage<ProxyModels.NodeVMExtension>, ProxyModels.ComputeNodeExtensionListHeaders> response = BatchTestHelpers.CreateComputeNodeExtensionListResponse(CreateTestExtensions(count));
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeExtensionListOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeVMExtension>, ProxyModels.ComputeNodeExtensionListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeVMExtension> pipeline = new List<PSNodeVMExtension>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSNodeVMExtension>())).Callback<object>(c => pipeline.Add((PSNodeVMExtension)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the compute node returned from the OM to the pipeline
            Assert.Equal(count, pipeline.Count);
            for (int i = 1; i <= count; i++)
            {
                PSVMExtension extension = pipeline[i-1].VmExtension;
                Assert.Equal($"testExtension{i}", extension.Name);
                Assert.Equal($"testPublisher{i}", extension.Publisher);
                Assert.Equal($"testType{i}", extension.Type);
            }
        }

        private IEnumerable<VMExtension> CreateTestExtensions(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return new VMExtension($"testExtension{i}", $"testPublisher{i}", $"testType{i}");
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchComputeNodeExtensionsWithMaxCountTest()
        {
            int maxCount = 3;

            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "testComputeNode";
            cmdlet.MaxCount = maxCount;

            int count = 5;

            // Build an extension instead of querying the service on a Get ComputeNodeExtension call
            AzureOperationResponse<IPage<ProxyModels.NodeVMExtension>, ProxyModels.ComputeNodeExtensionListHeaders> response = BatchTestHelpers.CreateComputeNodeExtensionListResponse(CreateTestExtensions(count));
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeExtensionListOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeVMExtension>, ProxyModels.ComputeNodeExtensionListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeVMExtension> pipeline = new List<PSNodeVMExtension>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSNodeVMExtension>())).Callback<object>(c => pipeline.Add((PSNodeVMExtension)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the compute node returned from the OM to the pipeline
            Assert.Equal(maxCount, pipeline.Count);
            for (int i = 1; i <= maxCount; i++)
            {
                PSVMExtension extension = pipeline[i - 1].VmExtension;
                Assert.Equal($"testExtension{i}", extension.Name);
                Assert.Equal($"testPublisher{i}", extension.Publisher);
                Assert.Equal($"testType{i}", extension.Type);
            }
        }
    }
}
