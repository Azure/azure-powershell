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

using Microsoft.Azure.Commands.Relay.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands.HybridConnections
{
    /// <summary>
    /// 'Get-AzureRmRelayHybridConnection' Cmdlet gives the details of a / List of HybridConnections(s)
    /// <para> If HybridConnections name provided, a single HybridConnections detials will be returned</para>
    /// <para> If WcfRelayHybridConnections name not provided, list of WcfRelayHybridConnections will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, RelayHybridConnectionVerb), OutputType(typeof(List<HybridConnectionAttibutes>))]
    public class GetAzureRmRelayHybridConnection : AzureRelayCmdletBase
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

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "HybridConnections Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get a HybridConnections
                HybridConnectionAttibutes hybridConnections = Client.GetHybridConnections(ResourceGroupName, Namespace, Name);
                WriteObject(hybridConnections);
            }
            else
            {
                // Get all HybridConnections
                IEnumerable<HybridConnectionAttibutes> hybridConnectionsList = Client.ListAllHybridConnections(ResourceGroupName, Namespace);
                WriteObject(hybridConnectionsList.ToList(), true);
            }
        }
    }
}
