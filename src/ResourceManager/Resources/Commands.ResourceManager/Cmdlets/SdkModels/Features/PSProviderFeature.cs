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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    /// <summary>
    /// Represents a feature
    /// </summary>
    public class PSProviderFeature
    {
        /// <summary>
        /// Gets the name of the feature
        /// </summary>
        public string FeatureName { get; internal set; }

        /// <summary>
        /// Gets the name of the feature
        /// </summary>
        public string ProviderName { get; internal set; }

        /// <summary>
        /// Gets the registration state of the feature
        /// </summary>
        public string RegistrationState { get; internal set; }
    }
}
