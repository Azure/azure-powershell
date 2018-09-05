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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;

    /// <summary>
    /// Gets the preview features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmProviderFeature", DefaultParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
    [OutputType(typeof(List<PSProviderFeature>))]
    public class GetAzureProviderFeatureCmdlet : ProviderFeatureCmdletBase
    {
        /// <summary>
        /// The filter unregistered parameter set
        /// </summary>
        public const string ListAvailableParameterSet = "ListAvailableParameterSet";

        /// <summary>
        /// The get feature parameter set
        /// </summary>
        public const string GetFeatureParameterSet = "GetFeature";

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.", ParameterSetName = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource provider namespace.", ParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the feature name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The feature name.", ParameterSetName = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to list all available features or just the ones registered with the current subscription
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "When set, lists all available features including those not registered with the current subscription.", ParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
        public SwitchParameter ListAvailable { get; set; }

        public override void ExecuteCmdlet()
        {
            var parameterSetName = this.DetermineParameterSetName();

            switch (parameterSetName)
            {
                case GetAzureProviderFeatureCmdlet.ListAvailableParameterSet:
                    this.WriteObject(this.ProviderFeatureClient.ListPSProviderFeatures(this.ListAvailable, this.ProviderNamespace), enumerateCollection: true);
                    break;

                case GetAzureProviderFeatureCmdlet.GetFeatureParameterSet:
                    this.WriteObject(this.ProviderFeatureClient.ListPSProviderFeatures(this.ProviderNamespace, this.FeatureName), enumerateCollection: true);
                    break;

                default:
                    throw new ApplicationException(string.Format("Unknown parameter set encountered: '{0}'", this.ParameterSetName));
            }
        }
    }
}
