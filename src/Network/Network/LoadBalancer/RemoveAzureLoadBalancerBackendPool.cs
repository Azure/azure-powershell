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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool"), OutputType(typeof(PSBackendAddressPool))]
    public partial class RemoveAzureLoadBalancerBackendPool : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string BackendAddressPoolName { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();
            var found = NetworkBaseCmdlet.IsResourcePresent(() => this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Get(
                this.ResourceGroupName,
                this.LoadBalancerName, 
                this.BackendAddressPoolName));

            if (!found)
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, BackendAddressPoolName),
                Properties.Resources.RemoveResourceMessage,
                BackendAddressPoolName,
                () =>
                {
                    this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Delete(this.ResourceGroupName, 
                        this.LoadBalancerName, this.BackendAddressPoolName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            WriteObject(HttpStatusCode.OK);
        }
    }
}
