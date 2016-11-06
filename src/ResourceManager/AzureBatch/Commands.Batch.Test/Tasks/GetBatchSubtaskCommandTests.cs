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
using Microsoft.Azure.Batch.Protocol.BatchRequests;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Subtasks
{
    public class GetBatchSubtaskCommandTests
    {
        private GetBatchSubtaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchSubtaskCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchSubtaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchSubtaskParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.TaskId = null;

            AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult, ProxyModels.TaskListSubtasksHeaders> response = BatchTestHelpers.CreateCloudTaskListSubtasksResponse();
            // Build a SubtaskInformation instead of querying the service on a List Subtasks call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskListSubtasksOptions,
                AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult,
                ProxyModels.TaskListSubtasksHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task1";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchSubtasksWithoutFiltersTest()
        {
            // Setup cmdlet to list Subtasks without filters. Use WorkItemName and JobName.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task1";

            int[] idsOfConstructedSubtasks = new[] { 1, 2, 3 };

            // Build some SubtaskInformation objects instead of querying the service on a List Subtasks call
            AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult, ProxyModels.TaskListSubtasksHeaders> response = BatchTestHelpers.CreateCloudTaskListSubtasksResponse(idsOfConstructedSubtasks);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskListSubtasksOptions,
                AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult,
                ProxyModels.TaskListSubtasksHeaders>>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSSubtaskInformation> pipeline = new List<PSSubtaskInformation>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSSubtaskInformation>()))
                .Callback<object>(s => pipeline.Add((PSSubtaskInformation)s));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Subtasks to the pipeline
            Assert.Equal(3, pipeline.Count);
            int SubtaskCount = 0;
            foreach (PSSubtaskInformation s in pipeline)
            {
                Assert.True(idsOfConstructedSubtasks.Contains(s.Id.Value));
                SubtaskCount++;
            }
            Assert.Equal(idsOfConstructedSubtasks.Length, SubtaskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchSubtasksMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list Subtasks with a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task1";
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            int[] idsOfConstructedSubtasks = new[] { 1, 2, 3 };

            // Build some SubtaskInformation objects instead of querying the service on a List Subtasks call
            AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult, ProxyModels.TaskListSubtasksHeaders> response = BatchTestHelpers.CreateCloudTaskListSubtasksResponse(idsOfConstructedSubtasks);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskListSubtasksOptions,
                AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult,
                ProxyModels.TaskListSubtasksHeaders>>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSSubtaskInformation> pipeline = new List<PSSubtaskInformation>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSSubtaskInformation>()))
                .Callback<object>(s => pipeline.Add((PSSubtaskInformation)s));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedSubtasks.Length, pipeline.Count);
        }
    }
}
