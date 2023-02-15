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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal
{
    /// <summary>
    /// The root node for a configuration.
    /// </summary>
    internal class ConfigurationRoot : IConfigurationRoot, IDisposable
    {
        private readonly IList<IConfigurationProvider> _providers;

        /// <summary>
        /// Initializes a Configuration root with a list of providers.
        /// </summary>
        /// <param name="providers">The <see cref="IConfigurationProvider"/>s for this configuration.</param>
        public ConfigurationRoot(IList<IConfigurationProvider> providers)
        {
            if (providers == null)
            {
                throw new ArgumentNullException(nameof(providers));
            }

            _providers = providers;
            foreach (IConfigurationProvider p in providers)
            {
                p.Load();
            }
        }

        /// <summary>
        /// The <see cref="IConfigurationProvider"/>s for this configuration.
        /// </summary>
        public IEnumerable<IConfigurationProvider> Providers => _providers;

        /// <summary>
        /// Gets or sets the value corresponding to a configuration key.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        public (string value, string providerId) this[string key]
        {
            get
            {
                return GetValueWithProviderId(key);
            }
            set
            {
                throw new NotSupportedException("todo");
                //if (!_providers.Any())
                //{
                //    throw new InvalidOperationException($"Error: none config source is registered.");
                //}

                //foreach (IConfigurationProvider provider in _providers)
                //{
                //    provider.Set(key, value);
                //}
            }
        }

        public (string, string) GetValueWithProviderId(string key)
        {
            for (int i = _providers.Count - 1; i >= 0; i--)
            {
                IConfigurationProvider provider = _providers[i];

                if (provider.TryGet(key, out string value))
                {
                    return (value, provider.Id);
                }
            }

            return (null, null);

        }

        public string GetValueByProviderId(string key, string providerId)
        {
            for (int i = _providers.Count - 1; i >= 0; i--)
            {
                IConfigurationProvider provider = _providers[i];

                if (provider.Id == providerId && provider.TryGet(key, out string value))
                {
                    return value;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the immediate children sub-sections.
        /// </summary>
        /// <returns>The children.</returns>
        public IEnumerable<IConfigurationSection> GetChildren() => this.GetChildrenImplementation(null);

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="IConfigurationSection"/>.</returns>
        /// <remarks>
        ///     This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        ///     an empty <see cref="IConfigurationSection"/> will be returned.
        /// </remarks>
        public IConfigurationSection GetSection(string key)
            => new ConfigurationSection(this, key);

        /// <summary>
        /// Force the configuration values to be reloaded from the underlying sources.
        /// </summary>
        public void Reload()
        {
            foreach (IConfigurationProvider provider in _providers)
            {
                provider.Load();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            // dispose providers
            foreach (IConfigurationProvider provider in _providers)
            {
                (provider as IDisposable)?.Dispose();
            }
        }

        public IConfigurationProvider GetConfigurationProvider(string id)
        {
            return _providers.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
