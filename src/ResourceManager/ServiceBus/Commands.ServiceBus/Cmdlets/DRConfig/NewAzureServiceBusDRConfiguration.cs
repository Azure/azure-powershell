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

using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'New-AzureRmServicebusDRConfiguration' Cmdlet Creates an new Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusDRConfigurationVerb, SupportsShouldProcess = true), OutputType(typeof(ServiceBusDRConfigurationAttributes))]
    public class NewAzureRmEventHubDRConfiguration : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "DR Configuration Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            Position = 3,
           HelpMessage = "DR Configuration PartnerNamespace")]
        [ValidateNotNullOrEmpty]
        public string PartnerNamespace { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
            Position = 4,
           HelpMessage = "AlternateName ")]
        [ValidateNotNullOrEmpty]
        public string AlternateName { get; set; }

        public override void ExecuteCmdlet()
        {
            ServiceBusDRConfigurationAttributes drConfiguration = new ServiceBusDRConfigurationAttributes() { PartnerNamespace = PartnerNamespace };

            if (!string.IsNullOrEmpty(AlternateName))
                drConfiguration.AlternateName = AlternateName;

            if (ShouldProcess(target: Name, action:string.Format("Creating new GeoDRConfigs:{0} under NameSpace:{1} ", Name,Namespace)))
            {
                WriteObject(Client.CreateServiceBusDRConfiguration(ResourceGroupName, Namespace, Name, drConfiguration));
            }                        
        }
    }
}
