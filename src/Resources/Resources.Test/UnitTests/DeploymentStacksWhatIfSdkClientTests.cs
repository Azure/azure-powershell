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

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.DeploymentStacks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Management.Resources.DeploymentStacks.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using System.Reflection;
    using Xunit;

    public class DeploymentStacksWhatIfSdkClientTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(typeof(NewAzManagementGroupDeploymentStackWhatIfResult))]
        [InlineData(typeof(NewAzResourceGroupDeploymentStackWhatIfResult))]
        [InlineData(typeof(NewAzSubscriptionDeploymentStackWhatIfResult))]
        [InlineData(typeof(SetAzManagementGroupDeploymentStackWhatIfResult))]
        [InlineData(typeof(SetAzResourceGroupDeploymentStackWhatIfResult))]
        [InlineData(typeof(SetAzSubscriptionDeploymentStackWhatIfResult))]
        public void DeploymentStackWhatIfCmdlet_UsesConsistentDeploymentStackParameters(Type cmdletType)
        {
            Assert.NotNull(cmdletType.GetProperty("DenySettingsApplyToChildScopes"));
            Assert.Null(cmdletType.GetProperty("DenySettingsApplyToChildScope"));
            Assert.NotNull(cmdletType.GetProperty("ResourcesWithoutDeleteSupport"));
            Assert.NotNull(cmdletType.GetProperty("Tag"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDeploymentStacksWhatIfResult_SetsActionAndTags()
        {
            var client = new DeploymentStacksWhatIfSdkClient(deploymentStacksClient: null);

            DeploymentStacksWhatIfResult result = Assert.IsType<DeploymentStacksWhatIfResult>(InvokeCreateDeploymentStacksWhatIfResult(
                client,
                deploymentStackName: "stackName",
                resourceGroupName: null,
                managementGroupId: null,
                stackResourceId: "/subscriptions/subscriptionId/providers/Microsoft.Resources/deploymentStacks/stackName"));

            Assert.Equal("fail", result.Properties.ActionOnUnmanage.ResourcesWithoutDeleteSupport);
            Assert.Equal("value", result.Tags["key"]);
        }

        // Verify a running What-If result is polled once and uses the injectable delay hook.
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WaitWhatIfResultCompletion_UsesInjectedDelayAndPollsUntilTerminalState()
        {
            var client = new DeploymentStacksWhatIfSdkClient(deploymentStacksClient: null);
            int delayMilliseconds = 0;
            int getCount = 0;
            client.DelayAction = milliseconds => delayMilliseconds += milliseconds;

            DeploymentStacksWhatIfResult result = client.WaitWhatIfResultCompletion(
                CreateResult("Running"),
                () =>
                {
                    getCount++;
                    return CreateResult("Succeeded");
                },
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled");

            Assert.Equal("Succeeded", result.Properties.ProvisioningState);
            Assert.Equal(1, getCount);
            Assert.Equal(5000, delayMilliseconds);
        }

        // Verify a terminal initial What-If result returns immediately without polling or delaying.
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WaitWhatIfResultCompletion_DoesNotPollTerminalInitialResult()
        {
            var client = new DeploymentStacksWhatIfSdkClient(deploymentStacksClient: null);
            int delayCount = 0;
            int getCount = 0;
            client.DelayAction = _ => delayCount++;

            DeploymentStacksWhatIfResult result = client.WaitWhatIfResultCompletion(
                CreateResult("Succeeded"),
                () =>
                {
                    getCount++;
                    return CreateResult("Succeeded");
                },
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled");

            Assert.Equal("Succeeded", result.Properties.ProvisioningState);
            Assert.Equal(0, getCount);
            Assert.Equal(0, delayCount);
        }

        // Verify StackResourceId construction fails with a clear error when subscription context is unavailable.
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDeploymentStacksWhatIfResult_ThrowsClearErrorWhenSubscriptionContextIsRequiredButMissing()
        {
            var client = new DeploymentStacksWhatIfSdkClient(deploymentStacksClient: null);

            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => InvokeCreateDeploymentStacksWhatIfResult(
                client,
                deploymentStackName: "stackName",
                resourceGroupName: "resourceGroupName",
                managementGroupId: null,
                stackResourceId: null));

            PSArgumentException argumentException = Assert.IsType<PSArgumentException>(exception.InnerException);
            Assert.Contains("A subscription context is required to construct the deployment stack resource ID", argumentException.Message);
        }

        private static DeploymentStacksWhatIfResult CreateResult(string provisioningState)
        {
            return new DeploymentStacksWhatIfResult(
                properties: new DeploymentStacksWhatIfResultProperties(
                    actionOnUnmanage: null,
                    denySettings: null,
                    deploymentStackResourceId: null,
                    retentionInterval: TimeSpan.FromHours(2),
                    provisioningState: provisioningState));
        }

        private static object InvokeCreateDeploymentStacksWhatIfResult(
            DeploymentStacksWhatIfSdkClient client,
            string deploymentStackName,
            string resourceGroupName,
            string managementGroupId,
            string stackResourceId)
        {
            MethodInfo method = typeof(DeploymentStacksWhatIfSdkClient).GetMethod(
                "CreateDeploymentStacksWhatIfResult",
                BindingFlags.Instance | BindingFlags.NonPublic);

            return method.Invoke(client, new object[]
            {
                null,
                null,
                null,
                null,
                new Hashtable(),
                null,
                null,
                null,
                "detach",
                "detach",
                "detach",
                "fail",
                new Hashtable { { "key", "value" } },
                null,
                "none",
                null,
                null,
                false,
                deploymentStackName,
                resourceGroupName,
                managementGroupId,
                stackResourceId,
                null,
                null,
                null,
                false
            });
        }
    }
}
