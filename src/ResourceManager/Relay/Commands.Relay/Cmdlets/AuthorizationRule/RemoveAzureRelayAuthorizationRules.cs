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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands
{
    /// <summary>
    /// 'Remove-AzureRmRelayAuthorizationRule' Cmdlet removes/deletes AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, RelayAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRelayAuthorizationRule : AzureRelayCmdletBase
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
            Position = 1, ParameterSetName = NamespaceAuthoRuleParameterSet,
            HelpMessage = "Namespace Name.")]
        [Parameter(ParameterSetName = WcfRelayAuthoRuleParameterSet)]
        [Parameter(ParameterSetName = HybridConnectionAuthoRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = WcfRelayAuthoRuleParameterSet,
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string WcfRelay { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = HybridConnectionAuthoRuleParameterSet,
            HelpMessage = "HybridConnection Name.")]
        [ValidateNotNullOrEmpty]
        public string HybridConnection { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Delete Namespace authorizationRule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingNamespaceAuthorizationRule, Name, Namespace),
                string.Format(Resources.RemoveNamespaceAuthorizationRule, Name, Namespace),
                Name,
                () =>
                {
                    Client.DeleteNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            // Delete WcfRelay authorizationRule
            if (ParameterSetName == WcfRelayAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingWcfRelayAuthorizationRule, Namespace, WcfRelay, Name),
                string.Format(Resources.RemoveWcfRelayAuthorizationRule, Namespace, WcfRelay, Name),
                Name,
                () =>
                {
                    Client.DeleteWcfRelayAuthorizationRules(ResourceGroupName, Namespace, WcfRelay, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            // Delete Hybird authorizationRule
            if (ParameterSetName == HybridConnectionAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingHybirdconnectionAuthorizationrule, Namespace, HybridConnection, Name),
                string.Format(Resources.RemovingHybirdconnectionAuthorizationrule, Namespace, HybridConnection, Name),
                Name,
                () =>
                {
                    Client.DeleteHybridConnectionsAuthorizationRules(ResourceGroupName, Namespace, HybridConnection, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
