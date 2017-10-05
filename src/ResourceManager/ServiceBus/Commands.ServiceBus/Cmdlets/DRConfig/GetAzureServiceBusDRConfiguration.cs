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

using Microsoft.Azure.Commands.ServiceBus;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'Get-AzureServicebusDRConfigurations' CmdletRetrieves Alias(Disaster Recovery configuration) for primary or secondary namespace    
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ServicebusDRConfigurationVerb), OutputType(typeof(List<ServiceBusDRConfigurationAttributes>))]
    public class GetServiceBusDRConfiguration : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "DR Configuration Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get a DRConfiguration
                ServiceBusDRConfigurationAttributes drConfiguration = Client.GetServiceBusDRConfiguration(ResourceGroupName, NamespaceName, Name);
                WriteObject(drConfiguration);
            }
            else
            {
                // Get all DRConfigurations
                IEnumerable<ServiceBusDRConfigurationAttributes> drConfigurationList = Client.ListAllServiceBusDRConfiguration(ResourceGroupName, NamespaceName);
                WriteObject(drConfigurationList.ToList(), true);
            }
        }
    }
}
