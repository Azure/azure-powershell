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

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal
{
    /// <summary>
    /// Represents a section of application configuration values.
    /// </summary>
    internal class ConfigurationSection : IConfigurationSection
    {
        private readonly IConfigurationRoot _root;
        private readonly string _path;
        private string _key;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="root">The configuration root.</param>
        /// <param name="path">The path to this section.</param>
        public ConfigurationSection(IConfigurationRoot root, string path)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            _root = root;
            _path = path;
        }

        /// <summary>
        /// Gets the full path to this section from the <see cref="IConfigurationRoot"/>.
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// Gets the key this section occupies in its parent.
        /// </summary>
        public string Key
        {
            get
            {
                if (_key == null)
                {
                    // Key is calculated lazily as last portion of Path
                    _key = ConfigurationPath.GetSectionKey(_path);
                }
                return _key;
            }
        }

        /// <summary>
        /// Gets or sets the section value.
        /// </summary>
        public (string, string) Value
        {
            get
            {
                return _root[Path];
            }
            set
            {
                _root[Path] = value;
            }
        }

        public (string, string) GetValueWithProviderId()
        {
            return _root.GetValueWithProviderId(Path);
        }

        /// <summary>
        /// Gets or sets the value corresponding to a configuration key.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        public (string, string) this[string key]
        {
            get
            {
                return _root[ConfigurationPath.Combine(Path, key)];
            }

            set
            {
                _root[ConfigurationPath.Combine(Path, key)] = value;
            }
        }

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="IConfigurationSection"/>.</returns>
        /// <remarks>
        ///     This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        ///     an empty <see cref="IConfigurationSection"/> will be returned.
        /// </remarks>
        public IConfigurationSection GetSection(string key) => _root.GetSection(ConfigurationPath.Combine(Path, key));

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>The configuration sub-sections.</returns>
        public IEnumerable<IConfigurationSection> GetChildren() => _root.GetChildrenImplementation(Path);

        public string GetValueByProviderId(string providerId)
        {
            return _root.GetValueByProviderId(Path, providerId);
        }
    }
}
