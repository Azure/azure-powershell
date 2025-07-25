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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.Add,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoutingPolicy",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRoutingIntent))]
    public class AddAzureRmRoutingPolicyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the routing intent resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSRoutingIntent RoutingIntent { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of all destinations which this routing policy is applicable to (for example: Internet, PrivateTraffic).")]
        [ValidateNotNullOrEmpty]
        public string[] Destination { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The next hop resource id on which this routing policy is applicable to.")]
        [ValidateNotNullOrEmpty]
        public string NextHop { get; set; }

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

            if (this.RoutingIntent.RoutingPolicies == null)
            {
                this.RoutingIntent.RoutingPolicies = new List<PSRoutingPolicy>();
            }
            else
            {
                var existingRoutingPolicy = this.RoutingIntent.RoutingPolicies.SingleOrDefault(
                policy => string.Equals(policy.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));
                if (existingRoutingPolicy != null)
                {
                    throw new ArgumentException("RoutingPolicy with specified name already exists");
                }
            }

            var routingPolicy = new PSRoutingPolicy
            {
                Name = this.Name,
                Destinations = this.Destination?.ToList(),
                NextHop = this.NextHop,
            };
            this.RoutingIntent.RoutingPolicies.Add(routingPolicy);
            WriteObject(this.RoutingIntent);
        }
    }
}
