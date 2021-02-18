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
    using Management.ResourceManager.Models;
    using ResourceManager.Cmdlets.Formatters;
    using ResourceManager.Cmdlets.SdkModels.Deployments;
    using System;
    using System.Collections.Generic;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class WhatIfOperationResultFormatterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_EmptyResourceChanges_ReturnsNoChangeInfo()
        {
            // Arrange.
            var psWhatIfOperationResult = new PSWhatIfOperationResult(new WhatIfOperationResult());
            string noChangeInfo = new ColoredStringBuilder()
                .AppendLine()
                .Append("Resource changes: no change.")
                .ToString();

            // Act.
            string result = WhatIfOperationResultFormatter.Format(psWhatIfOperationResult);

            // Assert.
            Assert.Contains(noChangeInfo, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NonEmptyResourceChanges_AddsLegendAtTheBeginning()
        {
            // Arrange.
            var resourceChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Deploy
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Ignore
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Create
                }
            };

            var psWhatIfOperationResult =
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: resourceChanges));

            string legend = @"Resource and property changes are indicated with these symbols:
  + Create
  ! Deploy
  * Ignore
"
                .Replace("+", new ColoredStringBuilder().Append("+", Color.Green).ToString())
                .Replace("!", new ColoredStringBuilder().Append("!", Color.Blue).ToString())
                .Replace("*", new ColoredStringBuilder().Append("*", Color.Gray).ToString())
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(psWhatIfOperationResult);

            // Assert.
            Assert.Contains(legend, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NonEmptyResourceChanges_AddsStatsAtTheEnd()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Modify
                },
                new WhatIfChange
                {
                    ResourceId = "",
                    ChangeType = ChangeType.Delete
                }
            };

            string stats = new ColoredStringBuilder()
                .AppendLine()
                .Append("Resource changes: 1 to delete, 2 to create, 1 to modify.")
                .ToString();

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.EndsWith(stats, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NonEmptyResourceChanges_ExtractApiVersion()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg1/providers/p2/foo",
                    ChangeType = ChangeType.Modify,
                    Before = new { apiVersion = "2018-07-01" },
                    After = new { apiVersion = "2018-07-01" }
                },
            };

            string changesInfo = $@"
Scope: /subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg1
{Color.Purple}
  ~ p2/foo{Color.Reset} [2018-07-01]{Color.Purple}
{Color.Reset}"
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(changesInfo, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NonEmptyResourceChanges_SortsAndGroupsByScopeAndChangeType()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/Subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/RG1/providers/p1/foo1",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "/Subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p2/bar",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg2/providers/p1/foo2",
                    ChangeType = ChangeType.Modify
                },
                new WhatIfChange
                {
                    ResourceId = "/SUBSCRIPTIONS/00000000-0000-0000-0000-000000000002/providers/p3/foobar1",
                    ChangeType = ChangeType.Ignore
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/providers/p3/foobar2",
                    ChangeType = ChangeType.Delete
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg3",
                    ChangeType = ChangeType.Delete
                }
            };

            string changesInfo = $@"
Scope: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/RG1
{Color.Green}
  + p1/foo1
  + p2/bar
{Color.Reset}
Scope: /subscriptions/00000000-0000-0000-0000-000000000002
{Color.Orange}
  - p3/foobar2
  - resourceGroups/rg3{Color.Reset}{Color.Gray}
  * p3/foobar1
{Color.Reset}
Scope: /subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg2
{Color.Purple}
  ~ p1/foo2
{Color.Reset}"
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(changesInfo, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_ResourceIdOnly_SortsAndGroupsByShortResourceId()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p1/foo",
                    ChangeType = ChangeType.Ignore,
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p2/foo",
                    ChangeType = ChangeType.Create,
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p3/foo",
                    ChangeType = ChangeType.NoChange,
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p4/foo",
                    ChangeType = ChangeType.Deploy,
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p5/foo",
                    ChangeType = ChangeType.Delete,
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p6/foo",
                    ChangeType = ChangeType.Delete,
                }
            };

            string shortResourceIds = $@"
{Color.Orange}
  - p5/foo
  - p6/foo{Color.Reset}{Color.Green}
  + p2/foo{Color.Reset}{Color.Blue}
  ! p4/foo{Color.Reset}{Color.Reset}
  = p3/foo{Color.Reset}{Color.Gray}
  * p1/foo
{Color.Reset}
"
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(shortResourceIds, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_ChangeTypeDelete_FormatsBeforeValue()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p1/foo",
                    ChangeType = ChangeType.Delete,
                    Before = new
                    {
                        numberValue = 1.2,
                        booleanValue = true,
                        stringValue = "str",
                    }
                }
            };

            string colon = $"{Color.Reset}:{Color.Orange}";
            string beforeValue = @"

      numberValue:  1.2
      booleanValue: true
      stringValue:  ""str""
"
                .Replace(":", colon)
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(beforeValue, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_ChangeTypeCreate_FormatsAfterValue()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p1/foo",
                    ChangeType = ChangeType.Create,
                    After = new
                    {
                        numberValue = 1.2,
                        booleanValue = true,
                        stringValue = "str",
                    }
                }
            };

            string colon = $"{Color.Reset}:{Color.Green}";
            string afterValue = $@"

      numberValue:  1.2
      booleanValue: true
      stringValue:  ""str""
"
                .Replace(":", colon)
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(afterValue, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_ChangeTypeModify_FormatsPropertyChanges()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p1/foo",
                    ChangeType = ChangeType.Modify,
                    Delta = new List<WhatIfPropertyChange>
                    {
                        new WhatIfPropertyChange
                        {
                            Path = "path.to.property.change",
                            PropertyChangeType = PropertyChangeType.Modify,
                            Before = "foo",
                            After = "bar"
                        },
                        new WhatIfPropertyChange
                        {
                            Path = "path.to.array.change",
                            PropertyChangeType = PropertyChangeType.Array,
                            Children = new List<WhatIfPropertyChange>
                            {
                                new WhatIfPropertyChange
                                {
                                    Path = "1",
                                    PropertyChangeType = PropertyChangeType.Modify,
                                    Before = "foo",
                                    After = "bar"
                                }
                            }
                        },
                    }
                }
            };

            string foo = $@"{Color.Orange}""foo""{Color.Reset}";
            string bar = $@"{Color.Green}""bar""{Color.Reset}";
            string expected = $@"
Scope: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1
{Color.Purple}
  ~ p1/foo{Color.Reset}
    {Color.Purple}~{Color.Reset} path.to.array.change{Color.Reset}:{Color.Reset} [
      {Color.Purple}~{Color.Reset} 1{Color.Reset}:{Color.Reset} ""foo"" => ""bar""
      ]
    {Color.Purple}~{Color.Reset} path.to.property.change{Color.Reset}:{Color.Reset} ""foo"" => ""bar""
"
                .Replace(@"""foo""", foo)
                .Replace(@"""bar""", bar)
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.Contains(expected, result);
        }
    }
}

