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
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.SecurityCenter.Common
{
    public static class AzureIdUtilities
    {
        private static Regex locationRegex = new Regex("/locations/(?<Location>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex rgRegex = new Regex("/resourceGroups/(?<RG>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static Regex subscriptionRegex = new Regex("/subscriptions/(?<subscriptionId>.*?)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string GetResourceName(string id)
        {
            return id.Split('/').Last();
        }

        public static string GetResourceLocation(string id)
        {
            var match = locationRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["Location"].Value;
        }

        public static string GetResourceGroup(string id)
        {
            var match = rgRegex.Match(id);

            if (match.Success != true)
            {
                return null;
            }

            return match.Groups["RG"].Value;
        }

        public static string GetResourceSubscription(string id)
        {
            var match = subscriptionRegex.Match(id);

            if (match.Success != true)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "id");
            }

            return match.Groups["subscriptionId"].Value;
        }
    }
}
