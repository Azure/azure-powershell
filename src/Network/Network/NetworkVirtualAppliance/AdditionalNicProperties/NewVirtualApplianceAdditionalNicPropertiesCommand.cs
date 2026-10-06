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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceAdditionalNicProperty",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualApplianceAdditionalNicProperties))]
    public class NewVirtualApplianceAdditionaNicPropertyCommand : VirtualApplianceAdditionalNicPropertiesBaseCmdlet
    {
        private const int NicNameValueMaxLength = 24;

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Name of Interface.")]
        [ValidateNotNullOrEmpty]
        public string NicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Additional Interface to have public IP or not.")]
        [ValidateNotNullOrEmpty]
        public bool HasPublicIP { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Address Family for IP for Interface.")]
        [ValidateSet(
           IPv4,
           IPv6,
           IgnoreCase = true)]
        public string AddressFamily { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            var additionalNicProperty = new PSVirtualApplianceAdditionalNicProperties();
            additionalNicProperty.Name = this.NicName;
            additionalNicProperty.HasPublicIP = this.HasPublicIP;
            additionalNicProperty.AddressFamily = "IPv4";

            var additionalNicProperties = new List<PSVirtualApplianceAdditionalNicProperties>
            {
                additionalNicProperty
            };

            WriteObject(additionalNicProperties, true);
        }

        private void Validate()
        {
            // validate name length
            if (this.NicName.Length > NicNameValueMaxLength)
            {
                throw new ArgumentException($"Nic Name length is limited to {NicNameValueMaxLength} characters.");
            }
        }
    }
}
