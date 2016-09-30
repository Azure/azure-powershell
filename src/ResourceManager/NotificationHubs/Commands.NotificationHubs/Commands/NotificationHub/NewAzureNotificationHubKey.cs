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

using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Management.NotificationHubs.Models;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.NotificationHub
{
    [Cmdlet(VerbsCommon.New, "AzureRmNotificationHubKey", SupportsShouldProcess = true), OutputType(typeof(ResourceListKeys))]
    public class NewAzureNotificationHubKey : AzureNotificationHubsCmdletBase
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
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "NotificationHub Name.")]
        [ValidateNotNullOrEmpty]
        public string NotificationHub { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "NotificationHub AuthorizationRule Name.")]
        public string AuthorizationRule { get; set; }

        [Parameter(Mandatory = true,
            Position = 4,
            HelpMessage = "Namespace Authorization Rule Key Name.")]
        [ValidateSet(PrimaryKey, SecondaryKey, IgnoreCase = true)]
        public string PolicyKey { get; set; }

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
                string.Format(CultureInfo.InvariantCulture, Resources.RegenerateNotificationHubKey_Confirm, AuthorizationRule),
                string.Format(CultureInfo.InvariantCulture, Resources.RegenerateNotificationHubKey_WhatIf, AuthorizationRule),
                AuthorizationRule,
                () =>
                {
                    // Regenerate the NotificationHub authorizationRule key
                    var authRule = Client.RegenerateNotificationHubKeys(ResourceGroup, Namespace, NotificationHub, AuthorizationRule, PolicyKey);
                    WriteObject(authRule);
                });
        }
    }
}
