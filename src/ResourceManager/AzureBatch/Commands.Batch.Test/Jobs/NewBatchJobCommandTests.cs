﻿// ----------------------------------------------------------------------------------
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
    }
}
