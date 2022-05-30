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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoutingPolicy",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRoutingPolicy))]
    public class NewAzureRmRoutingPolicyCommand : NetworkBaseCmdlet
    {
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
            base.Execute();

            var routingPolicy = new PSRoutingPolicy
            {
                Name = this.Name,
                Destinations = this.Destination?.ToList(),
                NextHop = this.NextHop,
            };

            WriteObject(routingPolicy);
        }
    }
}
