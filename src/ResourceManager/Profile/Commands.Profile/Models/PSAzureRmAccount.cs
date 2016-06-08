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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure account details.
    /// </summary>
    public class PSAzureRmAccount
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

            var result = new PSAzureRmAccount
            {
                Id = account.Id,
                AccountType = account.Type.ToString()
            };

            if (account.IsPropertySet(AzureAccount.Property.AccessToken))
            {
                result.AccessToken = account.GetProperty(AzureAccount.Property.AccessToken);
            }

            if (account.IsPropertySet(AzureAccount.Property.Tenants))
            {
                result.Tenants = new List<string>(account.GetPropertyAsArray(AzureAccount.Property.Tenants));
            }

            if (account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                result.CertificateThumbprint = account.GetProperty(AzureAccount.Property.CertificateThumbprint);
            }

            return result;
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

            var result = new AzureAccount
            {
                Id = account.Id,
            };
            AzureAccount.AccountType accountType;
            if (Enum.TryParse(account.AccountType, out accountType))
            {
                result.Type = accountType;
            }

            if (!string.IsNullOrWhiteSpace(account.AccessToken))
            {
                result.SetProperty(AzureAccount.Property.AccessToken, account.AccessToken);
            }

            if (account.Tenants != null &&
                account.Tenants.Any(s => !string.IsNullOrWhiteSpace(s)))
            {
                result.SetProperty(
                    AzureAccount.Property.Tenants,
                    account.Tenants.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray());
            }

            if (!string.IsNullOrWhiteSpace(account.CertificateThumbprint))
            {
                result.SetProperty(AzureAccount.Property.CertificateThumbprint, account.CertificateThumbprint);
            }
            return result;
        }

        /// <summary>
        /// The UPN or SPN for this account.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The type of the account
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// The tenant ids for the account
        /// </summary>
        public List<string> Tenants { get; set; }

        /// <summary>
        /// The access token for the account (if any)
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets Thumbprint for associated certificate
        /// </summary>
        public string CertificateThumbprint { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
