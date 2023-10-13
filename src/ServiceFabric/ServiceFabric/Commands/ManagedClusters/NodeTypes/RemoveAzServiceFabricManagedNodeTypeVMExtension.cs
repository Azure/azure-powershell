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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeTypeVMExtension", DefaultParameterSetName = ByObj, SupportsShouldProcess = true), OutputType(typeof(PSManagedNodeType))]
    public class RemoveAzServiceFabricManagedNodeTypeVMExtension : ServiceFabricManagedCmdletBase
    {
        protected const string ByName = "ByName";
        protected const string ByObj = "ByObj";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        public string NodeTypeName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ByObj,
            HelpMessage = "Node type resource")]
        [ValidateNotNull]
        public PSManagedNodeType InputObject { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "extension name.")]
        [Alias("ExtensionName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            this.SetParams();
            if (ShouldProcess(target: this.Name, action: string.Format("Remove Extenions {0} from node type {1}", this.Name, this.NodeTypeName)))
            {
                try
                {
                    NodeType updatedNodeTypeParams = this.GetNodeTypeWithRemovedExtension();
                    var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.NodeTypeName, updatedNodeTypeParams)
                        .GetAwaiter().GetResult();

                    var nodeType = this.PollLongRunningOperation(beginRequestResponse);

                    if (this.PassThru)
                    {
                        WriteObject(true);
                    }
                    else
                    {
                        WriteObject(new PSManagedNodeType(nodeType), false);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private NodeType GetNodeTypeWithRemovedExtension()
        {
            NodeType currentNodeType = this.SfrpMcClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.NodeTypeName);

            if (currentNodeType.VmExtensions != null)
            {
                var originalLength = currentNodeType.VmExtensions.Count();
                currentNodeType.VmExtensions = currentNodeType.VmExtensions.Where(ext => !string.Equals(ext.Name, this.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (originalLength == currentNodeType.VmExtensions.Count())
                {
                    throw new ArgumentException(string.Format("extension with name {0} not found", this.Name));
                }
            }

            return currentNodeType;
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.ManagedNodeTypeProvider, out string resourceGroup, out string resourceName, out string parentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.NodeTypeName = resourceName;
            this.ClusterName = parentResourceName;
        }
    }
}
