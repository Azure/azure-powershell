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

using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using MNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVpnClientConfiguration"), OutputType(typeof(MNM.PSVpnProfile))]
    public class GetAzureVpnClientConfigurationCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            // There are no validations to be done here
            // Just get the package URL if the package exists
            // There may be a required Json serialize for the package URL to conform to REST-API
            // The try-catch below handles the case till the change is made and deployed to PROD
            string serializedPackageUrl = this.NetworkClient.GetVpnProfilePackageUrl(this.ResourceGroupName, this.Name);
            string packageUrl = string.Empty;
            try
            {
                packageUrl = JsonConvert.DeserializeObject<string>(serializedPackageUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                packageUrl = serializedPackageUrl;
            }

            MNM.PSVpnProfile vpnProfile = new MNM.PSVpnProfile() { VpnProfileSASUrl = packageUrl };
            WriteObject(vpnProfile);
        }
    }
}
