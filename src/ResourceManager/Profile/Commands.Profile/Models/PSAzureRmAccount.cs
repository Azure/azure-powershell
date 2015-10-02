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

using System;
using System.Configuration;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Utilities;

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

            return new PSAzureRmAccount
            {
                Id = account.Id,
                AccountType = account.Type.ToString()
            };
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

        public override string ToString()
        {
            return this.Id;
        }
    }
}
