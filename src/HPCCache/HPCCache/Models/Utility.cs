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

namespace Microsoft.Azure.Commands.HPCCache
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Utility Class.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Validate Resource Group.
        /// </summary>
        /// <param name="resourceGroupName"> string resourceGroupName.</param>
        public static void ValidateResourceGroup(string resourceGroupName)
        {
            if (resourceGroupName != null && resourceGroupName.Contains("/"))
            {
                throw new ArgumentException("Invalid Resource Group Name");
            }
        }

        /// <summary>
        /// Convert tags to dictionary.
        /// </summary>
        /// <param name="table"> Hashtable table. </param>
        /// <returns>dictionary of tags. </returns>
        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            return table?.Cast<DictionaryEntry>()
                .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }
    }
}