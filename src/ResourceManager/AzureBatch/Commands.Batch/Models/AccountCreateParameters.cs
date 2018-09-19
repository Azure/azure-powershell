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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class AccountCreateParameters
    {
        public AccountCreateParameters(string resourceGroup, string batchAccount, string location)
        {
            if (string.IsNullOrWhiteSpace(resourceGroup))
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (string.IsNullOrWhiteSpace(batchAccount))
            {
                throw new ArgumentNullException(nameof(batchAccount));
            }
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.ResourceGroup = resourceGroup;
            this.BatchAccount = batchAccount;
            this.Location = location;
        }

        /// <summary>
        /// The resource group in which to create the Batch account.
        /// </summary>
        public string ResourceGroup { get; private set; }

        /// <summary>
        /// The name of the Batch account to create.
        /// </summary>
        public string BatchAccount { get; private set; }

        /// <summary>
        /// The region in which to create the account.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// The resource ID of the Storage account to be used for auto storage.
        /// </summary>
        public string AutoStorageAccountId { get; set; }

        /// <summary>
        /// The allocation mode to use for creating pools in the Batch account.
        /// </summary>
        public PoolAllocationMode? PoolAllocationMode { get; set; }

        /// <summary>
        /// The resource ID of the Azure key vault associated with the Batch account.
        /// </summary>
        public string KeyVaultId { get; set; }

        /// <summary>
        /// The URL of the Azure key vault associated with the Batch account.
        /// </summary>
        public string KeyVaultUrl { get; set; }

        /// <summary>
        /// The user specified tags associated with the account.
        /// </summary>
        public Hashtable Tags { get; set; }
    }
}
