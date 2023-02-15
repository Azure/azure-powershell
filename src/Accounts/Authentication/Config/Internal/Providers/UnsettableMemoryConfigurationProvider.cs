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
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    /// <summary>
    /// In-memory implementation of <see cref="IConfigurationProvider"/>
    /// </summary>
    internal class UnsettableMemoryConfigurationProvider : ConfigurationProvider, IEnumerable<KeyValuePair<string, string>>
    {
        private readonly UnsettableMemoryConfigurationSource _source;

        /// <summary>
        /// Initialize a new instance from the source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        /// <param name="id">Id of the provider.</param>
        public UnsettableMemoryConfigurationProvider(UnsettableMemoryConfigurationSource source, string id) : base(id)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _source = source;

            if (_source.InitialData != null)
            {
                foreach (KeyValuePair<string, string> pair in _source.InitialData)
                {
                    Data.Add(pair.Key, pair.Value);
                }
            }
        }

        /// <summary>
        /// Add a new key and value pair.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <param name="value">The configuration value.</param>
        public void Add(string key, string value)
        {
            Data.Add(key, value);
        }

        public void Unset(string key)
        {
            Data.Remove(key);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void UnsetAll()
        {
            Data.Clear();
        }
    }
}
