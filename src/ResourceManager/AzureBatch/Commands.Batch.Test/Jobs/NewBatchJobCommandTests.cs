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
using System.Linq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Jobs
{
    public class NewBatchJobCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchJobCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchJobCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchJobCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchJobParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testJob";
            cmdlet.OnAllTasksComplete = Azure.Batch.Common.OnAllTasksComplete.TerminateJob;
            cmdlet.OnTaskFailure = Azure.Batch.Common.OnTaskFailure.PerformExitOptionsJobAction;

            // Don't go to the service on an Add CloudJob call
            var interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<JobAddParameter, JobAddOptions, AzureOperationHeaderResponse<JobAddHeaders>>(
                    new AzureOperationHeaderResponse<JobAddHeaders>(),
                    request =>
                        {
                            Assert.Equal(request.Parameters.OnAllTasksComplete, OnAllTasksComplete.TerminateJob);
                            Assert.Equal(request.Parameters.OnTaskFailure, OnTaskFailure.PerformExitOptionsJobAction);
                        });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchJobParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testJob";
            cmdlet.DisplayName = "display name";
            cmdlet.CommonEnvironmentSettings = new Dictionary<string, string>();
            cmdlet.CommonEnvironmentSettings.Add("commonEnv1", "value1");
            cmdlet.Constraints = new PSJobConstraints(TimeSpan.FromHours(1), 5);
            cmdlet.JobManagerTask = new PSJobManagerTask("job manager", "cmd /c echo job manager");
            cmdlet.JobPreparationTask = new PSJobPreparationTask("cmd /c echo job prep");
            cmdlet.JobReleaseTask = new PSJobReleaseTask("cmd /c echo job release");
            cmdlet.PoolInformation = new PSPoolInformation()
            {
                PoolId = "myPool"
            };
            cmdlet.Priority = 2;
            cmdlet.Metadata = new Dictionary<string, string>();
            cmdlet.Metadata.Add("meta1", "value1");
            cmdlet.Metadata.Add("meta2", "value2");
            cmdlet.UsesTaskDependencies = true;

            JobAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobAddParameter,
                JobAddOptions,
                AzureOperationHeaderResponse<JobAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.DisplayName, requestParameters.DisplayName);
            Assert.Equal(cmdlet.CommonEnvironmentSettings.Count, requestParameters.CommonEnvironmentSettings.Count);
            Assert.Equal(cmdlet.CommonEnvironmentSettings[requestParameters.CommonEnvironmentSettings[0].Name], requestParameters.CommonEnvironmentSettings[0].Value);
            Assert.Equal(cmdlet.Constraints.MaxTaskRetryCount, requestParameters.Constraints.MaxTaskRetryCount);
            Assert.Equal(cmdlet.Constraints.MaxWallClockTime, requestParameters.Constraints.MaxWallClockTime);
            Assert.Equal(cmdlet.JobManagerTask.Id, requestParameters.JobManagerTask.Id);
            Assert.Equal(cmdlet.JobPreparationTask.CommandLine, requestParameters.JobPreparationTask.CommandLine);
            Assert.Equal(cmdlet.JobReleaseTask.CommandLine, requestParameters.JobReleaseTask.CommandLine);
            Assert.Equal(cmdlet.PoolInformation.PoolId, requestParameters.PoolInfo.PoolId);
            Assert.Equal(cmdlet.Priority, requestParameters.Priority);
            Assert.Equal(cmdlet.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.Metadata[requestParameters.Metadata[0].Name], requestParameters.Metadata[0].Value);
            Assert.Equal(cmdlet.Metadata[requestParameters.Metadata[1].Name], requestParameters.Metadata[1].Value);
            Assert.Equal(cmdlet.UsesTaskDependencies, requestParameters.UsesTaskDependencies);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplicationPackageReferencesAreSentToService()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "job-id";
            string applicationId = "foo";
            string applicationVersion = "beta";

            cmdlet.JobManagerTask = new PSJobManagerTask { ApplicationPackageReferences = new[] 
            {
                new PSApplicationPackageReference { ApplicationId = applicationId, Version = applicationVersion} ,
            }};
            
            // Don't go to the service on an Add CloudJob call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<JobAddParameter, JobAddOptions, AzureOperationHeaderResponse<JobAddHeaders>>(
                new AzureOperationHeaderResponse<JobAddHeaders>(),
                request =>
                    {
                        var applicationPackageReference = request.Parameters.JobManagerTask.ApplicationPackageReferences.First();
                        Assert.Equal(applicationId, applicationPackageReference.ApplicationId);
                        Assert.Equal(applicationVersion, applicationPackageReference.Version);
                    });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchJobPoolUserAccountsGetPassedToRequest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testJob";

            PSUserAccount adminUser = new PSUserAccount("admin", "password1", Azure.Batch.Common.ElevationLevel.Admin);
            PSUserAccount nonAdminUser = new PSUserAccount("user2", "password2", Azure.Batch.Common.ElevationLevel.NonAdmin);
            PSUserAccount sshUser = new PSUserAccount("user3", "password3", Azure.Batch.Common.ElevationLevel.Admin, new PSLinuxUserConfiguration(uid: 1, gid:2, sshPrivateKey: "my ssh key"));
            cmdlet.PoolInformation = new PSPoolInformation
            {
                AutoPoolSpecification = new PSAutoPoolSpecification
                {
                    AutoPoolIdPrefix = "prefix",
                    PoolLifetimeOption = Azure.Batch.Common.PoolLifetimeOption.Job,
                    PoolSpecification = new PSPoolSpecification
                    {
                        CloudServiceConfiguration = new PSCloudServiceConfiguration("4", "*"),
                        UserAccounts = new List<PSUserAccount>() { adminUser, nonAdminUser, sshUser }
                    }
                }
            };

            JobAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                JobAddParameter,
                JobAddOptions,
                AzureOperationHeaderResponse<JobAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(3, cmdlet.PoolInformation.AutoPoolSpecification.PoolSpecification.UserAccounts.Count);
            Assert.Equal(adminUser.Name, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[0].Name);
            Assert.Equal(adminUser.Password, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[0].Password);
            Assert.Equal(adminUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[0].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(nonAdminUser.Name, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[1].Name);
            Assert.Equal(nonAdminUser.Password, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[1].Password);
            Assert.Equal(nonAdminUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[1].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(sshUser.Name, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].Name);
            Assert.Equal(sshUser.Password, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].Password);
            Assert.Equal(sshUser.ElevationLevel.ToString().ToLowerInvariant(),
                requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].ElevationLevel.ToString().ToLowerInvariant());
            Assert.Equal(sshUser.LinuxUserConfiguration.Uid, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].LinuxUserConfiguration.Uid);
            Assert.Equal(sshUser.LinuxUserConfiguration.Gid, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].LinuxUserConfiguration.Gid);
            Assert.Equal(sshUser.LinuxUserConfiguration.SshPrivateKey, requestParameters.PoolInfo.AutoPoolSpecification.Pool.UserAccounts[2].LinuxUserConfiguration.SshPrivateKey);
        }
    }
}
