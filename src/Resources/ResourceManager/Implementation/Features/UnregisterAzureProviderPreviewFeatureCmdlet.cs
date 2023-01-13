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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Unregisters feature registration.
    /// </summary>
    [Cmdlet("Unregister", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ProviderPreviewFeature", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class UnregisterAzureProviderPreviewFeatureCmdlet : ProviderFeatureCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The feature name.")]
        [Alias("FeatureName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.")]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the pass thru.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                processMessage: ProjectResources.RemoveFeatureRegistrationMessage,
                target: this.ProviderNamespace,
                action: () =>
                {
                    this.ProviderFeatureClient.DeleteFeatureRegistration(providerName: this.ProviderNamespace, featureName: this.Name);

                    if (this.PassThru.IsPresent)
                    {
                        this.WriteObject(true);
                    }
                });
        }
    }
}
