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
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

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

        public override void ExecuteCmdlet()
        {
            // Delete Namespace authorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection == null)
                if (ShouldProcess(target: Name, action: string.Format("Deleting AtuhorizationRule:{0} of Namespace: {1}", Name, Namespace)))
                {
                    WriteObject(Client.DeleteNamespaceAuthorizationRules(ResourceGroup, Namespace, Name));
                }

            // Delete WcfRelay authorizationRule
            if (Namespace != null && WcfRelay != null && HybridConnection == null)
                if (ShouldProcess(target: Name, action: string.Format("Deleting AtuhorizationRule:{0} from WcfRelay:{1} of Namespace: {2}", Name, WcfRelay, Namespace)))
                {
                    WriteObject(Client.DeleteWcfRelayAuthorizationRules(ResourceGroup, Namespace, WcfRelay, Name));
                }

            // Delete Hybird authorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection != null)
                if (ShouldProcess(target: Name, action: string.Format("Deleting AtuhorizationRule:{0} from HybridConnection:{1} of Namespace: {2}", Name, HybridConnection, Namespace)))
                {
                    WriteObject(Client.DeleteHybridConnectionsAuthorizationRules(ResourceGroup, Namespace, HybridConnection, Name));
                }
        }
    }
}
