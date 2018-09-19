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

using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites
{
    public static class SiteNameParser
    {
        public const string ProductionSlot = "production";
        private static readonly Regex SiteWithSlotNameRegexp =
            new Regex(@"^(?<siteName>[^\(]+)\((?<slotName>[^\)]+)\)$");

        public static void ParseSiteWithSlotName(string siteWithSlotName, out string siteName, out string slotName)
        {
            var match = SiteWithSlotNameRegexp.Match(siteWithSlotName);
            if (match.Success)
            {
                siteName = match.Groups["siteName"].Value;
                slotName = match.Groups["slotName"].Value;
            }
            else
            {
                siteName = siteWithSlotName;
                slotName = ProductionSlot;
            }
        }
    }
}
