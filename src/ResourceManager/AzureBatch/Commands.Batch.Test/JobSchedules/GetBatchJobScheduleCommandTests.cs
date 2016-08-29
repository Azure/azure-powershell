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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.JobSchedules
{
    public class GetBatchJobScheduleCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchJobScheduleCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchJobScheduleCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
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
            AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders> response = BatchTestHelpers.CreateCloudJobScheduleGetResponse(cmdlet.Id);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.JobScheduleGetOptions,
                AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders>>(response);

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
        public void GetBatchJobScheduleODataTest()
        {
            // Setup cmdlet to get a single job schedule
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "testJobSchedule";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestSelect = null;
            string requestExpand = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders> getResponse = BatchTestHelpers.CreateCloudJobScheduleGetResponse(cmdlet.Id);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.JobScheduleGetOptions, AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders>>(getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.JobScheduleGetOptions options = (ProxyModels.JobScheduleGetOptions)request.Options;

                requestSelect = options.Select;
                requestExpand = options.Expand;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchJobSchedulesODataTest()
        {
            // Setup cmdlet to list job schedules using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestFilter = null;
            string requestSelect = null;
            string requestExpand = null;

            AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders> response = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleListHeaders>();
            Action<BatchRequest<ProxyModels.JobScheduleListOptions, AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders>>> listJobScheduleAction =
                (request) =>
                {
                    ProxyModels.JobScheduleListOptions options = request.Options;
                    requestFilter = options.Filter;
                    requestSelect = options.Select;
                    requestExpand = options.Expand;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.JobScheduleListOptions, AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders>>(responseToUse: response, requestAction: listJobScheduleAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
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
            AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders> response = BatchTestHelpers.CreateCloudJobScheduleListResponse(idsOfConstructedJobSchedules);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.JobScheduleListOptions, AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders>>(response);
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
            AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders> response = BatchTestHelpers.CreateCloudJobScheduleListResponse(idsOfConstructedJobSchedules);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.JobScheduleListOptions, AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders>>(response);
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
