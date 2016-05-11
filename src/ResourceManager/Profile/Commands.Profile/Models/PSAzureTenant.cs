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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure subscription details.
    /// </summary>
    public class PSAzureTenant
    {
        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator PSAzureTenant(AzureTenant other)
        {
            if (other == null)
            {
                return null;
            }

            return new PSAzureTenant
            {
                TenantId = other.Id.ToString(),
                Domain = other.Domain
            };
        }

        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator AzureTenant(PSAzureTenant other)
        {
            if (other == null)
            {
                return null;
            }

            var result = new AzureTenant
            {
                Domain = other.Domain
            };

            if (other.TenantId != null)
            {
                Guid tenantId;
                if (Guid.TryParse(other.TenantId, out tenantId))
                {
                    result.Id = tenantId;
                }
            }

            return result;
        }

        /// <summary>
        /// The subscription id.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The name of the subscription.
        /// </summary>
        public string Domain { get; set; }


        public override string ToString()
        {
            return (this.TenantId == Guid.Empty.ToString()) ? this.Domain : this.TenantId;
        }
    }
}
