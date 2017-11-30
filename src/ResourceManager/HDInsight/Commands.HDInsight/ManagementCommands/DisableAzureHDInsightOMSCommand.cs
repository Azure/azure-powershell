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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsLifecycle.Disable,
        Constants.CommandNames.AzureHDInsightOMS,
        SupportsShouldProcess = true)]
    [Alias("Disable-AzureRmHDInsightOMS")]
    [OutputType(typeof(OperationResource))]
    public class DisableAzureHDInsightOMSCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster to disable Operations Management Suite(OMS).",
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true)]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(
            HelpMessage = "Gets or sets the resource group of the cluster.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(Name);
            }

            if (ShouldProcess("Disable Operations Management Suite"))
            {
                var operationResource = HDInsightManagementClient.DisableOMS(ResourceGroupName, Name);
                WriteObject(operationResource);
            }
        }
    }
}
