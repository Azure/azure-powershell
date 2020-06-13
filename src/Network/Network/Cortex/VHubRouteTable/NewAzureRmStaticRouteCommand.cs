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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StaticRoute",
        SupportsShouldProcess = false),
        OutputType(typeof(PSStaticRoute))]
    public class NewAzureRmStaticRouteCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of this static route.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of address prefixes.")]
        public string[] AddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The next hop IpAddress.")]
        public string NextHopIpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            var staticRoute = new PSStaticRoute
            {
                Name = Name,
                NextHopIpAddress = NextHopIpAddress,
                AddressPrefixes = AddressPrefix?.ToList()
            };

            WriteObject(staticRoute);
        }
    }
}
