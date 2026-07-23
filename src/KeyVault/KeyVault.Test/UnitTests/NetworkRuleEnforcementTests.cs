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
    /// Unit tests for (legacy) management client network rule normalization.
    /// Updated semantics: client no longer silently flips DefaultAction; validation occurs in cmdlets.
    /// These tests ensure pass-through behavior (no auto mutation) is preserved.
    /// </summary>
    public class NetworkRuleEnforcementTests : KeyVaultUnitTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Preserve_Allow_Even_When_IpRules_Present_No_AutoFlip()
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
            Assert.Equal(CmdModels.NetworkRuleAction.Allow.ToString(), props.NetworkAcls.DefaultAction);
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Preserve_Allow_With_VirtualNetworkRules_Present_No_AutoFlip()
        {
            // Arrange (simulate future enablement of VNets; cmdlets would block today but client path must be passive)
            var props = new ManagedHsmProperties
            {
                NetworkAcls = new MhsmNetworkRuleSet
                {
                    DefaultAction = CmdModels.NetworkRuleAction.Allow.ToString(),
                    IPRules = new List<MhsmipRule>(),
                    VirtualNetworkRules = new List<MhsmVirtualNetworkRule> { new MhsmVirtualNetworkRule { Id = "/subscriptions/xxx/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/sub" } }
                }
            };

            // Act
            VaultManagementClient.UpdateManagedHsmNetworkRuleSetProperties(props, props.NetworkAcls);

            // Assert
            Assert.Equal(CmdModels.NetworkRuleAction.Allow.ToString(), props.NetworkAcls.DefaultAction);
            Assert.Single(props.NetworkAcls.VirtualNetworkRules);
        }
    }
}
