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

namespace Microsoft.Azure.Commands.Resources.Test.Formatters
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class DeploymentStackWhatIfFormatterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_AlignsResourceStatusesAndPropertiesAndIndentsMultilineValues()
        {
            var result = new PSDeploymentStackWhatIfResult
            {
                Properties = new PSDeploymentStackWhatIfProperties
                {
                    Changes = new PSDeploymentStackWhatIfChanges
                    {
                        ResourceChanges = new List<PSDeploymentStackWhatIfResourceChange>
                        {
                            new PSDeploymentStackWhatIfResourceChange
                            {
                                Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/test",
                                Type = "Microsoft.Storage/storageAccounts",
                                ApiVersion = "2023-05-01",
                                ChangeType = "Create",
                                ChangeCertainty = "Definite",
                                ManagementStatusChange = new PSDeploymentStackWhatIfChangeBase
                                {
                                    ChangeType = "Modify",
                                    Before = "notManaged",
                                    After = "managed"
                                },
                                DenyStatusChange = new PSDeploymentStackWhatIfChangeBase
                                {
                                    ChangeType = "NoChange",
                                    Before = "none",
                                    After = "none"
                                },
                                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                                {
                                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>
                                    {
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.scalar",
                                            ChangeType = "Modify",
                                            Before = "before",
                                            After = "after"
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.nested",
                                            ChangeType = "Create",
                                            After = new JObject
                                            {
                                                ["type"] = "object",
                                                ["value"] = new JObject
                                                {
                                                    ["enabled"] = true
                                                }
                                            }
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "condition",
                                            ChangeType = "Create",
                                            After = "[greater(int(utcNow('%f')), 4)]"
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.subnets[0].type",
                                            ChangeType = "NoEffect",
                                            Before = "Microsoft.Network/virtualNetworks/subnets",
                                            After = "Microsoft.Network/virtualNetworks/subnets"
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.subnets[1].type",
                                            ChangeType = "NoChange",
                                            Before = "Microsoft.Network/virtualNetworks/subnets",
                                            After = "Microsoft.Network/virtualNetworks/subnets"
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.unchangedValue",
                                            Before = "same",
                                            After = "same"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            string output = DeploymentStackWhatIfFormatter.Format(result, includeResultInfo: false);
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string resourceLine = Assert.Single(lines, line => line.Contains("Microsoft.Storage/storageAccounts/test"));
            string managementLine = Assert.Single(lines, line => line.Contains("Management Status:"));
            string denyLine = Assert.Single(lines, line => line.Contains("Deny Status:"));
            string propertyLine = Assert.Single(lines, line => line.Contains("properties.scalar:"));
            string nestedPathLine = Assert.Single(lines, line => line.Contains("properties.nested:"));
            string nestedValueLine = Assert.Single(lines, line => line.Contains("\"type\": \"object\""));

            int resourceIndent = resourceLine.TakeWhile(char.IsWhiteSpace).Count();
            Assert.Equal(resourceIndent, managementLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent, denyLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent, propertyLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent, nestedPathLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent + 2, nestedValueLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.DoesNotContain("Deny Status:", managementLine);
            Assert.DoesNotContain("condition:", output);
            Assert.DoesNotContain("utcNow", output);
            Assert.DoesNotContain("properties.subnets[0].type", output);
            Assert.DoesNotContain("properties.subnets[1].type", output);
            Assert.DoesNotContain("properties.unchangedValue", output);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_RendersPropertiesFromCreateAfterConfiguration()
        {
            var result = new PSDeploymentStackWhatIfResult
            {
                Properties = new PSDeploymentStackWhatIfProperties
                {
                    Changes = new PSDeploymentStackWhatIfChanges
                    {
                        ResourceChanges = new List<PSDeploymentStackWhatIfResourceChange>
                        {
                            new PSDeploymentStackWhatIfResourceChange
                            {
                                Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Resources/templateSpecs/test",
                                Type = "Microsoft.Resources/templateSpecs",
                                ApiVersion = "2022-02-01",
                                ChangeType = "Create",
                                ChangeCertainty = "Definite",
                                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                                {
                                    After = new JObject
                                    {
                                        ["apiVersion"] = "2022-02-01",
                                        ["name"] = "test",
                                        ["properties"] = new JObject
                                        {
                                            ["displayName"] = "Created template spec",
                                            ["description"] = "Created by WhatIf"
                                        },
                                        ["type"] = "Microsoft.Resources/templateSpecs"
                                    },
                                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>()
                                }
                            }
                        }
                    }
                }
            };

            string output = DeploymentStackWhatIfFormatter.Format(result, includeResultInfo: false);
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string propertiesLine = Assert.Single(lines, line => line.Contains("properties:"));
            string displayNameLine = Assert.Single(lines, line => line.Contains("\"displayName\": \"Created template spec\""));

            Assert.Equal(
                propertiesLine.TakeWhile(char.IsWhiteSpace).Count() + 2,
                displayNameLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Contains("\"description\": \"Created by WhatIf\"", output);
            Assert.DoesNotContain("apiVersion:", output);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_RendersArrayValuesAndNestedChildrenWithoutNullPlaceholders()
        {
            var result = new PSDeploymentStackWhatIfResult
            {
                Properties = new PSDeploymentStackWhatIfProperties
                {
                    Changes = new PSDeploymentStackWhatIfChanges
                    {
                        ResourceChanges = new List<PSDeploymentStackWhatIfResourceChange>
                        {
                            new PSDeploymentStackWhatIfResourceChange
                            {
                                Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Network/virtualNetworks/test",
                                Type = "Microsoft.Network/virtualNetworks",
                                ApiVersion = "2023-11-01",
                                ChangeType = "Modify",
                                ChangeCertainty = "Definite",
                                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                                {
                                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>
                                    {
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.addressSpace.addressPrefixes",
                                            ChangeType = "Array",
                                            Children = new List<PSDeploymentStackWhatIfPropertyChange>
                                            {
                                                new PSDeploymentStackWhatIfPropertyChange
                                                {
                                                    Path = "0",
                                                    ChangeType = "Delete",
                                                    Before = "10.10.0.0/16"
                                                },
                                                new PSDeploymentStackWhatIfPropertyChange
                                                {
                                                    Path = "0",
                                                    ChangeType = "Create",
                                                    After = "10.20.0.0/16"
                                                }
                                            }
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.subnets",
                                            ChangeType = "Array",
                                            Children = new List<PSDeploymentStackWhatIfPropertyChange>
                                            {
                                                new PSDeploymentStackWhatIfPropertyChange
                                                {
                                                    Path = "0",
                                                    ChangeType = "Modify",
                                                    Children = new List<PSDeploymentStackWhatIfPropertyChange>
                                                    {
                                                        new PSDeploymentStackWhatIfPropertyChange
                                                        {
                                                            Path = "properties.addressPrefix",
                                                            ChangeType = "Modify",
                                                            Before = "10.10.0.0/24",
                                                            After = "10.20.0.0/24"
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new PSDeploymentStackWhatIfPropertyChange
                                        {
                                            Path = "properties.privateLinkServiceConnections",
                                            ChangeType = "Array",
                                            Children = new List<PSDeploymentStackWhatIfPropertyChange>
                                            {
                                                new PSDeploymentStackWhatIfPropertyChange
                                                {
                                                    Path = "0",
                                                    ChangeType = "Modify"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            string output = DeploymentStackWhatIfFormatter.Format(result, includeResultInfo: false);

            Assert.Contains("properties.addressSpace.addressPrefixes", output);
            Assert.Contains("\"10.10.0.0/16\"", output);
            Assert.Contains("\"10.20.0.0/16\"", output);
            Assert.Contains("properties.addressPrefix", output);
            Assert.Contains("\"10.10.0.0/24\"", output);
            Assert.Contains("\"10.20.0.0/24\"", output);
            Assert.DoesNotContain("privateLinkServiceConnections", output);
            Assert.DoesNotContain("null", output);
        }
    }
}
