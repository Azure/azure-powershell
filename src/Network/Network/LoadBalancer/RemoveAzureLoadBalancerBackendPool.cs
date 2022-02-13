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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool",SupportsShouldProcess = true, DefaultParameterSetName = "DeleteByNameParameterSet"), OutputType(typeof(PSBackendAddressPool))]
    public partial class RemoveAzureLoadBalancerBackendPool : NetworkBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet"; // tested
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ParameterSetName = DeleteByNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ParameterSetName = DeleteByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the load balancer.")]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The load balancer resource.",
            ValueFromPipeline = true,
            ParameterSetName = DeleteByParentObjectParameterSet)]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend address pool to remove",
            ValueFromPipeline = true,
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSBackendAddressPool InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.LoadBalancer))
            {
                this.ResourceGroupName = this.LoadBalancer.ResourceGroupName;
                this.LoadBalancerName = this.LoadBalancer.Name;
            }

            if (this.IsParameterBound(c => c.InputObject) || this.IsParameterBound(p => p.ResourceId))
            {
                var id = this.IsParameterBound(c => c.InputObject) ? this.InputObject.Id : this.ResourceId;
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.LoadBalancerName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
            }
         
            // check if resource already exists
            var found = NetworkBaseCmdlet.IsResourcePresent(
                () => this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Get(
                this.ResourceGroupName,
                this.LoadBalancerName,
                this.Name));

            if (!found)
            {
                throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound,this.Name));
            }
            // this prompts user to confirm the deletion of the backend pool
            if (ShouldProcess(Name, Microsoft.Azure.Commands.Network.Properties.Resources.RemoveResourceMessage))
            {
                this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Delete(this.ResourceGroupName,
                        this.LoadBalancerName, this.Name);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
