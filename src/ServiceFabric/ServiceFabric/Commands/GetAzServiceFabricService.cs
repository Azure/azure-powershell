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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricService", DefaultParameterSetName = "ByResourceGroupAndCluster"), OutputType(typeof(PSService))]
    public class GetAzServiceFabricService : ProxyResourceCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByName = "ByName";
        private const string ByResourceId = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
            HelpMessage = "Specify the name of the application.")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the application.")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationName { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the service.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ServiceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the service.")]
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
                        var serviceList = this.SFRPClient.Services.
                            List(this.ResourceGroupName, this.ClusterName, this.ApplicationName).Value.
                            Select(service => new PSService(service));
                        WriteObject(serviceList, true);
                        break;
                    case ByName:
                        GetByName();
                        break;
                    case ByResourceId:
                        SetParametersByResourceId();
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
            var service = this.SFRPClient.Services.Get(this.ResourceGroupName, this.ClusterName, this.ApplicationName, this.Name);
            WriteObject(new PSService(service), false);
        }

        private void SetParametersByResourceId()
        {
            ResourceIdentifier serviceRId = new ResourceIdentifier(this.ResourceId);
            this.ResourceGroupName = serviceRId.ResourceGroupName;
            string subscription = serviceRId.Subscription;
            ResourceIdentifier appRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{serviceRId.ParentResource}");
            ResourceIdentifier clusterRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appRId.ParentResource}");
            if (!serviceRId.ResourceType.EndsWith(Constants.serviceProvider)
                || !appRId.ResourceType.EndsWith(Constants.applicationProvider)
                || !clusterRId.ResourceType.EndsWith(Constants.clusterProvider))
            {
                throw new PSArgumentException(string.Format("invalid resource id {0}", this.ResourceId));
            }

            this.ApplicationName = appRId.ResourceName;
            this.ClusterName = clusterRId.ResourceName;
            this.Name = serviceRId.ResourceName;
        }
    }
}
