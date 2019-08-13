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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.ServiceFabric;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplicationTypeVersion", DefaultParameterSetName = "ByResourceGroupAndCluster"), OutputType(typeof(PSApplicationTypeVersion))]
    public class GetAzServiceFabricApplicationTypeVersion : ProxyResourceCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByVersion = "ByVersion";
        private const string ByResourceId = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the application type.")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the application type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the version of the application type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the application type version.")]
        [ResourceIdCompleter("Microsoft.ServiceFabric/clusters")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ByResourceGroupAndCluster:
                        var appTypeVersionList = this.SFRPClient.ApplicationTypeVersions.
                        List(this.ResourceGroupName, this.ClusterName, this.Name).Value.
                        Select(typeVersion => new PSApplicationTypeVersion(typeVersion));
                        WriteObject(appTypeVersionList, true);
                        break;
                    case ByVersion:
                        GetByVersion();
                        break;
                    case ByResourceId:
                        SetParametersByResourceId();
                        GetByVersion();
                        break;
                    default:
                        throw new PSArgumentException("Invalid ParameterSetName");
                }
            }
            catch (Exception ex)
            {
                this.PrintSdkExceptionDetail(ex);
                throw;
            }
        }

        private void GetByVersion()
        {
            var appTypeVersion = this.SFRPClient.ApplicationTypeVersions.Get(this.ResourceGroupName, this.ClusterName, this.Name, this.Version);
            WriteObject(new PSApplicationTypeVersion(appTypeVersion), false);
        }

        private void SetParametersByResourceId()
        {
            ResourceIdentifier appTypeVersionRId = new ResourceIdentifier(this.ResourceId);
            this.ResourceGroupName = appTypeVersionRId.ResourceGroupName;
            string subscription = appTypeVersionRId.Subscription;
            ResourceIdentifier appTypeRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appTypeVersionRId.ParentResource}");
            ResourceIdentifier clusterRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appTypeRId.ParentResource}");
            if (!appTypeVersionRId.ResourceType.EndsWith(Constants.applicationTypeVersionProvider)
                || !appTypeRId.ResourceType.EndsWith(Constants.applicationTypeProvider)
                || !clusterRId.ResourceType.EndsWith(Constants.clusterProvider))
            {
                throw new PSArgumentException(string.Format("invalid resource id {0}", this.ResourceId));
            }

            this.ClusterName = clusterRId.ResourceName;
            this.Name = appTypeRId.ResourceName;
            this.Version = appTypeVersionRId.ResourceName;
        }
    }
}
