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
    [Cmdlet(VerbsCommon.Remove, "AzureDedicatedCircuitLink"), OutputType(typeof(bool))]
    public class RemoveAzureDedicatedCircuitLinkCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key for the Azure Circuit Vnet Mapping to be removed")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Network Name for the Azure Circuit Vnet Mapping to be removed")]
        [ValidateNotNullOrEmpty]
        public string VNetName { get; set; }

        [Parameter(HelpMessage = "Do not confirm Azure Circuit Route deletion")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAzureDedicatedCircuitLinkWarning, ServiceKey, VNetName),
                Resources.RemoveAzureDedicatedCircuitLinkMessage,
                ServiceKey+" "+VNetName,
                () =>
                {
                    if (!ExpressRouteClient.RemoveAzureDedicatedCircuitLink(ServiceKey, VNetName))
                    {
                        throw new Exception(Resources.RemoveAzureDedicatedCircuitLinkFailed);
                    }
                    else
                    {
                        WriteVerboseWithTimestamp(Resources.RemoveAzureDedicatedCircuitLinkSucceeded, ServiceKey, VNetName);
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                });
        }
    }
}
