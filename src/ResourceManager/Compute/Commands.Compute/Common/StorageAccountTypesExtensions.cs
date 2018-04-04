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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class StorageAccountTypesExtensions
    {
        private static string StandardLRS = "StandardLRS";
        private static string StandardZRS = "StandardZRS";
        private static string PremiumLRS = "PremiumLRS";

        private static string Standard_LRS = "Standard_LRS";
        private static string Standard_ZRS = "Standard_ZRS";
        private static string Premium_LRS = "Premium_LRS";

        private static Dictionary<string, string> _mappings = new Dictionary<string, string>()
        {
            { StandardLRS, Standard_LRS },
            { StandardZRS, Standard_ZRS },
            { PremiumLRS, Premium_LRS }
        };

        public static string ToSerializedValue(this string storageAccountType)
        {
            if (!string.IsNullOrEmpty(storageAccountType) && _mappings.ContainsKey(storageAccountType))
            {
                return _mappings[storageAccountType];
            }

            return storageAccountType;
        }
    }
}