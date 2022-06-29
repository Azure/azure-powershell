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
// ------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.SecurityCenter.Common
{
    public static class Utilities
    {
        /// <summary>
        /// Converts the hash table to dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="hashTable">The hash table.</param>
        /// <returns></returns>
        public static IDictionary<TKey,TValue> ConvertHashTableToDictionary<TKey, TValue>(Hashtable hashTable)
        {
            return hashTable?.Cast<DictionaryEntry>().ToDictionary(d => (TKey)d.Key, d => (TValue)d.Value);
        }

        /// <summary>
        /// Converts the dictionary to hash table.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        public static Hashtable ConvertDictionaryToHashTable(IDictionary dictionary)
        {
            return new Hashtable(dictionary);
        }
    }
}
