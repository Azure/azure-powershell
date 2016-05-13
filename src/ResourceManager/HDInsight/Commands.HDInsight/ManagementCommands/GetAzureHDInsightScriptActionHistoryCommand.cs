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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Get,
        Constants.CommandNames.AzureHDInsightScriptActionHistory),
    OutputType(typeof(IList<AzureHDInsightRuntimeScriptActionDetail>))]
    public class GetAzureHDInsightScriptActionHistory : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Gets or sets the script execution id.")]
        public long? ScriptExecutionId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var result = new List<AzureHDInsightRuntimeScriptActionDetail>();

            if (ScriptExecutionId.HasValue)
            {
                var executionDetailResponse = HDInsightManagementClient.GetScriptExecutionDetail(ResourceGroupName, ClusterName, ScriptExecutionId.Value);
                if (executionDetailResponse != null && executionDetailResponse.RuntimeScriptActionDetail != null)
                {
                    result.Add(new AzureHDInsightRuntimeScriptActionDetail(executionDetailResponse.RuntimeScriptActionDetail));
                }
            }
            else
            {
                var executionHistory = HDInsightManagementClient.ListScriptExecutionHistory(ResourceGroupName, ClusterName);
                if (executionHistory != null)
                {
                    result.AddRange(executionHistory.Select(h => new AzureHDInsightRuntimeScriptActionDetail(h)));
                }
            }

            WriteObject(result, true);
        }
    }
}
