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

using Microsoft.Azure.Commands.NotificationHubs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{

    [Cmdlet(VerbsCommon.Get, "AzureRmNotificationHubsNamespace"), OutputType(typeof(List<NamespaceAttributes>))]
    public class GetAzureNotificationHubsNamespace : AzureNotificationHubsCmdletBase
    {

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets a Namespace from the service.
        /// </summary>
        /// <returns>A single Namespace</returns>
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroup) && !string.IsNullOrEmpty(Namespace))
            {
                // Get a namespace
                var attributes = Client.GetNamespace(ResourceGroup, Namespace);
                WriteObject(attributes);
            }
            else if (!string.IsNullOrEmpty(ResourceGroup) && string.IsNullOrEmpty(Namespace))
            {
                // List all namespaces in given resource group 
                var namespaceList = Client.ListNamespaces(ResourceGroup);
                WriteObject(namespaceList.ToList(), true);
            }
            else
            {
                // List all namespaces in the given subscription
                var namespaceList = Client.ListAllNamespaces();
                WriteObject(namespaceList.ToList(), true);
            }
        }
    }
}
