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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplicationType", DefaultParameterSetName = ByResourceGroupAndCluster), OutputType(typeof(PSManagedApplicationType))]
    public class GetAzServiceFabricManagedClusterApplicationType : ManagedApplicationCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByName = "ByName";
        private const string ByResourceId = "ByResourceId";

        #region Parameters
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the managed application type")]
        [Alias("ApplicationTypeName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed application type.")]
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
                        var managedAppTypeList = this.ReturnListByPageResponse(
                            this.SfrpMcClient.ApplicationTypes.List(this.ResourceGroupName, this.ClusterName),
                            this.SfrpMcClient.ApplicationTypes.ListNext);
                        WriteObject(managedAppTypeList.Select(appType => new PSManagedApplicationType(appType)), true);
                        break;
                    case ByName:
                        GetByName();
                        break;
                    case ByResourceId:
                        SetParametersByResourceId(this.ResourceId);
                        GetByName();
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

        private void GetByName()
        {
            var managedAppType = this.SfrpMcClient.ApplicationTypes.Get(this.ResourceGroupName, this.ClusterName, this.Name);
            WriteObject(new PSManagedApplicationType(managedAppType), false);
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.applicationTypeProvider, out string resourceGroup, out string resourceName, out string parentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
            this.ClusterName = parentResourceName;
        }
    }
}