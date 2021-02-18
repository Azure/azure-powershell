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
    /// 'Get-AzRelayHybridConnection' Cmdlet gives the details of a / List of HybridConnections(s)
    /// <para> If HybridConnections name provided, a single HybridConnections detials will be returned</para>
    /// <para> If WcfRelayHybridConnections name not provided, list of WcfRelayHybridConnections will be returned</para>
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RelayHybridConnection"), OutputType(typeof(PSHybridConnectionAttibutes))]
=======
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RelayHybridConnection"), OutputType(typeof(PSHybridConnectionAttributes))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                PSHybridConnectionAttibutes hybridConnections = Client.GetHybridConnections(ResourceGroupName, Namespace, Name);
=======
                PSHybridConnectionAttributes hybridConnections = Client.GetHybridConnections(ResourceGroupName, Namespace, Name);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                WriteObject(hybridConnections);
            }
            else
            {
                // Get all HybridConnections
<<<<<<< HEAD
                IEnumerable<PSHybridConnectionAttibutes> hybridConnectionsList = Client.ListAllHybridConnections(ResourceGroupName, Namespace);
=======
                IEnumerable<PSHybridConnectionAttributes> hybridConnectionsList = Client.ListAllHybridConnections(ResourceGroupName, Namespace);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                WriteObject(hybridConnectionsList.ToList(), true);
            }
        }
    }
}
