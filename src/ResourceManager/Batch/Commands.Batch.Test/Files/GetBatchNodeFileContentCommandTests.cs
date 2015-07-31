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
using System.IO;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class GetBatchNodeFileContentCommandTests
    {
        private GetBatchNodeFileContentCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchNodeFileContentCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchNodeFileContentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByTaskParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;
            cmdlet.DestinationPath = null;

            string fileName = "stdout.txt";

            // Don't go to the service on a Get NodeFile call or Get NodeFile Properties call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<NodeFileGetParameters, NodeFileGetResponse> fileRequest = baseRequest as 
                BatchRequest<NodeFileGetParameters, NodeFileGetResponse>;

                if (fileRequest != null)
                {
                    fileRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        NodeFileGetResponse response = new NodeFileGetResponse();
                        Task<NodeFileGetResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
                else
                {
                    BatchRequest<NodeFileGetPropertiesParameters, NodeFileGetPropertiesResponse> propRequest =
                        (BatchRequest<NodeFileGetPropertiesParameters, NodeFileGetPropertiesResponse>)baseRequest;

                    propRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        NodeFileGetPropertiesResponse response = BatchTestHelpers.CreateNodeFileGetPropertiesResponse(cmdlet.Name);
                        Task<NodeFileGetPropertiesResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            using (MemoryStream memStream = new MemoryStream())
            {
                // Don't hit the file system during unit tests
                cmdlet.DestinationStream = memStream;

                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

                // Fill required task details
                cmdlet.JobId = "job-1";
                cmdlet.TaskId = "task";
                cmdlet.Name = fileName;

                // Verify no exceptions occur
                cmdlet.ExecuteCmdlet();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByComputeNodeContentParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = null;
            cmdlet.ComputeNodeId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;
            cmdlet.DestinationPath = null;

            string fileName = "startup\\stdout.txt";

            // Don't go to the service on a Get NodeFile call or Get NodeFile Properties call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<NodeFileGetParameters, NodeFileGetResponse> fileRequest = baseRequest as
                BatchRequest<NodeFileGetParameters, NodeFileGetResponse>;

                if (fileRequest != null)
                {
                    fileRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        NodeFileGetResponse response = new NodeFileGetResponse();
                        Task<NodeFileGetResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
                else
                {
                    BatchRequest<NodeFileGetPropertiesParameters, NodeFileGetPropertiesResponse> propRequest =
                        (BatchRequest<NodeFileGetPropertiesParameters, NodeFileGetPropertiesResponse>)baseRequest;

                    propRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        NodeFileGetPropertiesResponse response = BatchTestHelpers.CreateNodeFileGetPropertiesResponse(cmdlet.Name);
                        Task<NodeFileGetPropertiesResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            using (MemoryStream memStream = new MemoryStream())
            {
                // Don't hit the file system during unit tests
                cmdlet.DestinationStream = memStream;

                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

                // Fill required compute node details
                cmdlet.PoolId = "pool";
                cmdlet.ComputeNodeId = "computeNode1";
                cmdlet.Name = fileName;

                // Verify no exceptions occur
                cmdlet.ExecuteCmdlet();
            }
        }
    }
}
