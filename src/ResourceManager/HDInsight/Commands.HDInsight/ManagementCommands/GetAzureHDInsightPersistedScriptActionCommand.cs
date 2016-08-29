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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Get,
        Constants.CommandNames.AzureHDInsightPersistedScriptAction),
    OutputType(typeof(IList<AzureHDInsightRuntimeScriptAction>))]
    public class GetAzureHDInsightPersistedScriptAction : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Gets or sets the script name.")]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var result = new List<AzureHDInsightRuntimeScriptAction>();

            var persistedScripts = HDInsightManagementClient.ListPersistedScripts(ResourceGroupName, ClusterName);
            if (persistedScripts != null)
            {
                if (string.IsNullOrEmpty(Name))
                {
                    result.AddRange(persistedScripts.Select(p => new AzureHDInsightRuntimeScriptAction(p)));
                }
                else
                {
                    var filteredScripts = persistedScripts.Where(p => string.Equals(p.Name, Name, StringComparison.OrdinalIgnoreCase))
                        .Select(p => new AzureHDInsightRuntimeScriptAction(p));
                    result.AddRange(filteredScripts);
                }
            }

            WriteObject(result, true);
        }
    }
}
