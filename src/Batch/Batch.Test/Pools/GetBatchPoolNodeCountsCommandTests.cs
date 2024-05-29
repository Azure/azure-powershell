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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class GetBatchPoolNodeCountsCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchPoolNodeCountCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolNodeCountsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(
                new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPoolNodeCountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithoutFilter_ShouldReturnAllPools()
        {
            // Setup cmdlet to get a pool by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            var poolNodeCounts1 = new ProxyModels.PoolNodeCounts()
            {
                PoolId = "Pool1",
                Dedicated = new ProxyModels.NodeCounts(
                    creating: 1,
                    idle: 2,
                    offline: 3,
                    preempted: 4,
                    rebooting: 5,
                    reimaging: 6,
                    running: 7,
                    starting: 8,
                    startTaskFailed: 9,
                    leavingPool: 10,
                    unknown: 11,
                    unusable: 12,
                    waitingForStartTask: 13,
                    total: 91,
                    upgradingOS: 1), // Total
                LowPriority = new ProxyModels.NodeCounts(
                    creating: 1,
                    idle: 2,
                    offline: 3,
                    preempted: 4,
                    rebooting: 5,
                    reimaging: 6,
                    running: 7,
                    starting: 8,
                    startTaskFailed: 9,
                    leavingPool: 10,
                    unknown: 11,
                    unusable: 12,
                    waitingForStartTask: 13,
                    total: 91,
                    upgradingOS: 1), // Total
            };

            var poolNodeCounts2 = new ProxyModels.PoolNodeCounts()
            {
                PoolId = "Pool2",
                Dedicated = new ProxyModels.NodeCounts(
                    creating: 11,
                    idle: 12,
                    offline: 13,
                    preempted: 14,
                    rebooting: 15,
                    reimaging: 16,
                    running: 17,
                    starting: 18,
                    startTaskFailed: 19,
                    leavingPool: 20,
                    unknown: 21,
                    unusable: 22,
                    waitingForStartTask: 23,
                    total: 221,
                    upgradingOS: 1), // Total
                LowPriority = new ProxyModels.NodeCounts(
                    creating: 11,
                    idle: 12,
                    offline: 13,
                    preempted: 14,
                    rebooting: 15,
                    reimaging: 16,
                    running: 17,
                    starting: 18,
                    startTaskFailed: 19,
                    leavingPool: 20,
                    unknown: 21,
                    unusable: 22,
                    waitingForStartTask: 23,
                    total: 221,
                    upgradingOS: 1), // Total
            };

            // Simulate node state counts for two pools are returned
            var poolsNodeCounts = new List<ProxyModels.PoolNodeCounts>()
            {
                poolNodeCounts1,
                poolNodeCounts2
            };

            // Build a PoolNodeCounts instead of querying the service on a Get PoolNodeCounts call
            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> response =
                BatchTestHelpers.CreatePoolNodeCountsGetResponse(poolsNodeCounts);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.AccountListPoolNodeCountsOptions,
                AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            List<PSPoolNodeCounts> psPoolsNodeCounts = new List<PSPoolNodeCounts>();
            commandRuntimeMock.Setup(r =>
                    r.WriteObject(It.IsAny<PSPoolNodeCounts>()))
                .Callback<object>(p => psPoolsNodeCounts.Add((PSPoolNodeCounts)p));

            cmdlet.ExecuteCmdlet();

            var psPoolNodeCounts1 = psPoolsNodeCounts.FirstOrDefault(c => c.PoolId == "Pool1");

            var psPoolNodeCounts2 = psPoolsNodeCounts.FirstOrDefault(c => c.PoolId == "Pool2");

            Assert.NotNull(psPoolNodeCounts1);
            Assert.NotNull(psPoolNodeCounts2);

            var comparer = new PoolNodeCountsObjectComparer();

            Assert.True(comparer.AreEqual(poolNodeCounts1, psPoolNodeCounts1));
            Assert.True(comparer.AreEqual(poolNodeCounts2, psPoolNodeCounts2));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithPoolIdOption_ShouldHonorPoolIdFilter()
        {
            const string poolId = "Pool1";
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = poolId;

            string requestFilter = null;

            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> fakeResponse = 
                BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.PoolNodeCounts, ProxyModels.AccountListPoolNodeCountsHeaders>();

            Action<BatchRequest<ProxyModels.AccountListPoolNodeCountsOptions, AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>> requestAction =
                (request) =>
                {
                    ProxyModels.AccountListPoolNodeCountsOptions options = request.Options;
                    requestFilter = options.Filter;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(
                responseToUse: fakeResponse, requestAction: requestAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal($"(poolId eq '{poolId}')", requestFilter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithCloudPoolOption_ShouldHonorPoolFilter()
        {
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();

            PSCloudPool fakeCloudPool = new PSCloudPool(BatchTestHelpers.CreateFakeBoundPool(context));
            cmdlet.BatchContext = context;
            cmdlet.Pool = fakeCloudPool;

            string requestFilter = null;

            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> fakeResponse =
                BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.PoolNodeCounts, ProxyModels.AccountListPoolNodeCountsHeaders>();

            Action<BatchRequest<ProxyModels.AccountListPoolNodeCountsOptions, AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>> requestAction =
                (request) =>
                {
                    ProxyModels.AccountListPoolNodeCountsOptions options = request.Options;
                    requestFilter = options.Filter;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(
                responseToUse: fakeResponse, requestAction: requestAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(requestFilter, $"(poolId eq '{fakeCloudPool.Id}')");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenPSNodeCountsFormatObjectIsCalled_ShouldSerlializeNodeCountsToString()
        {
            const int creating = 1;
            const int idle = 2;
            const int offline = 3;
            const int preempted = 4;
            const int rebooting = 5;
            const int reimaging = 6;
            const int running = 7;
            const int starting = 8;
            const int startTaskFailed = 9;
            const int leavingPool = 10;
            const int unknown = 11;
            const int unusable = 12;
            const int waitingForStartTask = 13;
            const int total = 91;
            const int upgradingOS = 1;

            var poolNodeCounts = new ProxyModels.PoolNodeCounts()
            {
                PoolId = "Pool1",
                // all non-zero properties
                Dedicated = new ProxyModels.NodeCounts(
                    creating: creating,
                    idle: idle,
                    offline: offline,
                    preempted: preempted,
                    rebooting: rebooting,
                    reimaging: reimaging,
                    running: running,
                    starting: starting,
                    startTaskFailed: startTaskFailed,
                    leavingPool: leavingPool,
                    unknown: unknown,
                    unusable: unusable,
                    waitingForStartTask: waitingForStartTask,
                    total: total,
                    upgradingOS: upgradingOS), // Total
                // all zero properties
                LowPriority = new ProxyModels.NodeCounts(
                    creating: 0,
                    idle: 0,
                    offline: 0,
                    preempted: 0,
                    rebooting: 0,
                    reimaging: 0,
                    running: 0,
                    starting: 0,
                    startTaskFailed: 0,
                    leavingPool: 0,
                    unknown: 0,
                    unusable: 0,
                    waitingForStartTask: 0,
                    total: 0,
                    upgradingOS: 0), // Total
            };

            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            // Build a PoolNodeCounts instead of querying the service on a Get PoolNodeCounts call
            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> response =
                BatchTestHelpers.CreatePoolNodeCountsGetResponse(new [] { poolNodeCounts });
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.AccountListPoolNodeCountsOptions,
                AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            List<PSPoolNodeCounts> psPoolsNodeCounts = new List<PSPoolNodeCounts>();
            commandRuntimeMock.Setup(r =>
                    r.WriteObject(It.IsAny<PSPoolNodeCounts>()))
                .Callback<object>(p => psPoolsNodeCounts.Add((PSPoolNodeCounts)p));

            cmdlet.ExecuteCmdlet();

            var str = PSNodeCounts.FormatObject(psPoolsNodeCounts[0].Dedicated);
            const string segmentFormat = "{0}: {1}";

            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Creating), creating), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Idle), idle), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Offline), offline), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Preempted), preempted), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Rebooting), rebooting), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Reimaging), reimaging), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Running), running), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Starting), starting), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.StartTaskFailed), startTaskFailed), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.LeavingPool), leavingPool), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Unknown), unknown), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Unusable), unusable), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.WaitingForStartTask), waitingForStartTask), str);
            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Total), total), str);
            Assert.EndsWith(string.Format(segmentFormat, nameof(PSNodeCounts.Total), total), str);

            str = PSNodeCounts.FormatObject(psPoolsNodeCounts[0].LowPriority);

            Assert.Contains(string.Format(segmentFormat, nameof(PSNodeCounts.Total), 0), str);
        }

        public class PoolNodeCountsObjectComparer
        {
            private IEnumerable<PropertyInfo> poolNodeCountsPropertInfos;
            private IEnumerable<PropertyInfo> psPoolNodeCountsPropertInfos;

            public PoolNodeCountsObjectComparer()
            {
                this.poolNodeCountsPropertInfos =
                    typeof(ProxyModels.PoolNodeCounts).GetProperties(BindingFlags.Public | BindingFlags.GetProperty);
                this.psPoolNodeCountsPropertInfos =
                    typeof(PSPoolNodeCounts).GetProperties(BindingFlags.Public | BindingFlags.GetProperty);
            }

            public bool AreEqual(ProxyModels.PoolNodeCounts poolNodeCounts, PSPoolNodeCounts psPoolNodeCounts)
            {
                foreach (var pi in this.poolNodeCountsPropertInfos)
                {
                    var poolNodeCountsValue = pi.GetValue(poolNodeCounts);
                    var psPoolNodeCountsValue = this.psPoolNodeCountsPropertInfos.First(psPi => psPi.Name == pi.Name).GetValue(psPoolNodeCounts);

                    if (poolNodeCountsValue != psPoolNodeCountsValue)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
