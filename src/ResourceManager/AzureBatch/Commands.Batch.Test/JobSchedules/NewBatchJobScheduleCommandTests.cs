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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.JobSchedules
{
    public class NewBatchJobScheduleCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchJobScheduleCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchJobScheduleCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchJobScheduleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchJobScheduleParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testJobSchedule";

            // Don't go to the service on an Add CloudJobSchedule call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobScheduleAddParameter,
                JobScheduleAddOptions,
                AzureOperationHeaderResponse<JobScheduleAddHeaders>>();
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchJobScheduleParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testJobSchedule";
            cmdlet.DisplayName = "display name";
            Models.PSJobSpecification jobSpec = new Models.PSJobSpecification()
            {
                DisplayName = "job display name",
                CommonEnvironmentSettings = new List<Models.PSEnvironmentSetting>()
                {
                    new Models.PSEnvironmentSetting("common1", "val1"),
                    new Models.PSEnvironmentSetting("common2", "val2")
                },
                JobManagerTask = new Models.PSJobManagerTask("job manager", "cmd /c echo job manager"),
                JobPreparationTask = new Models.PSJobPreparationTask("cmd /c echo job prep"),
                JobReleaseTask = new Models.PSJobReleaseTask("cmd /c echo job release"),
                PoolInformation = new Models.PSPoolInformation()
                {
                    PoolId = "myPool"
                }
            };
            cmdlet.JobSpecification = jobSpec;
            Models.PSSchedule schedule = new Models.PSSchedule()
            {
                DoNotRunAfter = DateTime.Now.AddYears(1),
                DoNotRunUntil = DateTime.Now.AddDays(1),
                RecurrenceInterval = TimeSpan.FromDays(1),
                StartWindow = TimeSpan.FromHours(1)
            };
            cmdlet.Schedule = schedule;
            cmdlet.Metadata = new Dictionary<string, string>();
            cmdlet.Metadata.Add("meta1", "value1");
            cmdlet.Metadata.Add("meta2", "value2");

            JobScheduleAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobScheduleAddParameter,
                JobScheduleAddOptions,
                AzureOperationHeaderResponse<JobScheduleAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.DisplayName, requestParameters.DisplayName);
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
            Assert.Equal(cmdlet.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.Metadata[requestParameters.Metadata[0].Name], requestParameters.Metadata[0].Value);
            Assert.Equal(cmdlet.Metadata[requestParameters.Metadata[1].Name], requestParameters.Metadata[1].Value);
        }
    }
}
