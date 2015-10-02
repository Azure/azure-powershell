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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class GetBatchTaskCommandTests
    {
        private GetBatchTaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchTaskCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchTaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.Job = null;
            cmdlet.Filter = null;

            // Build a CloudTask instead of querying the service on a List CloudTask call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskListParameters, CloudTaskListResponse>();
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskTest()
        {
            // Setup cmdlet to get a task by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.Id = "task1";
            cmdlet.Filter = null;

            // Build a CloudTask instead of querying the service on a Get CloudTask call
            CloudTaskGetResponse response = BatchTestHelpers.CreateCloudTaskGetResponse(cmdlet.Id);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskGetParameters, CloudTaskGetResponse>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudTask>())).Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the task returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Id, pipeline[0].Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskODataTest()
        {
            // Setup cmdlet to get a single task
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "testJob";
            cmdlet.Id = "testTask1";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestSelect = null;
            string requestExpand = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            CloudTaskGetResponse getResponse = BatchTestHelpers.CreateCloudTaskGetResponse(cmdlet.Id);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskGetParameters, CloudTaskGetResponse>(getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                requestSelect = request.Parameters.DetailLevel.SelectClause;
                requestExpand = request.Parameters.DetailLevel.ExpandClause;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTasksODataTest()
        {
            // Setup cmdlet to list tasks using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "testJob";
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestFilter = null;
            string requestSelect = null;
            string requestExpand = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskListParameters, CloudTaskListResponse>();
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                requestFilter = request.Parameters.DetailLevel.FilterClause;
                requestSelect = request.Parameters.DetailLevel.SelectClause;
                requestExpand = request.Parameters.DetailLevel.ExpandClause;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTasksWithoutFiltersTest()
        {
            // Setup cmdlet to list tasks without filters. Use WorkItemName and JobName.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedTasks = new[] { "testTask1", "testTask2", "testTask3" };

            // Build some CloudTasks instead of querying the service on a List CloudTasks call
            CloudTaskListResponse response = BatchTestHelpers.CreateCloudTaskListResponse(idsOfConstructedTasks);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskListParameters, CloudTaskListResponse>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudTask>()))
                .Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed tasks to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSCloudTask t in pipeline)
            {
                Assert.True(idsOfConstructedTasks.Contains(t.Id));
                taskCount++;
            }
            Assert.Equal(idsOfConstructedTasks.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTasksMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list tasks without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";
            cmdlet.Id = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] idsOfConstructedTasks = new[] { "testTask1", "testTask2", "testTask3" };

            // Build some CloudTasks instead of querying the service on a List CloudTasks call
            CloudTaskListResponse response = BatchTestHelpers.CreateCloudTaskListResponse(idsOfConstructedTasks);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<CloudTaskListParameters, CloudTaskListResponse>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudTask>()))
                .Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedTasks.Length, pipeline.Count);
        }
    }
}
