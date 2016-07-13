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

using Microsoft.Azure.Management.StreamAnalytics;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public partial class StreamAnalyticsClient
    {
        public virtual List<PSQuota> GetQuotas(string location)
        {
            List<PSQuota> quotas = new List<PSQuota>();
            var response = StreamAnalyticsManagementClient.Subscriptions.GetQuotas(location);

            if (response != null && response.Value != null)
            {
                foreach (var quota in response.Value)
                {
                    quotas.Add(new PSQuota(quota)
                    {
                        Location = location
                    });
                }
            }

            return quotas;
        }
    }
}