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
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodes
{
    public class StartBatchComputeNodeServiceLogUploadCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private StartBatchComputeNodeServiceLogUploadCommand startComputeNodeServiceLogUploadCommand;
        private GetBatchComputeNodeCommand getComputeNodeCommand;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private const string fakeUrl = "https://containerUrl?sv==";

        public StartBatchComputeNodeServiceLogUploadCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();

            getComputeNodeCommand = new GetBatchComputeNodeCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };

            startComputeNodeServiceLogUploadCommand = new StartBatchComputeNodeServiceLogUploadCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenStartBatchComputeNodeServiceLogUploadCommandIsCalledWithPoolIdAndComputeNodeId_ShouldSucceed()
        {
            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            startComputeNodeServiceLogUploadCommand.BatchContext = context;
            startComputeNodeServiceLogUploadCommand.PoolId = "pool";
            startComputeNodeServiceLogUploadCommand.ComputeNodeId = "tvm";
            startComputeNodeServiceLogUploadCommand.ContainerUrl = fakeUrl;
            startComputeNodeServiceLogUploadCommand.StartTime = DateTime.UtcNow;

            const int numberOfFilesUploaded = 2;
            const string virtualDirectoryName = "pool1/tvm";

            // Build a compute node instead of querying the service on a Get ComputeNode call
            AzureOperationResponse<ProxyModels.UploadBatchServiceLogsResult, ProxyModels.ComputeNodeUploadBatchServiceLogsHeaders> response = 
                BatchTestHelpers.CreateComputeNodeServiceLogsAddResponse(numberOfFilesUploaded, virtualDirectoryName);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeUploadBatchServiceLogsOptions,
                AzureOperationResponse<ProxyModels.UploadBatchServiceLogsResult, ProxyModels.ComputeNodeUploadBatchServiceLogsHeaders>>(response);

            startComputeNodeServiceLogUploadCommand.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            PSStartComputeNodeServiceLogUploadResult result = null;
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSStartComputeNodeServiceLogUploadResult>())).Callback<object>(c => result = (PSStartComputeNodeServiceLogUploadResult)c);

            startComputeNodeServiceLogUploadCommand.ExecuteCmdlet();

            Assert.NotNull(result);
            Assert.Equal(result.NumberOfFilesUploaded, numberOfFilesUploaded);
            Assert.Equal(result.VirtualDirectoryName, virtualDirectoryName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenStartBatchComputeNodeServiceLogUploadCommandIsCalledWithComputeNode_ShouldSucceed()
        {
            // First get a fake tvm
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            getComputeNodeCommand.BatchContext = context;
            getComputeNodeCommand.PoolId = "Pool1";
            getComputeNodeCommand.Id = null;
            getComputeNodeCommand.Filter = null;

            AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders> response1 =
                BatchTestHelpers.CreateComputeNodeListResponse(new[] { "tvm1" });

            RequestInterceptor interceptor1 = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeListOptions,
                AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>>(response1);

            var computeNodes = new List<PSComputeNode>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSComputeNode>()))
                .Callback<object>(c => computeNodes.Add((PSComputeNode) c)); 
            
            getComputeNodeCommand.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor1 };

            getComputeNodeCommand.ExecuteCmdlet();

            // test StartBatchComputeNodeServiceLogUploadCommand
            startComputeNodeServiceLogUploadCommand.BatchContext = context;
            startComputeNodeServiceLogUploadCommand.ComputeNode = computeNodes[0];
            startComputeNodeServiceLogUploadCommand.ContainerUrl = fakeUrl;

            var utcNow = DateTime.UtcNow;
            startComputeNodeServiceLogUploadCommand.StartTime = utcNow.AddDays(-1);
            startComputeNodeServiceLogUploadCommand.EndTime = utcNow;

            const int numberOfFilesUploaded = 2;
            const string virtualDirectoryName = "pool1/tvm";

            AzureOperationResponse<ProxyModels.UploadBatchServiceLogsResult, ProxyModels.ComputeNodeUploadBatchServiceLogsHeaders> response2 =
                BatchTestHelpers.CreateComputeNodeServiceLogsAddResponse(numberOfFilesUploaded, virtualDirectoryName);

            RequestInterceptor interceptor2 = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeUploadBatchServiceLogsOptions,
                AzureOperationResponse<ProxyModels.UploadBatchServiceLogsResult, ProxyModels.ComputeNodeUploadBatchServiceLogsHeaders>>(response2);

            startComputeNodeServiceLogUploadCommand.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor2 };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            PSStartComputeNodeServiceLogUploadResult result = null;
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSStartComputeNodeServiceLogUploadResult>())).Callback<object>(c => result = (PSStartComputeNodeServiceLogUploadResult)c);

            startComputeNodeServiceLogUploadCommand.ExecuteCmdlet();

            Assert.NotNull(result);
            Assert.Equal(result.NumberOfFilesUploaded, numberOfFilesUploaded);
            Assert.Equal(result.VirtualDirectoryName, virtualDirectoryName);
        }
    }
}
