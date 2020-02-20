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
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class ScriptActionTests : HDInsightTestBase
    {
        private RuntimeScriptActionDetail scriptActionDetail;
        private RuntimeScriptActionDetail scriptActionDetailWithApplicationName;

        public ScriptActionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();


            scriptActionDetail = new RuntimeScriptActionDetail
            (
                applicationName: "AppName",
                debugInformation: "DebugInfo",
                endTime: new DateTime(2016, 1, 1).ToString(),
                executionSummary:
                    new List<Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary>
                    {
                        new Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary
                        (
                            status: "Succeeded",
                            instanceCount: 4
                        )
                    },
                name: "ScriptName",
                operation: "PostCreation",
                parameters: "Parameters",
                roles: new List<string> { "HeadNode", "WorkerNode" },
                scriptExecutionId: DateTime.UtcNow.Ticks,
                startTime: new DateTime(2016, 1, 2).ToString(),
                status: "Succeeded",
                uri: "http://bing.com"
            );

            scriptActionDetailWithApplicationName = new RuntimeScriptActionDetail
            (
                applicationName: "AppName",
                debugInformation: "DebugInfo",
                endTime: new DateTime(2016, 1, 1).ToString(),
                executionSummary:
                    new List<Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary>
                    {
                        new Microsoft.Azure.Management.HDInsight.Models.ScriptActionExecutionSummary
                        (
                            status: "Succeeded",
                            instanceCount: 1
                        )
                    },
                name: "ScriptNameWithApp",
                operation: "PostCreation",
                parameters: "Parameters",
                roles: new List<string> { "EdgeNode" },
                scriptExecutionId: DateTime.UtcNow.Ticks,
                startTime: new DateTime(2016, 1, 2).ToString(),
                status: "Succeeded",
                uri: "http://bing.com"
            );
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
                Uri = new Uri(scriptActionDetail.Uri),
                Parameters = scriptActionDetail.Parameters,
                NodeTypes = scriptActionDetail.Roles.Select(r => (RuntimeScriptActionClusterNodeType)Enum.Parse(typeof(RuntimeScriptActionClusterNodeType), r, true)).ToArray(),
                PersistOnSuccess = true
            };

            hdinsightManagementMock.Setup(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName,
                It.Is<ExecuteScriptActionParameters>(param => CompareScriptActions(param.ScriptActions.First(), scriptActionDetail) && param.PersistOnSuccess == true)))
                .Verifiable();

            submitCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<AzureHDInsightRuntimeScriptActionOperationResource>(
                    scriptOperationResource =>
                        CompareScriptActions(scriptOperationResource, new AzureHDInsightRuntimeScriptAction(scriptActionDetail)))));
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
                Uri = new Uri(scriptActionDetailWithApplicationName.Uri),
                Parameters = scriptActionDetailWithApplicationName.Parameters,
                ApplicationName = scriptActionDetailWithApplicationName.ApplicationName,
                NodeTypes = scriptActionDetailWithApplicationName.Roles.Select(r => (RuntimeScriptActionClusterNodeType)Enum.Parse(typeof(RuntimeScriptActionClusterNodeType), r, true)).ToArray(),
                PersistOnSuccess = false
            };

            hdinsightManagementMock.Setup(c => c.ExecuteScriptActions(ResourceGroupName, ClusterName,
                It.Is<ExecuteScriptActionParameters>(param => CompareScriptActions(param.ScriptActions.First(), scriptActionDetailWithApplicationName) && param.PersistOnSuccess == false)))
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
                ScriptExecutionId = scriptActionDetail.ScriptExecutionId.Value
            };

            hdinsightManagementMock.Setup(c => c.PromoteScript(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId.Value))
                .Verifiable();

            promoteCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.PromoteScript(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId.Value),
                Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetPersistedScriptActions()
        {
            var persistedScripts = new List<RuntimeScriptActionDetail> { scriptActionDetail };
            var getCmdlet = new GetAzureHDInsightPersistedScriptAction
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.ListPersistedScripts(ResourceGroupName, ClusterName))
                .Returns(persistedScripts)
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
            var persistedScripts = new List<RuntimeScriptActionDetail> { scriptActionDetail };
            var getCmdlet = new GetAzureHDInsightPersistedScriptAction
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                Name = scriptActionDetail.Name,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.ListPersistedScripts(ResourceGroupName, ClusterName))
                .Returns(persistedScripts)
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
                .Returns(history)
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

            hdinsightManagementMock.Setup(c => c.GetScriptExecutionDetail(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId.Value))
                .Returns(scriptActionDetail)
                .Verifiable();

            getCmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(
                It.Is<IList<AzureHDInsightRuntimeScriptActionDetail>>(
                    scripts =>
                        CompareScriptActionDetails(scripts.Single(), new AzureHDInsightRuntimeScriptActionDetail(scriptActionDetail))), true));
            hdinsightManagementMock.VerifyAll();
            hdinsightManagementMock.Verify(c => c.GetScriptExecutionDetail(ResourceGroupName, ClusterName, scriptActionDetail.ScriptExecutionId.Value),
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