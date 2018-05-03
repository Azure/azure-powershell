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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
namespace Microsoft.Azure.Commands.Relay.Commands.WcfRelay
{
    /// <summary>
    /// 'Remove-AzureRmWcfRelay' Cmdlet removes the specified WcfRelay
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, RelayWcfRelayVerb, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureWcfRelay : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // Remove a HybridConnections             
            ConfirmAction(
            string.Format(Resources.RemoveWcfRelay, Name, Namespace),
            Name,
            () =>
            {
                Client.DeleteWcfRelay(ResourceGroupName, Namespace, Name);
            });

        }
    }
}
