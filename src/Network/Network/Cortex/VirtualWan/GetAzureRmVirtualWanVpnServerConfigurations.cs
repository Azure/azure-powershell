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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWanVpnServerConfigurations", SupportsShouldProcess = true), OutputType(typeof(PSVpnServerConfigurationsResponse))]
    public class GetAzureRmVirtualWanVpnServerConfigurationsCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "ResourceGroupName")]
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
            string shouldProcessMessage = string.Format("Execute Get-AzureRmVirtualWanVpnServerConfigurations for ResourceGroupName {0} VirtualWan {1}", ResourceGroupName, Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Get))
            {
                // There may be a required Json serialize for the returned contents to conform to REST-API
                // The try-catch below handles the case till the change is made and deployed to PROD
                string serializedVpnServerConfigurations = this.NetworkClient.GetVirtualWanVpnServerConfigurations(this.ResourceGroupName, this.Name);
                MNM.VpnServerConfigurationsResponse vpnServerConfigurations = new MNM.VpnServerConfigurationsResponse();
                try
                {
                    vpnServerConfigurations = JsonConvert.DeserializeObject<MNM.VpnServerConfigurationsResponse>(serializedVpnServerConfigurations);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                PSVpnServerConfigurationsResponse vpnServerConfigurationsResponse = new PSVpnServerConfigurationsResponse() { VpnServerConfigurationResourceIds = vpnServerConfigurations?.VpnServerConfigurationResourceIds };
                WriteObject(vpnServerConfigurationsResponse);
            }
        }
    }
}
