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

namespace Microsoft.Azure.Commands.Media.Models
{
    /// <summary>
    /// Storage Account associated with Media Service Account
    /// </summary>
    public class PSStorageAccount
    {
        private const string AccountKeyFormat = @"\/subscriptions\/(?<{0}>[^/]+)\/resourcegroups\/(?<{1}>[^/]+)\/providers\/Microsoft\.(ClassicStorage|Storage)\/storageAccounts\/(?<{2}>.*)";
        private const string SubscriptionIdGroupKey = "subscriptionId";
        private const string ResourceGroupGroupKey = "resourceGroup";
        private const string AcountNameKey = "accountName";

        public string Id { get; set; }

        public bool? IsPrimary { get; set; }

        public string ResourceGroupName
        {
            get
            {
                var match = Regex.Match(Id,
                    string.Format(AccountKeyFormat,
                        SubscriptionIdGroupKey,
                        ResourceGroupGroupKey,
                        AcountNameKey), RegexOptions.IgnoreCase);

                return match.Groups[ResourceGroupGroupKey].Value;
            }
        }

        public string AccountName
        {
            get
            {
                var match = Regex.Match(Id,
                    string.Format(AccountKeyFormat,
                        SubscriptionIdGroupKey,
                        ResourceGroupGroupKey,
                        AcountNameKey), RegexOptions.IgnoreCase);

                return match.Groups[AcountNameKey].Value;
            }
        }
    }
}
