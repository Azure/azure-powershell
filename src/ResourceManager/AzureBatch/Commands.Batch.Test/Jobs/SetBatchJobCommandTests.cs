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
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
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
        public void AutoCompletionSettingIsSentToService()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

<<<<<<< HEAD
            CloudJob cloudJob = new Azure.Batch.Protocol.Models.CloudJob(
                id: "job-id",
                poolInfo: new Azure.Batch.Protocol.Models.PoolInformation(),
                onAllTasksComplete: (Azure.Batch.Protocol.Models.OnAllTasksComplete?)OnAllTasksComplete.TerminateJob);

            cmdlet.Job = new PSCloudJob(BatchTestHelpers.CreateFakeBoundJob(context, cloudJob));
            cmdlet.Job.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
=======
            var cloudJob = new Azure.Batch.Protocol.Models.CloudJob(
                id: "job-id",
                poolInfo: new Azure.Batch.Protocol.Models.PoolInformation(),
                onAllTasksComplete: OnAllTasksComplete.TerminateJob);

            cmdlet.Job = new PSCloudJob(BatchTestHelpers.CreateFakeBoundJob(context, cloudJob));
>>>>>>> hotfix/batch-tests-fixup

            RequestInterceptor interceptor =
                BatchTestHelpers.CreateFakeServiceResponseInterceptor<JobUpdateParameter, JobUpdateOptions, AzureOperationHeaderResponse<JobUpdateHeaders>>(
                    new AzureOperationHeaderResponse<JobUpdateHeaders>(),
                    request =>
                        {
<<<<<<< HEAD
                            Assert.Equal((OnAllTasksComplete)request.Parameters.OnAllTasksComplete, OnAllTasksComplete.TerminateJob);
=======
                            Assert.Equal(request.Parameters.OnAllTasksComplete, OnAllTasksComplete.TerminateJob);
>>>>>>> hotfix/batch-tests-fixup
                        });

            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };

            // Verify that no exceptions occur
            cmdlet.ExecuteCmdlet();
    }
}
