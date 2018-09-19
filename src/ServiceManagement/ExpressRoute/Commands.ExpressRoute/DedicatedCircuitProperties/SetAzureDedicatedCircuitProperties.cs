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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ExpressRoute.Properties;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    using Management.ExpressRoute.Models;

    [Cmdlet(VerbsCommon.Set, "AzureDedicatedCircuitProperties"), OutputType(typeof(AzureDedicatedCircuit))]
    public class SetAzureDedicatedCircuitPropertiesCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key of Azure Dedicated Circuit to be removed")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Circuit Bandwidth")]
        public UInt32? Bandwidth { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Circuit Sku")]
        public CircuitSku? Sku { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Circuit Billing Type")]
        [ValidateSet("MeteredData", "UnlimitedData", IgnoreCase = true)]
        public BillingType? BillingType { get; set; }

        [Parameter(HelpMessage = "Do not confirm Azure Dedicated Circuit Update")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.SetAzureDedicatedCircuitBandwidthWarning, ServiceKey, Bandwidth, Sku, BillingType),
                Resources.SetAzureDedicatedCircuitBandwidthMessage,
                ServiceKey.ToString(),
                () =>
                {
                    var circuit = ExpressRouteClient.SetAzureDedicatedCircuitProperties(ServiceKey, Bandwidth, Sku, BillingType);
                    
                    WriteObject(circuit);
                    
                });
        }
    }
}

