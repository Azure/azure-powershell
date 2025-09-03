// ----------------------------------------------------------------------------------
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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "RedeployManagedNodeType", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class InvokeAzServiceFabricRedeployManagedNodeType : ServiceFabricManagedCmdletBase
    {
        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = false, HelpMessage = "List of node names for the operation.")]
        public string[] NodeName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specify the update type. Valid values are 'Default' and 'ByUpgradeDomain'.")]
        public string UpdateType { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Using this flag will force the nodes to redeploy even if service fabric is unable to disable the nodes.")]
        public SwitchParameter ForceRedeploy { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Redeploy node(s) {0}, from node type {1} on cluster {2} with update type {3}", (this.NodeName == null)? String.Empty : string.Join(", ", this.NodeName), this.Name, this.ClusterName, this.UpdateType ?? "Default")))
            {
                try
                {
                    var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, updateType: this.UpdateType, force: this.ForceRedeploy.IsPresent);
                    var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginRedeployWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.ClusterName,
                            this.Name,
                            actionParams).GetAwaiter().GetResult();

                    this.PollLongRunningOperation(beginRequestResponse);

                    if (this.PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }
    }
}
