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
using Microsoft.Azure.Batch.Protocol.Entities;
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
            cmdlet.WorkItemName = "workItem";
            cmdlet.Name = "job-0000000001";
            cmdlet.Filter = null;

            // Build a Job instead of querying the service on a GetJob call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetJobRequest)
                {
                    GetJobResponse response = BatchTestHelpers.CreateGetJobResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudJob>())).Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the Job returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobsByODataFilterTest()
        {
            // Setup cmdlet to list Jobs using an OData filter. Use WorkItemName input.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.Name = null;
            cmdlet.Filter = "state -eq 'active'";

            string[] namesOfConstructedJobs = new[] { "job-0000000001", "job-0000000002" };

            // Build some Jobs instead of querying the service on a ListJobs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListJobsRequest)
                {
                    ListJobsResponse response = BatchTestHelpers.CreateListJobsResponse(namesOfConstructedJobs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJob>()))
                .Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Jobs to the pipeline
            Assert.Equal(2, pipeline.Count);
            int jobCount = 0;
            foreach (PSCloudJob j in pipeline)
            {
                Assert.True(namesOfConstructedJobs.Contains(j.Name));
                jobCount++;
            }
            Assert.Equal(namesOfConstructedJobs.Length, jobCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobsWithoutFiltersTest()
        {
            // Setup cmdlet to list Jobs without filters. Use WorkItem input.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItem = BatchTestHelpers.CreatePSCloudWorkItem();
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedJobs = new[] { "job-0000000001", "job-0000000002", "job-0000000003" };

            // Build some Jobs instead of querying the service on a ListJobs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListJobsRequest)
                {
                    ListJobsResponse response = BatchTestHelpers.CreateListJobsResponse(namesOfConstructedJobs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudJob> pipeline = new List<PSCloudJob>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudJob>()))
                .Callback<object>(j => pipeline.Add((PSCloudJob)j));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Jobs to the pipeline
            Assert.Equal(3, pipeline.Count);
            int jobCount = 0;
            foreach (PSCloudJob j in pipeline)
            {
                Assert.True(namesOfConstructedJobs.Contains(j.Name));
                jobCount++;
            }
            Assert.Equal(namesOfConstructedJobs.Length, jobCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListJobsMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Verify setting max count <= 0
            cmdlet.MaxCount = -5;
            Assert.Equal(int.MaxValue, cmdlet.MaxCount);

            // Setup cmdlet to list Jobs without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItem = BatchTestHelpers.CreatePSCloudWorkItem();
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedJobs = new[] { "job-0000000001", "job-0000000002", "job-0000000003" };

            // Build some Jobs instead of querying the service on a ListJobs call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListJobsRequest)
                {
                    ListJobsResponse response = BatchTestHelpers.CreateListJobsResponse(namesOfConstructedJobs);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
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
        }
    }
}
