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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'New-AzRelayKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given EventHub Authorization Rule
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAccessKeys'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubKey", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSListKeysAttributes))]
    public class NewAzureEventhubKey : AzureEventHubsCmdletBase
    {
        [CmdletParameterBreakingChange("ResourceGroupName", ChangeDescription = "Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [Alias(AliasEventHubName)]
        [ValidateNotNullOrEmpty]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 4, HelpMessage = "Regenerate Keys - 'PrimaryKey'/'SecondaryKey'")]
        [ValidateSet(RegeneKeys.PrimaryKey, RegeneKeys.SecondaryKey, IgnoreCase = true)]
        public string RegenerateKey { get; set; }

        [Parameter(Mandatory = false, Position = 5, HelpMessage = "A base64-encoded 256-bit key for signing and validating the SAS token.")]
        public string KeyValue { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                // Generate new Namespace List Keys for the specified AuthorizationRule
                if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: RegenerateKey, action: string.Format(Resources.RegenerateKeyNamesapce, Name, Namespace)))
                    {
                        WriteObject(UtilityClient.SetRegenerateKeys(ResourceGroupName, Namespace, Name, RegenerateKey, KeyValue));
                    }
                }

                // Generate new EventHub List Keys for the specified AuthorizationRule
                if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: RegenerateKey, action: string.Format(Resources.RegenerateKeyEventHub, Name, EventHub)))
                    {
                        WriteObject(UtilityClient.SetRegenerateKeys(ResourceGroupName, Namespace, EventHub, Name, RegenerateKey, KeyValue));
                    }
                }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
