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
        public void GetBatchTaskTest()
        {
            // Setup cmdlet to get a Task by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.Name = "task1";
            cmdlet.Filter = null;

            // Build a Task instead of querying the service on a GetJob call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetTaskRequest)
                {
                    GetTaskResponse response = BatchTestHelpers.CreateGetTaskResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudTask>())).Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the Task returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTasksByODataFilterTest()
        {
            // Setup cmdlet to list Tasks using an OData filter. Use WorkItemName and JobName input.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'test')";

            string[] namesOfConstructedTasks = new[] { "testTask1", "testTask2" };

            // Build some Tasks instead of querying the service on a ListTasks call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTasksRequest)
                {
                    ListTasksResponse response = BatchTestHelpers.CreateListTasksResponse(namesOfConstructedTasks);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudTask>()))
                .Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Tasks to the pipeline
            Assert.Equal(2, pipeline.Count);
            int taskCount = 0;
            foreach (PSCloudTask t in pipeline)
            {
                Assert.True(namesOfConstructedTasks.Contains(t.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedTasks.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTasksWithoutFiltersTest()
        {
            // Setup cmdlet to list Tasks without filters. Use WorkItemName and JobName. A PSCloudJob object is difficult to construct, so save that for the scenario tests.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedTasks = new[] { "testTask1", "testTask2", "testTask3" };

            // Build some Tasks instead of querying the service on a ListTasks call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTasksRequest)
                {
                    ListTasksResponse response = BatchTestHelpers.CreateListTasksResponse(namesOfConstructedTasks);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudTask> pipeline = new List<PSCloudTask>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudTask>()))
                .Callback<object>(t => pipeline.Add((PSCloudTask)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Tasks to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSCloudTask t in pipeline)
            {
                Assert.True(namesOfConstructedTasks.Contains(t.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedTasks.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTasksMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list Tasks without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedTasks = new[] { "testTask1", "testTask2", "testTask3" };

            // Build some Tasks instead of querying the service on a ListTasks call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTasksRequest)
                {
                    ListTasksResponse response = BatchTestHelpers.CreateListTasksResponse(namesOfConstructedTasks);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
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

            Assert.Equal(namesOfConstructedTasks.Length, pipeline.Count);
        }
    }
}
