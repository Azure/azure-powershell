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

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces
{
    internal interface IConfigurationSection : IConfiguration
    {
        /// <summary>
        /// Gets the key this section occupies in its parent.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the full path to this section within the <see cref="IConfiguration"/>.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets or sets the section value.
        /// </summary>
        (string, string) Value { get; set; }

        /// <summary>
        /// Gets the section value and the ID of the provider which provides this value.
        /// </summary>
        /// <returns>The configuration value and the ID of the provider which provides the value.</returns>
        (string, string) GetValueWithProviderId();

        /// <summary>
        /// Get value of config by provider ID.
        /// </summary>
        /// <param name="providerId">expected provider ID</param>
        /// <returns>The configuration value. Null if not found.</returns>
        string GetValueByProviderId(string providerId);
    }
}
