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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VHubRoute",
        SupportsShouldProcess = false),
        OutputType(typeof(PSVHubRoute))]
    public class NewAzureRmVHubRouteCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "List of Destinations.")]
        [ValidateNotNullOrEmpty]
        public string[] Destination { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Type of Destinations.")]
        [ValidateNotNullOrEmpty]
        public string DestinationType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Next hop.")]
        [ValidateNotNullOrEmpty]
        public string NextHop { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name for this route.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Next Hop type.")]
        [ValidateNotNullOrEmpty]
        public string NextHopType { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vHubRoute = new PSVHubRoute
            {
                Name = this.Name,
                Destinations = this.Destination?.ToList(),
                DestinationType = this.DestinationType,
                NextHop = this.NextHop,
                NextHopType = this.NextHopType
            };

            WriteObject(vHubRoute);
        }
    }
}
