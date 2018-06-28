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
using Microsoft.Azure.Commands.Profile.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure account details.
    /// </summary>
    public class PSAzureRmAccount : IAzureAccount
    {
        /// <summary>
        /// Convert between implementation of Azure Account metadata
        /// </summary>
        /// <param name="account">The account to convert.</param>
        /// <returns>The converted account.</returns>
        public static implicit operator PSAzureRmAccount(AzureAccount account)
        {
            if (account == null)
            {
                return null;
            }

            return new PSAzureRmAccount(account);
        }

        /// <summary>
        /// Convert between implementation of Azure Account metadata
        /// </summary>
        /// <param name="account">The account to convert.</param>
        /// <returns>The converted account.</returns>
        public static implicit operator AzureAccount(PSAzureRmAccount account)
        {
            if (account == null)
            {
                return null;
            }

            var result = new AzureAccount();
            result.CopyFrom(account);
            return result;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PSAzureRmAccount()
        {

        }

        public PSAzureRmAccount(IAzureAccount other)
        {
            this.CopyFrom(other);
        }

        /// <summary>
        /// Populate the account from a PSObject
        /// </summary>
        /// <param name="other"></param>
        public PSAzureRmAccount(PSObject other)
        {
            if (other == null || other.Properties == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            Id = other.GetProperty<string>(nameof(Id));
            Type = other.GetProperty<string>(nameof(Type));
            Credential = other.GetProperty<string>(nameof(Credential));
            TenantMap.Populate(nameof(TenantMap), other);
            this.PopulateExtensions(other);
        }

        /// <summary>
        /// The UPN or SPN for this account.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The type of the account
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The tenant ids for the account
        /// </summary>
        public List<string> Tenants
        {
            get
            {
                return this.GetTenants().ToList();
            }
            set
            {
                this.SetTenants(value.ToArray());
            }
        }

        /// <summary>
        /// The access token for the account (if any)
        /// </summary>
        public string AccessToken
        {
            get { return this.GetAccessToken(); }
            set { this.SetAccessToken(value); }
        }

        public string Credential { get; set; }

        public IDictionary<string, string> TenantMap { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets or sets Thumbprint for associated certificate
        /// </summary>
        public string CertificateThumbprint
        {
            get
            {
                return this.GetThumbprint();
            }
            set
            {
                this.SetThumbprint(value);
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; set; } = new Dictionary<string, string>();

        public override string ToString()
        {
            return this.Id;
        }
    }
}
