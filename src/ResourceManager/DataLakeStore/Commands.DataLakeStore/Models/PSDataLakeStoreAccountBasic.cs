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

using Microsoft.Azure.Management.DataLake.Store.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class PSDataLakeStoreAccountBasic : DataLakeStoreAccountBasic
    {
        /// <summary>
        /// Gets or sets the Key Vault encryption identity, if any.
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public EncryptionIdentity Identity { get; private set; }

        /// <summary>
        /// Gets or sets the current state of encryption for this Data Lake
        /// store account. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public EncryptionState? EncryptionState { get; private set; }

        /// <summary>
        /// Gets the current state of encryption provisioning for this Data
        /// Lake store account. Possible values include: 'Creating',
        /// 'Succeeded'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public EncryptionProvisioningState? EncryptionProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets the Key Vault encryption configuration.
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public EncryptionConfig EncryptionConfig { get; private set; }

        /// <summary>
        /// Gets or sets the current state of the IP address firewall for this
        /// Data Lake store account. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public FirewallState? FirewallState { get; private set; }

        /// <summary>
        /// Gets or sets the list of firewall rules associated with this Data
        /// Lake store account.
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<FirewallRule> FirewallRules { get; private set; }

        /// <summary>
        /// Gets or sets the current state of the trusted identity provider
        /// feature for this Data Lake store account. Possible values include:
        /// 'Enabled', 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public TrustedIdProviderState? TrustedIdProviderState { get; private set; }

        /// <summary>
        /// Gets or sets the list of trusted identity providers associated with
        /// this Data Lake store account.
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<TrustedIdProvider> TrustedIdProviders { get; private set; }

        /// <summary>
        /// Gets or sets the default owner group for all new folders and files
        /// created in the Data Lake Store account.
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public string DefaultGroup { get; private set; }

        /// <summary>
        /// Gets or sets the commitment tier to use for next month. Possible
        /// values include: 'Consumption', 'Commitment_1TB', 'Commitment_10TB',
        /// 'Commitment_100TB', 'Commitment_500TB', 'Commitment_1PB',
        /// 'Commitment_5PB'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public TierType? NewTier { get; private set; }

        /// <summary>
        /// Gets the commitment tier in use for the current month. Possible
        /// values include: 'Consumption', 'Commitment_1TB', 'Commitment_10TB',
        /// 'Commitment_100TB', 'Commitment_500TB', 'Commitment_1PB',
        /// 'Commitment_5PB'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public TierType? CurrentTier { get; private set; }

        /// <summary>
        /// Gets or sets the current state of allowing or disallowing IPs
        /// originating within Azure through the firewall. If the firewall is
        /// disabled, this is not enforced. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeStoreAccount but removed in DataLakeStoreAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public FirewallAllowAzureIpsState? FirewallAllowAzureIps { get; private set; }

        public PSDataLakeStoreAccountBasic (DataLakeStoreAccountBasic baseAccount) :
            base(
                baseAccount.Location,
                baseAccount.Id,
                baseAccount.Name,
                baseAccount.Type,
                baseAccount.Tags,
                baseAccount.ProvisioningState,
                baseAccount.State,
                baseAccount.CreationTime,
                baseAccount.LastModifiedTime,
                baseAccount.Endpoint,
                baseAccount.AccountId)
        {
            this.Identity = null;
            this.EncryptionState = null;
            this.EncryptionProvisioningState = null;
            this.EncryptionConfig = null;
            this.FirewallState = null;
            this.FirewallRules = null;
            this.TrustedIdProviderState = null;
            this.TrustedIdProviders = null;
            this.DefaultGroup = null;
            this.NewTier = null;
            this.CurrentTier = null;
            this.FirewallAllowAzureIps = null;
        }
    }
}
