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
    /// The policy definition properties.
    /// </summary>
    public class ApplicationProperties
    {
        /// <summary>
        /// The managed resource group id.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ManagedResourceGroupId { get; set; }

        /// <summary>
        /// The application definition id.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string ApplicationDefinitionId { get; set; }

        /// <summary>
        /// The publisher package id.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string PublisherPackageId { get; set; }

        /// <summary>
        /// The outputs.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject Outputs { get; set; }

        /// <summary>
        /// The parameters declaration.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject Parameters { get; set; }

        /// <summary>
        /// The ui definition uri.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string UiDefinitionUri { get; set; }

        /// <summary>
        /// The read-only authorizations property that is retrieved from the appliance package.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationProviderAuthorization[] Authorizations { get; set; }

        /// <summary>
        /// The read-only customer support property that is retrieved from the application package.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationPackageCustomerSupport CustomerSupport { get; set; }

        /// <summary>
        /// The read-only support URLs property that is retrieved from the application package.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public ApplicationPackageSupportUrls SupportUrls { get; set; }
    }
}
