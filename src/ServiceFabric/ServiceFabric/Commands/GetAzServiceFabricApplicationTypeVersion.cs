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
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplicationTypeVersion", DefaultParameterSetName = "ByResourceGroupAndCluster"), OutputType(typeof(PSApplicationTypeVersion))]
    public class GetAzServiceFabricApplicationTypeVersion : ProxyResourceCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByVersion = "ByVersion";

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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroupAndCluster,
                   HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
                   HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "Specify the name of the application type")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByVersion,
                   HelpMessage = "Specify the name of the cluster.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName == ByVersion)
                {
                    var appTypeVersion = this.SFRPClient.ApplicationTypeVersions.Get(this.ResourceGroupName, this.ClusterName, this.Name, this.Version);
                    WriteObject(new PSApplicationTypeVersion(appTypeVersion), false);
                }
                else
                {
                    var appTypeVersionList = this.SFRPClient.ApplicationTypeVersions.
                        List(this.ResourceGroupName, this.ClusterName, this.Name).Value.
                        Select(typeVersion => new PSApplicationTypeVersion(typeVersion));
                    WriteObject(appTypeVersionList, true);
                }
            }
            catch (Exception ex)
            {
                this.PrintSdkExceptionDetail(ex);
                throw;
            }
        }
    }
}
