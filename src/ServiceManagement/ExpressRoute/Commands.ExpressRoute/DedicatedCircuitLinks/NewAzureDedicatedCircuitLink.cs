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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using System;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{

    [Cmdlet(VerbsCommon.New, "AzureDedicatedCircuitLink"), OutputType(typeof(AzureDedicatedCircuitLink))]
    public class NewAzureDedicatedCircuitLinkCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key representing Azure Circuit")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Virtual Network Name")]
        [ValidateNotNullOrEmpty]
        public string VNetName { get; set; }

        public override void ExecuteCmdlet()
        {
            var mapping = ExpressRouteClient.NewAzureDedicatedCircuitLink(ServiceKey, VNetName);
            WriteObject(mapping);
        }
    }
}

