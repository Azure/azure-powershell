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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Management.Automation;
using System.IO;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsLifecycle.Enable,
        Constants.CommandNames.AzureHDInsightOMS,
        SupportsShouldProcess = true)]
    [Alias("Enable-AzureRmHDInsightOMS")]
    [OutputType(typeof(OperationResource))]
    public class EnableAzureHDInsightOMSCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster to enable Operations Management Suite(OMS).",
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true)]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the ID of the Operations Management Suite(OMS) workspace.")]
        public string WorkspaceId { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Gets to sets the primary key of the Operations Management Suite(OMS) workspace.")]
        public string PrimaryKey { get; set; }

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

            var monitoringParams = new ClusterMonitoringRequest
            {
                WorkspaceId = WorkspaceId,
                PrimaryKey = PrimaryKey
            };

            if (ShouldProcess("Enable Operations Management Suite"))
            {
                var operationResource = HDInsightManagementClient.EnableOMS(ResourceGroupName, Name, monitoringParams);
                WriteObject(operationResource);
            }
        }
    }
}
