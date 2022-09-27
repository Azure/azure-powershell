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

using System;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'Set-AzServiceBusAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusAuthorizationRule", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessAuthorizationRuleAttributes))]
    public class SetAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Queue Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasQueueName)]
        public string Queue { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Topic Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicName)]
        public string Topic { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [CmdletParameterBreakingChange("InputObject", OldParamaterType = typeof(PSSharedAccessAuthorizationRuleAttributes), NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule", ChangeDescription = AuthoRuleInputObjectParameterSet + " parameter set is changing. Please refer the migration guide for examples.\n- InputObject would no longer support alias -AuthRuleObj.")]
        [Parameter(Mandatory = true, ParameterSetName = AuthoRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "ServiceBus AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "ServiceBus AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "ServiceBus AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "ServiceBus AuthorizationRule Object")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthRuleObj)]
        public PSSharedAccessAuthorizationRuleAttributes InputObject { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Listen", "Send", "Manage", IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            try
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
                        if (Array.Exists(Rights, element => element == "Manage") && !Array.Exists(Rights, element => element == "Listen") || !Array.Exists(Rights, element => element == "Send"))
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

                if (ParameterSetName.Equals(AuthoRuleInputObjectParameterSet))
                {
                    if (Topic != null)
                    {
                        if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateTopicAuthorizationrule, Name, Topic)))
                        {
                            WriteObject(Client.CreateOrUpdateServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name, sasRule));
                        }
                    }
                    else if (Queue != null)
                    {
                        if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateQueueAuthorizationrule, Name, Queue)))
                        {
                            WriteObject(Client.CreateOrUpdateServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name, sasRule));
                        }
                    }
                    else if (Namespace != null)
                    {
                        if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                        {
                            WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                        }
                    }
                }

                // update Namespace Authorization Rule
                if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                    {
                        WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                    }
                }


                // Update Topic authorizationRule
                if (ParameterSetName.Equals(QueueAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateQueueAuthorizationrule, Name, Queue)))
                    {
                        WriteObject(Client.CreateOrUpdateServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name, sasRule));
                    }
                }

                // Update Topic authorizationRule
                if (ParameterSetName.Equals(TopicAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateTopicAuthorizationrule, Name, Topic)))
                    {
                        WriteObject(Client.CreateOrUpdateServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name, sasRule));
                    }
                }
            }
            catch (ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
