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
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", SupportsShouldProcess = true), OutputType(typeof(PSManagedNodeType))]
    public class NewAzServiceFabricManagedNodeType : ServiceFabricCommonCmdletBase
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
        //TODO alsantam: validate length? 9
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "TODO")]
        public int InstanceCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public SwitchParameter Primary { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO in GB")]
        public int? DiskSize { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public int? ApplicationStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public int? ApplicationEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public int? EphemeralStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public int? EphemeralEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public string VmSize { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public string VmImagePublisher { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public string VmImageOffer { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public string VmImageSku { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "TODO")]
        public string VmImageVersion { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Create new managed cluster. name {0}, resouce group: {1}", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    NodeType newNodeTypeParams = this.GetNewNodeTypeParameters();
                    var beginRequestResponse = this.SFRPClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, newNodeTypeParams)
                        .GetAwaiter().GetResult();

                    NodeType nodeType = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedNodeType(nodeType), false);
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private NodeType GetNewNodeTypeParameters()
        {
            if (!this.DiskSize.HasValue)
            {
                this.DiskSize = 100;
            }

            var vmSize = "Standard_D2";
            if (!string.IsNullOrEmpty(this.VmSize))
            {
                vmSize = this.VmSize;
            }

            var vmImagePublisher = "MicrosoftWindowsServer";
            if (!string.IsNullOrEmpty(this.VmImagePublisher))
            {
                vmImagePublisher = this.VmImagePublisher;
            }

            var vmImageOffer = "WindowsServer";
            if (!string.IsNullOrEmpty(this.VmImageOffer))
            {
                vmImageOffer = this.VmImageOffer;
            }

            var vmImageSku = "2019-Datacenter";
            if (!string.IsNullOrEmpty(this.VmImageSku))
            {
                vmImageSku = this.VmImageSku;
            }

            var vmImageVersion = "latest";
            if (!string.IsNullOrEmpty(this.VmImageVersion))
            {
                vmImageVersion = this.VmImageVersion;
            }

            var newNodeType = new NodeType(
                isPrimary: this.Primary.IsPresent,
                vmInstanceCount: this.InstanceCount,
                dataDiskSizeGB: this.DiskSize.Value,
                name: this.Name,
                vmSize: vmSize,
                vmImagePublisher: vmImagePublisher,
                vmImageOffer: vmImageOffer,
                vmImageSku: vmImageSku,
                vmImageVersion: vmImageVersion
            );

            if (this.ApplicationStartPort.HasValue && this.ApplicationEndPort.HasValue)
            {
                newNodeType.ApplicationPorts = new EndpointRangeDescription(this.ApplicationStartPort.Value, this.ApplicationEndPort.Value);
            }

            if (this.EphemeralStartPort.HasValue && this.EphemeralEndPort.HasValue)
            {
                newNodeType.EphemeralPorts = new EndpointRangeDescription(this.EphemeralStartPort.Value, this.EphemeralEndPort.Value);
            }

            return newNodeType;
        }
    }
}
