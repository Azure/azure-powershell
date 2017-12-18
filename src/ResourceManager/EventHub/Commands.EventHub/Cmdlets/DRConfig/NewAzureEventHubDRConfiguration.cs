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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{
    /// <summary>
    /// 'New-AzureRmEventHubDRConfiguration' Cmdlet Creates an new Alias(Disaster Recovery configuration)
    /// </summary>
    [Cmdlet(VerbsCommon.New, EventHubDRConfigurationVerb, SupportsShouldProcess = true), OutputType(typeof(EventHubDRConfigurationAttributes))]
    public class NewAzureRmEventHubDRConfiguration : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
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
        public string Name { get; set; }

        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            Position = 3,
           HelpMessage = "DR Configuration PartnerNamespace")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasPartnerNamespace)]
        public string PartnerNamespace { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
            Position = 4,
           HelpMessage = "AlternateName ")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string AlternateName { get; set; }

        public override void ExecuteCmdlet()
        {
            EventHubDRConfigurationAttributes drConfiguration = new EventHubDRConfigurationAttributes() { PartnerNamespace = PartnerNamespace };

            if (!string.IsNullOrEmpty(AlternateName))
                drConfiguration.AlternateName = AlternateName;
            
            if (ShouldProcess(target: Name, action:string.Format("Creating new Alias :{0} under NameSpace:{1} ", Name, Namespace)))
            {
                WriteObject(Client.CreateEventHubDRConfiguration(ResourceGroupName, Namespace, Name, drConfiguration));
            }                        
        }
    }
}
