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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'Remove-AzureRmServiceBusNamespaceAuthorizationRule' Cmdlet deletes specified ServiceBus Namespace AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ServiceBusNamespaceAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmServiceBusNamespaceAuthorizationRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Namespace AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new namespace authorizationRule
            
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Delete AuthorizationRule:{0} of the Namespace:{1}", AuthorizationRuleName, NamespaceName)))
            {
                WriteObject(Client.DeleteNamespaceAuthorizationRules(ResourceGroup, NamespaceName, AuthorizationRuleName));
            }
        }
    }
}
