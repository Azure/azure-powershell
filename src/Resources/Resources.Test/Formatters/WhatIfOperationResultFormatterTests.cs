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
    using System.Collections.Generic;
    using Management.ResourceManager.Models;
    using ResourceManager.Cmdlets.Formatters;
    using ResourceManager.Cmdlets.SdkModels.Deployments;
    using System;
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
            string noChangeInfo = new ColorStringBuilder()
                .AppendLine()
                .Append("Deployment what-if: no change.")
                .ToString();

            // Act.
            string result = WhatIfOperationResultFormatter.Format(psWhatIfOperationResult);

            // Assert.
            Assert.Equal(noChangeInfo, result);
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
                .Replace("+", new ColorStringBuilder().Append("+", Color.Green).ToString())
                .Replace("!", new ColorStringBuilder().Append("!", Color.Blue).ToString())
                .Replace("*", new ColorStringBuilder().Append("*", Color.Cyan).ToString())
                .Replace("\r\n", Environment.NewLine);

            // Act.
            string result = WhatIfOperationResultFormatter.Format(psWhatIfOperationResult);

            // Assert.
            Assert.StartsWith(legend, result);
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

            string stats = new ColorStringBuilder()
                .AppendLine()
                .Append("Deployment what-if: 1 to delete, 2 to create, 1 to modify.")
                .ToString();

            // Act.
            string result = WhatIfOperationResultFormatter.Format(
                new PSWhatIfOperationResult(new WhatIfOperationResult(changes: whatIfChanges)));

            // Assert.
            Assert.EndsWith(stats, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NonEmptyResourceChanges_SortsAndGroupsThemByScopeAndChangeType()
        {
            // Arrange.
            var whatIfChanges = new List<WhatIfChange>
            {
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p1/foo1",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1/providers/p2/bar",
                    ChangeType = ChangeType.Create
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg2/providers/p1/foo2",
                    ChangeType = ChangeType.Modify
                },
                new WhatIfChange
                {
                    ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000002/providers/p3/foobar1",
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
Scope: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1
{Color.Green}
  + p1/foo1
  + p2/bar
{Color.Reset}
Scope: /subscriptions/00000000-0000-0000-0000-000000000002
{Color.Red}
  - Microsoft.Resources/resourceGroups/rg3
  - p3/foobar2{Color.Reset}{Color.Cyan}
  * p3/foobar1
{Color.Reset}
Scope: /subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/rg2
{Color.Yellow}
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
{Color.Red}
  - p5/foo
  - p6/foo{Color.Reset}{Color.Green}
  + p2/foo{Color.Reset}{Color.Blue}
  ! p4/foo{Color.Reset}{Color.Cyan}
  * p1/foo{Color.Reset}{Color.Reset}
  = p3/foo
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

            string colon = $"{Color.Reset}:{Color.Red}";
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
            string beforeValue = $@"

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
                        }
                    }
                }
            };

            string foo = $@"{Color.Red}""foo""{Color.Reset}";
            string bar = $@"{Color.Green}""bar""{Color.Reset}";
            string expected = $@"
Scope: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg1
{Color.Yellow}
  ~ p1/foo{Color.Reset}
    {Color.Yellow}~{Color.Reset} path.to.property.change{Color.Reset}:{Color.Reset} ""foo"" => ""bar""
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
