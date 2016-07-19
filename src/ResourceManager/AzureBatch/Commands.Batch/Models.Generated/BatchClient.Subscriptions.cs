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

using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Gets the quotas of the subscription in the Batch Service.
        /// </summary>
        /// <param name="location">The location to use when getting the Batch subscription quotas.</param>
        /// <returns>A PSBatchSubscriptionQuotas object containing the subscription quotas.</returns>
        public virtual PSBatchSubscriptionQuotas GetSubscriptionQuotas(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }

            WriteVerbose(string.Format(Resources.GettingSubscriptionQuotas, location));

            SubscriptionQuotasGetResult response = this.BatchManagementClient.Subscription.GetSubscriptionQuotas(location);
            return new PSBatchSubscriptionQuotas(location, response);
        }
    }
}
