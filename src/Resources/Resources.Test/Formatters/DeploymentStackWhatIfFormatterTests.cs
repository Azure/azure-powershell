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
    using System.Text.RegularExpressions;
    using Xunit;

    public class DeploymentStackWhatIfFormatterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_RendersTagsInStableOrder()
        {
            var result = new PSDeploymentStackWhatIfResult
            {
                Tags = new Dictionary<string, string>
                {
                    { "zebra", "last" },
                    { "alpha", "first" }
                }
            };

            string output = DeploymentStackWhatIfFormatter.Format(result);

            Assert.Contains("Tags:", output);
            Assert.Contains("alpha=first", output);
            Assert.Contains("zebra=last", output);
            Assert.True(output.IndexOf("alpha=first", StringComparison.Ordinal) < output.IndexOf("zebra=last", StringComparison.Ordinal));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_IndentsResourceStatusesAndPropertiesAndMultilineValues()
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
            output = Regex.Replace(output, @"\x1B\[[0-9;]*m", string.Empty);
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string resourceLine = Assert.Single(lines, line => line.Contains("Microsoft.Storage/storageAccounts/test"));
            string managementLine = Assert.Single(lines, line => line.Contains("Management Status:"));
            string denyLine = Assert.Single(lines, line => line.Contains("Deny Status:"));
            string propertyLine = Assert.Single(lines, line => line.Contains("properties.scalar:"));
            string nestedPathLine = Assert.Single(lines, line => line.Contains("properties.nested:"));
            string nestedValueLine = Assert.Single(lines, line => line.Contains("\"type\": \"object\""));

            int resourceIndent = resourceLine.TakeWhile(char.IsWhiteSpace).Count();
            Assert.Equal(resourceIndent + 2, managementLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent + 2, denyLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent + 2, propertyLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent + 2, nestedPathLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.Equal(resourceIndent + 6, nestedValueLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.EndsWith("properties.nested: {", nestedPathLine);
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
            output = Regex.Replace(output, @"\x1B\[[0-9;]*m", string.Empty);
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string propertiesLine = Assert.Single(lines, line => line.Contains("properties:"));
            string displayNameLine = Assert.Single(lines, line => line.Contains("\"displayName\": \"Created template spec\""));

            Assert.Equal(
                propertiesLine.TakeWhile(char.IsWhiteSpace).Count() + 4,
                displayNameLine.TakeWhile(char.IsWhiteSpace).Count());
            Assert.EndsWith("properties: {", propertiesLine);
            Assert.Contains("\"description\": \"Created by WhatIf\"", output);
            Assert.DoesNotContain("apiVersion:", output);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create", "Definite", "+")]
        [InlineData("Delete", "Definite", "-")]
        [InlineData("Create", "Potential", "+")]
        [InlineData("Delete", "Potential", "-")]
        public void Format_RendersFilteredResourceConfiguration(string changeType, string certainty, string symbol)
        {
            var configuration = new JObject
            {
                ["properties"] = new JObject { ["name"] = "nested-name", ["type"] = "nested-type", ["enabled"] = true },
                ["tags"] = new JObject { ["name"] = "tag-name", ["environment"] = "test" },
                ["sku"] = new JObject { ["name"] = "Standard_LRS" },
                ["location"] = "centralus",
                ["kind"] = "StorageV2",
                ["identity"] = new JObject { ["type"] = "SystemAssigned" },
                ["condition"] = "[greater(int(utcNow('s')), 4)]",
                ["zones"] = new JArray("1", "2"),
                ["enabled"] = false,
                ["replicas"] = 0,
                ["emptyString"] = "",
                ["nullable"] = JValue.CreateNull(),
                ["apiVersion"] = "2023-05-01",
                ["extension"] = new JObject { ["name"] = "hidden-extension" },
                ["id"] = "hidden-id",
                ["identifiers"] = new JObject { ["name"] = "hidden-identifier" },
                ["name"] = "hidden-name",
                ["resourceGroup"] = "hidden-group",
                ["type"] = "hidden-type"
            };
            var otherConfiguration = new JObject { ["properties"] = new JObject { ["wrongSide"] = "not-selected" } };
            var resourceChange = new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/test",
                ApiVersion = "2023-05-01",
                ChangeType = changeType,
                ChangeCertainty = certainty,
                ManagementStatusChange = new PSDeploymentStackWhatIfChangeBase { Before = "notManaged", After = "managed" },
                DenyStatusChange = new PSDeploymentStackWhatIfChangeBase { Before = "none", After = "denyDelete" },
                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                {
                    Before = changeType == "Delete" ? configuration : otherConfiguration,
                    After = changeType == "Create" ? configuration : otherConfiguration,
                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>
                    {
                        new PSDeploymentStackWhatIfPropertyChange { Path = "ignoredDelta", ChangeType = "Modify", Before = "old", After = "new" }
                    }
                }
            };
            string output = FormatResourceForTest(resourceChange);

            Assert.Contains("Management Status:", output);
            Assert.Contains("Deny Status:", output);
            Assert.Contains($"{symbol} location: \"centralus\"", output);
            Assert.Contains($"{symbol} kind: \"StorageV2\"", output);
            Assert.Contains($"{symbol} enabled: false", output);
            Assert.Contains($"{symbol} replicas: 0", output);
            Assert.Contains($"{symbol} emptyString: \"\"", output);
            Assert.Contains($"{symbol} condition:", output);
            Assert.Contains("\"Standard_LRS\"", output);
            Assert.Contains("\"SystemAssigned\"", output);
            Assert.Contains("\"name\": \"nested-name\"", output);
            Assert.Contains("\"type\": \"nested-type\"", output);
            Assert.Contains("\"name\": \"tag-name\"", output);
            Assert.Contains("\"enabled\": true", output);
            Assert.DoesNotContain("nullable:", output);
            Assert.DoesNotContain("not-selected", output);
            Assert.DoesNotContain("ignoredDelta", output);
            foreach (string key in new[] { "apiVersion", "extension", "id", "identifiers", "name", "resourceGroup", "type" })
            {
                Assert.DoesNotContain($"{symbol} {key}:", output);
            }
            Assert.DoesNotContain("hidden-", output);
            string[] orderedKeys = { "condition", "emptyString", "enabled", "identity", "kind", "location", "replicas", "sku", "tags", "zones", "properties" };
            int previousIndex = -1;
            foreach (string key in orderedKeys)
            {
                int index = output.IndexOf($"{symbol} {key}:", StringComparison.Ordinal);
                Assert.True(index > previousIndex, $"Expected {key} in sorted configuration output.");
                previousIndex = index;
            }
            if (certainty == "Potential")
            {
                Assert.Contains($"?{symbol} [Potential]", output);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create")]
        [InlineData("Delete")]
        public void Format_RendersConfigurationWithoutProperties(string changeType)
        {
            var configuration = new JObject { ["location"] = "centralus", ["tags"] = new JObject() };
            string output = FormatResourceForTest(new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/test",
                ChangeType = changeType,
                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                {
                    Before = changeType == "Delete" ? configuration : null,
                    After = changeType == "Create" ? configuration : null
                }
            });

            Assert.Contains("location: \"centralus\"", output);
            Assert.Contains("tags: {}", output);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create", false)]
        [InlineData("Create", true)]
        [InlineData("Delete", false)]
        [InlineData("Delete", true)]
        [InlineData("Modify", false)]
        [InlineData("Modify", true)]
        public void Format_UsesDeltaWhenNoSelectedConfiguration(string changeType, bool hasConfiguration)
        {
            var configuration = changeType == "Modify"
                ? new JObject { ["properties"] = new JObject { ["snapshotOnly"] = "do-not-render" } }
                : new JObject();
            string output = FormatResourceForTest(new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/test",
                ChangeType = changeType,
                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                {
                    Before = hasConfiguration ? configuration : null,
                    After = hasConfiguration ? configuration : null,
                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>
                    {
                        new PSDeploymentStackWhatIfPropertyChange { Path = "properties.sku", ChangeType = "Modify", Before = "Basic", After = "Standard" }
                    }
                }
            });

            Assert.Contains("~ properties.sku: \"Basic\" => \"Standard\"", output);
            Assert.DoesNotContain("snapshotOnly", output);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create")]
        [InlineData("Delete")]
        public void Format_HandlesMissingResourceConfiguration(string changeType)
        {
            string output = FormatResourceForTest(new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/test",
                ChangeType = changeType,
                ManagementStatusChange = new PSDeploymentStackWhatIfChangeBase { Before = "notManaged", After = "managed" }
            });

            Assert.Contains("/subscriptions/test/resourceGroups/test", output);
            Assert.Contains("Management Status:", output);
            Assert.DoesNotContain("properties:", output);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create")]
        [InlineData("Delete")]
        public void Format_DoesNotFallBackToDeltaForMetadataOnlyConfiguration(string changeType)
        {
            var configuration = new JObject { ["name"] = "hidden-name", ["nullable"] = JValue.CreateNull() };
            string output = FormatResourceForTest(new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/test",
                ChangeType = changeType,
                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                {
                    Before = changeType == "Delete" ? configuration : null,
                    After = changeType == "Create" ? configuration : null,
                    Delta = new List<PSDeploymentStackWhatIfPropertyChange>
                    {
                        new PSDeploymentStackWhatIfPropertyChange { Path = "ignoredDelta", ChangeType = "Create", After = "not-selected" }
                    }
                }
            });

            Assert.Contains("/subscriptions/test/resourceGroups/test", output);
            Assert.DoesNotContain("hidden-name", output);
            Assert.DoesNotContain("nullable:", output);
            Assert.DoesNotContain("ignoredDelta", output);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Create", "Definite", "+")]
        [InlineData("Delete", "Definite", "-")]
        [InlineData("Create", "Potential", "+")]
        [InlineData("Delete", "Potential", "-")]
        public void Format_UsesCliIndentationForConfigurationAndSubsequentResources(string changeType, string certainty, string symbol)
        {
            var configuration = new JObject
            {
                ["location"] = "centralus",
                ["sku"] = new JObject { ["name"] = "Standard_LRS" },
                ["zones"] = new JArray("1"),
                ["properties"] = new JObject
                {
                    ["enabled"] = false,
                    ["nested"] = new JObject { ["type"] = "example" }
                }
            };
            var first = new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/a",
                ChangeType = changeType,
                ChangeCertainty = certainty,
                ManagementStatusChange = new PSDeploymentStackWhatIfChangeBase
                {
                    ChangeType = "Modify",
                    Before = changeType == "Create" ? "notManaged" : "managed",
                    After = changeType == "Create" ? "managed" : "notManaged"
                },
                DenyStatusChange = new PSDeploymentStackWhatIfChangeBase { ChangeType = "NoChange", Before = "none", After = "none" },
                ResourceConfigurationChanges = new PSDeploymentStackWhatIfResourceConfigurationChanges
                {
                    Before = changeType == "Delete" ? configuration : null,
                    After = changeType == "Create" ? configuration : null
                }
            };
            var second = new PSDeploymentStackWhatIfResourceChange
            {
                Id = "/subscriptions/test/resourceGroups/z",
                ChangeType = changeType,
                ChangeCertainty = certainty
            };
            string output = FormatResourceForTest(first, second);
            string headingSymbol = certainty == "Potential" ? $"?{symbol} [Potential]" : symbol;
            string expected = string.Join(Environment.NewLine, new[]
            {
                $"  {headingSymbol} {first.Id}",
                $"    ~ Management Status: \"{first.ManagementStatusChange.Before}\" => \"{first.ManagementStatusChange.After}\"",
                "    = Deny Status: \"none\"",
                $"    {symbol} location: \"centralus\"",
                $"    {symbol} sku: {{",
                "        \"name\": \"Standard_LRS\"",
                "      }",
                $"    {symbol} zones: [",
                "        \"1\"",
                "      ]",
                $"    {symbol} properties: {{",
                "        \"enabled\": false,",
                "        \"nested\": {",
                "          \"type\": \"example\"",
                "        }",
                "      }",
                $"  {headingSymbol} {second.Id}"
            });

            Assert.Contains(expected, output);
        }

        private static string FormatResourceForTest(params PSDeploymentStackWhatIfResourceChange[] resourceChanges)
        {
            string output = DeploymentStackWhatIfFormatter.Format(new PSDeploymentStackWhatIfResult
            {
                Properties = new PSDeploymentStackWhatIfProperties
                {
                    Changes = new PSDeploymentStackWhatIfChanges
                    {
                        ResourceChanges = resourceChanges.ToList()
                    }
                }
            }, includeResultInfo: false);

            return Regex.Replace(output, @"\x1B\[[0-9;]*m", string.Empty);
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
