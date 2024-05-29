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
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceInternetIngressIpsProperty",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualApplianceInternetIngressIpsProperties))]
    public class NewVirtualApplianceInternetIngressIpsPropertyCommand : VirtualApplianceInternetIngressIpsPropertiesBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Public IPs for Internet Ingress.")]
        [ValidateNotNullOrEmpty]
        public string[] InternetIngressPublicIpId { get; set; }

        public override void Execute()
        {
            base.Execute();

            int elements = InternetIngressPublicIpId.Length;
            var InternetIngressIpsList = new List<PSVirtualApplianceInternetIngressIpsProperties>();

            for (int i = 0; i < elements; i++)
            {
                var currentelement = new PSVirtualApplianceInternetIngressIpsProperties();
                currentelement.Id = InternetIngressPublicIpId[i];
                InternetIngressIpsList.Add(currentelement);
            }

            WriteObject(InternetIngressIpsList, true);

        }
    }
}