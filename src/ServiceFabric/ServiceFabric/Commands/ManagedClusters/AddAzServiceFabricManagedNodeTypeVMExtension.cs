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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeTypeVMExtension", SupportsShouldProcess = true), OutputType(typeof(PSManagedNodeType))]
    public class AddAzServiceFabricManagedNodeTypeVMExtension : ServiceFabricCommonCmdletBase
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

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        public string NodeTypeName { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "extension name.")]
        [Alias("ExtensionName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.")]
        public string ForceUpdateTag { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the extension handler publisher.")]
        public string Publisher { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Specifies the type of the extension; an example is \"CustomScriptExtension\".")]
        public string Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Specifies the version of the script handler.")]
        public string TypeHandlerVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.")]
        public SwitchParameter AutoUpgradeMinorVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Json formatted public settings for the extension.")]
        public Object Settings { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.")]
        public Object ProtectedSettings { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Collection of extension names after which this extension needs to be provisioned.")]
        public String[] ProvisionAfterExtensions { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Add Extenions {0} with type {1} to node type {2}", this.Name, this.Type, this.NodeTypeName)))
            {
                try
                {
                    NodeType updatedNodeTypeParams = this.GetNodeTypeWithAddedExtension();
                    var beginRequestResponse = this.SFRPClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.NodeTypeName, updatedNodeTypeParams)
                        .GetAwaiter().GetResult();

                    var nodeType = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedNodeType(nodeType), false);
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private NodeType GetNodeTypeWithAddedExtension()
        {
            NodeType currentNodeType = this.SFRPClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.NodeTypeName);

            if (currentNodeType.VmExtensions == null)
            {
                currentNodeType.VmExtensions = new List<VMSSExtension>();
            }

            currentNodeType.VmExtensions.Add(new VMSSExtension()
            {
                Name = this.Name,
                Publisher = this.Publisher,
                Type = this.Type,
                TypeHandlerVersion = this.TypeHandlerVersion,
                ForceUpdateTag = this.ForceUpdateTag,
                AutoUpgradeMinorVersion = this.AutoUpgradeMinorVersion.IsPresent,
                Settings = this.Settings,
                ProtectedSettings = this.ProtectedSettings,
                ProvisionAfterExtensions = this.ProvisionAfterExtensions
            });

            return currentNodeType;
        }
    }
}
