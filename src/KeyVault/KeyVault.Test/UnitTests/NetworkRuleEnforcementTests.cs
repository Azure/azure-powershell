// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using CmdModels = Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Unit tests for final network rule default action enforcement on Managed HSM updates.
    /// These tests are offline (no service calls) and validate the logic that prevents
    /// sending DefaultAction=Allow alongside explicit IP/VNet rules.
    /// </summary>
    public class NetworkRuleEnforcementTests : KeyVaultUnitTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Enforce_Deny_When_IpRules_Present_And_Default_Allow()
        {
            // Arrange
            var props = new ManagedHsmProperties
            {
                NetworkAcls = new MhsmNetworkRuleSet
                {
                    DefaultAction = CmdModels.NetworkRuleAction.Allow.ToString(),
                    IPRules = new List<MhsmipRule> { new MhsmipRule { Value = "1.2.3.4" } }
                }
            };

            // Act
            VaultManagementClient.UpdateManagedHsmNetworkRuleSetProperties(props, props.NetworkAcls);

            // Assert
            Assert.Equal(CmdModels.NetworkRuleAction.Deny.ToString(), props.NetworkAcls.DefaultAction);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Preserve_Allow_When_No_Rules_Present()
        {
            // Arrange
            var props = new ManagedHsmProperties
            {
                NetworkAcls = new MhsmNetworkRuleSet
                {
                    DefaultAction = CmdModels.NetworkRuleAction.Allow.ToString(),
                    IPRules = new List<MhsmipRule>(),
                    VirtualNetworkRules = new List<MhsmVirtualNetworkRule>()
                }
            };

            // Act
            VaultManagementClient.UpdateManagedHsmNetworkRuleSetProperties(props, props.NetworkAcls);

            // Assert
            Assert.Equal(CmdModels.NetworkRuleAction.Allow.ToString(), props.NetworkAcls.DefaultAction);
        }
    }
}
