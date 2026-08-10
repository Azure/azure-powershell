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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpAddress"), OutputType(typeof(PSPublicIpAddress))]
    public class SetAzurePublicIpAddressCommand : PublicIpAddressBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The DDoS custom policy ID to associate with the Public IP address.")]
        [ValidateNotNullOrEmpty]
        public string DdosCustomPolicyId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Removes the DDoS custom policy association from the Public IP address.")]
        public SwitchParameter RemoveDdosCustomPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (this.RemoveDdosCustomPolicy.IsPresent && !string.IsNullOrEmpty(this.DdosCustomPolicyId))
            {
                throw new ArgumentException("Specify either DdosCustomPolicyId or RemoveDdosCustomPolicy, but not both.");
            }

            if (!this.IsPublicIpAddressPresent(this.PublicIpAddress.ResourceGroupName, this.PublicIpAddress.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (!string.IsNullOrEmpty(this.DdosCustomPolicyId))
            {
                if (this.PublicIpAddress.DdosSettings == null)
                {
                    this.PublicIpAddress.DdosSettings = new PSDdosSettings();
                }

                this.PublicIpAddress.DdosSettings.DdosCustomPolicy = new PSResourceId { Id = this.DdosCustomPolicyId };
            }
            else if (this.RemoveDdosCustomPolicy.IsPresent)
            {
                if (this.PublicIpAddress.DdosSettings != null)
                {
                    this.PublicIpAddress.DdosSettings.DdosCustomPolicy = null;
                }
            }

            // Map to the sdk object
            var publicIpModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PublicIPAddress>(this.PublicIpAddress);
            publicIpModel.Tags = TagsConversionHelper.CreateTagDictionary(this.PublicIpAddress.Tag, validate: true);

            this.PublicIpAddressClient.CreateOrUpdate(this.PublicIpAddress.ResourceGroupName, this.PublicIpAddress.Name, publicIpModel);

            var getPublicIp = this.GetPublicIpAddress(this.PublicIpAddress.ResourceGroupName, this.PublicIpAddress.Name);

            WriteObject(getPublicIp);
        }
    }
}
