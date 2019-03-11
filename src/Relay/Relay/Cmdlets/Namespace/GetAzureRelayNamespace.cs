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
using Microsoft.Azure.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Relay.Commands.Namespace
{
    /// <summary>
    /// 'Get-AzRelayNamespace' Cmdlet gives the details of a / List of Relay Namespace(s)
    /// <para> If Namespace name provided, a single Namespace detials will be returned</para>
    /// <para> If Namespace name not provided, list of Namespace will be returned</para>
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RelayNamespace"), OutputType(typeof(PSRelayNamespaceAttributes))]
    public class GetAzureRmRelayNamespace : AzureRelayCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Relay Namespace Name.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                // Get Relay namespace
                PSRelayNamespaceAttributes attributes = Client.GetNamespace(ResourceGroupName, Name);
                WriteObject(attributes);
            }
            else if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
            {
                // List all Relay namespace in given resource group 
                IEnumerable<PSRelayNamespaceAttributes> namespaceList = Client.ListNamespacesByResourceGroup(ResourceGroupName);
                WriteObject(namespaceList.ToList(), true);
            }
            else
            {
                // List all Relay namespaces in the given subscription
                IEnumerable<PSRelayNamespaceAttributes> namespaceList = Client.ListNamespacesBySubscription();
                WriteObject(namespaceList.ToList(), true);
            }
        }
    }
}
