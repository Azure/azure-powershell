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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ExpressRoute.Properties;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    [Cmdlet(VerbsCommon.Remove, "AzureBGPPeering"),OutputType(typeof(bool))]
    public class RemoveAzureBGPPeeringCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key associated with the Azure BGP Peering to be removed")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Bgp Peering Access Type: Public or Private")]
        [DefaultValue("Private")]
        public BgpPeeringAccessType AccessType { get; set; }

        [Parameter(HelpMessage = "Do not confirm Azure BGP Peering deletion")]
        public SwitchParameter Force { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveAzureBGPPeeringWarning, ServiceKey),
                Resources.RemoveAzureBGPPeeringMessage,
                ServiceKey.ToString(),
                () =>
                {
                   
                    if(!ExpressRouteClient.RemoveAzureBGPPeering(ServiceKey, AccessType))
                    {
                        throw new Exception(Resources.RemoveAzureBGPPeeringFailed);
                    }
                    else
                    {
                        WriteVerboseWithTimestamp(Resources.RemoveAzureBGPPeeringSucceeded, ServiceKey);
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                });
        }
    }
}
