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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models.ProviderFeatures;

    /// <summary>
    /// Gets the preview features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmProviderFeature", DefaultParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
    [OutputType(typeof(List<PSProviderFeature>))]
    [CliCommandAlias("resource provider feature ls")]
    public class GetAzureProviderFeatureCmdlet : AzureProviderFeatureCmdletBase
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
        [Alias("m", "namespace")]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the feature name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The feature name.", ParameterSetName = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("n", "name")]
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to list all available features or just the ones registered with the current subscription
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "When set, lists all available features including those not registered with the current subscription.", ParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
        [Alias("a")]
        public SwitchParameter ListAvailable { get; set; }

        protected override void ProcessRecord()
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
                    throw new PSInvalidOperationException(string.Format("Unknown parameter set encountered: '{0}'", this.ParameterSetName));
            }
        }
    }
}
