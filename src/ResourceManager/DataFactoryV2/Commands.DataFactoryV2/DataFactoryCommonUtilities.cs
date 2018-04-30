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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    internal static class DataFactoryCommonUtilities
    {
        public static Dictionary<string, string> ToDictionary(this Hashtable hashTable)
        {
            return hashTable.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
        }


        public static bool IsSucceededProvisioningState(string provisioningState)
        {
            return
                string.Equals(provisioningState, OperationStatus.Succeeded.ToString(),
                    StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNextPageLink(this string nextLink)
        {
            return !string.IsNullOrEmpty(nextLink);
        }

        public static bool IsEmptyOrWhiteSpace(this string value)
        {
            return value.All(char.IsWhiteSpace);
        }
    }
}
