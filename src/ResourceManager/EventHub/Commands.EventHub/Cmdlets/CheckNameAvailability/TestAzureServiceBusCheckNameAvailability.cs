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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Test-AzureRmCheckNameAvailability' Cmdlet Check Availability of the NameSpace Name
    /// </summary>
    [Cmdlet("Test", "AzureRmEventHubName", DefaultParameterSetName = NamespaceCheckNameAvailabilityParameterSet), OutputType(typeof(List<CheckNameAvailabilityResultAttributes>))]
    public class TestAzureEventhubCheckNameAvailability : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0, ParameterSetName = AliasCheckNameAvailabilityParameterSet,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0, ParameterSetName = NamespaceCheckNameAvailabilityParameterSet,
            HelpMessage = "Eventhub Namespace Name.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AliasCheckNameAvailabilityParameterSet)]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = AliasCheckNameAvailabilityParameterSet,
            HelpMessage = "DR Configuration Name - Alias Name")]
        [Alias(AliasAliasName)]
        public string AliasName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == NamespaceCheckNameAvailabilityParameterSet)
            {//Check the EventHub namespaces name is availability
                CheckNameAvailabilityResultAttributes checkNameAvailabilityResult = Client.GetCheckNameAvailability(Namespace);
                WriteObject(checkNameAvailabilityResult, true);
            }

            if (ParameterSetName == AliasCheckNameAvailabilityParameterSet)
            {//Check the EventHub namespaces name is availability
                CheckNameAvailabilityResultAttributes checkNameAvailabilityResult = Client.GetAliasCheckNameAvailability(ResourceGroupName, Namespace, AliasName);
                WriteObject(checkNameAvailabilityResult, true);
            }

        }
    }
}