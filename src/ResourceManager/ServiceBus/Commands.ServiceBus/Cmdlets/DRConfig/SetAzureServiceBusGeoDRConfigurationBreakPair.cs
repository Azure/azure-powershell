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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.GeoDR
{
    /// <summary>
    /// 'Set-AzureRmServicebusGeoDRConfigurationBreakPair' Cmdlet disables the Disaster Recovery and stops replicating changes from primary to secondary namespace
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusDRConfigurationBreakPairingVerb, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class SetAzureServiceBusGeoDRConfigurationBreakPair : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name - Primary Namespace")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "DR Configuration Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.DRFailOver, Name, Namespace),
                string.Format(Resources.DRFailOver, Name, Namespace),
                Name,
                () =>
                {
                    Client.SetServiceBusDRConfigurationBreakPairing(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
