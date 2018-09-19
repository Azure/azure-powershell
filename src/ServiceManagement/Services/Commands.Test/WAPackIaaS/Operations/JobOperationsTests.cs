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

using System;
using Microsoft.WindowsAzure.Commands.Common.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Operations
{
    
    public class JobOperationsTests
    { 
        /// <summary>
        /// Tests WaitOnJob with no timeout and a job that completes immediately.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void WaitOnJobCompletesImmediately()
        {
            // Fix test flakiness
            TestExecutionHelpers.RetryAction(
                () =>
                {
                    Guid jobId = Guid.NewGuid();

                    MockRequestChannel mockChannel = MockRequestChannel.Create();
                    mockChannel.AddReturnObject(new Job {Name = "TestJob", ID = jobId, IsCompleted = true});

                    var jobOperations = new JobOperations(new WebClientFactory(
                        new Subscription(),
                        mockChannel));
                    DateTime start = DateTime.Now;
                    jobOperations.WaitOnJob(jobId);
                    Assert.True((DateTime.Now - start).TotalMilliseconds < 500);
                });
        }

        /// <summary>
        /// Tests WaitOnJob with a timeout where the the Job does not complete before timeout occurs
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void WaitOnJobTimeoutJobNotFinished()
        {
            Guid jobId = Guid.NewGuid();

            MockRequestChannel mockChannel = MockRequestChannel.Create();
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });

            var jobOperations = new JobOperations(new WebClientFactory(
                                                      new Subscription(),
                                                      mockChannel));
            DateTime start = DateTime.Now;
            var result = jobOperations.WaitOnJob(jobId, 6000);
            var diff = (DateTime.Now - start).TotalMilliseconds;
            Assert.True(diff > 6000);
            Assert.Equal(JobStatusEnum.OperationTimedOut, result.jobStatus);
        }

        /// <summary>
        /// Tests WaitOnJob with empty response (no job) from server
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        [Trait("Type", "WAPackIaaS-Negative")]
        public void ShouldReturnJobNotFoundOnNonexistantJob()
        {
            Guid jobId = Guid.NewGuid();

            MockRequestChannel mockChannel = MockRequestChannel.Create();

            var jobOperations = new JobOperations(new WebClientFactory(
                                                     new Subscription(),
                                                     mockChannel));

            var result = jobOperations.WaitOnJob(jobId);

            Assert.Equal(JobStatusEnum.JobNotFound, result.jobStatus);
        }

        /// <summary>
        /// Tests WaitOnJob with a timeout where the job completes before the timeout occurs
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void WaitOnJobTimeoutJobFinished()
        {
            Guid jobId = Guid.NewGuid();

            MockRequestChannel mockChannel = MockRequestChannel.Create();
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = false, Status = "Running" });
            mockChannel.AddReturnObject(new Job { Name = "TestJob", ID = jobId, IsCompleted = true, Status = "Completed" });

            var jobOperations = new JobOperations(new WebClientFactory(
                                                      new Subscription(),
                                                      mockChannel));
            DateTime start = DateTime.Now;
            var result = jobOperations.WaitOnJob(jobId, 50000);
            var diff = (DateTime.Now - start).TotalMilliseconds;
            Assert.True(diff < 50000);
            Assert.Equal(JobStatusEnum.CompletedSuccessfully, result.jobStatus);
        }
    }
}
