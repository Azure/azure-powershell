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

using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    public class DurabilityLevelTests
    {
        private sealed class TestServiceFabricClusterCmdlet : ServiceFabricClusterCmdlet
        {
            public DurabilityLevel GetNodeTypeDurabilityLevel(string durabilityLevel)
            {
                return GetDurabilityLevel(durabilityLevel);
            }

            public DurabilityLevel GetVmssDurabilityLevel(string durabilityLevel)
            {
                var vmss = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSet
                {
                    VirtualMachineProfile = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetVMProfile
                    {
                        ExtensionProfile = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetExtensionProfile
                        {
                            Extensions = new[]
                            {
                                new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetExtension
                                {
                                    Type = "ServiceFabricNode",
                                    Settings = new Newtonsoft.Json.Linq.JObject
                                    {
                                        ["durabilityLevel"] = durabilityLevel
                                    }
                                }
                            }
                        }
                    }
                };

                return GetDurabilityLevel(vmss);
            }

            public override void ExecuteCmdlet()
            {
            }
        }

        [Theory]
        [InlineData("bronze", DurabilityLevel.Bronze)]
        [InlineData("silver", DurabilityLevel.Silver)]
        [InlineData("gold", DurabilityLevel.Gold)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDurabilityLevelAcceptsLowercaseValues(string durabilityLevel, DurabilityLevel expectedDurabilityLevel)
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            Assert.Equal(expectedDurabilityLevel, cmdlet.GetNodeTypeDurabilityLevel(durabilityLevel));
            Assert.Equal(expectedDurabilityLevel, cmdlet.GetVmssDurabilityLevel(durabilityLevel));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDurabilityLevelReportsInvalidValue()
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            var exception = Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetNodeTypeDurabilityLevel("invalid"));

            Assert.Equal(
                string.Format("Cannot parse durability level {0}. Valid values are Bronze, Silver, and Gold.", "invalid"),
                exception.Message);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("999")]
        [InlineData("0")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDurabilityLevelRejectsNumericStrings(string numericValue)
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetNodeTypeDurabilityLevel(numericValue));

            Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetVmssDurabilityLevel(numericValue));
        }
    }
}
