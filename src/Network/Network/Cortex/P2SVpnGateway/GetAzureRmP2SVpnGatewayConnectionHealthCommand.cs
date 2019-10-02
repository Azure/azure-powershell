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
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2sVpnGatewayConnectionHealth", SupportsShouldProcess = true), OutputType(typeof(PSP2SVpnGateway))]
    public class GetAzureRmP2SVpnGatewayConnectionHealthCommand : P2SVpnGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/p2sVpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            string shouldProcessMessage = string.Format("Execute Get-AzureRmP2sVpnGatewayConnectionHealth for ResourceGroupName {0} P2SVpnGateway {1}", ResourceGroupName, Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Get))
            {
                // There may be a required Json serialize for the returned contents to conform to REST-API
                // The try-catch below handles the case till the change is made and deployed to PROD
                string serializedP2SVpnGatewayConnectionHealth = this.NetworkClient.GetP2SVpnGatewayConnectionHealth(this.ResourceGroupName, this.Name);
                MNM.P2SVpnGateway p2sVpnGatewayConnectionHealth = new MNM.P2SVpnGateway();
                try
                {
                    p2sVpnGatewayConnectionHealth = JsonConvert.DeserializeObject<MNM.P2SVpnGateway>(serializedP2SVpnGatewayConnectionHealth);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                PSP2SVpnGateway p2sVpnGatewayWithHealthResponse = this.ToPsP2SVpnGateway(p2sVpnGatewayConnectionHealth);
                WriteObject(p2sVpnGatewayWithHealthResponse);
            }
        }
    }
}
