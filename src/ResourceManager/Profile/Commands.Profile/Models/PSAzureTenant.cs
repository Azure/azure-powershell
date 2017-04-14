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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure subscription details.
    /// </summary>
    public class PSAzureTenant : IAzureTenant
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

            var tenant = new PSAzureTenant();
            tenant.CopyFrom(other);
            return tenant;
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

            var result = new AzureTenant();
            result.CopyFrom(other);
            return result;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PSAzureTenant()
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="other">The tenanht to copy</param>
        public PSAzureTenant(IAzureTenant other)
        {
            this.CopyFrom(other);
        }
        /// <summary>
        /// The subscription id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the subscription.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Extended proeprties of the tenant
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);


        public override string ToString()
        {
            return (this.Id == Guid.Empty.ToString()) ? this.Directory : this.Id;
        }
    }
}
