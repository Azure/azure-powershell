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

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoutingPolicy",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRoutingIntent))]
    public class RemoveAzureRmRoutingPolicyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the routing intent resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSRoutingIntent RoutingIntent { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique name for this routing policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            if (this.RoutingIntent == null)
            {
                throw new ArgumentException("The given routing intent does not exist.");
            }

            if (this.RoutingIntent.RoutingPolicies == null || !this.RoutingIntent.RoutingPolicies.Any())
            {
                WriteObject(this.RoutingIntent);
                return;
            }

            var routingPolicyToRemove = this.RoutingIntent.RoutingPolicies.SingleOrDefault(
                    policy => string.Equals(policy.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (routingPolicyToRemove != null)
            {
                this.RoutingIntent.RoutingPolicies.Remove(routingPolicyToRemove);
            }

            if(this.RoutingIntent.RoutingPolicies.Count == 0)
            {
                this.RoutingIntent.RoutingPolicies = null;
            }    

            WriteObject(this.RoutingIntent);
        }
    }
}
