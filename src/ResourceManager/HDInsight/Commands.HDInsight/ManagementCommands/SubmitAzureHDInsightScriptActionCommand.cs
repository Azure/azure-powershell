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
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsLifecycle.Submit,
        Constants.CommandNames.AzureHDInsightScriptAction),
    OutputType(typeof(AzureHDInsightRuntimeScriptActionOperationResource))]
    public class SubmitAzureHDInsightScriptActionCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the script name.")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the script uri.")]
        public Uri Uri { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the script node types.")]
        public RuntimeScriptActionClusterNodeType[] NodeTypes { get; set; }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the script parameters.")]
        public string Parameters { get; set; }

        [Parameter(
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the application name. ")]
        public string ApplicationName { get; set; }

        [Parameter(
            Position = 6,
            HelpMessage = "Gets or sets persist on success.")]
        public SwitchParameter PersistOnSuccess { get; set; }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var scriptAction = new RuntimeScriptAction
            {
                Name = Name,
                Parameters = Parameters,
                Roles = NodeTypes.Select(n => n.ToString()).ToList(),
                Uri = Uri,
                ApplicationName = ApplicationName
            };

            var scriptActions = new List<RuntimeScriptAction> { scriptAction };

            var executeScriptActionParameters = new ExecuteScriptActionParameters
            {
                ScriptActions = scriptActions,
                PersistOnSuccess = PersistOnSuccess.IsPresent
            };

            var operationResource = HDInsightManagementClient.ExecuteScriptActions(ResourceGroupName, ClusterName, executeScriptActionParameters);
            WriteObject(new AzureHDInsightRuntimeScriptActionOperationResource(scriptAction, operationResource));
        }
    }
}
