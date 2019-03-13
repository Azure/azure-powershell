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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Application
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The application definition properties.
    /// </summary>
    public class ApplicationDefinitionProperties
    {
        /// <summary>
        /// The value indicating whether the package is enabled or not.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// The lock level that determines customer's access to the managed resource group.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public ApplicationLockLevel LockLevel { get; set; }

        /// <summary>
        /// The application definition display name.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The application definition description.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// The collection of provider authorizations.
        /// ARM will use information in this collection to onboard the appliance provider so that they can perform operations on behalf of the customer.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationProviderAuthorization[] Authorizations { get; set; }

        /// <summary>
        /// The collection of appliance artifacts.
        /// The portal will use the files specified as artifacts to construct the user experience of creating an appliance from an application definition.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationArtifact[] Artifacts { get; set; }

        /// <summary>
        /// The package zip blob uri.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string PackageFileUri { get; set; }

        /// <summary>
        /// The create ui definition json.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject CreateUiDefinition { get; set; }

        /// <summary>
        /// The main template json.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject MainTemplate { get; set; }
    }
}
