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

using System;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{

    [Cmdlet(VerbsCommon.Get, "AzureAuthorizedDedicatedCircuit"), OutputType(typeof(AzureAuthorizedDedicatedCircuit), typeof(IEnumerable<AzureAuthorizedDedicatedCircuit>))]
    public class GetAzureAuthorizedDedicatedCircuitCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key representing the Dedicated Circuit")]
        public Guid ServiceKey { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ServiceKey != Guid.Empty)
            {
                GetByServiceKey();
            }
            else
            {
                GetNoServiceKey();
            }
        }

        private void GetByServiceKey()
        {
            var circuit = ExpressRouteClient.GetAuthorizedAzureDedicatedCircuit(ServiceKey);
            WriteObject(circuit);
        }

        private void GetNoServiceKey()
        {
            var circuits = ExpressRouteClient.ListAzureAuthorizedDedicatedCircuits();
            WriteObject(circuits, true);   
        }
    }
}
