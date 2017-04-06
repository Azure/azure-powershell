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

namespace Microsoft.Azure.Commands.Relay.Commands.HybridConnections
{
    /// <summary>
    /// 'Remove-AzureRmRelayHybridConnectionAuthorizationRule' Cmdlet removes/deletes AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, RelayHybridConnectionAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRelayHybridConnectionsAuthorizationRule : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "HybridConnections Name.")]
        [ValidateNotNullOrEmpty]
        public string HybridConnectionsName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "HybridConnections AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            // Delete HybridConnections authorizationRule
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Deleting AtuhorizationRule:{0} from HybridConnections:{1} of Namespace: {2}", AuthorizationRuleName, HybridConnectionsName, NamespaceName)))
            {
                WriteObject(Client.DeleteHybridConnectionsAuthorizationRules(ResourceGroupName, NamespaceName, HybridConnectionsName, AuthorizationRuleName));
            }            
        }
    }
}
