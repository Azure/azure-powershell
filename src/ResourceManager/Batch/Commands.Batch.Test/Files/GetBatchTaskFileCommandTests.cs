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
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
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

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class GetBatchTaskFileCommandTests
    {
        private GetBatchTaskFileCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchTaskFileCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchTaskFileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskFileParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = null;
            cmdlet.JobName = null;
            cmdlet.TaskName = null;
            cmdlet.Name = null;
            cmdlet.Task = null;
            cmdlet.Filter = null;

            // Build some Task files instead of querying the service on a ListTaskFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTaskFilesRequest)
                {
                    ListTaskFilesResponse response = BatchTestHelpers.CreateListTaskFilesResponse(new string[] { "stdout.txt" });
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();

            cmdlet.WorkItemName = null;
            cmdlet.JobName = null;
            cmdlet.TaskName = null;
            cmdlet.Task = new PSCloudTask("task", "cmd /c dir /s");

            // Verify that we don't get an argument exception. We should get an InvalidOperationException though since the task is unbound
            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskFileTest()
        {
            // Setup cmdlet to get a Task file by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";
            cmdlet.Name = "stdout.txt";
            cmdlet.Filter = null;

            // Build a Task file instead of querying the service on a GetTaskFileProperties call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetTaskFilePropertiesRequest)
                {
                    GetTaskFilePropertiesResponse response = BatchTestHelpers.CreateGetTaskFilePropertiesResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSTaskFile> pipeline = new List<PSTaskFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSTaskFile>())).Callback<object>(f => pipeline.Add((PSTaskFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the Task file returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTaskFilesByODataFilterTest()
        {
            // Setup cmdlet to list Tasks using an OData filter. Use WorkItemName and JobName input.
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'std')";

            string[] namesOfConstructedTaskFiles = new[] { "stdout.txt", "stderr.txt" };

            // Build some Task files instead of querying the service on a ListTaskFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTaskFilesRequest)
                {
                    ListTaskFilesResponse response = BatchTestHelpers.CreateListTaskFilesResponse(namesOfConstructedTaskFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSTaskFile> pipeline = new List<PSTaskFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSTaskFile>()))
                .Callback<object>(f => pipeline.Add((PSTaskFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Tasks to the pipeline
            Assert.Equal(2, pipeline.Count);
            int taskCount = 0;
            foreach (PSTaskFile f in pipeline)
            {
                Assert.True(namesOfConstructedTaskFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedTaskFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchTaskFilesWithoutFiltersTest()
        {
            // Setup cmdlet to list Task files without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedTaskFiles = new[] { "stdout.txt", "stderr.txt", "wd" };

            // Build some Task files instead of querying the service on a ListTaskFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTaskFilesRequest)
                {
                    ListTaskFilesResponse response = BatchTestHelpers.CreateListTaskFilesResponse(namesOfConstructedTaskFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSTaskFile> pipeline = new List<PSTaskFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSTaskFile>()))
                .Callback<object>(t => pipeline.Add((PSTaskFile)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed Task files to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSTaskFile f in pipeline)
            {
                Assert.True(namesOfConstructedTaskFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedTaskFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTaskFilesMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list Task files and a max count. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedTaskFiles = new[] { "stdout.txt", "stderr.txt", "wd" };

            // Build some Task files instead of querying the service on a ListTaskFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTaskFilesRequest)
                {
                    ListTaskFilesResponse response = BatchTestHelpers.CreateListTaskFilesResponse(namesOfConstructedTaskFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSTaskFile> pipeline = new List<PSTaskFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSTaskFile>()))
                .Callback<object>(t => pipeline.Add((PSTaskFile)t));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(namesOfConstructedTaskFiles.Length, pipeline.Count);
        }
    }
}
