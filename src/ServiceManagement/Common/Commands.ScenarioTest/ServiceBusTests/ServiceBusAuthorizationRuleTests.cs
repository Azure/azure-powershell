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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.ServiceBusTests
{
    [TestClass]
    public class ServiceBusAuthorizationRuleTests : AzurePowerShellCertificateTest
    {
        public ServiceBusAuthorizationRuleTests()
            : base("ServiceBus\\Common.ps1",
                   "ServiceBus\\AuthorizationRuleScenarioTests.ps1")
        {
            
        }

        #region New-AzureSBAuthorizationRule Scenario Tests

        /// <summary>
        /// Test New-AzureSBAuthorizationRule when creating queue without passing any SAS keys.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void CreatesAuthorizationRuleWithoutKeys()
        {
            RunPowerShellTest("Test-CreatesAuthorizationRuleWithoutKeys");
        }

        /// <summary>
        /// Test New-AzureSBAuthorizationRule when creating topic with passing just primary key.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void CreatesAuthorizationRuleWithPrimaryKey()
        {
            RunPowerShellTest("Test-CreatesAuthorizationRuleWithPrimaryKey");
        }

        /// <summary>
        /// Test New-AzureSBAuthorizationRule when creating relay with passing primary and secondary key.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        public void CreatesAuthorizationRuleWithPrimaryAndSecondaryKey()
        {
            RunPowerShellTest("Test-CreatesAuthorizationRuleWithPrimaryAndSecondaryKey");
        }

        /// <summary>
        /// Test New-AzureSBAuthorizationRule on notification hub scope.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void CreatesAuthorizationRuleForNotificationHub()
        {
            RunPowerShellTest("Test-CreatesAuthorizationRuleForNotificationHub");
        }

        /// <summary>
        /// Test New-AzureSBAuthorizationRule on namespace scope.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void CreatesAuthorizationRuleForNamespace()
        {
            RunPowerShellTest("Test-CreatesAuthorizationRuleForNamespace");
        }

        #endregion

        #region Set-AzureSBAuthorizationRule Scenario Tests

        /// <summary>
        /// Test Set-AzureSBAuthorizationRule when creating queue and renewing primary key.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void SetsAuthorizationRuleRenewPrimaryKey()
        {
            RunPowerShellTest("Test-SetsAuthorizationRuleRenewPrimaryKey");
        }

        /// <summary>
        /// Test Set-AzureSBAuthorizationRule when creating topic and setting secondary key.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void SetsAuthorizationRuleSecondaryKey()
        {
            RunPowerShellTest("Test-SetsAuthorizationRuleSecondaryKey");
        }

        /// <summary>
        /// Test Set-AzureSBAuthorizationRule when creating notification hub and changing the permissions.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void SetsAuthorizationRuleForPermission()
        {
            RunPowerShellTest("Test-SetsAuthorizationRuleForPermission");
        }

        /// <summary>
        /// Test Set-AzureSBAuthorizationRule on namespace level.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void SetsAuthorizationRuleOnNamespace()
        {
            RunPowerShellTest("Test-SetsAuthorizationRuleOnNamespace");
        }
         
        #endregion

        #region Remove-AzureSBNamespaceAuthoorizationRule Scenario Tests

        /// <summary>
        /// Tests removing a namespace level authorization rule.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void RemovesNamespaceAuthorizationRule()
        {
            RunPowerShellTest("Test-RemovesNamespaceAuthorizationRule");
        }

        /// <summary>
        /// Tests removing a queue entity authorization rule.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void RemovesQueueAuthorizationRule()
        {
            RunPowerShellTest("Test-RemovesQueueAuthorizationRule");
        }

        /// <summary>
        /// Tests removing a topic entity authorization rule.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void RemovesTopicAuthorizationRule()
        {
            RunPowerShellTest("Test-RemovesTopicAuthorizationRule");
        }

        /// <summary>
        /// Tests removing a relay entity authorization rule.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        public void RemovesRelayAuthorizationRule()
        {
            RunPowerShellTest("Test-RemovesRelayAuthorizationRule");
        }

        /// <summary>
        /// Tests removing a notification hub entity authorization rule.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void RemovesNotificationHubAuthorizationRule()
        {
            RunPowerShellTest("Test-RemovesNotificationHubAuthorizationRule");
        }

        #endregion

        #region Get-AzureSBAuthorizationRules Scenario Tests

        /// <summary>
        /// Tests getting all authorization rules on a given namespace.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void GetsNamespaceAuthorizationRules()
        {
            RunPowerShellTest("Test-GetsNamespaceAuthorizationRules");
        }

        /// <summary>
        /// Tests getting specific authorization rules on a queue.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void GetsQueueSpecificAuthorizationRule()
        {
            RunPowerShellTest("Test-GetsQueueSpecificAuthorizationRule");
        }

        /// <summary>
        /// Tests getting all authorization rules on a notification hub filtered by Permission.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void FilterAuthorizationRulesByPermission()
        {
            RunPowerShellTest("Test-FilterAuthorizationRulesByPermission");
        }

        /// <summary>
        /// Tests getting authorization rules on a topic that does not have any authorization rules.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void GetsEmptyListForTopic()
        {
            RunPowerShellTest("Test-GetsEmptyListForTopic");
        }

        #endregion
    }
}