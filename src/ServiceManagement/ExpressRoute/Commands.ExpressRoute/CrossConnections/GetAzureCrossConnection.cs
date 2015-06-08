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


using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    using System;

    [Cmdlet(VerbsCommon.Get, "AzureCrossConnection"), OutputType(typeof(AzureCrossConnection), typeof(IEnumerable<AzureCrossConnection>))]
    public class GetAzureCrossConnectionCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key representing the Dedicated Circuit")]
        public Guid ServiceKey { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ServiceKey != Guid.Empty)
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
            var crossConnection = ExpressRouteClient.GetAzureCrossConnection(ServiceKey);
            WriteObject(crossConnection);
        }

        private void GetNoServiceKey()
        {
            var crossConnections = ExpressRouteClient.ListAzureCrossConnections();
            WriteObject(crossConnections, true);
        }
    }
}

