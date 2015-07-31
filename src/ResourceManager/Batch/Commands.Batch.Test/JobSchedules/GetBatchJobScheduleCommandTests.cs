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

namespace Microsoft.Azure.Commands.Batch.Test.JobSchedules
{
    public class GetBatchJobScheduleCommandTests
    {
        private GetBatchJobScheduleCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchJobScheduleCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchJobScheduleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchJobScheduleTest()
        {
            // Setup cmdlet to get a job schedule by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "testJobSchedule";
            cmdlet.Filter = null;

            // Build a CloudJobSchedule instead of querying the service on a Get CloudJobSchedule call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobScheduleGetParameters, CloudJobScheduleGetResponse> request =
                (BatchRequest<CloudJobScheduleGetParameters, CloudJobScheduleGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobScheduleGetResponse response = BatchTestHelpers.CreateCloudJobScheduleGetResponse(cmdlet.Id);
                    Task<CloudJobScheduleGetResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJobSchedule> pipeline = new List<PSCloudJobSchedule>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudJobSchedule>())).Callback<object>(j => pipeline.Add((PSCloudJobSchedule)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the job schedule returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Id, pipeline[0].Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobScheduleByODataFilterTest()
        {
            // Setup cmdlet to list job schedules using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";

            string[] idsOfConstructedJobSchedules = new[] { "test1", "test2" };

            // Build some CloudJobSchedules instead of querying the service on a List CloudJobSchedules call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse> request =
                (BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobScheduleListResponse response = BatchTestHelpers.CreateCloudJobScheduleListResponse(idsOfConstructedJobSchedules);
                    Task<CloudJobScheduleListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJobSchedule> pipeline = new List<PSCloudJobSchedule>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJobSchedule>()))
                .Callback<object>(j => pipeline.Add((PSCloudJobSchedule)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed job schedules to the pipeline
            Assert.Equal(2, pipeline.Count);
            int jobScheduleCount = 0;
            foreach (PSCloudJobSchedule j in pipeline)
            {
                Assert.True(idsOfConstructedJobSchedules.Contains(j.Id));
                jobScheduleCount++;
            }
            Assert.Equal(idsOfConstructedJobSchedules.Length, jobScheduleCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobSchedulesWithoutFiltersTest()
        {
            // Setup cmdlet to list job schedules without filters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedJobSchedules = new[] { "id1", "id2", "id3" };

            // Build some CloudJobSchedules instead of querying the service on a List CloudJobSchedules call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse> request =
                (BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobScheduleListResponse response = BatchTestHelpers.CreateCloudJobScheduleListResponse(idsOfConstructedJobSchedules);
                    Task<CloudJobScheduleListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJobSchedule> pipeline = new List<PSCloudJobSchedule>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJobSchedule>()))
                .Callback<object>(j => pipeline.Add((PSCloudJobSchedule)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed job schedules to the pipeline
            Assert.Equal(3, pipeline.Count);
            int jobScheduleCount = 0;
            foreach (PSCloudJobSchedule j in pipeline)
            {
                Assert.True(idsOfConstructedJobSchedules.Contains(j.Id));
                jobScheduleCount++;
            }
            Assert.Equal(idsOfConstructedJobSchedules.Length, jobScheduleCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListJobSchedulesMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list job schedules without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] idsOfConstructedJobSchedules = new[] { "id1", "id2", "id3" };

            // Build some CloudJobSchedules instead of querying the service on a List CloudJobSchedules call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse> request =
                (BatchRequest<CloudJobScheduleListParameters, CloudJobScheduleListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudJobScheduleListResponse response = BatchTestHelpers.CreateCloudJobScheduleListResponse(idsOfConstructedJobSchedules);
                    Task<CloudJobScheduleListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJobSchedule> pipeline = new List<PSCloudJobSchedule>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJobSchedule>()))
                .Callback<object>(j => pipeline.Add((PSCloudJobSchedule)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedJobSchedules.Length, pipeline.Count);
        }

    }
}
