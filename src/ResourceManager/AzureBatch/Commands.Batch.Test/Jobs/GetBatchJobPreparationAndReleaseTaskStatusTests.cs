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
using System.Threading.Tasks;
using Microsoft.Azure.Batch.Common;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Jobs
{
    public class GetBatchJobPreparationAndReleaseTaskStatusTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private readonly GetBatchJobPreparationAndReleaseTaskStatusCommand cmdlet;
        private readonly Mock<BatchClient> batchClientMock;
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchJobPreparationAndReleaseTaskStatusTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchJobPreparationAndReleaseTaskStatusCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchJobPreparationAndReleaseTaskStatusTest()
        {
            // Setup cmdlet to list jobs without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "job-1";

            const string poolId = "Test";
            // Build some PrepAndReleaseTaskStatuses instead of querying the service on a List CloudJobs call
            var taskExecutionInformationList = new List<ProxyModels.JobPreparationAndReleaseTaskExecutionInformation>
            {
                new ProxyModels.JobPreparationAndReleaseTaskExecutionInformation(
                    poolId: poolId,
                    nodeId: Guid.NewGuid().ToString(),
                    jobPreparationTaskExecutionInfo: new ProxyModels.JobPreparationTaskExecutionInformation(
                        retryCount: 0,
                        state: ProxyModels.JobPreparationTaskState.Completed,
                        startTime: DateTime.UtcNow),
                    jobReleaseTaskExecutionInfo: new ProxyModels.JobReleaseTaskExecutionInformation(
                        state: ProxyModels.JobReleaseTaskState.Completed,
                        startTime: DateTime.UtcNow))
            };
            var response = BatchTestHelpers.CreateJobPreparationAndReleaseTaskStatusListResponse(taskExecutionInformationList);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.JobListPreparationAndReleaseTaskStatusOptions,
                AzureOperationResponse<IPage<ProxyModels.JobPreparationAndReleaseTaskExecutionInformation>, ProxyModels.JobListPreparationAndReleaseTaskStatusHeaders>>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            var pipeline = new List<PSJobPreparationAndReleaseTaskExecutionInformation>();
            commandRuntimeMock.Setup(r =>
                    r.WriteObject(It.IsAny<PSJobPreparationAndReleaseTaskExecutionInformation>()))
                .Callback<object>(j => pipeline.Add((PSJobPreparationAndReleaseTaskExecutionInformation)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed jobs to the pipeline
            Assert.Single(pipeline);
            foreach (PSJobPreparationAndReleaseTaskExecutionInformation j in pipeline)
            {
                Assert.Equal(poolId, j.PoolId);
                Assert.NotNull(j.JobPreparationTaskExecutionInformation);
                Assert.NotNull(j.JobReleaseTaskExecutionInformation);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchJobPreparationAndReleaseTaskStatusTestMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list jobs without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "test";
            cmdlet.Filter = null;
            const int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            const string poolId = "Test";
            // Build some PrepAndReleaseTaskStatuses instead of querying the service on a List CloudJobs call
            var taskExecutionInformationList = new List<ProxyModels.JobPreparationAndReleaseTaskExecutionInformation>();
            const int countReturned = 3;
            for (int i = 0; i < countReturned; i++)
            {
                var jpjrInfo = new ProxyModels.JobPreparationAndReleaseTaskExecutionInformation(
                    poolId: poolId,
                    nodeId: Guid.NewGuid().ToString(),
                    jobPreparationTaskExecutionInfo: new ProxyModels.JobPreparationTaskExecutionInformation(
                        retryCount: 0,
                        state: ProxyModels.JobPreparationTaskState.Completed,
                        startTime: DateTime.UtcNow),
                    jobReleaseTaskExecutionInfo: new ProxyModels.JobReleaseTaskExecutionInformation(
                        state: ProxyModels.JobReleaseTaskState.Completed,
                        startTime: DateTime.UtcNow));
                taskExecutionInformationList.Add(jpjrInfo);
            }

            var response = BatchTestHelpers.CreateJobPreparationAndReleaseTaskStatusListResponse(taskExecutionInformationList);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.JobListPreparationAndReleaseTaskStatusOptions,
                AzureOperationResponse<IPage<ProxyModels.JobPreparationAndReleaseTaskExecutionInformation>, ProxyModels.JobListPreparationAndReleaseTaskStatusHeaders>>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            var pipeline = new List<PSJobPreparationAndReleaseTaskExecutionInformation>();
            commandRuntimeMock.Setup(r =>
                    r.WriteObject(It.IsAny<PSJobPreparationAndReleaseTaskExecutionInformation>()))
                .Callback<object>(j => pipeline.Add((PSJobPreparationAndReleaseTaskExecutionInformation)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(countReturned, pipeline.Count);
        }
    }
}
