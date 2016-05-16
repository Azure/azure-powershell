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

using Microsoft.Azure.Management.Batch.Models;
using System;

namespace Microsoft.Azure.Commands.Batch.Models
{
    /// <summary>
    /// The quotas of a subscription in the Batch Service.
    /// </summary>
    public class PSBatchSubscriptionQuotas
    {
        public PSBatchSubscriptionQuotas(string location, SubscriptionQuotasGetResult subscriptionQuotasResponse)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }

            if (subscriptionQuotasResponse == null)
            {
                throw new ArgumentNullException("subscriptionQuotasResponse");
            }

            this.Location = location;
            this.AccountQuota = subscriptionQuotasResponse.AccountQuota.GetValueOrDefault();
        }

        /// <summary>
        /// The number of accounts the subscription is allowed to create in the Batch Service at the specified region.
        /// </summary>
        public int AccountQuota { get; private set; }

        /// <summary>
        /// The region name.
        /// </summary>
        public string Location { get; private set; }
    }
}
