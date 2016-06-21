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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmRouteConfig"), OutputType(typeof(PSRouteTable))]
    public class SetAzureRouteConfigCommand : AzureRouteConfigBase
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The name of the route")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteTable")]
        public PSRouteTable RouteTable { get; set; }

        public override void Execute()
        {

            base.Execute();
            // Verify if the subnet exists in the NetworkSecurityGroup
            var route = this.RouteTable.Routes.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (route == null)
            {
                throw new ArgumentException("route with the specified name does not exist");
            }

            route.Name = this.Name;
            route.AddressPrefix = this.AddressPrefix;
            route.NextHopType = this.NextHopType;
            route.NextHopIpAddress = this.NextHopIpAddress;

            WriteObject(this.RouteTable);
        }
    }
}
