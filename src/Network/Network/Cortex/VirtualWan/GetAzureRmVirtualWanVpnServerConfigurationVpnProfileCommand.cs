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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWanVpnServerConfigurationVpnProfile", SupportsShouldProcess = true), OutputType(typeof(PSVpnProfileResponse))]
    public class GetAzureRmVirtualWanVpnServerConfigurationVpnProfileCommand : VirtualWanBaseCmdlet
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

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The VpnServerConfiguration with which this VirtualWan is associated.")]
        [ValidateNotNull]
        public PSVpnServerConfiguration VpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Authentication Method")]
        [ValidateSet(
            MNM.AuthenticationMethod.EAPTLS,
            MNM.AuthenticationMethod.EAPMSCHAPv2,
            IgnoreCase = true)]
        public string AuthenticationMethod { get; set; }

        public override void Execute()
        {
            base.Execute();
            string shouldProcessMessage = string.Format("Execute Get-AzureRmVirtualWanVpnServerConfigurationVpnProfile for ResourceGroupName {0} VirtualWan {1} and the associated VpnServerConfiguration{2}",
                ResourceGroupName, Name, VpnServerConfiguration.Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Get))
            {
                PSVirtualWanVpnProfileParameters virtualWanVpnProfileParams = new PSVirtualWanVpnProfileParameters();

                virtualWanVpnProfileParams.AuthenticationMethod = string.IsNullOrWhiteSpace(this.AuthenticationMethod)
                    ? MNM.AuthenticationMethod.EAPTLS.ToString()
                    : this.AuthenticationMethod;

                if (this.VpnServerConfiguration != null)
                {
                    virtualWanVpnProfileParams.VpnServerConfigurationResourceId = this.VpnServerConfiguration.Id;
                }

                var virtualWanVpnProfileParametersModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualWanVpnProfileParameters>(virtualWanVpnProfileParams);

                // There may be a required Json serialize for the package URL to conform to REST-API
                // The try-catch below handles the case till the change is made and deployed to PROD
                string serializedPackageUrl = this.NetworkClient.GenerateVirtualWanVpnProfile(this.ResourceGroupName, this.Name, virtualWanVpnProfileParametersModel);
                MNM.VpnProfileResponse vpnProfile = new MNM.VpnProfileResponse();
                try
                {
                    vpnProfile = JsonConvert.DeserializeObject<MNM.VpnProfileResponse>(serializedPackageUrl);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                PSVpnProfileResponse vpnProfileResponse = new PSVpnProfileResponse() { ProfileUrl = vpnProfile.ProfileUrl };
                WriteObject(vpnProfileResponse);
            }
        }
    }
}
