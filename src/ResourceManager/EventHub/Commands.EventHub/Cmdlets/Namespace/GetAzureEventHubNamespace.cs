﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Get-AzureRmEventHubNamespace' Cmdlet gives the details of a / List of Eventhub Namespace(s)
    /// <para> If Namespace name provided, a single Namespace detials will be returned</para>
    /// <para> If Namespace name not provided, list of Namespace will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, EventHubNamespaceVerb), OutputType(typeof(List<NamespaceAttributes>))]
    public class GetAzureRmEventHubNamespace : AzureEventHubsCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventHub Namespace Name.")]
        public string NamespaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(NamespaceName))
            {
                // Get EventHub namespace
                NamespaceAttributes attributes = Client.GetNamespace(ResourceGroupName, NamespaceName);
                WriteObject(attributes);
            }
            else if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(NamespaceName))
            {
                // List all EventHub namespace in given resource group 
                IEnumerable< NamespaceAttributes> namespaceList = Client.ListNamespacesByResourceGroup(ResourceGroupName);
                WriteObject(namespaceList.ToList(), true);
            }
            else
            {
                // List all EventHub namespaces in the given subscription
                IEnumerable<NamespaceAttributes> namespaceList = Client.ListNamespacesBySubscription();
                WriteObject(namespaceList.ToList(), true);
            }
        }
    }
}