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

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Utility methods to help with SKU's.
    /// </summary>
    internal static class SqlSkuUtils
    {
        /// <summary>
        /// Gets sku name based on edition name for vcore editions.
        /// Returns null for unknown editions.
        /// 
        ///    Edition              | SkuName
        ///    GeneralPurpose       | GP
        ///    BusinessCritical     | BC
        ///    Hyperscale           | HS
        /// </summary>
        /// <param name="tier">Azure Sql database edition</param>
        /// <returns>The sku name</returns>
        public static string GetVcoreSkuPrefix(string tier)
        {
            if (string.IsNullOrWhiteSpace(tier))
            {
                return null;
            }

            switch (tier.ToLowerInvariant())
            {
                case "generalpurpose":
                    return "GP";
                case "businesscritical":
                    return "BC";
                case "hyperscale":
                    return "HS";
                default:
                    return null;
            }
        }
    }
}
