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
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'Set-AzEventHubAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAuthorizationRule'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubAuthorizationRule", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessAuthorizationRuleAttributes))]
    public class SetAzureEventhubAuthorizationRules : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [CmdletParameterBreakingChange("InputObject", OldParamaterType = typeof(PSSharedAccessAuthorizationRuleAttributes), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IAuthorizationRule", ChangeDescription = AuthoRuleInputObjectParameterSet + " parameter set is changing. Please refer the migration guide for examples.\n- InputObject would no longer support alias -AuthRuleObj.")]
        [Parameter(Mandatory = true, ParameterSetName = AuthoRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthRuleObj)]
        public PSSharedAccessAuthorizationRuleAttributes InputObject { get; set; }

        [CmdletParameterBreakingChange("Rights", ChangeDescription = "- The output type of the parameter would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.AccessRights[]'")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Listen", "Send", "Manage", IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSharedAccessAuthorizationRuleAttributes sasRule = new PSSharedAccessAuthorizationRuleAttributes();

            if (InputObject != null)
            {
                sasRule = InputObject;
            }
            else
            {
                sasRule.Rights = new List<string>();
                if (Rights != null && Rights.Length > 0)
                {
                    if (Array.Exists(Rights, element => element.Equals(Manage) && (!Array.Exists(Rights, element1 => element1.Equals(Listen)) || !Array.Exists(Rights, element1 => element1.Equals(Send)))))
                    {
                        Exception exManage = new Exception("Assigning 'Manage' to rights requires ‘Listen and ‘Send' to be included with. e.g. @(\"Manage\",\"Listen\",\"Send\")");
                        throw exManage;
                    }

                    foreach (string right in Rights)
                    {
                        sasRule.Rights.Add(right);
                    }
                }
            }

            try
            {
                // InputObject Authorization Rule
                if (ParameterSetName.Equals(AuthoRuleInputObjectParameterSet))
                    if (EventHub != null)
                    {
                        if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateEventHubAuthorizationrule, Name, EventHub)))
                        {
                            WriteObject(UtilityClient.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                        }
                    }
                    else
                    {
                        if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                        {
                            sasRule = InputObject;
                            WriteObject(UtilityClient.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                        }
                    }

                // update Namespace Authorization Rule
                if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                    {
                        WriteObject(UtilityClient.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                    }


                // Update EventHub authorizationRule
                if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateEventHubAuthorizationrule, Name, EventHub)))
                    {
                        WriteObject(UtilityClient.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                    }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
