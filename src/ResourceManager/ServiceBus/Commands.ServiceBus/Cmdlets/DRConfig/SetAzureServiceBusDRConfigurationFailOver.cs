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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'Set-AzureRmServicebusDRConfigurationFailOver' Cmdlet invokes GEO DR failover and reconfigure the alias to point to the secondary namespace
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusDRConfigurationFailoverVerb, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class SetAzureServiceBusDRConfigurationFailOver : AzureServiceBusCmdletBase
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
            HelpMessage = "Namespace Name - Secondary Namespace")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "DR Configuration Name - Alias.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            //Set FailOver
            if (ShouldProcess(target: Name, action: string.Format(Resources.DRFailOver, Name, Namespace)))
            {
                Client.SetServiceBusDRConfigurationFailOver(ResourceGroupName, Namespace, Name);
            }
        }
    }
}
