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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class DeploymentStackWhatIfFormatterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_RendersManagementAndDenyStatusesOnSameLine()
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
                                }
                            }
                        }
                    }
                }
            };

            string output = DeploymentStackWhatIfFormatter.Format(result, includeResultInfo: false);
            string[] statusLines = output
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Where(line => line.Contains("Management Status:") || line.Contains("Deny Status:"))
                .ToArray();

            string statusLine = Assert.Single(statusLines);
            Assert.Contains("Management Status:", statusLine);
            Assert.Contains("Deny Status:", statusLine);
        }
    }
}
