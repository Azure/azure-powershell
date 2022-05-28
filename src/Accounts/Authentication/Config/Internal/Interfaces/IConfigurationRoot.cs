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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces
{
    /// <summary>
    /// Represents the root of an <see cref="IConfiguration"/> hierarchy.
    /// </summary>
    internal interface IConfigurationRoot : IConfiguration
    {
        /// <summary>
        /// Force the configuration values to be reloaded from the underlying <see cref="IConfigurationProvider"/>s.
        /// </summary>
        void Reload();

        /// <summary>
        /// The <see cref="IConfigurationProvider"/>s for this configuration.
        /// </summary>
        IEnumerable<IConfigurationProvider> Providers { get; }

        IConfigurationProvider GetConfigurationProvider(string id);

        /// <summary>
        /// Get value of config by key.
        /// </summary>
        /// <param name="key">config key</param>
        /// <returns>The configuration value and the ID of the provider which provides the value.</returns>
        (string, string) GetValueWithProviderId(string key);

        /// <summary>
        /// Get value of config by key and provider ID.
        /// </summary>
        /// <param name="key">config key</param>
        /// <param name="providerId">expected provider ID</param>
        /// <returns>The configuration value. Null if not found.</returns>
        string GetValueByProviderId(string key, string providerId);
    }
}
