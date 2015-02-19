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

namespace Microsoft.Azure.Commands.Batch.Test.WorkItems
{
    public class GetBatchWorkItemCommandTests
    {
        private GetBatchWorkItemCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchWorkItemCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchWorkItemCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchWorkItemTest()
        {
            // Setup cmdlet to get a WorkItem by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Name = "testWorkItem";
            cmdlet.Filter = null;

            // Build a WorkItem instead of querying the service on a GetWorkItem call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetWorkItemRequest)
                {
                    GetWorkItemResponse response = BatchTestHelpers.CreateGetWorkItemResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudWorkItem> pipeline = new List<PSCloudWorkItem>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudWorkItem>())).Callback<object>(w => pipeline.Add((PSCloudWorkItem)w));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the WorkItem returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchWorkItemByODataFilterTest()
        {
            // Setup cmdlet to list WorkItems using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'test')";

            string[] namesOfConstructedWorkItems = new[] {"test1", "test2"};

            // Build some WorkItems instead of querying the service on a ListWorkItems call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListWorkItemsRequest)
                {
                    ListWorkItemsResponse response = BatchTestHelpers.CreateListWorkItemsResponse(namesOfConstructedWorkItems);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudWorkItem> pipeline = new List<PSCloudWorkItem>();
            commandRuntimeMock.Setup(r => 
                r.WriteObject(It.IsAny<PSCloudWorkItem>()))
                .Callback<object>(w => pipeline.Add((PSCloudWorkItem)w));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the enumerator to the pipeline and that it contains the constructed WorkItems
            Assert.Equal(2, pipeline.Count);
            int workItemCount = 0;
            foreach (PSCloudWorkItem w in pipeline)
            {
                Assert.True(namesOfConstructedWorkItems.Contains(w.Name));
                workItemCount++;
            }
            Assert.Equal(namesOfConstructedWorkItems.Length, workItemCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchWorkItemWithoutFiltersTest()
        {
            // Setup cmdlet to list WorkItems without filters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedWorkItems = new[] { "name1", "name2", "name3" };

            // Build some WorkItems instead of querying the service on a ListWorkItems call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListWorkItemsRequest)
                {
                    ListWorkItemsResponse response = BatchTestHelpers.CreateListWorkItemsResponse(namesOfConstructedWorkItems);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudWorkItem> pipeline = new List<PSCloudWorkItem>();
            commandRuntimeMock.Setup(r => 
                r.WriteObject(It.IsAny<PSCloudWorkItem>()))
                .Callback<object>(w => pipeline.Add((PSCloudWorkItem)w));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the enumerator to the pipeline and that it contains the constructed WorkItems
            Assert.Equal(3, pipeline.Count);
            int workItemCount = 0;
            foreach (PSCloudWorkItem w in pipeline)
            {
                Assert.True(namesOfConstructedWorkItems.Contains(w.Name));
                workItemCount++;
            }
            Assert.Equal(namesOfConstructedWorkItems.Length, workItemCount);
        }
    }
}
