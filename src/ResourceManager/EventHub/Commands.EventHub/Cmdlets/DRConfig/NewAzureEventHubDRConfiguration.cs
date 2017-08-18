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

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'New-AzureRmEventHub' Cmdlet creates a new EventHub
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
        public string NamespaceName { get; set; }

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
        public string PartnerNamespace { get; set; }

        public override void ExecuteCmdlet()
        {
            EventHubDRConfigurationAttributes drConfiguration = new EventHubDRConfigurationAttributes();
            
            if (!string.IsNullOrEmpty(PartnerNamespace))
                drConfiguration.PartnerNamespace = PartnerNamespace;

            if (!string.IsNullOrEmpty(Name))
                drConfiguration.Name = Name;

            if (ShouldProcess(target: drConfiguration.Name, action:string.Format("Creating new EventHub:{0} under NameSpace:{1} ", drConfiguration.Name,NamespaceName)))
            {
                WriteObject(Client.CreateEventHubDRConfiguration(ResourceGroupName, NamespaceName, drConfiguration.Name, drConfiguration));
            }
                        
        }
    }
}
