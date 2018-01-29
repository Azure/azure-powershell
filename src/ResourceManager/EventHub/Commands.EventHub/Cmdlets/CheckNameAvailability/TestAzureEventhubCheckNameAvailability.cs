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
    /// 'Test-AzureRmEventHubName' Cmdlet Check Availability of the NameSpace Name and DRConfig name
    /// </summary>
    [Cmdlet("Test", "AzureRmEventHubName", DefaultParameterSetName = NamespaceCheckNameAvailabilityParameterSet), OutputType(typeof(PSCheckNameAvailabilityResultAttributes))]
    public class TestAzureEventhubCheckNameAvailability : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = AliasCheckNameAvailabilityParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceCheckNameAvailabilityParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Eventhub Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = AliasCheckNameAvailabilityParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Eventhub Namespace Name")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AliasCheckNameAvailabilityParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "DR Configuration Name - Alias Name")]
        [ValidateNotNullOrEmpty]
        public string AliasName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(NamespaceCheckNameAvailabilityParameterSet))
            {
                PSCheckNameAvailabilityResultAttributes checkNameAvailabilityResult = Client.GetCheckNameAvailability(Namespace);
                WriteObject(checkNameAvailabilityResult, true);
            }

            if (ParameterSetName.Equals(AliasCheckNameAvailabilityParameterSet))
            {
                PSCheckNameAvailabilityResultAttributes checkNameAvailabilityResult = Client.GetAliasCheckNameAvailability(ResourceGroupName, Namespace, AliasName);
                WriteObject(checkNameAvailabilityResult, true);
            }

        }
    }
}