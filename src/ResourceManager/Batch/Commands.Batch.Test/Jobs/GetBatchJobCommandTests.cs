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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Jobs
{
    public class GetBatchJobCommandTests
    {
        private GetBatchJobCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchJobCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchJobCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchJobTest()
        {
            // Setup cmdlet to get a Job by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "job-1";
            cmdlet.Filter = null;

            // Build a CloudJob instead of querying the service on a Get CloudJob call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobGetParameters, CloudJobGetResponse> request =
                (BatchRequest<CloudJobGetParameters, CloudJobGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobGetResponse response = BatchTestHelpers.CreateCloudJobGetResponse(cmdlet.Id);
                    Task<CloudJobGetResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudJob>())).Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the job returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Id, pipeline[0].Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobsByODataFilterTest()
        {
            // Setup cmdlet to list jobs using an OData filter. Use JobScheduleId input.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobScheduleId = "jobSchedule";
            cmdlet.Id = null;
            cmdlet.Filter = "state -eq 'active'";

            string[] idsOfConstructedJobs = new[] { "job-1", "job-2" };

            // Build some CloudJobs instead of querying the service on a List CloudJobs call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobListParameters, CloudJobListResponse> request =
                (BatchRequest<CloudJobListParameters, CloudJobListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobListResponse response = BatchTestHelpers.CreateCloudJobListResponse(idsOfConstructedJobs);
                    Task<CloudJobListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJob>()))
                .Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed jobs to the pipeline
            Assert.Equal(2, pipeline.Count);
            int jobCount = 0;
            foreach (PSCloudJob j in pipeline)
            {
                Assert.True(idsOfConstructedJobs.Contains(j.Id));
                jobCount++;
            }
            Assert.Equal(idsOfConstructedJobs.Length, jobCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobsWithoutFiltersTest()
        {
            // Setup cmdlet to list jobs without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobScheduleId = "jobSchedule";
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedJobs = new[] { "job-1", "job-2", "job-3" };

            // Build some CloudJobs instead of querying the service on a List CloudJobs call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobListParameters, CloudJobListResponse> request =
                (BatchRequest<CloudJobListParameters, CloudJobListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobListResponse response = BatchTestHelpers.CreateCloudJobListResponse(idsOfConstructedJobs);
                    Task<CloudJobListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJob>()))
                .Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed jobs to the pipeline
            Assert.Equal(3, pipeline.Count);
            int jobCount = 0;
            foreach (PSCloudJob j in pipeline)
            {
                Assert.True(idsOfConstructedJobs.Contains(j.Id));
                jobCount++;
            }
            Assert.Equal(idsOfConstructedJobs.Length, jobCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListJobsMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list jobs without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobScheduleId = "jobSchedule";
            cmdlet.Id = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] idsOfConstructedJobs = new[] { "job-1", "job-2", "job-3" };

            // Build some CloudJobs instead of querying the service on a List CloudJobs call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobListParameters, CloudJobListResponse> request =
                (BatchRequest<CloudJobListParameters, CloudJobListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobListResponse response = BatchTestHelpers.CreateCloudJobListResponse(idsOfConstructedJobs);
                    Task<CloudJobListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJob>()))
                .Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedJobs.Length, pipeline.Count);
        }
    }
}
