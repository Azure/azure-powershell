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

using System;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System.Collections.Generic;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Un-registers the resource provider from the current subscription.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureRmResourceProvider", SupportsShouldProcess = true), 
        OutputType(typeof(List<PSResourceProvider>))]
    public class UnregisterAzureProviderCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.")]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                processMessage: ProjectResources.UnregisterProviderMessage,
                target: this.ProviderNamespace,
                action: () => this.WriteObject(this.ResourceManagerSdkClient.UnregisterProvider(providerName: this.ProviderNamespace)));
        }
    }
}