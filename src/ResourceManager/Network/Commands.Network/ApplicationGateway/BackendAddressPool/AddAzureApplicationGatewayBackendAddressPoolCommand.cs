﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureApplicationGatewayBackendAddressPool"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayBackendAddressPoolCommand : AzureApplicationGatewayBackendAddressPoolBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var backendAddressPool = this.ApplicationGateway.BackendAddressPools.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (backendAddressPool != null)
            {
                throw new ArgumentException("Backend address pool with the specified name already exists");
            }

            backendAddressPool = base.NewObject();
            this.ApplicationGateway.BackendAddressPools.Add(backendAddressPool);

            WriteObject(this.ApplicationGateway);
        }
    }
}
