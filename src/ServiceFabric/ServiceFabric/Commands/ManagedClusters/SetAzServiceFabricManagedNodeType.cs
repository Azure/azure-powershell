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
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", DefaultParameterSetName = ReimageParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class SetAzServiceFabricManagedNodeType : ServiceFabricCommonCmdletBase
    {
        protected const string ReimageParameterSet = "Reimage";

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

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = true, ParameterSetName = ReimageParameterSet, HelpMessage = "List of node names for the operation.")]
        [ValidateNotNullOrEmpty()]
        public List<string> NodeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ReimageParameterSet, HelpMessage = "Specify to reimage nodes on the node type.")]
        public SwitchParameter Reimage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ReimageParameterSet,
            HelpMessage = "Using this flag will force the removal even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the node.")]
        public SwitchParameter ForceReimage { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName == ReimageParameterSet)
                {
                    if (ShouldProcess(target: this.Name, action: string.Format("Reimage node(s) {0}, from node type {1} on cluster {2}", string.Join(", ", this.NodeName), this.Name, this.ClusterName)))
                    {

                        var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, force: this.ForceReimage.IsPresent);
                        var beginRequestResponse = this.SFRPClient.NodeTypes.BeginReimageWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.ClusterName,
                                this.Name,
                                actionParams).GetAwaiter().GetResult();

                        this.PollLongRunningOperation(beginRequestResponse);
                    }
                }

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
