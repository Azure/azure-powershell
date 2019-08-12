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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricService", DefaultParameterSetName = "ByResourceGroupAndCluster"), OutputType(typeof(PSService))]
    public class GetAzServiceFabricService : ProxyResourceCmdletBase
    {
        private const string ByResourceGroupAndCluster = "ByResourceGroupAndCluster";
        private const string ByName = "ByName";

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
        [ResourceGroupCompleter]
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

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName ==  ByName)
                {
                    var service = this.SFRPClient.Services.Get(this.ResourceGroupName, this.ClusterName, this.ApplicationName, this.Name);
                    WriteObject(new PSService(service), false);
                }
                else
                {
                    var serviceList = this.SFRPClient.Services.
                        List(this.ResourceGroupName, this.ClusterName, this.ApplicationName).Value.
                        Select(service => new PSService(service));
                    WriteObject(serviceList, true);
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
