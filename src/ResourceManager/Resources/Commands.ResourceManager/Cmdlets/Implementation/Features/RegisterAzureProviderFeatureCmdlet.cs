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
    using System.Collections.Generic;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;

    /// <summary>
    /// Register the previewed features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmProviderFeature", SupportsShouldProcess = true), OutputType(typeof(List<PSProviderFeature>))]
    public class RegisterAzureProviderFeatureCmdlet : ProviderFeatureCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The feature name.")]
        [ValidateNotNullOrEmpty]
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets the provider name
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
                processMessage: ProjectResources.RegisterProviderFeatureMessage,
                target: this.ProviderNamespace,
                action: () => this.WriteObject(this.ProviderFeatureClient.RegisterProviderFeature(providerName: this.ProviderNamespace, featureName: this.FeatureName)));
        }
    }
}