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

using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class ScriptActionTests : HDInsightTestBase
    {
        private RuntimeScriptActionDetail scriptActionDetail;
        private RuntimeScriptActionDetail scriptActionDetailWithApplicationName;

        public ScriptActionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();

            scriptActionDetail = new RuntimeScriptActionDetail
            {
                ApplicationName = "AppName",
                DebugInformation = "DebugInfo",
                EndTime = new DateTime(2016, 1, 1),
                ExecutionSummary =
                    new List<Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary>
                    {
                        new Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary
                        {
                            Status = "Succeeded",
                            InstanceCount = 4
                        }
                    },
                Name = "ScriptName",
                Operation = "PostCreation",
                Parameters = "Parameters",
                Roles = new List<string> { "HeadNode", "WorkerNode" },
                ScriptExecutionId = DateTime.UtcNow.Ticks,
                StartTime = new DateTime(2016, 1, 2),
                Status = "Succeeded",
                Uri = new Uri("http://bing.com")
            };

            scriptActionDetailWithApplicationName = new RuntimeScriptActionDetail
            {
                ApplicationName = "AppName",
                DebugInformation = "DebugInfo",
                EndTime = new DateTime(2016, 1, 1),
                ExecutionSummary =
                    new List<Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary>
                    {
                        new Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary
                        {
                            Status = "Succeeded",
                            InstanceCount = 1
                        }
                    },
                Name = "ScriptNameWithApp",
                Operation = "PostCreation",
                Parameters = "Parameters",
                Roles = new List<string> { "EdgeNode" },
                ScriptExecutionId = DateTime.UtcNow.Ticks,
                StartTime = new DateTime(2016, 1, 2),
                Status = "Succeeded",
                Uri = new Uri("http://bing.com")
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubmitScriptAction()
        {
            var submitCmdlet = new SubmitAzureHDInsightScriptActionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                Name = scriptActionDetail.Name,
                Uri = scriptActionDetail.Uri,
                Parameters = scriptActionDetail.Parameters,
                NodeTypes = scriptActionDetail.Roles.Select(r => (RuntimeScriptActionClusterNodeType)Enum.Parse(typeof(RuntimeScriptActionClusterNodeType), r, true)).ToArray(),
                PersistOnSuccess = true
            };

            hdinsightManagementMock.Setup(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName,
                It.Is<ExecuteScriptActionParameters>(param => CompareScriptActions(param.ScriptActions.First(), scriptActionDetail) && param.PersistOnSuccess == true)))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            submitCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<AzureHDInsightRuntimeScriptActionOperationResource>(
                    scriptOperationResource =>
                        CompareScriptActions(scriptOperationResource, new AzureHDInsightRuntimeScriptAction(scriptActionDetail)) &&
                            scriptOperationResource.OperationState == AsyncOperationState.Succeeded.ToString())));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName, It.IsAny<ExecuteScriptActionParameters>()),
                Times.Once);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubmitScriptActionOnEdgeNode()
        {
            var submitCmdlet = new SubmitAzureHDInsightScriptActionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                Name = scriptActionDetailWithApplicationName.Name,
                Uri = scriptActionDetailWithApplicationName.Uri,
                Parameters = scriptActionDetailWithApplicationName.Parameters,
                ApplicationName = scriptActionDetailWithApplicationName.ApplicationName,
                NodeTypes = scriptActionDetailWithApplicationName.Roles.Select(r => (RuntimeScriptActionClusterNodeType)Enum.Parse(typeof(RuntimeScriptActionClusterNodeType), r, true)).ToArray(),
                PersistOnSuccess = false
            };

            hdinsightManagementMock.Setup(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName,
                It.Is<ExecuteScriptActionParameters>(param => CompareScriptActions(param.ScriptActions.First(), scriptActionDetailWithApplicationName) && param.PersistOnSuccess == false)))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            submitCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<AzureHDInsightRuntimeScriptActionOperationResource>(
                    scriptOperationResource =>
                        CompareScriptActions(scriptOperationResource, new AzureHDInsightRuntimeScriptAction(scriptActionDetailWithApplicationName)) &&
                            scriptOperationResource.OperationState == AsyncOperationState.Succeeded.ToString())));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName, It.IsAny<ExecuteScriptActionParameters>()),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveScriptAction()
        {
            var demoteCmdlet = new RemoveAzureHDInsightPersistedScriptActionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                Name = scriptActionDetail.Name
            };

            hdinsightManagementMock.Setup(c => c.DeletePersistedScript(ResourceGroupName, ClusterName, scriptActionDetail.Name))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            demoteCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.DeletePersistedScript(ResourceGroupName, ClusterName, scriptActionDetail.Name),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PromoteScriptAction()
        {
            var promoteCmdlet = new SetAzureHDInsightPersistedScriptActionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                ScriptExecutionId = scriptActionDetail.ScriptExecutionId
            };

            hdinsightManagementMock.Setup(c => c.PromoteScript(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            promoteCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.PromoteScript(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetPersistedScriptActions()
        {
            var persistedScripts = new List<RuntimeScriptAction> { scriptActionDetail };
            var getCmdlet = new GetAzureHDInsightPersistedScriptAction
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.ListPersistedScripts(ResourceGroupName, ClusterName))
                .Returns(new ClusterListPersistedScriptActionsResponse
                {
                    PersistedScriptActions = persistedScripts,
                    StatusCode = HttpStatusCode.OK,
                    RequestId = null
                })
                .Verifiable();

            getCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<IList<AzureHDInsightRuntimeScriptAction>>(
                    scripts =>
                        CompareScriptActions(scripts.Single(), new AzureHDInsightRuntimeScriptAction(scriptActionDetail))), true));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.ListPersistedScripts(ResourceGroupName, ClusterName),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetPersistedScriptAction()
        {
            var persistedScripts = new List<RuntimeScriptAction> { scriptActionDetail };
            var getCmdlet = new GetAzureHDInsightPersistedScriptAction
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                Name = scriptActionDetail.Name,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.ListPersistedScripts(ResourceGroupName, ClusterName))
                .Returns(new ClusterListPersistedScriptActionsResponse
                {
                    PersistedScriptActions = persistedScripts,
                    StatusCode = HttpStatusCode.OK,
                    RequestId = null
                })
                .Verifiable();

            getCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<IList<AzureHDInsightRuntimeScriptAction>>(
                    scripts =>
                        CompareScriptActions(scripts.Single(), new AzureHDInsightRuntimeScriptAction(scriptActionDetail))), true));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.ListPersistedScripts(ResourceGroupName, ClusterName),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetHistory()
        {
            var history = new List<RuntimeScriptActionDetail> { scriptActionDetail };
            var getCmdlet = new GetAzureHDInsightScriptActionHistory
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.ListScriptExecutionHistory(ResourceGroupName, ClusterName))
                .Returns(new ClusterListRuntimeScriptActionDetailResponse
                {
                    RuntimeScriptActionDetail = history,
                    StatusCode = HttpStatusCode.OK,
                    RequestId = null
                })
                .Verifiable();

            getCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<IList<AzureHDInsightRuntimeScriptActionDetail>>(
                    scripts =>
                        CompareScriptActionDetails(scripts.Single(), new AzureHDInsightRuntimeScriptActionDetail(scriptActionDetail))), true));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.ListScriptExecutionHistory(ResourceGroupName, ClusterName),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetScriptExecutionDetail()
        {
            var getCmdlet = new GetAzureHDInsightScriptActionHistory
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                ScriptExecutionId = scriptActionDetail.ScriptExecutionId
            };

            hdinsightManagementMock.Setup(c => c.GetScriptExecutionDetail(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId))
                .Returns(new ClusterRuntimeScriptActionDetailResponse
                {
                    RuntimeScriptActionDetail = scriptActionDetail,
                    StatusCode = HttpStatusCode.OK,
                    RequestId = null
                })
                .Verifiable();

            getCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<IList<AzureHDInsightRuntimeScriptActionDetail>>(
                    scripts =>
                        CompareScriptActionDetails(scripts.Single(), new AzureHDInsightRuntimeScriptActionDetail(scriptActionDetail))), true));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.GetScriptExecutionDetail(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId),
                Times.Once);
        }

        private static bool CompareScriptActions(RuntimeScriptAction scriptA, RuntimeScriptAction scriptB)
        {
            return CompareScriptActions(new AzureHDInsightRuntimeScriptAction(scriptA), new AzureHDInsightRuntimeScriptAction(scriptB));
        }

        private static bool CompareScriptActions(AzureHDInsightRuntimeScriptAction scriptA, AzureHDInsightRuntimeScriptAction scriptB)
        {
            return scriptA.Name == scriptB.Name
                && scriptA.Parameters == scriptB.Parameters
                && scriptA.NodeTypes.Count() == scriptB.NodeTypes.Count()
                && scriptA.NodeTypes.Zip(scriptB.NodeTypes, (nodeA, nodeB) => nodeA == nodeB).All(x => x)
                && scriptA.Uri == scriptB.Uri;
        }

        private static bool CompareScriptActionDetails(AzureHDInsightRuntimeScriptActionDetail scriptA, AzureHDInsightRuntimeScriptActionDetail scriptB)
        {
            if (!CompareScriptActions(scriptA, scriptB)) { return false; }

            return scriptA.ApplicationName == scriptB.ApplicationName
                && scriptA.DebugInformation == scriptB.DebugInformation
                && scriptA.EndTime == scriptB.EndTime
                && scriptA.ExecutionSummary.Count == scriptB.ExecutionSummary.Count
                && scriptA.ExecutionSummary.Zip(scriptB.ExecutionSummary, (summaryA, summaryB) => summaryA == summaryB).All(x => x)
                && scriptA.Operation == scriptB.Operation
                && scriptA.ScriptExecutionId == scriptB.ScriptExecutionId
                && scriptA.StartTime == scriptB.StartTime
                && scriptA.Status == scriptB.Status;
        }
    }
}