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
using System.Linq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class GetBatchNodeFileCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchNodeFileCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchNodeFileCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchNodeFileCommand()
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
            cmdlet.Task = null;
            cmdlet.Filter = null;

            // Build a NodeFile instead of querying the service on a List NodeFile call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders> response = BatchTestHelpers.CreateNodeFileListByTaskResponse(new string[] { });
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromTaskOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();

            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.Task = new PSCloudTask("task", "cmd /c dir /s");

            // Verify that we don't get an argument exception. We should get an InvalidOperationException though since the task is unbound
            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByTaskTest()
        {
            // Setup cmdlet to get a Task file by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";
            cmdlet.Name = "stdout.txt";
            cmdlet.Filter = null;

            // Build a NodeFile instead of querying the service on a Get NodeFile Properties call
            AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders> response = BatchTestHelpers.CreateNodeFileGetPropertiesByTaskResponse();
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.FileGetNodeFilePropertiesFromTaskOptions,
                AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSNodeFile>())).Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the node file returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeFilesByTaskByODataFilterTest()
        {
            // Setup cmdlet to list node files using an OData filter. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'std')";

            string[] namesOfConstructedNodeFiles = new[] { "stdout.txt", "stderr.txt" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders> response =
                BatchTestHelpers.CreateNodeFileListByTaskResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromTaskOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed node files to the pipeline
            Assert.Equal(2, pipeline.Count);
            int taskCount = 0;
            foreach (PSNodeFile f in pipeline)
            {
                Assert.True(namesOfConstructedNodeFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedNodeFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeFilesByTaskWithoutFiltersTest()
        {
            // Setup cmdlet to list Task files without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedNodeFiles = new[] { "stdout.txt", "stderr.txt", "wd" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders> response =
                BatchTestHelpers.CreateNodeFileListByTaskResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromTaskOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>,
                ProxyModels.FileListFromTaskHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed node files to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSNodeFile f in pipeline)
            {
                Assert.True(namesOfConstructedNodeFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedNodeFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListNodeFilesByTaskMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list node files and a max count. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedNodeFiles = new[] { "stdout.txt", "stderr.txt", "wd" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders> response =
                BatchTestHelpers.CreateNodeFileListByTaskResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromTaskOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(namesOfConstructedNodeFiles.Length, pipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByComputeNodeParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = null;
            cmdlet.ComputeNodeId = null;
            cmdlet.Name = null;
            cmdlet.ComputeNode = null;
            cmdlet.Filter = null;

            // Build a NodeFile instead of querying the service on a List NodeFile call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders> response =
                BatchTestHelpers.CreateNodeFileListByComputeNodeResponse(new string[] { });
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromComputeNodeOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolId = "pool";
            cmdlet.ComputeNodeId = "computeNode1";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByComputeNodeTest()
        {
            // Setup cmdlet to get a Task file by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "pool";
            cmdlet.ComputeNodeId = "vm1";
            cmdlet.Name = "startup\\stdout.txt";
            cmdlet.Filter = null;

            // Build a NodeFile instead of querying the service on a Get NodeFile Properties call
            AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders> response = BatchTestHelpers.CreateNodeFileGetPropertiesByComputeNodeResponse();
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.FileGetNodeFilePropertiesFromComputeNodeOptions,
                AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSNodeFile>())).Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the node file returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeFilesByComputeNodeByODataFilterTest()
        {
            // Setup cmdlet to list vm files using an OData filter. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "pool";
            cmdlet.ComputeNodeId = "computeNode1";
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'startup')";

            string[] namesOfConstructedNodeFiles = new[] { "startup\\stdout.txt", "startup\\stderr.txt" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders> response =
                BatchTestHelpers.CreateNodeFileListByComputeNodeResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromComputeNodeOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>,
                ProxyModels.FileListFromComputeNodeHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed node files to the pipeline
            Assert.Equal(2, pipeline.Count);
            int taskCount = 0;
            foreach (PSNodeFile f in pipeline)
            {
                Assert.True(namesOfConstructedNodeFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedNodeFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeFilesByComputeNodeWithoutFiltersTest()
        {
            // Setup cmdlet to list vm files without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "pool";
            cmdlet.ComputeNodeId = "computeNode1";
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedNodeFiles = new[] { "startup", "workitems", "shared" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders> response =
                BatchTestHelpers.CreateNodeFileListByComputeNodeResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromComputeNodeOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>,
                ProxyModels.FileListFromComputeNodeHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed node files to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSNodeFile f in pipeline)
            {
                Assert.True(namesOfConstructedNodeFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedNodeFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListNodeFilesByComputeNodeMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list vm files and a max count. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "pool";
            cmdlet.ComputeNodeId = "computeNode1";
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedNodeFiles = new[] { "startup", "workitems", "shared" };

            // Build some NodeFiles instead of querying the service on a List NodeFiles call
            AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders> response =
                BatchTestHelpers.CreateNodeFileListByComputeNodeResponse(namesOfConstructedNodeFiles);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                ProxyModels.FileListFromComputeNodeOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeFile>,
                ProxyModels.FileListFromComputeNodeHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeFile> pipeline = new List<PSNodeFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeFile>()))
                .Callback<object>(f => pipeline.Add((PSNodeFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(namesOfConstructedNodeFiles.Length, pipeline.Count);
        }
    }
}
