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
using Microsoft.Azure.Management.ServiceFabricManagedClusters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplicationTypeVersion", DefaultParameterSetName = ByResourceGroupAndCluster), OutputType(typeof(PSManagedApplicationTypeVersion))]
    public class GetAzServiceFabricManagedClusterApplicationTypeVersion : ManagedApplicationCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByVersion = "ByVersion";
        private const string ByResourceId = "ByResourceId";

        #region Parameters
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the managed application type.")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the name of the managed application type.")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
            HelpMessage = "Specify the version of the managed application type.")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed application type version.")]
        [ResourceIdCompleter(Constants.ManagedClustersFullType)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ByResourceGroupAndCluster:
                        var managedAppTypeVersionList = this.ReturnListByPageResponse(
                            this.SfrpMcClient.ApplicationTypeVersions.ListByApplicationTypes(this.ResourceGroupName, this.ClusterName, this.Name),
                            this.SfrpMcClient.ApplicationTypeVersions.ListByApplicationTypesNext);
                        WriteObject(managedAppTypeVersionList.Select(appType => new PSManagedApplicationTypeVersion(appType)), true);
                        break;
                    case ByVersion:
                        GetByVersion();
                        break;
                    case ByResourceId:
                        SetParametersByResourceId(this.ResourceId);
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
            var managedAppTypeVersion = this.SfrpMcClient.ApplicationTypeVersions.Get(this.ResourceGroupName, this.ClusterName, this.Name, this.Version);
            WriteObject(new PSManagedApplicationTypeVersion(managedAppTypeVersion), false);
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.applicationTypeVersionProvider, out string resourceGroup, out string resourceName, out string parentResourceName, out string grandParentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = parentResourceName;
            this.Version = resourceName;
            this.ClusterName = grandParentResourceName;
        }
    }
}
