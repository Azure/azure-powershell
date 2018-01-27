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
using Microsoft.Azure.Commands.NotificationHubs.Models;
using System.Collections;
using System.Management.Automation;
using System.Globalization;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{

    [Cmdlet(VerbsCommon.Set, "AzureRmNotificationHubsNamespace", SupportsShouldProcess = true), OutputType(typeof(NamespaceAttributes))]
    public class SetAzureNotificationHubsNamespace : AzureNotificationHubsCmdletBase
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
            HelpMessage = "Namespace Location.")]
        [LocationCompleter("Microsoft.NotificationHubs/namespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Disable/Enable Namespace.")]
        public NamespaceState State { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "Make a Namespace Critical.")]
        public bool Critical { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = "Hashtables which represents resource Tags.")]
        [Obsolete("Set-AzureRmNotificationHubsNamespace: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          Position = 4,
          HelpMessage = "Sku tier of the namespace")]
        public string SkuTier { get; set; }

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
                string.Format(CultureInfo.InvariantCulture, Resources.UpdateNamespace_Confirm, Namespace),
                Resources.UpdateNamespace_WhatIf,
                Namespace,
                () =>
                {
                    // Update a namespace 
#pragma warning disable CS0618
                    var nsAttribute = Client.UpdateNamespace(ResourceGroup, Namespace, Location, State, Critical, ConvertTagsToDictionary(Tag), SkuTier);
#pragma warning restore CS0618
                    WriteObject(nsAttribute);
                });
        }
    }
}
