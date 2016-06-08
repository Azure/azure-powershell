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
    [Cmdlet(VerbsCommon.Remove, "AzureDedicatedCircuit"),OutputType(typeof(bool))]
    public class RemoveAzureDedicatedCircuitCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key of Azure Dedicated Circuit to be removed")]
        public Guid ServiceKey { get; set; }

        [Parameter(HelpMessage = "Do not confirm Azure Dedicated Circuit deletion")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAzureDedicatdCircuitWarning, ServiceKey),
                Resources.RemoveAzureDedicatedCircuitMessage,
                ServiceKey.ToString(),
                () =>
                    {
                        if (!ExpressRouteClient.RemoveAzureDedicatedCircuit(ServiceKey))
                        {
                            throw new Exception(Resources.RemoveAzureDedicatedCircuitFailed);
                        }
                        else
                        {
                            WriteVerboseWithTimestamp(Resources.RemoveAzureDedicatedCircuitSucceeded,ServiceKey);
                            if (PassThru.IsPresent)
                            {
                                WriteObject(true);
                            }
                        }
                    });
        }
    }
}
