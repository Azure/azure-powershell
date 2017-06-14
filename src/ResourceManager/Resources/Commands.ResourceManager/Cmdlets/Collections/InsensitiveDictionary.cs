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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The insensitive version of dictionary.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [JsonPreserveCaseDictionary]
    public class InsensitiveDictionary<TValue> : Dictionary<string, TValue>
    {
        /// <summary>
        /// The empty dictionary.
        /// </summary>
        public static readonly InsensitiveDictionary<TValue> Empty = new InsensitiveDictionary<TValue>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InsensitiveDictionary{TValue}"/> class.
        /// </summary>
        public InsensitiveDictionary()
            : base(StringComparer.InvariantCultureIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsensitiveDictionary{TValue}"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="T:System.Collections.Generic.Dictionary`2" /> can contain.</param>
        public InsensitiveDictionary(int capacity)
            : base(capacity, StringComparer.InvariantCultureIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsensitiveDictionary{TValue}"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public InsensitiveDictionary(IDictionary<string, TValue> dictionary)
            : base(dictionary, StringComparer.InvariantCultureIgnoreCase)
        {
        }
    }
}
