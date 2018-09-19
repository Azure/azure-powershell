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
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using CloudJob = Microsoft.Azure.Batch.Protocol.Models.CloudJob;
using OnAllTasksComplete = Microsoft.Azure.Batch.Common.OnAllTasksComplete;

namespace Microsoft.Azure.Commands.Batch.Test.Jobs
{
    public class SetBatchJobCommandTests
    {
        private SetBatchJobCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchJobCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchJobCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchJobParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Job = new PSCloudJob(BatchTestHelpers.CreateFakeBoundJob(context, new CloudJob(id: "testJob")));

            // Update job
            cmdlet.Job.Constraints = new PSJobConstraints(TimeSpan.FromHours(1), 5);
            cmdlet.Job.PoolInformation = new PSPoolInformation()
            {
                PoolId = "myPool"
            };
            cmdlet.Job.Priority = 2;
            cmdlet.Job.Metadata = new List<PSMetadataItem>()
            {
                new PSMetadataItem("meta1", "value1"),
                new PSMetadataItem("meta2", "value2")
            };

            JobUpdateParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobUpdateParameter,
                JobUpdateOptions,
                AzureOperationHeaderResponse<JobUpdateHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.Job.Constraints.MaxTaskRetryCount, requestParameters.Constraints.MaxTaskRetryCount);
            Assert.Equal(cmdlet.Job.Constraints.MaxWallClockTime, requestParameters.Constraints.MaxWallClockTime);
            Assert.Equal(cmdlet.Job.PoolInformation.PoolId, requestParameters.PoolInfo.PoolId);
            Assert.Equal(cmdlet.Job.Priority, requestParameters.Priority);
            Assert.Equal(cmdlet.Job.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.Job.Metadata[0].Name, requestParameters.Metadata[0].Name);
            Assert.Equal(cmdlet.Job.Metadata[0].Value, requestParameters.Metadata[0].Value);
            Assert.Equal(cmdlet.Job.Metadata[1].Name, requestParameters.Metadata[1].Name);
            Assert.Equal(cmdlet.Job.Metadata[1].Value, requestParameters.Metadata[1].Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AutoCompletionSettingIsSentToService()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            CloudJob cloudJob = new Azure.Batch.Protocol.Models.CloudJob(
                id: "job-id",
                poolInfo: new Azure.Batch.Protocol.Models.PoolInformation(),
                onAllTasksComplete: (Azure.Batch.Protocol.Models.OnAllTasksComplete?)OnAllTasksComplete.TerminateJob);

            cmdlet.Job = new PSCloudJob(BatchTestHelpers.CreateFakeBoundJob(context, cloudJob));
            cmdlet.Job.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;

            RequestInterceptor interceptor =
                BatchTestHelpers.CreateFakeServiceResponseInterceptor<JobUpdateParameter, JobUpdateOptions, AzureOperationHeaderResponse<JobUpdateHeaders>>(
                    new AzureOperationHeaderResponse<JobUpdateHeaders>(),
                    request =>
                    {
                        Assert.Equal(OnAllTasksComplete.TerminateJob, (OnAllTasksComplete)request.Parameters.OnAllTasksComplete);
                    });

            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };

            // Verify that no exceptions occur
            cmdlet.ExecuteCmdlet();
        }
    }
}

