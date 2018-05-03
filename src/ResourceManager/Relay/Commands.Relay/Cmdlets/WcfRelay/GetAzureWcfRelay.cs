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

namespace Microsoft.Azure.Commands.Relay.Commands.WcfRelay
{
    /// <summary>
    /// 'Get-AzureRmWcfRelay' Cmdlet gives the details of a / List of WcfRelay(s)
    /// <para> If WcfRelay name provided, a single WcfRelay detials will be returned</para>
    /// <para> If WcfRelay name not provided, list of WcfRelay will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, RelayWcfRelayVerb), OutputType(typeof(List<WcfRelayAttributes>))]
    public class GetAzureRmRelayWcfRelay : AzureRelayCmdletBase
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
            Position = 3,
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get a WcfRelay
                WcfRelayAttributes wcfRelay = Client.GetWcfRelay(ResourceGroupName, Namespace, Name);
                WriteObject(wcfRelay);
            }
            else
            {
                // Get all WcfRelay
                IEnumerable<WcfRelayAttributes> wcfRelayList = Client.ListAllWcfRelay(ResourceGroupName, Namespace);
                WriteObject(wcfRelayList.ToList(), true);
            }
        }
    }
}
