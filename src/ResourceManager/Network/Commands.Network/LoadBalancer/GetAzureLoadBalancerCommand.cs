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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmLoadBalancer"), OutputType(typeof(PSLoadBalancer))]
    public class GetAzureLoadBalancerCommand : LoadBalancerBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var loadBalancer = this.GetLoadBalancer(this.ResourceGroupName, this.Name, this.ExpandResource);

                WriteObject(loadBalancer);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var lbList = this.LoadBalancerClient.List(this.ResourceGroupName);

                var psLoadBalancers = new List<PSLoadBalancer>();

                foreach (var lb in lbList)
                {
                    var psLb = this.ToPsLoadBalancer(lb);
                    psLb.ResourceGroupName = this.ResourceGroupName;
                    psLoadBalancers.Add(psLb);
                }

                WriteObject(psLoadBalancers, true);
            }

            else
            {
                var lbList = this.LoadBalancerClient.ListAll();

                var psLoadBalancers = new List<PSLoadBalancer>();

                foreach (var lb in lbList)
                {
                    var psLb = this.ToPsLoadBalancer(lb);
                    psLb.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(lb.Id);
                    psLoadBalancers.Add(psLb);
                }

                WriteObject(psLoadBalancers, true);
            }
        }
    }
}

