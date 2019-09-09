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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{
    [GenericBreakingChange("Remove-AzNotificationHubsNamespaceAuthorizationRules alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NotificationHubsNamespaceAuthorizationRule", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AzNotificationHubsNamespaceAuthorizationRules")]
    public class RemoveAzureNotificationHubsNamespaceAuthorizationRules : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Namespace AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRule { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Resources.DeleteNamespaceAuthorizationRule_Confirm, AuthorizationRule),
                Resources.DeleteNamespaceAuthorizationRule_WhatIf,
                AuthorizationRule,
                () =>
                {
                    // Create a new namespace authorizationRule
                    Client.DeleteNamespaceAuthorizationRules(ResourceGroup, Namespace, AuthorizationRule);
                });
        }
    }
}
