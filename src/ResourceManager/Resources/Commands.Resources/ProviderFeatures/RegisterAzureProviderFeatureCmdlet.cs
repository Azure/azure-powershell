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

namespace Microsoft.Azure.Commands.Resources.ProviderFeatures
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models.ProviderFeatures;
    using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

    /// <summary>
    /// Register the previewed features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmProviderFeature"), OutputType(typeof(List<PSProviderFeature>))]
    public class RegisterAzureProviderFeatureCmdlet : AzureProviderFeatureCmdletBase
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
        /// Gets or sets a switch that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            this.ConfirmAction(
                force: this.Force,
                actionMessage: string.Format(ProjectResources.RegisteringProviderFeature, this.FeatureName, this.ProviderNamespace),
                processMessage: ProjectResources.RegisterProviderFeatureMessage,
                target: this.ProviderNamespace,
                action: () => this.WriteObject(this.ProviderFeatureClient.RegisterProviderFeature(providerName: this.ProviderNamespace, featureName: this.FeatureName)));
        }
    }
}