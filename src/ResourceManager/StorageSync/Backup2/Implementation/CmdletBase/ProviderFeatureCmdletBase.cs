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
    using ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;

    /// <summary>
    /// Base class for all feature cmdlets
    /// </summary>
    public abstract class ProviderFeatureCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Cache for the feature client
        /// </summary>
        private ProviderFeatureClient providerFeatureClient;

        /// <summary>
        /// Gets the feature client
        /// </summary>
        public ProviderFeatureClient ProviderFeatureClient
        {
            get
            {
                if (this.providerFeatureClient == null)
                {
                    this.providerFeatureClient = new ProviderFeatureClient(DefaultContext);
                }

                return this.providerFeatureClient;
            }

            set { this.providerFeatureClient = value; }
        }

        /// <summary>
        /// Determines the parameter set name.
        /// </summary>
        public virtual string DetermineParameterSetName()
        {
            return this.ParameterSetName;
        }
    }
}
