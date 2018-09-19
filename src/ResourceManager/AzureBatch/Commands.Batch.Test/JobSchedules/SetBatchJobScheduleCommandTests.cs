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

namespace Microsoft.Azure.Commands.Batch.Test.JobSchedules
{
    public class SetBatchJobScheduleCommandTests
    {
        private SetBatchJobScheduleCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchJobScheduleCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchJobScheduleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchJobScheduleParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobSchedule = new PSCloudJobSchedule(BatchTestHelpers.CreateFakeBoundJobSchedule(context));

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobScheduleUpdateParameter,
                JobScheduleUpdateOptions,
                AzureOperationHeaderResponse<JobScheduleUpdateHeaders>>();
            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };

            // Verify that no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchJobScheduleParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.JobSchedule = new PSCloudJobSchedule(BatchTestHelpers.CreateFakeBoundJobSchedule(context));

            // Make changes to the job schedule
            PSJobSpecification jobSpec = new PSJobSpecification()
            {
                DisplayName = "job display name",
                CommonEnvironmentSettings = new List<PSEnvironmentSetting>()
                {
                    new PSEnvironmentSetting("common1", "val1"),
                    new PSEnvironmentSetting("common2", "val2")
                },
                JobManagerTask = new PSJobManagerTask("job manager", "cmd /c echo job manager"),
                JobPreparationTask = new PSJobPreparationTask("cmd /c echo job prep"),
                JobReleaseTask = new PSJobReleaseTask("cmd /c echo job release"),
                PoolInformation = new PSPoolInformation()
                {
                    PoolId = "myPool"
                }
            };
            cmdlet.JobSchedule.JobSpecification = jobSpec;

            PSSchedule schedule = new PSSchedule()
            {
                DoNotRunAfter = DateTime.Now.AddYears(1),
                DoNotRunUntil = DateTime.Now.AddDays(1),
                RecurrenceInterval = TimeSpan.FromDays(1),
                StartWindow = TimeSpan.FromHours(1)
            };
            cmdlet.JobSchedule.Schedule = schedule;

            cmdlet.JobSchedule.Metadata = new List<PSMetadataItem>()
            {
                new PSMetadataItem("metadata1", "value1")
            };

            // Store the request parameters
            JobScheduleUpdateParameter requestParameters = null;
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobScheduleUpdateParameter,
                JobScheduleUpdateOptions,
                AzureOperationHeaderResponse<JobScheduleUpdateHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify that the request parameters contain the updated properties
            Assert.Equal(jobSpec.CommonEnvironmentSettings.Count, requestParameters.JobSpecification.CommonEnvironmentSettings.Count);
            Assert.Equal(jobSpec.CommonEnvironmentSettings[0].Name, requestParameters.JobSpecification.CommonEnvironmentSettings[0].Name);
            Assert.Equal(jobSpec.CommonEnvironmentSettings[0].Value, requestParameters.JobSpecification.CommonEnvironmentSettings[0].Value);
            Assert.Equal(jobSpec.CommonEnvironmentSettings[1].Name, requestParameters.JobSpecification.CommonEnvironmentSettings[1].Name);
            Assert.Equal(jobSpec.CommonEnvironmentSettings[1].Value, requestParameters.JobSpecification.CommonEnvironmentSettings[1].Value);
            Assert.Equal(jobSpec.JobManagerTask.Id, requestParameters.JobSpecification.JobManagerTask.Id);
            Assert.Equal(jobSpec.JobPreparationTask.CommandLine, requestParameters.JobSpecification.JobPreparationTask.CommandLine);
            Assert.Equal(jobSpec.JobReleaseTask.CommandLine, requestParameters.JobSpecification.JobReleaseTask.CommandLine);
            Assert.Equal(jobSpec.PoolInformation.PoolId, requestParameters.JobSpecification.PoolInfo.PoolId);
            Assert.Equal(schedule.DoNotRunAfter, requestParameters.Schedule.DoNotRunAfter);
            Assert.Equal(schedule.DoNotRunUntil, requestParameters.Schedule.DoNotRunUntil);
            Assert.Equal(schedule.RecurrenceInterval, requestParameters.Schedule.RecurrenceInterval);
            Assert.Equal(schedule.StartWindow, requestParameters.Schedule.StartWindow);
            Assert.Equal(cmdlet.JobSchedule.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.JobSchedule.Metadata[0].Name, requestParameters.Metadata[0].Name);
            Assert.Equal(cmdlet.JobSchedule.Metadata[0].Value, requestParameters.Metadata[0].Value);
        }
    }
}
