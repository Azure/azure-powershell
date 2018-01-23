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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Xunit;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using OutputFileUploadCondition = Microsoft.Azure.Batch.Common.OutputFileUploadCondition;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class NewBatchTaskCommandTests
    {
        private NewBatchTaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchTaskCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchTaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskShouldHaveExpectedMandatoryProperties()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testTask";

            // Don't go to the service on an Add CloudTask call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskAddParameter,
                ProxyModels.TaskAddOptions,
                AzureOperationHeaderResponse<ProxyModels.TaskAddHeaders>>();
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testTask";
            cmdlet.JobId = "testJob";
            cmdlet.AffinityInformation = new PSAffinityInformation("affinityValue");
            cmdlet.DisplayName = "display name";
            cmdlet.Constraints = new PSTaskConstraints(TimeSpan.FromHours(1), TimeSpan.FromDays(2), 5);
            cmdlet.CommandLine = "cmd /c echo hello";
            cmdlet.EnvironmentSettings = new Dictionary<string, string>();
            cmdlet.EnvironmentSettings.Add("env1", "value1");
            cmdlet.MultiInstanceSettings = new PSMultiInstanceSettings("cmd /c echo coordinating", 3)
            {
                CommonResourceFiles = new List<PSResourceFile>()
                {
                    new PSResourceFile("https://some.blob", "myFile.txt")
                }
            };
            cmdlet.ResourceFiles = new Dictionary<string, string>();
            cmdlet.ResourceFiles.Add("anotherFile.txt", "https://another.blob");

            TaskAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                TaskAddParameter,
                TaskAddOptions,
                AzureOperationHeaderResponse<TaskAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.AffinityInformation.AffinityId, requestParameters.AffinityInfo.AffinityId);
            Assert.Equal(cmdlet.DisplayName, requestParameters.DisplayName);
            Assert.Equal(cmdlet.Constraints.RetentionTime, requestParameters.Constraints.RetentionTime);
            Assert.Equal(cmdlet.Constraints.MaxTaskRetryCount, requestParameters.Constraints.MaxTaskRetryCount);
            Assert.Equal(cmdlet.Constraints.MaxWallClockTime, requestParameters.Constraints.MaxWallClockTime);
            Assert.Equal(cmdlet.CommandLine, requestParameters.CommandLine);
            Assert.Equal(cmdlet.EnvironmentSettings.Count, requestParameters.EnvironmentSettings.Count);
            Assert.Equal(cmdlet.EnvironmentSettings["env1"], requestParameters.EnvironmentSettings[0].Value);
            Assert.Equal(cmdlet.MultiInstanceSettings.NumberOfInstances, requestParameters.MultiInstanceSettings.NumberOfInstances);
            Assert.Equal(cmdlet.MultiInstanceSettings.CoordinationCommandLine, requestParameters.MultiInstanceSettings.CoordinationCommandLine);
            Assert.Equal(cmdlet.MultiInstanceSettings.CommonResourceFiles.Count, requestParameters.MultiInstanceSettings.CommonResourceFiles.Count);
            Assert.Equal(cmdlet.MultiInstanceSettings.CommonResourceFiles[0].BlobSource, requestParameters.MultiInstanceSettings.CommonResourceFiles[0].BlobSource);
            Assert.Equal(cmdlet.MultiInstanceSettings.CommonResourceFiles[0].FilePath, requestParameters.MultiInstanceSettings.CommonResourceFiles[0].FilePath);
            Assert.Equal(cmdlet.ResourceFiles.Count, requestParameters.ResourceFiles.Count);
            Assert.Equal(cmdlet.ResourceFiles["anotherFile.txt"], requestParameters.ResourceFiles[0].BlobSource);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplicationPackageReferencesAreSentOnATask()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "task-id";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-id";

            string applicationId = "foo";
            string applicationVersion = "beta";

            cmdlet.ApplicationPackageReferences = new[]
            {
                new PSApplicationPackageReference { ApplicationId = applicationId, Version = applicationVersion} ,
            };

            // Don't go to the service on an Add CloudJob call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<TaskAddParameter, TaskAddOptions, AzureOperationHeaderResponse<TaskAddHeaders>>(
                new AzureOperationHeaderResponse<TaskAddHeaders>(),
                request =>
                {
                    var applicationPackageReference = request.Parameters.ApplicationPackageReferences.First();
                    Assert.Equal(applicationId, applicationPackageReference.ApplicationId);
                    Assert.Equal(applicationVersion, applicationPackageReference.Version);
                });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        public void ExitConditionsAreSentToService()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            TaskAddParameter requestParameters = null;

            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                TaskAddBatchRequest request = (TaskAddBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    requestParameters = request.Parameters;

                    var response = new AzureOperationHeaderResponse<TaskAddHeaders>();
                    Task<AzureOperationHeaderResponse<TaskAddHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior> { interceptor };

            var none = new PSExitOptions(new Azure.Batch.ExitOptions { JobAction = Azure.Batch.Common.JobAction.None });
            var terminate = new PSExitOptions(new Azure.Batch.ExitOptions { JobAction = Azure.Batch.Common.JobAction.Terminate });
            var satisfyDependency = new PSExitOptions(new Azure.Batch.ExitOptions { DependencyAction = Azure.Batch.Common.DependencyAction.Satisfy });

            cmdlet.ExitConditions = new PSExitConditions
            {
                ExitCodes = new List<PSExitCodeMapping> { new PSExitCodeMapping(0, none) },
                PreProcessingError = terminate,
                FileUploadError = none,
                ExitCodeRanges = new List<PSExitCodeRangeMapping> { new PSExitCodeRangeMapping(1, 5, satisfyDependency) },
                Default = none,
            };

            cmdlet.JobId = "job-Id";
            cmdlet.Id = "task-id";
            cmdlet.ExecuteCmdlet();

            var exitConditions = requestParameters.ExitConditions;
            Assert.Equal(1, exitConditions.ExitCodeRanges.First().Start);
            Assert.Equal(5, exitConditions.ExitCodeRanges.First().End);
            Assert.Equal(ProxyModels.DependencyAction.Satisfy, exitConditions.ExitCodeRanges.First().ExitOptions.DependencyAction);
            Assert.Equal(ProxyModels.JobAction.None, exitConditions.ExitCodes.First().ExitOptions.JobAction);
            Assert.Equal(ProxyModels.JobAction.Terminate, exitConditions.PreProcessingError.JobAction);
            Assert.Equal(ProxyModels.JobAction.None, exitConditions.FileUploadError.JobAction);
            Assert.Equal(ProxyModels.JobAction.None, exitConditions.DefaultProperty.JobAction);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskUserIdentityGetsPassedToRequest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testTask";
            cmdlet.JobId = "testJob";
            cmdlet.CommandLine = "cmd /c echo hello";
            cmdlet.UserIdentity = new PSUserIdentity(
                new PSAutoUserSpecification(Azure.Batch.Common.AutoUserScope.Task, Azure.Batch.Common.ElevationLevel.Admin));

            TaskAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                TaskAddParameter,
                TaskAddOptions,
                AzureOperationHeaderResponse<TaskAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.UserIdentity.AutoUser.Scope.ToString().ToLowerInvariant(), 
                requestParameters.UserIdentity.AutoUser.Scope.ToString().ToLowerInvariant());
            Assert.Equal(cmdlet.UserIdentity.AutoUser.ElevationLevel.ToString().ToLowerInvariant(), 
                requestParameters.UserIdentity.AutoUser.ElevationLevel.ToString().ToLowerInvariant());
            Assert.Null(requestParameters.UserIdentity.UserName);

            // Set the user name instead and verify the request matches expectations
            cmdlet.UserIdentity = new PSUserIdentity("user1");
            cmdlet.ExecuteCmdlet();
            Assert.Equal(cmdlet.UserIdentity.UserName, requestParameters.UserIdentity.UserName);
            Assert.Null(requestParameters.UserIdentity.AutoUser);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskAuthTokenSettingsGetsPassedToRequest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "testTask";
            cmdlet.JobId = "testJob";
            cmdlet.CommandLine = "cmd /c echo hello";
            cmdlet.AuthenticationTokenSettings = new PSAuthenticationTokenSettings
            {
                Access = Azure.Batch.Common.AccessScope.Job
            };

            TaskAddParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                TaskAddParameter,
                TaskAddOptions,
                AzureOperationHeaderResponse<TaskAddHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.AuthenticationTokenSettings.Access.ToString().ToLowerInvariant(), 
                requestParameters.AuthenticationTokenSettings.Access.Single().ToString().ToLowerInvariant());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskCollectionParametersTest()
        {
            string commandLine = "cmd /c dir /s";

            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-collection";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            string[] taskIds = new[] {"simple1", "simple2"};
            PSCloudTask expected1 = new PSCloudTask(taskIds[0], commandLine);
            PSCloudTask expected2 = new PSCloudTask(taskIds[1], commandLine);

            cmdlet.Tasks = new PSCloudTask[] {expected1, expected2};

            IList<TaskAddParameter> requestCollection = null;

            Action<BatchRequest<
                IList<TaskAddParameter>,
                TaskAddCollectionOptions,
                AzureOperationResponse<TaskAddCollectionResult, TaskAddCollectionHeaders>>> extractCollection =
                (request) =>
                {
                    requestCollection = request.Parameters;
                };

            // Don't go to the service on an Add Task Collection call
            AzureOperationResponse<TaskAddCollectionResult, TaskAddCollectionHeaders> response =
                BatchTestHelpers.CreateTaskCollectionResponse(cmdlet.Tasks);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(responseToUse: response, requestAction: extractCollection);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, requestCollection.Count);
            foreach (var task in requestCollection)
            {
                Assert.True(taskIds.Contains(task.Id));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OutputFilesAreSentToService()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            
            cmdlet.Id = "task-id";
            cmdlet.JobId = "job-id";

            const string pattern = @"**\*.txt";
            const string containerUrl = "containerUrl";
            const string path = "path";
            const OutputFileUploadCondition uploadCondition = OutputFileUploadCondition.TaskCompletion;

            cmdlet.OutputFile = new[]
            {
                new PSOutputFile(
                    pattern,
                    new PSOutputFileDestination(new PSOutputFileBlobContainerDestination(containerUrl, path)),
                    new PSOutputFileUploadOptions(uploadCondition))
            };

            // Don't go to the service on an Add CloudJob call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<TaskAddParameter, TaskAddOptions, AzureOperationHeaderResponse<TaskAddHeaders>>(
                new AzureOperationHeaderResponse<TaskAddHeaders>(),
                request =>
                {
                    var outputFile = request.Parameters.OutputFiles.Single();
                    Assert.Equal(pattern, outputFile.FilePattern);
                    Assert.Equal(containerUrl, outputFile.Destination.Container.ContainerUrl);
                    Assert.Equal(path, outputFile.Destination.Container.Path);
                    Assert.Equal(uploadCondition.ToString().ToLowerInvariant(), outputFile.UploadOptions.UploadCondition.ToString().ToLowerInvariant());
                });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ContainerSettingsAreSentToService()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Id = "task-id";
            cmdlet.JobId = "job-id";

            const string imageName = "foo";
            const string containerRunOptions = "bar";
            const string userName = "abc";
            const string password = "mypass";

            cmdlet.ContainerSettings = new PSTaskContainerSettings(
                imageName,
                containerRunOptions, new PSContainerRegistry(
                    userName, 
                    password: password));

            // Don't go to the service on an Add CloudTask call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<TaskAddParameter, TaskAddOptions, AzureOperationHeaderResponse<TaskAddHeaders>>(
                new AzureOperationHeaderResponse<TaskAddHeaders>(),
                request =>
                {
                    var containerSettings = request.Parameters.ContainerSettings;
                    Assert.Equal(imageName, containerSettings.ImageName);
                    Assert.Equal(containerRunOptions, containerSettings.ContainerRunOptions);
                    Assert.Equal(userName, containerSettings.Registry.UserName);
                    Assert.Equal(password, containerSettings.Registry.Password);
                });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }
    }
}
